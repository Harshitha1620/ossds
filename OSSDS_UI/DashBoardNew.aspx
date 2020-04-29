<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DashBoardNew.aspx.cs" Inherits="DashBoard_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register TagPrefix="menu" TagName="menu" Src="~/Menu.ascx" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="startmin.css" rel="stylesheet" type="text/css" />
    <link href="font-awesome.min.css" rel="stylesheet" type="text/css" />
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
        
        <div id="comments " style="padding-bottom: 0; padding-left:10px;padding-right:10px ; background-color: White"><br />
            <h2>
                DASH-BOARD Year:
                <asp:Label ID="lblyear" runat="server"></asp:Label>
                Season
                <asp:Label ID="lblseason" runat="server"></asp:Label>
            </h2>
            <div class="row">
                <div class="col-lg-3 col-md-6">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-12 text-left">
                                   <div class=" col-lg-4"> Day</div>
                                    <div class="bold col-lg-8 text-right" >
                                        <asp:Label ID="lblStockToday" runat="server"></asp:Label></div>
                                </div>
                                <div class="col-xs-12 text-left" >
                                    <div class=" col-lg-4"> Week</div>
                                    <div class="bold col-lg-8 text-right" >
                                        <asp:Label ID="lblStockweek" runat="server"></asp:Label></div>
                                </div>
                                <div class="col-xs-12 text-left" >
                                   <div class=" col-lg-4">  Month</div>
                                    <div class="bold col-lg-8 text-right" >
                                        <asp:Label ID="lblStockmnth" runat="server"></asp:Label></div>
                                </div>
                                <div class="col-xs-12 text-left" >
                                  <div class=" col-lg-4"> Total</div>
                                    <div class="bold col-lg-8 text-right" >
                                        <asp:Label ID="lblstkseson" runat="server"></asp:Label></div>
                                </div>
                            </div>
                        </div>
                        <div class="panel-footer center h4">
                            Stock Received(Qtls)
                        </div>
                    </div>
                </div>
                <div class="col-lg-3 col-md-6">
                    <div class="panel panel-yellow">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-12 text-left">
                                   <div class=" col-lg-4 "> Day</div>
                                    <div class="bold col-lg-8 text-right">
                                        <asp:Label ID="lblPermitToday" runat="server"></asp:Label></div>
                                </div>
                                <div class="col-xs-12 text-left">
                                    <div class=" col-lg-4"> Week</div>
                                    <div class="bold col-lg-8 text-right">
                                        <asp:Label ID="lblPermitWeek" runat="server"></asp:Label></div>
                                </div>
                                <div class="col-xs-12 text-left">
                                   <div class=" col-lg-4">  Month</div>
                                    <div class="bold col-lg-8 text-right">
                                        <asp:Label ID="lblPermitMonth" runat="server"></asp:Label></div>
                                </div>
                                <div class="col-xs-12 text-left">
                                  <div class=" col-lg-4">   Total</div>
                                    <div class="bold col-lg-8 text-right">
                                        <asp:Label ID="lblpermitSesn" runat="server"></asp:Label></div>
                                </div>
                            </div>
                        </div>
                        <div class="panel-footer center h4">
                            Permits Generated(No.)
                        </div>
                    </div>
                </div>
                <div class="col-lg-3 col-md-6">
                    <div class="panel panel-green">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-12 text-left">
                                  <div class=" col-lg-4">  Day</div>
                                    <div class="bold col-lg-8 text-right">
                                        <asp:Label ID="lblSaleToday" runat="server"></asp:Label></div>
                                </div>
                                <div class="col-xs-12 text-left">
                                  <div class=" col-lg-4">   Week</div>
                                    <div class="bold col-lg-8 text-right">
                                        <asp:Label ID="lblSaleWeek" runat="server"></asp:Label></div>
                                </div>
                                <div class="col-xs-12 text-left">
                                 <div class=" col-lg-4">    Month</div>
                                    <div class="bold col-lg-8 text-right">
                                        <asp:Label ID="lblSaleMonth" runat="server"></asp:Label></div>
                                </div>
                                <div class="col-xs-12 text-left">
                                  <div class=" col-lg-4"> Total</div>
                                    <div class="bold col-lg-8 text-right">
                                        <asp:Label ID="lblSaleSesn" runat="server"></asp:Label></div>
                                </div>
                            </div>
                        </div>
                        <div class="panel-footer center h4">
                            Seed Distributed(Qtls)
                        </div>
                    </div>
                </div>
                <div class="col-lg-3 col-md-6">
                    <div class="panel panel-GRAPEFRUIT">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-12 text-left">
                                   <div class=" col-sm-4"> Day</div>
                                    <div class="bold col-sm-8 text-right">
                                        <asp:Label ID="lblSubsidyToday" runat="server"></asp:Label></div>
                                </div>
                                <div class="col-xs-12 text-left">
                                   <div class=" col-sm-4">  Week</div>
                                    <div class="bold col-sm-8 text-right">
                                        <asp:Label ID="lblSubsidyWeek" runat="server"></asp:Label></div>
                                </div>
                                <div class="col-xs-12 text-left">
                                   <div class=" col-sm-4">  Month</div>
                                    <div class="bold col-sm-8 text-right">
                                        <asp:Label ID="lblSubsidyMonth" runat="server"></asp:Label></div>
                                </div>
                                <div class="col-xs-12 text-left">
                                   <div class=" col-sm-4">  Total</div>
                                    <div class="bold col-sm-8 text-right">
                                        <asp:Label ID="lblSubsidySesn" runat="server"></asp:Label></div>
                                </div>
                            </div>
                        </div>
                        <div class="panel-footer center h4">
                            Subsidy Given(Rs.)
                        </div>
                    </div>
                </div>
                <div class="col-lg-3 col-md-6">
                    <div class="panel panel-ECSTASY">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-12 text-left">
                                   <div class=" col-lg-4"> Day</div>
                                    <div class="bold col-lg-8 text-right">
                                        <asp:Label ID="lblFarmersToday" runat="server"></asp:Label></div>
                                </div>
                                <div class="col-xs-12 text-left">
                                   <div class=" col-lg-4">  Week</div>
                                    <div class="bold col-lg-8 text-right">
                                        <asp:Label ID="lblFarmersWeek" runat="server" CssClass="lblsml"></asp:Label></div>
                                </div>
                                <div class="col-xs-12 text-left">
                                  <div class=" col-lg-4">   Month</div>
                                    <div class="bold col-lg-8 text-right">
                                        <asp:Label ID="lblFarmersMonth" runat="server"></asp:Label></div>
                                </div>
                                <div class="col-xs-12 text-left">
                                   <div class=" col-lg-5">  Total</div>
                                    <div class="bold col-lg-7 text-right">
                                        <asp:Label ID="lblFarmersSesn" runat="server"></asp:Label></div>
                                </div>
                            </div>
                        </div>
                        <div class="panel-footer center h4">
                            Farmers Taken Seed(No.)
                        </div>
                    </div>
                </div>
                <div class="col-lg-3 col-md-6">
                    <div class="panel panel-AQUA">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-12 text-left">
                                    <div class=" col-lg-4"> Day</div>
                                    <div class="bold col-lg-8 text-right">
                                        <asp:Label ID="lblscstToday" runat="server"></asp:Label></div>
                                </div>
                                <div class="col-xs-12 text-left">
                                    <div class=" col-lg-4"> Week</div>
                                    <div class="bold col-lg-8 text-right">
                                        <asp:Label ID="lblscstweek" runat="server"></asp:Label></div>
                                </div>
                                <div class="col-xs-12 text-left">
                                   <div class=" col-lg-4">  Month</div>
                                    <div class="bold col-lg-8 text-right">
                                        <asp:Label ID="lblscstmnth" runat="server"></asp:Label></div>
                                </div>
                                <div class="col-xs-12 text-left">
                                  <div class=" col-lg-5"> Total</div>
                                    <div class="bold col-lg-7 text-right">
                                        <asp:Label ID="lblscstSeason" runat="server"></asp:Label></div>
                                </div>
                            </div>
                        </div>
                        <div class="panel-footer center h4">
                            SC/ST Farmers (No.)
                        </div>
                    </div>
                </div>
                <div class="col-lg-3 col-md-6">
                    <div class="panel panel-PINKROSE">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-12 text-left">
                                  <div class=" col-lg-4">  Day</div>
                                    <div class="bold col-lg-8 text-right">
                                        <asp:Label ID="lblGnToday" runat="server"></asp:Label></div>
                                </div>
                                <div class="col-xs-12 text-left">
                                  <div class=" col-lg-4">   Week</div>
                                    <div class="bold col-lg-8 text-right">
                                        <asp:Label ID="lblGnWeek" runat="server" CssClass="te"></asp:Label></div>
                                </div>
                                <div class="col-xs-12 text-left">
                                  <div class=" col-lg-4"> Month</div>
                                    <div class="bold col-lg-8 text-right">
                                        <asp:Label ID="lblGnMnth" runat="server"></asp:Label></div>
                                </div>
                                <div class="col-xs-12 text-left">
                                  <div class=" col-lg-5">  Total</div>
                                    <div class="bold col-lg-7 text-right">
                                        <asp:Label ID="lblGnSeason" runat="server"></asp:Label></div>
                                </div>
                            </div>
                        </div>
                        <div class="panel-footer center h4">
                            General Farmers (No.)
                        </div>
                    </div>
                </div>
                <div class="col-lg-3 col-md-6">
                    <div class="panel panel-PEACH">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-12 text-left">
                                 <div class=" col-lg-5"> GrnMnr:</div>
                                    <div class="bold col-lg-7 text-right">
                                        <asp:Label ID="lblgrnmnr" runat="server"></asp:Label></div>
                                </div>
                                <div class="col-xs-12 text-left">
                                   <div class=" col-lg-5"> Pulses:</div>
                                    <div class="bold col-lg-7 text-right">
                                        <asp:Label ID="lblpulses" runat="server"></asp:Label></div>
                                </div>
                                <div class="col-xs-12 text-left">
                                  <div class=" col-lg-5">  Cereals :</div>
                                    <div class="bold col-lg-7 text-right">
                                        <asp:Label ID="lblcereals" runat="server"></asp:Label></div>
                                </div>
                                <div class="col-xs-12 text-left">
                                  <div class=" col-lg-5">  OilSeed:</div>
                                    <div class="bold col-lg-7 text-right">
                                        <asp:Label ID="lbloil" runat="server"></asp:Label></div>
                                </div>
                            </div>
                        </div>
                        <div class="panel-footer center h5 bold">
                            Category Wise Sales(Qtls)
                        </div>
                    </div>
                </div>
            </div>
            <h2>
                DASH-BOARD Year:
                <asp:Label ID="lblpyear" runat="server"></asp:Label>
                Season
                <asp:Label ID="lblpseason" runat="server"></asp:Label>
            </h2>
            <div class="row">
                <div class="col-lg-2 col-md-6">
                    <div class="panel panel-ECSTASY">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class="fa  fa-cube fa-2x"></i>
                                </div>
                                <div class="col-xs-12 text-left">
                                    <div class="huge ">
                                        <asp:Label ID="lblAllot" runat="server"></asp:Label></div>
                                </div>
                            </div>
                        </div>
                        <a href="#">
                            <div class="panel-footer h5">
                                Allotment(Qtls)
                            </div>
                        </a>
                    </div>
                </div>
                <div class="col-lg-2 col-md-6">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class="fa fa-cubes fa-2x"></i>
                                </div>
                                <div class="col-xs-12 text-left">
                                    <div class="huge ">
                                        <asp:Label ID="lblStockseason" runat="server"></asp:Label></div>
                                </div>
                            </div>
                        </div>
                        <a href="#">
                            <div class="panel-footer h5">
                                Position(Qtls)
                            </div>
                        </a>
                    </div>
                </div>
                <div class="col-lg-2 col-md-6">
                    <div class="panel panel-green">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class="fa fa-tablet fa-2x"></i>
                                </div>
                                <div class="col-xs-12 text-left">
                                    <div class="huge">
                                        <asp:Label ID="lblPermitSeason" runat="server"></asp:Label></div>
                                </div>
                            </div>
                        </div>
                        <a href="#">
                            <div class="panel-footer h5">
                                Permits(No.)
                            </div>
                        </a>
                    </div>
                </div>
                <div class="col-lg-2 col-md-6">
                    <div class="panel panel-yellow">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class="fa  fa-shopping-bag fa-2x"></i>
                                </div>
                                <div class="col-xs-12 text-left">
                                    <div class="huge">
                                        <asp:Label ID="lblSaleSeason" runat="server"></asp:Label></div>
                                </div>
                            </div>
                        </div>
                        <a href="#">
                            <div class="panel-footer h5">
                                Distribution(Qtls)
                            </div>
                        </a>
                    </div>
                </div>
                <div class="col-lg-2 col-md-6">
                    <div class="panel panel-AQUA">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class="fa fa-inr fa-2x"></i>
                                </div>
                                <div class="col-xs-12 text-left">
                                    <div class="bold" >
                                        <asp:Label ID="lblSubsidySeason" runat="server"></asp:Label></div>
                                </div>
                            </div>
                        </div>
                        <a href="#">
                            <div class="panel-footer h5">
                                Subsidy (Rs)
                            </div>
                        </a>
                    </div>
                </div>
                <div class="col-lg-2 col-md-6">
                    <div class="panel panel-Patrinia">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class="fa fa-users fa-2x"></i>
                                </div>
                                <div class="col-xs-12 text-left">
                                    <div class="huge">
                                        <asp:Label ID="lblFarmersSeason" runat="server"></asp:Label></div>
                                </div>
                            </div>
                        </div>
                        <a href="#">
                            <div class="panel-footer h5">
                                Beneficiaries
                            </div>
                        </a>
                    </div>
                </div>
                <div class="col-lg-2 col-md-6">
                    <div class="panel panel-MINT">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class="fa fa-male fa-2x"></i>
                                </div>
                                <div class="col-xs-12 text-left">
                                    <div class="huge">
                                        <asp:Label ID="lblmale" runat="server"></asp:Label></div>
                                </div>
                            </div>
                        </div>
                        <a href="#">
                            <div class="panel-footer h5">
                                Male Farmers
                            </div>
                        </a>
                    </div>
                </div>
                <div class="col-lg-2 col-md-6">
                    <div class="panel panel-PINKROSE">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class="fa fa-female fa-2x"></i>
                                </div>
                                <div class="col-xs-12 text-left">
                                    <div class="huge">
                                        <asp:Label ID="lblfemale" runat="server"></asp:Label></div>
                                </div>
                            </div>
                        </div>
                        <a href="#">
                            <div class="panel-footer h5">
                                Female Farmers
                            </div>
                        </a>
                    </div>
                </div>
                <div class="col-lg-2 col-md-6">
                    <div class="panel panel-PEACH">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class="fa fa-check-square fa-2x"></i>
                                </div>
                                <div class="col-xs-12 text-left">
                                    <div class="huge">
                                        <asp:Label ID="lblsc" runat="server"></asp:Label></div>
                                </div>
                            </div>
                        </div>
                        <a href="#">
                            <div class="panel-footer h5">
                                SC Farmers
                            </div>
                        </a>
                    </div>
                </div>
                <div class="col-lg-2 col-md-6">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class="fa fa-check-square fa-2x"></i>
                                </div>
                                <div class="col-xs-12 text-left">
                                    <div class="huge">
                                        <asp:Label ID="lblst" runat="server"></asp:Label></div>
                                </div>
                            </div>
                        </div>
                        <a href="#">
                            <div class="panel-footer h5">
                                ST Farmers
                            </div>
                        </a>
                    </div>
                </div>
                <div class="col-lg-2 col-md-6">
                    <div class="panel panel-LAVENDER">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class="fa fa-check-square fa-2x"></i>
                                </div>
                                <div class="col-xs-12 text-left">
                                    <div class="huge">
                                        <asp:Label ID="lblgn" runat="server"></asp:Label></div>
                                </div>
                            </div>
                        </div>
                        <a href="#">
                            <div class="panel-footer h5">
                                General Farmers
                            </div>
                        </a>
                    </div>
                </div>
                <%--<div class="col-lg-2 col-md-6">
                    <div class="panel panel-GRAPEFRUIT">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class="fa fa-female fa-2x"></i>
                                </div>
                                <div class="col-xs-12 text-left">
                                    <div class="huge col-lg-8">
                                        <asp:Label ID="Label4" runat="server"></asp:Label></div>
                                </div>
                            </div>
                        </div>
                        <a href="#">
                            <div class="panel-footer h5">
                                Female Farmers
                            </div>
                        </a>
                    </div>
                </div>--%>
            </div>
        </div>
        <div class="wrapper row4 bgded overlay">
            <footer id="footer" class="hoc clear">
  <div class="two_third">
    Content owned, maintained and updated by Department of Agriculture,Telangana
    <br />
    Designed, Developed and Hosted by National Informatics Center(TS),Hyderabad.
</div>
   <div class="one_quarter"><img src="../images/NIC-logo.png" />
    </div>
</footer>
        </div>
    </div>
    </main> <a id="backtotop" href="#top"><i class="fa fa-chevron-up"></i></a> <script
    type="text/javascript" src="../layout/scripts/jquery.min.js"></script> <script type="text/javascript"
    src="../layout/scripts/jquery.backtotop.js"></script> <script type="text/javascript"
    src="../layout/scripts/jquery.mobilemenu.js"></script>
    </form>
</body>
</html>
