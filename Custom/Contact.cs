using System;
using System.Linq;
using System.Web.UI.WebControls;
using Telerik.Sitefinity.Web.UI;
using Telerik.Sitefinity.Services;
using Telerik.Sitefinity.Configuration;
using System.Net.Mail;
using Telerik.Microsoft.Practices.EnterpriseLibrary.Logging;
using System.Net;
using System.Text;

namespace HappyCodingThis.SitefinityWebApp.Custom
{
    /// <summary>
    /// Class used to create custom page widget
    /// </summary>
    /// <remarks>
    /// If this widget is a part of a Sitefinity module,
    /// you can register it in the site's toolbox by adding this to the module's Install/Upgrade method(s):
    /// initializer.Installer
    ///     .Toolbox(CommonToolbox.PageWidgets)
    ///         .LoadOrAddSection(SectionName)
    ///             .SetTitle(SectionTitle) // When creating a new section
    ///             .SetDescription(SectionDescription) // When creating a new section
    ///             .LoadOrAddWidget<Contact>("Contact")
    ///                 .SetTitle("Contact")
    ///                 .SetDescription("Contact")
    ///                 .LocalizeUsing<ModuleResourceClass>() //Optional
    ///                 .SetCssClass(WidgetCssClass) // You can use a css class to add an icon (Optional)
    ///             .Done()
    ///         .Done()
    ///     .Done();
    /// </remarks>
    /// <see cref="http://www.sitefinity.com/documentation/documentationarticles/user-guide/widgets"/>
    public class Contact : SimpleView
    {
	   #region Properties
	   
	   /// <summary>
	   /// Obsolete. Use LayoutTemplatePath instead.
	   /// </summary>
	   protected override string LayoutTemplateName
	   {
		  get
		  {
			 return string.Empty;
		  }
	   }
	   
	   /// <summary>
	   /// Gets the layout template's relative or virtual path.
	   /// </summary>
	   public override string LayoutTemplatePath
	   {
		  get
		  {
			 if (string.IsNullOrEmpty(base.LayoutTemplatePath))
				return Contact.layoutTemplatePath;
			 return base.LayoutTemplatePath;
		  }
		  set
		  {
			 base.LayoutTemplatePath = value;
		  }
	   }
	   
	   #endregion
	   
	   #region Control References
	   
	   protected virtual TextBox FirstName
	   {
		  get
		  {
			 return this.Container.GetControl<TextBox>("FirstName", true);
		  }
	   }
	   
	   protected virtual TextBox LastName
	   {
		  get
		  {
			 return this.Container.GetControl<TextBox>("LastName", true);
		  }
	   }
	   
	   protected virtual TextBox Email
	   {
		  get
		  {
			 return this.Container.GetControl<TextBox>("Email", true);
		  }
	   }
	   
	   protected virtual TextBox Company
	   {
		  get
		  {
			 return this.Container.GetControl<TextBox>("Company", true);
		  }
	   }
	   
	   protected virtual TextBox Question
	   {
		  get
		  {
			 return this.Container.GetControl<TextBox>("Question", true);
		  }
	   }
	   
	   protected virtual Button Sumbit
	   {
		  get
		  {
			 return this.Container.GetControl<Button>("Submit", true);
		  }
	   }

	   protected virtual Literal Message
	   {
		  get
		  {
			 return this.Container.GetControl<Literal>("Message", true);
		  }
	   }

	   protected virtual Panel ContactFormPanel
	   {
		  get
		  {
			 return this.Container.GetControl<Panel>("ContactFormPanel", true);
		  }
	   }
	   
	   #endregion
	   
	   #region Methods
	   
	   /// <summary>
	   /// Initializes the controls.
	   /// </summary>
	   /// <param name="container"></param>
	   /// <remarks>
	   /// Initialize your controls in this method. Do not override CreateChildControls method.
	   /// </remarks>
	   protected override void InitializeControls(GenericContainer container)
	   {

			 Sumbit.Click += Submit_Click;

	   }
	   
	   protected void Submit_Click(object sender, EventArgs e)
	   {
		  if (this.Page.IsPostBack && this.Page.IsValid)
		  {
			 string host = Config.Get<SystemConfig>().SmtpSettings.Host;
			 int port = Config.Get<SystemConfig>().SmtpSettings.Port;
			 string address = Config.Get<SystemConfig>().SmtpSettings.DefaultSenderEmailAddress;
			 string username = Config.Get<SystemConfig>().SmtpSettings.UserName;
			 string psw = Config.Get<SystemConfig>().SmtpSettings.Password;
			 bool enableSSL = Config.Get<SystemConfig>().SmtpSettings.EnableSSL;
			 
			 ContactForm contactForm = new ContactForm();
			 contactForm.ID = Guid.NewGuid();
			 contactForm.FirstName = this.FirstName.Text;
			 contactForm.LastName = this.LastName.Text;
			 contactForm.Email = this.Email.Text;
			 contactForm.Company = this.Company.Text;
			 contactForm.Questions = this.Question.Text;

			 StringBuilder body = new StringBuilder();
			 body.Append("<h1>New Contact Form</h1>");
			 body.AppendFormat("{0}<br />", DateTime.Now);
			 body.AppendFormat("<b>Name: </b> {0} {1}<br />", contactForm.FirstName, contactForm.LastName);
			 body.AppendFormat("<b>Email: </b> {0}<br />", contactForm.Email);
			 body.AppendFormat("<b>Company: </b> {0} <br />", contactForm.Company);
			 body.AppendFormat("<b>Questions/Comments</b><br />{0}", contactForm.Questions);

			 using (happyCodingThisEntities context = new happyCodingThisEntities())
			 {
				context.ContactForms.Add(contactForm);
				context.SaveChanges();
			 }
			 
			 try
			 {
				SmtpClient smtp = new SmtpClient(host,port);
				smtp.Credentials = new System.Net.NetworkCredential(username,psw);
				smtp.EnableSsl = enableSSL;
				var message = new MailMessage(address, address)
				{
				    Subject = "New Contact Form",
				    Body = body.ToString(),
				    IsBodyHtml = true
				};
				smtp.Send(message);
				ContactFormPanel.Visible = false;
				this.Message.Text = string.Format("<div class='message'>Thanks {0} for contacting <span>Happy Coding this</span>.  We will respond to your request as soon as possible.</div>", contactForm.FirstName);
			 }
			 catch (Exception ex)
			 {
				Logger.Write(ex.Message);
				this.Message.Text = "There was an error. Please contact <a href='mailto:admin@happycodingthis.com'>admin@happycodingthis.com</a>";
			 }
		  }
	   }
	   
	   #endregion
	   
	   #region Private members & constants
	   
	   public static readonly string layoutTemplatePath = "~/Custom/Contact.ascx";
    
	   #endregion
    }
}
