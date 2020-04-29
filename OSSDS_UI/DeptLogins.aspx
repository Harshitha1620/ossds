<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DeptLogins.aspx.cs" Inherits="DeptLogins" %>

<%@ Register TagPrefix="footer" TagName="footer" Src="~/Footer.ascx" %>
<%@ Register TagPrefix="menu" TagName="menu" Src="~/Menu.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Online Subsidy Seed Distribution System-Logins</title>
    <link href="layout/styles/layout.css" rel="stylesheet" type="text/css" media="all" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="wrapper row1">
        <header id="header">
            <asp:Image ID="Image1" runat="server" ImageUrl="~/images/header.png" />
        </header>
        <menu:menu ID="menu" runat="server" />
    </div>
    <div class="wrapper row2">
         <main class="hoc container clear">
        <div id="comments">
            <br />
            <fieldset>

               <div class="one_full center ">
                    <span class="note">Note: Default Password for All Users is 'Sa@12345'.  User need to change their passwords at first login.<br />
                    SalePoint and AEO passwords can be reset at MAO login and MAO logins can be reset at DAO login. After reset password set to default.
                    </span>
                </div>

                <div class="one_third first">
                    <h4>
                        DAOs</h4>
                    <asp:GridView ID="GvDistLogins" runat="server" CssClass="grid" AutoGenerateColumns="false">
                        <Columns>
                            <asp:TemplateField HeaderText="Sno">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="DistName" HeaderText="District" />
                            <asp:BoundField DataField="UserName" HeaderText="UserID" />
                        </Columns>
                    </asp:GridView>
                </div>
                <div class="one_third">
                <div class="one_full ">
                 <h4>
                        DMs</h4>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; All Districts:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;   <span class="bold">  DM_TSSDC</span>
                    <asp:GridView ID="GVDmLogins" runat="server" CssClass="grid" AutoGenerateColumns="false">
                        <Columns>
                            <asp:TemplateField HeaderText="Sno">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="DistName" HeaderText="District" />
                            <asp:BoundField DataField="UserName" HeaderText="UserID" />
                        </Columns>
                    </asp:GridView>
                </div>

                <div class="one_full ">

                    <h4>
                        MAOs</h4>
                    <div class="one_half first">
                        Select District:</div>
                    <div class="one_half ">
                        <asp:DropDownList ID="ddlDist" runat="server" CssClass="fields" AutoPostBack="True"
                            OnSelectedIndexChanged="ddlDist_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                    <asp:GridView ID="GvMandLogins" runat="server" CssClass="grid" AutoGenerateColumns="false">
                        <Columns>
                            <asp:TemplateField HeaderText="Sno">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="MandName" HeaderText="Mandal" />
                            <asp:BoundField DataField="UserName" HeaderText="UserID" />
                        </Columns>
                    </asp:GridView>
                    </div>
                </div>
                <div class="one_third ">
                    <h4>
                        AEOs & Salepoints</h4>
                    <div class="one_half first">
                        Select District:</div>
                    <div class="one_half ">
                        <asp:DropDownList ID="ddldistnm" runat="server" CssClass="fields" AutoPostBack="True"
                            OnSelectedIndexChanged="ddldistnm_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                    <div class="one_half first ">
                        Select Mandal:</div>
                    <div class="one_half ">
                        <asp:DropDownList ID="ddlmand" runat="server" CssClass="fields" AutoPostBack="True"
                            OnSelectedIndexChanged="ddlmand_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                    <asp:GridView ID="GvAeoLogins" runat="server" CssClass="grid" AutoGenerateColumns="false">
                        <Columns>
                            <asp:TemplateField HeaderText="Sno">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="MandName" HeaderText="Mandal" />
                            <asp:BoundField DataField="UserName" HeaderText="AEO UserID" />
                        </Columns>
                    </asp:GridView>
                    <asp:GridView ID="GVSpLogins" runat="server" CssClass="grid" AutoGenerateColumns="false">
                        <Columns>
                            <asp:TemplateField HeaderText="Sno">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="SalePtName" HeaderText="SalePointName" />
                            <asp:BoundField DataField="UserName" HeaderText="SP UserID" />
                            <asp:BoundField DataField="Active" HeaderText="Active" />
                        </Columns>
                    </asp:GridView>
                </div>
            </fieldset>
        </div>
        </main>
    </div>
    <div class="wrapper row4 bgded overlay">
        <footer:footer ID="footer1" runat="server" />
    </div>
    <a id="backtotop" href="#top"><i class="fa fa-chevron-up"></i></a>
    <script type="text/javascript" src="../layout/scripts/jquery.min.js"></script>
    <script type="text/javascript" src="../layout/scripts/jquery.backtotop.js"></script>
    <script type="text/javascript" src="../layout/scripts/jquery.mobilemenu.js"></script>
    </form>
</body>
</html>
