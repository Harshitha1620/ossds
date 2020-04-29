<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Error.aspx.cs" Inherits="Error" %>

<%@ Register TagPrefix="footer" TagName="footer" Src="~/Footer.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>OSSDS-Error Page</title>
    <link href="layout/styles/layout.css" rel="stylesheet" type="text/css" media="all" />
    <script src="Scripts/JQuery-min.js" type="text/javascript"></script>
    <style type="text/css">
        .stl
        {
            border-style: double;
            border-color: Black;
            border-width: 1px;
            text-align: center;
            height: 85px;
            background-color: Gray;
            color: White;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="wrapper row1">
        <header id="header">
        <asp:Image ID="Image1" runat="server" ImageUrl="~/images/header.png" />       
        </header>
    </div>
    <div class="wrapper row2">
         <main class="hoc container clear">
        <div id="comments " style="background-color: White">
            <fieldset>
                <h3>
                    Error Possibilities
                </h3>
                <ul>
                    <li>Your net connection may be slow.</li>
                    <li>Your Session might have expired.</li>
                    <li>Entering alaphabets where only digits are allowed.</li>
                </ul>
              
                <div class="one_full center">
                    <h6>
                        Some thing is Wrong, Please login Again <a href="Login.aspx">Here</a>
                    </h6>
                </div>
                <br />
                <br />
                <br />
            </fieldset>
        </div>
        </main>
    </div>
    <div class="clear">
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
