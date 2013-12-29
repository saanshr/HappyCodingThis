<%@ Control Language="C#" %>

<div>
    <asp:Label runat="server" AssociatedControlID="FirstName">First Name:</asp:Label>
    <asp:TextBox runat="server" ID="FirstName" />
    <asp:RequiredFieldValidator runat="server" ID="FirstNameRequiredValidator" ControlToValidate="FirstName" ErrorMessage="This field is required" CssClass="error" SetFocusOnError="true" />
</div>
<div>
    <asp:Label runat="server" AssociatedControlID="LastName">Last Name:</asp:Label>
    <asp:TextBox runat="server" ID="LastName" />
    <asp:RequiredFieldValidator runat="server" ID="LastNameRequiredValidator" ControlToValidate="LastName" ErrorMessage="This field is required" CssClass="error" SetFocusOnError="true" />
</div>
<div>
    <asp:Label runat="server" AssociatedControlID="Email">Email:</asp:Label>
    <asp:TextBox runat="server" ID="Email" TextMode="Email" />
    <asp:RequiredFieldValidator runat="server" ID="EmailRequiredValidator" ControlToValidate="Email" ErrorMessage="This field is required" CssClass="error" SetFocusOnError="true" />
    <asp:RegularExpressionValidator runat="server" ID="EmailRegExValidator" ControlToValidate="Email" ErrorMessage="Improper email format" CssClass="error" SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
</div>
<div>
    <asp:TextBox runat="server" ID="Company" />
</div>
<div>
    <asp:TextBox runat="server" ID="Question" TextMode="MultiLine" />
</div>
<asp:Button runat="server" ID="Submit" Text="Submit" />