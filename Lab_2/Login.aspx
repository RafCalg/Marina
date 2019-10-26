<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Lab_2.Login" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="wrapper fadeInDown">
      <div id="formContent">

        <!-- Login Form -->
        <form>
            <br />
            <br />
&nbsp;<asp:TextBox ID="txtUsername" runat="server">Username</asp:TextBox>
&nbsp;<asp:TextBox ID="txtPassword" runat="server">Password</asp:TextBox>
&nbsp;<br />
        </form>

          <asp:Button ID="btnLogin" runat="server" OnClick="btnLogin_Click" Text="Log in" />
          <br />
          <asp:Label ID="loginCheckResult" runat="server" Enabled="False"></asp:Label>
          <br />
          <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUsername" Display="Dynamic" ErrorMessage="Username is required" ForeColor="Red"></asp:RequiredFieldValidator>
          <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword" Display="Dynamic" ErrorMessage="Password is required" ForeColor="Red"></asp:RequiredFieldValidator>

      </div>
    </div>

</asp:Content>
