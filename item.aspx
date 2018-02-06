<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/afterLogin.Master" CodeBehind="item.aspx.vb" Inherits="FastBid.item" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div class="container">
        <div class="row" style="margin: 20px auto">
            <asp:Label ID="debug" runat="server" CssClass="red-text center-align"></asp:Label>
            <div class="col s12 m6 center-align box-m">
                <h5>
                    <asp:Label ID="title" runat="server"></asp:Label>
                </h5>
                <asp:Image ID="Image1" Height="300px" CssClass="responsive-img" runat="server" />
                
                <p class="center-align">
                    <asp:Label ID="desc" runat="server"></asp:Label>
                    <br />
                    <br />
                    <b><asp:Label ID="base_price" runat="server"></asp:Label></b>
                    <br />
                    <br />
                    <asp:Label ID="location" runat="server"></asp:Label>
                </p>
            </div>
            <asp:TextBox Visible="false" runat="server" ID="hidden_max"></asp:TextBox>
            <div class="col s12 m6 box-m center-align">
                <asp:PlaceHolder ID="bidsPlaceholder" runat="server"></asp:PlaceHolder>
                <div id="makebid_div" runat="server">
                    <div class="row">
                        <div>
                            <asp:TextBox ID="bid_price" TextMode="Number" Width="90" CssClass="validate" runat="server"></asp:TextBox>
                            <br />
                            <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Price should be greater than base price" CssClass="red-text" ValidationGroup="g_cmp" ControlToValidate="bid_price" ControlToCompare="hidden_max" Operator="GreaterThan" Display="Dynamic" Type="Integer"></asp:CompareValidator>
                        </div>
                        <asp:Button ID="make_bid"  CssClass="btn purple darken-2" runat="server" Text="Make Bid" ValidationGroup="g_cmp" />
                    </div>
                </div>
                <div id="closedbid_div" class="center-block" runat="server">
                    Bid has been closed
                </div>
            </div>
        </div>
    </div>
</asp:Content>


