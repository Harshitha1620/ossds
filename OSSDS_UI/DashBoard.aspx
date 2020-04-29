<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DashBoard.aspx.cs" Inherits="DashBoard" %>

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
                <h2>
                     Year:
                    <asp:Label ID="lblyear" runat="server"></asp:Label>
                    Season:
                    <asp:Label ID="lblseason" runat="server"></asp:Label>
                </h2>
               <%-- <div class="one_third first bg_color_three">
                    <h4 class="inspace-15">
                        Stock Received(Qtls)</h4>
                    <div class="two_quarter first bold">
                        Today:</div>
                    <div class="two_quarter dblabel">
                        <asp:Label ID="lblStockToday" runat="server"></asp:Label></div>
                    <div class="two_quarter first bold">
                        This Week:</div>
                    <div class="two_quarter dblabel">
                        <asp:Label ID="lblStockweek" runat="server"></asp:Label></div>
                    <div class="two_quarter first bold">
                        This Month:</div>
                    <div class="two_quarter dblabel">
                        <asp:Label ID="lblStockmnth" runat="server"></asp:Label></div>
                    <div class="two_quarter first bold">
                        This Season:</div>
                    <div class="two_quarter dblabel">
                        <asp:Label ID="lblStockseason" runat="server"></asp:Label></div>
                </div>
                <div class="one_third bg_color_four">
                    <h4 class="inspace-15">
                        Permits Availed(No)</h4>
                    <div class="two_quarter first bold">
                        Today:</div>
                    <div class="two_quarter dblabel">
                        <asp:Label ID="lblPermitToday" runat="server"></asp:Label></div>
                    <div class="two_quarter first bold">
                        This Week:</div>
                    <div class="two_quarter dblabel">
                        <asp:Label ID="lblPermitWeek" runat="server"></asp:Label></div>
                    <div class="two_quarter first bold">
                        This Month:</div>
                    <div class="two_quarter dblabel">
                        <asp:Label ID="lblPermitMonth" runat="server"></asp:Label></div>
                    <div class="two_quarter first bold">
                        This Season:</div>
                    <div class="two_quarter dblabel">
                        <asp:Label ID="lblPermitSeason" runat="server"></asp:Label></div>
                </div>
                <div class="one_third bg_color_six">
                    <h4 class="inspace-15">
                        Seed Distributed(Qtls)</h4>
                    <div class="two_quarter first bold">
                        Today:</div>
                    <div class="two_quarter dblabel">
                        <asp:Label ID="lblSaleToday" runat="server"></asp:Label></div>
                    <div class="two_quarter first bold">
                        This Week:</div>
                    <div class="two_quarter dblabel">
                        <asp:Label ID="lblSaleWeek" runat="server"></asp:Label></div>
                    <div class="two_quarter first bold">
                        This Month:</div>
                    <div class="two_quarter dblabel">
                        <asp:Label ID="lblSaleMonth" runat="server"></asp:Label></div>
                    <div class="two_quarter first bold">
                        This Season:</div>
                    <div class="two_quarter dblabel">
                        <asp:Label ID="lblSaleSeason" runat="server"></asp:Label></div>
                </div>
                <div class="one_third first bg_color_five">
                    <h4 class="inspace-15">
                        Subsidy Given(Rs)</h4>
                    <div class="two_quarter first bold">
                        Today</div>
                    <div class="two_quarter dblabel">
                        <asp:Label ID="lblSubsidyToday" runat="server"></asp:Label></div>
                    <div class="two_quarter first bold">
                        This Week:</div>
                    <div class="two_quarter dblabel">
                        <asp:Label ID="lblSubsidyWeek" runat="server"></asp:Label></div>
                    <div class="two_quarter first bold">
                        This Month:</div>
                    <div class="two_quarter dblabel">
                        <asp:Label ID="lblSubsidyMonth" runat="server"></asp:Label></div>
                    <div class="two_quarter first bold">
                        This Season:</div>
                    <div class="two_quarter dblabel">
                        <asp:Label ID="lblSubsidySeason" runat="server"></asp:Label></div>
                </div>
                <div class="one_third bg_color_eight">
                    <h4 class="inspace-15">
                        Farmers Taken Seed(No)</h4>
                    <div class="two_quarter first bold">
                        Today:</div>
                    <div class="two_quarter dblabel">
                        <asp:Label ID="lblFarmersToday" runat="server"></asp:Label></div>
                    <div class="two_quarter first bold">
                        This Week:</div>
                    <div class="two_quarter dblabel">
                        <asp:Label ID="lblFarmersWeek" runat="server"></asp:Label></div>
                    <div class="two_quarter first bold">
                        This Month:</div>
                    <div class="two_quarter dblabel">
                        <asp:Label ID="lblFarmersMonth" runat="server"></asp:Label></div>
                    <div class="two_quarter first bold">
                        This Season:</div>
                    <div class="two_quarter dblabel">
                        <asp:Label ID="lblFarmersSeason" runat="server"></asp:Label></div>
                </div>
                <div class="one_third bg_color_seven">
                    <h4 class="inspace-15">
                        Category Wise Sales(Qtls)</h4>
                    <div class="two_quarter first bold">
                        Green Manure:</div>
                    <div class="two_quarter dblabel">
                        <asp:Label ID="lblgrnmnr" runat="server"></asp:Label></div>
                    <div class="two_quarter first bold">
                        Pulses:</div>
                    <div class="two_quarter dblabel">
                        <asp:Label ID="lblpulses" runat="server"></asp:Label></div>
                    <div class="two_quarter first bold">
                        Cereals:</div>
                    <div class="two_quarter dblabel">
                        <asp:Label ID="lblcereals" runat="server"></asp:Label></div>
                    <div class="two_quarter first bold">
                        OilSeeds:</div>
                    <div class="two_quarter dblabel">
                        <asp:Label ID="lbloil" runat="server"></asp:Label></div>
                </div>--%>
                <div class="clear">
                </div>
                <h4>
                    Crop Wise Allotment- Stock Received-Sales(Qtls)</h4>
                <div class="one_full">
                    <asp:Chart ID="Chart1" runat="server" Height="350px" Width="1220px">
                    </asp:Chart>
                </div>
                <h4>
                    District Wise Allotment- Stock Received-Sales(Qtls)</h4>
                <div class="one_full ">
                    <asp:Chart ID="Chart2" runat="server" Height="350px" Width="1220px">
                    </asp:Chart>
                </div>
                 <div class="one_full ">
                    <asp:Chart ID="Chart3" runat="server" Height="350px" Width="1220px">
                    </asp:Chart>
                </div>

                <h2>
                     Year:
                    <asp:Label ID="lblprevYear" runat="server"></asp:Label>
                    Season:
                    <asp:Label ID="lblprevSeason" runat="server"></asp:Label>
                </h2>
                 <div class="clear">
                </div>
                <h4>
                    Crop Wise Allotment- Stock Received-Sales(Qtls)</h4>
                <div class="one_full">
                    <asp:Chart ID="Chart4" runat="server" Height="350px" Width="1220px">
                    </asp:Chart>
                </div>
                <h4>
                    District Wise Allotment- Stock Received-Sales(Qtls)</h4>
                <div class="one_full ">
                    <asp:Chart ID="Chart5" runat="server" Height="350px" Width="1220px">
                    </asp:Chart>
                </div>
                 <div class="one_full ">
                    <asp:Chart ID="Chart6" runat="server" Height="350px" Width="1220px">
                    </asp:Chart>
                </div>




            </fieldset>
        </div>
        </main>
        <div class="clear">
        </div>
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
