
<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="NSDL.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Log In
    </h2>
    <p>
        Please enter your username and password.
    </p>
    <div class="accountInfo">
                <fieldset class="login">
                    <legend>Account Information</legend>
                    <p>
                        <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Username:</asp:Label>
                        <asp:TextBox ID="UserName" runat="server" CssClass="textEntry"></asp:TextBox>
                    </p>
                    <p>
                        <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password:</asp:Label>
                        <asp:TextBox ID="Password" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
                    </p>
                    
                </fieldset>
                <p class="submitButton">
                    <asp:Button ID="LoginButton" runat="server" Text="Log In" OnClick="Login_Click" />
                </p>
            </div>
</asp:Content>
