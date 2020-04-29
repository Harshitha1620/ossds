<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HelpDocs.aspx.cs" Inherits="HelpDocs" %>

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

             <div class="one_half center first ">
                    <span style="font-size: medium; font-weight: bold; color: #000000">User Manuals
                    </span>
                    <br />
                    <br />
                    <h4 class="bg_color_six">
                        <a href="HelpDocuments/DAO.docx" target="_blank" style="color: #000000; font-size: large;
                            font-weight: bold;">DAO Manual</a></h4>
                    <h4 class="bg_color_six">
                        <a href="HelpDocuments/MAO.docx" target="_blank" style="color: #000000; font-size: large;
                            font-weight: bold;">MAO Manual</a></h4>
                    <h4 class="bg_color_six">
                        <a href="HelpDocuments/SalePoint.docx" target="_blank" style="color: #000000; font-size: large;
                            font-weight: bold;">Salepoint Manual</a></h4>
                </div>

                <div class="one_half ">
                    <span style="font-size: medium; font-weight: bold; color: #000000">Help Desk </span>
                    (For any information/problems/ queries regarding OSSDS )
                   
                    <div class="one_full bg_color_four">
                        Kv.Surendra ( Programmer , NIC)-- 9494687725
                    </div>
                    <div class="one_full bg_color_four">
                        G.Sampath Kumar ( Programmer , NIC)-- 9492505405
                    </div>
                    <div class="one_full bg_color_four">
                        N Ch R Chakravarthi,(Scientist E / Technical Director, NIC TS) 9441319191
                    </div>
                </div>
               
        </div>
        </fieldset>
    </div>
    </main> </div>
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
