<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Dashboard.aspx.cs" Inherits="DAO_Dashboard" %>

<%@ Register TagPrefix="menu" TagName="menu" Src="~/DAO/DAOMenu.ascx" %>
<%@ Register TagPrefix="footer" TagName="footer" Src="~/DAO/Footer.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Online Subsidy Seed Distribution System</title>
    <link href="../layout/styles/layout.css" rel="stylesheet" type="text/css" media="all" />
    <script type="text/javascript">
        history.pushState(null, null, 'DashBoard.aspx');
        window.addEventListener('popstate', function (event) {
            history.pushState(null, null, 'DashBoard.aspx');
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
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
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
            <br />
            <fieldset>
                <h2>
                    DAO DASH-BOARD -&nbsp;&nbsp;&nbsp; Year :
                    <asp:Label ID="lblyear" runat="server"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Season:
                    <asp:Label ID="lblSeason" runat="server"></asp:Label>
                </h2>
                <div class="one_half first">
                    <span class="blinking">
                        <asp:Label ID="lbltitle" Text="Seed Requested" runat="server"></asp:Label>
                    </span>
                    <asp:GridView ID="gvrequest" runat="server" CssClass="grid" AutoGenerateColumns="false">
                        <Columns>
                            <asp:BoundField DataField="MandName" HeaderText="Mandal" />
                            <asp:BoundField DataField="CropName" HeaderText="Crop" />
                            <asp:BoundField DataField="CropVName" HeaderText="Crop Vareity" />
                            <asp:BoundField DataField="requested_qty" HeaderText="Quantity Requested" />
                        </Columns>
                    </asp:GridView>
                </div>
                <div class="one_half first">
                    <h4>
                        Seed Allotted
                    </h4>
                    <asp:GridView ID="gvAllotment" runat="server" CssClass="grid" AutoGenerateColumns="false">
                        <Columns>
                            <asp:BoundField DataField="Scheme_Name" HeaderText="Scheme" />
                            <asp:BoundField DataField="AgencyName" HeaderText="Agency" />
                            <asp:BoundField DataField="crop" HeaderText="Crop" />
                            <asp:BoundField DataField="CropVName" HeaderText="Crop Vareity" />
                            <asp:BoundField DataField="alloted_qty" HeaderText="Allotted Quantity" />
                            <asp:BoundField DataField="qty_left" HeaderText="Quantity Left" />
                        </Columns>
                    </asp:GridView>
                </div>
                <div class="one_half ">
                    <h4>
                        Stock Received</h4>
                    <asp:GridView ID="GvStock" runat="server" CssClass="grid" AutoGenerateColumns="false">
                        <Columns>
                        <asp:BoundField DataField="AgencyName" HeaderText="Agency" />
                            <asp:BoundField DataField="crop" HeaderText="Crop" />
                            <asp:BoundField DataField="packsize" HeaderText="Pack Size(kg)" />
                            <asp:BoundField DataField="stock_rcvd_qtls" HeaderText="Stock Received" />
                            <asp:BoundField DataField="stockleft" HeaderText="Stock Left" />
                        </Columns>
                    </asp:GridView>
                </div>
                <div class="one_half first">
                    <h4>
                        UnFreezed Allotments(By Admin to your District)</h4>
                    <asp:GridView ID="gvUnfrzStk" runat="server" CssClass="grid" AutoGenerateColumns="false">
                        <Columns>
                            <asp:BoundField DataField="CropName" HeaderText="Crop" />
                            <asp:BoundField DataField="alloted_qty" HeaderText="Allotted Quantity" />
                        </Columns>
                    </asp:GridView>
                </div>
                <div class="one_half ">
                    <h4>
                        UnFreezed Allotments(By DAO to Mandals)
                    </h4>
                    <asp:GridView ID="gvUnfrzAllot" runat="server" CssClass="grid" AutoGenerateColumns="false">
                        <Columns>
                            <asp:BoundField DataField="CropName" HeaderText="Crop" />
                            <asp:BoundField DataField="alloted_qty" HeaderText="Allotted Quantity" />
                        </Columns>
                    </asp:GridView>
                </div>
                <%--<div class="one_third first ">
                    <div class="one_half first center bg_color_three">
                        <h4>
                            Permits generated today</h4>
                        <asp:Label ID="lblPermitsToday" runat="server" CssClass="dblabel"></asp:Label>
                    </div>
                    <div class="one_half center bg_color_four">
                        <h4>
                            Seed Distributed today</h4>
                        <asp:Label ID="lbldistbtnToday" runat="server" CssClass="dblabel"></asp:Label>
                    </div>
                </div>
                <div class="one_third ">
                    <div class="one_half first center bg_color_six">
                        <h4>
                            Farmers Seed Distributed today</h4>
                        <asp:Label ID="lblfarmersToday" runat="server" CssClass="dblabel"></asp:Label>
                    </div>
                    <div class="one_half center bg_color_eight">
                        <h4>
                            Permits generated (Total)</h4>
                        <asp:Label ID="lblTotalPermits" runat="server" CssClass="dblabel"></asp:Label>
                    </div>
                </div>
                <div class="one_third ">
                    <div class="one_half first center bg_color_five">
                        <h4>
                            Seed Distributed (Total)</h4>
                        <asp:Label ID="lblTotalSeed" runat="server" CssClass="dblabel"></asp:Label>
                    </div>
                    <div class="one_half center bg_color_two">
                        <h4>
                            Total Farmers Seed Distributed</h4>
                        <asp:Label ID="lblTotalFarmers" runat="server" CssClass="dblabel"></asp:Label>
                    </div>
                </div>--%>
                <div class="clear">
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
