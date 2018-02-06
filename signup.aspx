<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/beforeLogin.Master" CodeBehind="signup.aspx.vb" Inherits="FastBid.signup" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div class="container">
        <asp:Label ID="debug_label" runat="server" Text=""></asp:Label>
        <div class="row">
            <div class="col s12 m12">
                <div class="card center-card">
                    <h5 class="center-align">Sign Up</h5>
                    <div class="input-field col s12">
                        <asp:TextBox ID="first_name" CssClass="validate" runat="server"></asp:TextBox>
                        <label for="first_name">First Name</label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator0" runat="server" ErrorMessage="Required" ControlToValidate="first_name" CssClass="red-text" Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>
                    <div class="input-field col s12">
                        <asp:TextBox ID="last_name" CssClass="validate" runat="server"></asp:TextBox>
                        <label for="last_name">Last Name</label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Required" ControlToValidate="last_name" CssClass="red-text" Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>
                    <div class="input-field col s12">
                        <asp:TextBox ID="u_email" CssClass="validate" runat="server"></asp:TextBox>
                        <label for="u_email">Email</label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Required" ControlToValidate="u_email" CssClass="red-text" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Enter a valid email" ControlToValidate="u_email" CssClass="red-text" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>

                    </div>
                    <div class="input-field col s12">
                        <asp:TextBox ID="u_password" TextMode="Password" CssClass="validate" runat="server"></asp:TextBox>
                        <label for="u_password">Password</label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Required" ControlToValidate="u_password" CssClass="red-text" Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>
                    <div class="center-align">
                        <asp:Label ID="error_msg" CssClass="red-text" runat="server" Text=""></asp:Label><br />
                        <asp:Button ID="signup" CssClass="waves-effect waves-light purple darken-3s btn" runat="server" Text="Sign Up" />
                    </div>
                    
                </div>
            </div>
        </div>
    </div>

    <script>
        $('#signup_nav').addClass("active");
    </script>
</asp:Content>




