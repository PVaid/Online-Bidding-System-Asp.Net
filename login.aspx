<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/beforeLogin.Master" CodeBehind="login.aspx.vb" Inherits="FastBid.login" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div class="container">
        <div class="row">
            <div class="col s12 m12">
                <div class="card center-card">
                    <h5 class="center-align">Log In</h5>
                    <div class="input-field col s12">
                        <asp:TextBox ID="u_email" CssClass="validate" runat="server"></asp:TextBox>
                        <label for="u_email">Email</label>
                    </div>
                     <div class="input-field col s12">
                        <asp:TextBox ID="u_password" TextMode="Password" CssClass="validate" runat="server"></asp:TextBox>
                        <label for="u_password">Password</label>
                    </div>
                    <div class="center-align">
                        <asp:Label ID="error_msg" CssClass="red-text" runat="server" Text=""></asp:Label><br />
                        <asp:Button ID="login" CssClass="waves-effect waves-light purple darken-3s btn btn-center" runat="server" Text="Log In" />
                    </div>
                </div>
            </div>
        </div>
    </div>

    <script>
        $('#login_nav').addClass("active");
    </script>
</asp:Content>



