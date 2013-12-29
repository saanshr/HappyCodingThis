using System;
using System.Linq;
using System.Web.UI.WebControls;
using Telerik.Sitefinity.Web.UI;

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
			 return this.Container.GetControl<TextBox>("FirstName", true);
		  }
	   }

	   protected virtual Button Sumbit
	   {
		  get
		  {
			 return this.Container.GetControl<Button>("Submit", true);
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
			 var fn = FirstName.Text;
		  }
	   }
	   
	   #endregion
	   
	   #region Private members & constants

	   public static readonly string layoutTemplatePath = "~/Custom/Contact.ascx";

	   #endregion
    }
}
