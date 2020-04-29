<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register TagPrefix="footer" TagName="footer" Src="~/Footer.ascx" %>
<%@ Register TagPrefix="menu" TagName="menu" Src="~/Menu.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Online Subsidy Seed Distribution System</title>
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
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <br />
    <div class="wrapper row2">
        <main class="hoc container clear">
        <div id="comments">
            <br />
            <fieldset>
            <div class="one_full">
                <p class="HomePg">
                    OSSDS is web based Subsidy Seed Distribution System designed and developed for
                    the welfare of Agriculture Farmers in the State of Telangana for issue of Subsidy
                    Seed. Seed is allotted to districts by state seed cell according to requirement.
                    Further seed is allotted to mandals by district agriculture officers. And further
                    allotment to sale points by mandal level authorities.
                </p>
                <p class="HomePg">
                    Stock received at sale points within allotment entered into the system. Farmers
                    need to visit the nearest Sale Point located in their Mandal along with pattadar
                    Passbook and Aadhar Card. By selecting the seed requested by the farmer, the system
                    prompts with seed eligibility, rate and amount to be paid. On confirmation, Permit
                    Slip is generated and SMS will be sent to the Farmer's Mobile Number. Printing of
                    Permit Slip is optional. The Farmer has to show the Permit Slip or SMS sent thru
                    the system at the Sale Point and buy the Seed.</p>
                </div>
                 <div class="one_full center">
                    <p class="quote">
                        <img src="images/left_quote.gif" height="50px" />
                        Let us join hands together and move to Online system to realize the dream of Good
                        Governance.
                        <img src="images/right_quote.gif" height="50px" />
                    </p>
                </div>
               

                <div class="one_full center">
                 <div id="hit" runat="server">
                    </div>
                </div>
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
