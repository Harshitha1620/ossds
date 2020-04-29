
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register TagPrefix="footer" TagName="footer" Src="~/Footer.ascx" %>
<%@ Register TagPrefix="menu" TagName="menu" Src="~/Menu.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Online Subsidy Seed Distribution System</title>
    <link href="layout/styles/layout.css" rel="stylesheet" type="text/css" media="all" />
    <script src="layout/JQuery.min.js" type="text/javascript"></script>
    <link href="layout/styles/ValidationEngine.css" rel="stylesheet" type="text/css" />
    <script src="layout/scripts/shaa256.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $("#form1").validationEngine('attach', { promptPosition: "topRight" });
        });
        function validateReg() {
            var pwd = document.getElementById('txtPwd').value;

            if (pwd != "") {
                var keyGenrate = '<%=ViewState["KeyGenerator"]%>';
                var myval = sha256(keyGenrate);
                document.getElementById('txtPwdHash').value = '';
                var myval1 = sha256(document.getElementById('txtPwd').value.toString());
                document.getElementById('txtPwd').value = '******';
                document.getElementById('txtPwdHash').value = sha256(myval1 + myval);
            }
        } 
    </script>
    <script type="text/javascript">
        history.pushState(null, null, 'login.aspx');
        window.addEventListener('popstate', function (event) {
            history.pushState(null, null, 'login.aspx');
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="wrapper row1">
        <header id="header">
            <asp:Image ID="Image1" runat="server" ImageUrl="~/images/header.png" />
            <menu:menu ID="menu" runat="server" />
        </header>
    </div>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>
        <div class="wrapper row2">
            <main class="hoc container clear">
            <div id="comments">
             
            <fieldset>
                <div class="one_third">
                </div>
                <div class="one_third ">
                    <br />
                    <h1 style="height:40px;text-align:center;vertical-align:bottom">
                      
                        &nbsp; &nbsp;<U>Login</U> &nbsp;
                       </h1>
                    <fieldset>
                        <legend></legend>
                        <label for="UserName">
                            User Name<span>*</span></label>
                        <asp:TextBox ID="txtUname" class="btmspace-15" runat="server" required  MaxLength="50"></asp:TextBox>
                        <label for="password">
                            Password<span>*</span></label>
                        <asp:TextBox ID="txtPwd" TextMode="Password" runat="server" class="btmspace-15" required ></asp:TextBox>
                        <asp:HiddenField ID="txtPwdHash" runat="server" /> <asp:HiddenField ID="hf" runat="server" />
                        <label for="Image2">
                            <asp:Label ID="lblmsg" runat="server"></asp:Label>
                        </label>
                        
                        <br />
                       <%-- <div class="one_full">
                            <div class="three_quarter first">
                                <asp:Image ID="Image2" runat="server" /></div>
                            <div class="one_quarter">
                                <asp:ImageButton ID="btnImgRefresh" runat="server" ImageUrl="~/images/refresh.png"
                                    BorderStyle="None" Width="70px" Height="50px" ToolTip="Refresh Captcha Text"
                                    OnClick="btnImgRefresh_Click" /></div>
                        </div>
                        <asp:TextBox ID="captch" runat="server" class="btmspace-15" placeholder="Enter Captcha"></asp:TextBox>--%>
                        <div class="one_full center">
                            <asp:Button ID="Button1" runat="server" Text="Login" OnClick="btnLogin_Click" Width="100%"
                                OnClientClick="return validateReg();"></asp:Button></div>
                    </fieldset>
                </div>
                <div class="one_third">
                </div>
                
                <div class="clear">
                </div>
                </fieldset>
            </div>
            </main>
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
