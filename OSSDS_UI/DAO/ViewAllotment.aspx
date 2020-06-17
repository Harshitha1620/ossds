<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewAllotment.aspx.cs" Inherits="DAO_ViewAllotment" %>

<%@ Register TagPrefix="menu" TagName="menu" Src="~/DAO/DAOMenu.ascx" %>
<%@ Register TagPrefix="footer" TagName="footer" Src="~/DAO/Footer.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>OSSDS-View Seed Allotted </title>
    <link href="../layout/styles/layout.css" rel="stylesheet" type="text/css" media="all" />
    <script type="text/javascript">
        history.pushState(null, null, 'ViewAllotment.aspx');
        window.addEventListener('popstate', function (event) {
            history.pushState(null, null, 'ViewAllotment.aspx');
        });
        function DisableBackButton() {
            window.history.forward()
        }
        DisableBackButton();
        window.onload = DisableBackButton;
        window.onpageshow = function (evt) { if (evt.persisted) DisableBackButton() }
        window.onunload = function () { void (0) }

        window.history.forward(1);
        function noBack() {
            window.history.forward();
        }     
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="wrapper row1">
        <header id="header">
        <asp:Image ID="Image1" runat="server" ImageUrl="../images/header.png" />
        </header>
        <menu:menu ID="menu" runat="server" />
    </div>
    <div class="wrapper row2">
       <main class="hoc container clear">
        <div class="borderedbox">
            <span style="float: left;">
                <img src="../images/14.gif" alt="Log" />
                Logged in As ::&nbsp;
                <asp:Label ID="lblUsrName" ForeColor="white" Font-Bold="true" runat="server"></asp:Label>&nbsp;
                <asp:Label ID="lblDist" ForeColor="white" Font-Bold="true" runat="server"></asp:Label></span>
            <span style="float: right;">
                <asp:Label ID="lblDate" Font-Bold="true" runat="server"></asp:Label>&nbsp;</span>
            <br />
        </div>
        <div id="comments">
        <fieldset>
            <div class=" one_half first">
                <label for="ddlyear">
                    Year:<span>*</span></label>
                <%--<asp:DropDownList ID="ddlyear" CssClass="fields" runat="server">
                </asp:DropDownList>--%><asp:Label ID="lblyear" runat="server" CssClass="bold" Text="Label"></asp:Label>
            </div>
            <div class="one_half">
                <label for="seasons">
                    Season:<span>*</span></label>
                <%--<asp:DropDownList ID="seasons" runat="server" CssClass="fields">
                    <asp:ListItem Text="Select Season" Value="0"></asp:ListItem>
                   <asp:ListItem Text="VANAKALAM" Value="Kharif"></asp:ListItem>
                    <asp:ListItem Text="YASANGI" Value="Rabi"></asp:ListItem>
                </asp:DropDownList>--%>
                <asp:Label ID="lblseason" runat="server" CssClass="bold" Text="Label"></asp:Label>
            </div>
          <div class=" two_third right ">
                <asp:Button ID="btnView" runat="server" Text="View" OnClick="Button1_Click" /><br />
                <asp:HiddenField runat="server" ID="hf" />
           </div>
           </fieldset>
           <div class="one_full ">
            <div class="scrollable ">
                <fieldset>
                    <h2>
                        Seed Allotted to Your District
                    </h2>
                    <asp:GridView ID="SeedGrid" runat="server" AutoGenerateColumns="false" CssClass="Grid">
                        <Columns>
                            <asp:TemplateField HeaderText="SlNo">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="year" HeaderText="Year" />
                            <asp:BoundField DataField="season" HeaderText="Season" />
                            <asp:BoundField DataField="Scheme_Name" HeaderText="Scheme" />
                            <asp:BoundField DataField="AgencyName" HeaderText="Supplying Agency" />
                            <asp:BoundField DataField="CropName" HeaderText="Crop" />
                            <asp:BoundField DataField="CropVName" HeaderText="CropVariety" />
                            <asp:BoundField DataField="alloted_qty" HeaderText="Alloted Quantity" />
                            <asp:BoundField DataField="qty_left" HeaderText="Qty Left" />
                            <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnAllot" runat="server" Text="Allot Seed" CommandArgument='<%# Eval("year")+ "," +Eval("season")+ "," +Eval("CropName")+ "," +Eval("crop")+ "," 
                                                +Eval("alloted_qty")+ "," +Eval("allot_id")+ "," +Eval("qty_left")+ "," +Eval("agency")+ "," +Eval("scheme")+ "," +Eval("AgencyName")+ "," +Eval("Scheme_Name")
                                                + "," +Eval("cv")+ "," +Eval("CropVName") %>'
                                        OnClick="AllotSeed"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                        <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#A55129" BorderStyle="Solid" Font-Bold="True" Font-Size="Small"
                            ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#FFF1D4" />
                        <SortedAscendingHeaderStyle BackColor="#B95C30" />
                        <SortedDescendingCellStyle BackColor="#F1E5CE" />
                        <SortedDescendingHeaderStyle BackColor="#93451F" />
                    </asp:GridView>
                </fieldset>
            </div>
            </div>
        </div>
        <div class="clear">
        </div>
        </main>
    </div>
    <div class="wrapper row4 bgded overlay">
        <footer:footer ID="footer1" runat="server" />
    </div>
    <script type="text/javascript" src="../layout/scripts/jquery.min.js"></script>
    <script type="text/javascript" src="../layout/scripts/jquery.backtotop.js"></script>
    <script type="text/javascript" src="../layout/scripts/jquery.mobilemenu.js"></script>
    </form>
</body>
</html>
