<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/afterLogin.Master" CodeBehind="home.aspx.vb" Inherits="FastBid.home" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div class="container">
        <h5>Welcome, 
        <asp:Label ID="greeting_name" runat="server" Text=""></asp:Label>
        </h5>
        <p>Here are the latest items on auction!</p>
        <hr />
        <div class="row">
            <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
        </div>
    </div>
</asp:Content>

