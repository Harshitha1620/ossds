<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CompanyMaster.aspx.cs" Inherits="Admin_CompanyMaster" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register TagPrefix="menu" TagName="menu" Src="~/Admin/Admin.ascx" %>
<%@ Register TagPrefix="footer" TagName="footer" Src="~/Footer.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>OSSDS-Company Master</title>
    <script src="../layout/scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../layout/datapicker/jquery-ui.js" type="text/javascript"></script>
    <link href="../layout/styles/layout.css" rel="stylesheet" type="text/css" media="all" />
    <link href="../layout/datapicker/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function Confirm(link) {
            if (confirm("Are you sure to delete the row?")) {
                return true;
            }
            else
                return false;
        }
    
        $(function () {
            $("#txt_Date").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: 'dd-mm-yy',
                buttonImageOnly: true,
                buttonText: "Select date",
                maxDate: new Date(),
                yearRange: "-10:+0"
            });
        });
   
        history.pushState(null, null, 'CompanyMaster.aspx');
        window.addEventListener('popstate', function (event) {
            history.pushState(null, null, 'CompanyMaster.aspx');
        });
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
                <asp:Label ID="lblUsrName" runat="server"></asp:Label>:: </span><span style="float: right;">
                    Date::<asp:Label ID="lblDate" runat="server"></asp:Label>
                </span>
            <br />
        </div>
        <div id="comments">
            <br />
            <fieldset>
                <h2>
                    Company Master</h2>
                <div class=" one_third first">
                    <label for="txtcmnyName">
                        Company Name:<span>*</span></label>
                    <asp:TextBox ID="txtcmnyName" placeholder=" Company Name" runat="server" required></asp:TextBox>
                    <asp:Label ID="lblcompnycode" runat="server" Visible="false"></asp:Label>
                </div>
                <div class=" one_third">
                    <label for="txt_Date">
                        Effective&nbsp;Date:<span>*</span></label>
                    <asp:TextBox ID="txt_Date" placeholder="Enter date" runat="server" required ></asp:TextBox>
                </div>
                <div class="one_third">
                    <label for="txt_Date">
                        Active:<span>*</span></label>
                    <asp:RadioButtonList ID="rblactive" runat="server" RepeatDirection="Horizontal" CssClass="fieldsrbl"
                        required>
                        <asp:ListItem Value="1">Yes</asp:ListItem>
                        <asp:ListItem Value="0">No</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
            </fieldset>
            <fieldset>
                <div class=" two_third center">
                    <asp:Button ID="btn_Update" runat="server" Height="30px" Text="Update" OnClick="btn_Update_Click" />
                    <asp:Button ID="btn_Save" runat="server" Height="27px" Text="Add" OnClick="btn_Save_Click" />
                    <asp:HiddenField runat="server" ID="hf" />
                </div>
            </fieldset>
            <div class="scrollable">
                <fieldset>
                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                        Width="75%" OnRowCommand="GridView1_RowCommand" OnPageIndexChanging="GridView1_PageIndexChanging"
                        PageSize="20" CellSpacing="2" CssClass="grid">
                        <Columns>
                            <asp:TemplateField HeaderText="SlNo">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Crop Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblcompcode" Visible="false" runat="server" Text='<%# Bind("company_code") %>'></asp:Label>
                                    <asp:Label ID="lblCpnm" runat="server" Text='<%# Bind("company_name") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Active">
                                <ItemTemplate>
                                    <asp:Label ID="lblstatus" runat="server" Text='<%# Bind("active") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Effective Date">
                                <ItemTemplate>
                                    <asp:Label ID="lbleffdate" runat="server" Text='<%# Bind("effective_dt") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Update/Delete" ShowHeader="False">
                                <ItemTemplate>
                                    <div class="one_half first">
                                        <asp:ImageButton  ImageUrl="~/images/edit.png" Width="30" ID="btnEdit"  formnovalidate="formnovalidate"
                                            runat="server" CommandName="Edt" Text="Edit"></asp:ImageButton>
                                    </div>
                                    <div class="one_half">
                                        <asp:ImageButton ImageUrl="~/images/delete1.png" Width="30" ID="btnDelete"
                                            runat="server" OnClientClick="return Confirm(this)" CommandName="Dlt" Text="Delete">
                                        </asp:ImageButton>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                        <asp:Label runat="server" ID="lblempty" Text="No Companies Added"></asp:Label>
                        </EmptyDataTemplate>
                    </asp:GridView>
                </fieldset>
            </div>
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
