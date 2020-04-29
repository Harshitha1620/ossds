<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChangePWD.aspx.cs" Inherits="ChangePWD" %>

<%@ Register TagPrefix="footer" TagName="footer" Src="~/Footer.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>OSSDS- Change Password</title>
    <link href="layout/styles/layout.css" rel="stylesheet" type="text/css" media="all" />
    <script src="layout/JQuery.min.js" type="text/javascript"></script>
    <script src="layout/scripts/shaa256.js" type="text/javascript"></script>
    <script type="text/javascript">
        history.pushState(null, null, 'ChangePWD.aspx');
        window.addEventListener('popstate', function (event) {
            history.pushState(null, null, 'ChangePWD.aspx');
        });
    </script>
    <style>
        #message
        {
            display: none;
            background: #f1f1f1;
            color: #000;
            position: relative;
            padding: 20px;
        }
        
        #message p
        {
            padding: 2px 20px;
            font-size: 12px;
        }
        
        #check
        {
            display: none;
            background: #f1f1f1;
            color: #000;
            position: relative;
            padding: 20px;
        }
        
        #check p
        {
            padding: 2px 20px;
            font-size: 12px;
        }
        
        /* Add a green text color and a checkmark when the requirements are right */
        .valid
        {
            color: green;
        }
        
        .valid:before
        {
            position: relative;
            left: -35px;
            content: "✔";
        }
        
        /* Add a red text color and an "x" when the requirements are wrong */
        .invalid
        {
            color: red;
        }
        
        .invalid:before
        {
            position: relative;
            left: -35px;
            content: "✖";
        }
    </style>
    <script type="text/javascript">
        function validateReg() {
            var newpwd = document.getElementById('txtNpwd').value;
            var cpwd = document.getElementById('txtCpwd').value;
            if (newpwd == cpwd) {
                if (newpwd != '') {
                    var oldpwd = document.getElementById('txtOpwd').value;
                    document.getElementById('txtOldPwdHash').value = '';
                    document.getElementById('txtNewPwdHash').value = '';
                    var keyGenrate = '<%= ViewState["KeyGenerator"]%>';
                    var myval1 = sha256(oldpwd);
                    var myval = sha256(keyGenrate);
                    var myval2 = sha256(newpwd);
                    document.getElementById('txtOpwd').value = '**********';
                    document.getElementById('txtNpwd').value = '**********';
                    document.getElementById('txtCpwd').value = '**********';
                    document.getElementById('txtOldPwdHash').value = sha256(myval1 + myval);
                    document.getElementById('txtNewPwdHash').value = myval2;
                }
            } else {
                alert("New Password and Confirm Password should be same");
                return;
            }
        }       
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="wrapper row1">
        <header id="header">
            <asp:Image ID="Image1" runat="server" ImageUrl="~/images/header.png" />
        </header>
    </div>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="wrapper row2">
        <main class="hoc container clear">
        <div id="comments">
      
            <br />
            <fieldset>
                <h3>
                    Change Password
                </h3>

                 <div class="one_full center ">
                    <span class="note">Note: Password can be alphanumeric, must contain atleast 8 characters, atleast one uppercase letter, atleast one lowercase letter and one numeric  </span>
                </div>
                <div class="one_third first">
                 <div id="message">                        
                            Password must contain the following:
                        <p id="letter" class="invalid">
                            A <b>lowercase</b> letter</p>
                        <p id="capital" class="invalid">
                            A <b>capital (uppercase)</b> letter</p>
                        <p id="number" class="invalid">
                            A <b>number</b></p>
                        <p id="length" class="invalid">
                            Minimum <b>8 characters</b></p>
                         <p id="spl" class="invalid">
                            A <b>Special character</b></p>
                    </div>

                      <div id="check">  
                        <p id="P1" class="invalid">
                            New Password and Confirm Password Must be <b>Same</b></p>                       
                    </div>

                </div>
                 <div class="one_third ">
                <label for="txtold">
                        Old Password:<span>*</span></label>
                    <asp:TextBox ID="txtOpwd" runat="server" TextMode="Password" required></asp:TextBox>
                    <asp:HiddenField ID="txtOldPwdHash" runat="server" />

                     <label for="txtNew">
                        New Password:<span>*</span></label>
                    <asp:TextBox ID="txtNpwd" runat="server"  TextMode="Password"  required></asp:TextBox>
                    <asp:HiddenField ID="txtNewPwdHash"
                        runat="server" />

                     <label for="txtconfrm">
                        Confirm Password:<span>*</span></label>
                    <asp:TextBox ID="txtCpwd" runat="server"  TextMode="Password" required></asp:TextBox>


                </div>
                 <div class="one_third ">   <br /><br /><br />
                 <label></label>
                        <input type="checkbox" onclick="myFunction()" value="Show New Password">  Show New Password          
                        <input type="checkbox" onclick="myFunction1()">  Show Confirm Password          
                </div>
            <div class="one_third first"></div>
                <div class="one_third center">
                    <asp:Button ID="Button1" runat="server" Text="Change PassWord" OnClientClick="validateReg();" OnClick="Button1_Click" Width="200">
                    </asp:Button>
                </div>
               <div class="one_third ">  </div>
            </fieldset>
        </div>
        </main>
    </div>
    <div class="wrapper row4 bgded overlay">
        <footer:footer ID="footer1" runat="server" />
    </div>
    <script type="text/javascript" src="../layout/scripts/jquery.backtotop.js"></script>
    <script type="text/javascript" src="../layout/scripts/jquery.mobilemenu.js"></script>
    <script type="text/javascript">
        var myInput = document.getElementById("txtNpwd");
        var letter = document.getElementById("letter");
        var capital = document.getElementById("capital");
        var number = document.getElementById("number");
        var length = document.getElementById("length");
        var spl = document.getElementById("spl");

        var cpwd = document.getElementById("txtCpwd");

        cpwd.onfocus = function () {
            document.getElementById("check").style.display = "block";
        }
        cpwd.onblur = function () {
            document.getElementById("check").style.display = "none";
        }
        cpwd.onkeyup = function () {
            if (myInput.value == cpwd.value) {
                P1.classList.remove("invalid");
                P1.classList.add("valid");
            } else {
                P1.classList.remove("valid");
                P1.classList.add("invalid");
            }
        }

        // When the user clicks on the password field, show the message box
        myInput.onfocus = function () {
            document.getElementById("message").style.display = "block";
        }

        // When the user clicks outside of the password field, hide the message box
        myInput.onblur = function () {
            document.getElementById("message").style.display = "none";
        }

        // When the user starts to type something inside the password field
        myInput.onkeyup = function () {
            // Validate lowercase letters
            var lowerCaseLetters = /[a-z]/g;
            if (myInput.value.match(lowerCaseLetters)) {
                letter.classList.remove("invalid");
                letter.classList.add("valid");
            } else {
                letter.classList.remove("valid");
                letter.classList.add("invalid");
            }

            // Validate capital letters
            var upperCaseLetters = /[A-Z]/g;
            if (myInput.value.match(upperCaseLetters)) {
                capital.classList.remove("invalid");
                capital.classList.add("valid");
            } else {
                capital.classList.remove("valid");
                capital.classList.add("invalid");
            }

            // Validate numbers
            var numbers = /[0-9]/g;
            if (myInput.value.match(numbers)) {
                number.classList.remove("invalid");
                number.classList.add("valid");
            } else {
                number.classList.remove("valid");
                number.classList.add("invalid");
            }

            // Validate length
            if (myInput.value.length >= 8) {
                length.classList.remove("invalid");
                length.classList.add("valid");
            } else {
                length.classList.remove("valid");
                length.classList.add("invalid");
            }

            //valid special characters
            var splchars = /[@ # $ % & *]/g;
            if (myInput.value.match(splchars)) {
                spl.classList.remove("invalid");
                spl.classList.add("valid");
            } else {
                spl.classList.remove("valid");
                spl.classList.add("invalid");
            }
        }

        function myFunction() {
            var x = document.getElementById("txtNpwd");
            if (x.type === "password") {
                x.type = "text";
            } else {
                x.type = "password";
            }
        }

        function myFunction1() {
            var x = document.getElementById("txtCpwd");
            if (x.type === "password") {
                x.type = "text";
            } else {
                x.type = "password";
            }
        }

    </script>
    </form>
</body>
</html>
