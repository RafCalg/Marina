<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Lab_2.Register" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="wrapper fadeInDown">
      <div id="formContent">

        <!-- Login Form -->
        <form>
            <br />
            <br />
&nbsp;<asp:TextBox ID="txtFirstName" runat="server" TabIndex="1">First Name</asp:TextBox>
&nbsp;<asp:TextBox ID="txtLastName" runat="server" TabIndex="2">Last Name</asp:TextBox>
&nbsp;<br />
            <asp:TextBox ID="txtPhone" runat="server" TabIndex="3">Phone number</asp:TextBox>
            <br />
            <asp:TextBox ID="txtCity" runat="server" TabIndex="4">City</asp:TextBox>
            <br />
            <asp:TextBox ID="txtUsername" runat="server" TabIndex="5">Username</asp:TextBox>
            <br />
            <asp:TextBox ID="txtPassword" runat="server" TabIndex="6">Password</asp:TextBox>
            <br />
            <asp:TextBox ID="txtRePassword" runat="server" TabIndex="7">Re-enter Passowrd</asp:TextBox>
            <br />
        </form>

          <asp:Button ID="btnRegister" runat="server" OnClick="btnRegister_Click" Text="Register" TabIndex="8" />
          <br />
          <asp:Label ID="registerCheckResult" runat="server" Enabled="False"></asp:Label>
          <br />
          <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtFirstName" Display="Dynamic" ErrorMessage="First Name is required" ForeColor="Red"></asp:RequiredFieldValidator>
          <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtLastName" Display="Dynamic" ErrorMessage="Last Name is required" ForeColor="Red"></asp:RequiredFieldValidator>
          <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtPhone" Display="Dynamic" ErrorMessage="Phone number is required" ForeColor="Red"></asp:RequiredFieldValidator>
          <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtCity" Display="Dynamic" ErrorMessage="City is required" ForeColor="Red"></asp:RequiredFieldValidator>
          <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUsername" Display="Dynamic" ErrorMessage="Username is required" ForeColor="Red"></asp:RequiredFieldValidator>
          <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword" Display="Dynamic" ErrorMessage="Password is required" ForeColor="Red"></asp:RequiredFieldValidator>

          <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtRePassword" Display="Dynamic" ErrorMessage="Password is required" ForeColor="Red"></asp:RequiredFieldValidator>

      </div>
    </div>

</asp:Content>

