<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Reports.aspx.cs" Inherits="DashBoard" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<%@ Register TagPrefix="footer" TagName="footer" Src="~/Footer.ascx" %>
<%@ Register TagPrefix="menu" TagName="menu" Src="~/Menu.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Online Subsidy Seed Distribution System-Dash Board</title>
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
                <div class="one_third first">
                    <h4>
                        Stock Received(Qtls)</h4>
                    <asp:GridView ID="GvdistStock" runat="server" CssClass="grid" ShowFooter="true" AutoGenerateColumns="false"
                        OnRowDataBound="GvdistStock_RowDataBound" FooterStyle-CssClass="gridfooter">
                        <Columns>
                            <asp:BoundField DataField="DistName" HeaderText="District" />
                            <asp:BoundField DataField="stockrcvd" HeaderText="Stock Received" />
                        </Columns>
                    </asp:GridView>
                </div>
                <div class="one_third ">
                    <h4>
                        No.Of Farmers</h4>
                    <asp:GridView ID="GvdistNof" runat="server" CssClass="grid" AutoGenerateColumns="false"
                        ShowFooter="true" FooterStyle-CssClass="gridfooter" OnRowDataBound="GvdistNof_RowDataBound">
                        <Columns>
                            <asp:BoundField DataField="DistName" HeaderText="District" />
                            <asp:BoundField DataField="farmers" HeaderText="Farmers" />
                        </Columns>
                    </asp:GridView>
                </div>
                <div class="one_third ">
                    <h4>
                        Seed Distributed(Qtls)</h4>
                    <asp:GridView ID="GvDistSeed" runat="server" CssClass="grid" AutoGenerateColumns="false"
                        ShowFooter="true" FooterStyle-CssClass="gridfooter" OnRowDataBound="GvDistSeed_RowDataBound">
                        <Columns>
                            <asp:BoundField DataField="DistName" HeaderText="District" />
                            <asp:BoundField DataField="seed" HeaderText="Seed" />
                        </Columns>
                    </asp:GridView>
                </div>
                <div class="one_third first">
                    <asp:GridView ID="GvCropStock" runat="server" CssClass="grid" AutoGenerateColumns="false"
                        ShowFooter="true" FooterStyle-CssClass="gridfooter" OnRowDataBound="GvCropStock_RowDataBound">
                        <Columns>
                            <asp:BoundField DataField="CropName" HeaderText="Crop" />
                            <asp:BoundField DataField="stockrcvd" HeaderText="Stock Received" />
                        </Columns>
                    </asp:GridView>
                </div>
                <div class="one_third ">
                    <asp:GridView ID="GVCropnof" runat="server" CssClass="grid" AutoGenerateColumns="false"
                        ShowFooter="true" FooterStyle-CssClass="gridfooter" OnRowDataBound="GVCropnof_RowDataBound">
                        <Columns>
                            <asp:BoundField DataField="CropName" HeaderText="Crop" />
                            <asp:BoundField DataField="farmers" HeaderText="Farmers" />
                        </Columns>
                    </asp:GridView>
                </div>
                <div class="one_third ">
                    <asp:GridView ID="GVCropSeed" runat="server" CssClass="grid" ShowFooter="true" FooterStyle-CssClass="gridfooter"
                        AutoGenerateColumns="false" OnRowDataBound="GVCropSeed_RowDataBound">
                        <Columns>
                            <asp:BoundField DataField="CropName" HeaderText="Crop" />
                            <asp:BoundField DataField="seed" HeaderText="Seed" />
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
