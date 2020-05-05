<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CropMaster.aspx.cs" Inherits="Admin_CropMaster" %>

<%@ Register TagPrefix="footer" TagName="footer" Src="~/Footer.ascx" %>
<%@ Register TagPrefix="menu" TagName="menu" Src="~/Admin/Admin.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Online Subsidy Seed Distribution System</title>
    <link href="../layout/styles/layout.css" rel="stylesheet" type="text/css" media="all" />
    <script type="text/javascript">
        function Confirm(link) {
            if (confirm("Are you sure to delete the row?")) {
                return true;
            }
            else
                return false;
        }
        history.pushState(null, null, 'CropMaster.aspx');
        window.addEventListener('popstate', function (event) {
            history.pushState(null, null, 'CropMaster.aspx');
        });
        
    </script>
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
                    CROP Master</h2>
                <div class=" one_third first">
                    <label for="ddlscheme">
                        Scheme</label>
                    <asp:DropDownList ID="ddlscheme" CssClass="fields" runat="server"></asp:DropDownList>
                </div>
                <div class=" one_third first">
                    <label for="txtslno">
                        SINo.</label>
                    <asp:TextBox ID="txtslno" MaxLength="3" runat="server"></asp:TextBox>
                </div>
                <div class=" one_third">
                    <label for="txtCropName">
                        Crop Name:<span>*</span></label>
                    <asp:TextBox ID="txtCropName" runat="server" placeholder="Crop Name" MaxLength="50" required></asp:TextBox>
                    <asp:Label ID="lblcpcode" runat="server" Visible="false"></asp:Label>
                </div>
                <div class=" one_third">
                    <label for="txttype">
                        Var/Hybrid:<span>*</span> </label>
                    <asp:TextBox ID="txttype" runat="server" required></asp:TextBox>
                </div>
                
                <div class=" one_third first">
                    <label for="txtArea">
                        Area to be considered (In acres):<span>*</span></label>
                    <asp:TextBox ID="txtArea" runat="server" required></asp:TextBox>
                </div>
               
                <div class=" one_third">
                    <label for="txtqty">
                        Quantity to be issued according to packing:<span>*</span>
                    </label>
                    <asp:TextBox ID="txtqty" runat="server" required></asp:TextBox>Kgs./acre
                </div>
          <br />
           
                <div class=" one_full center">
                    <asp:Button ID="btn_Update" runat="server" Text="Update" OnClick="btn_Update_Click" />
                    <asp:Button ID="btn_Save" runat="server" Text="Save" OnClick="btn_Save_Click" /><asp:HiddenField runat="server" ID="hf" />
                </div>
            </fieldset>
            <div class="scrollable">
                <fieldset>
                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" 
                        DataKeyNames="CropCode" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCancelingEdit="GridView1_RowCancelling"
                        OnRowCommand="GridView1_RowCommand" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" PageSize="10" CssClass="grid">
                        <Columns>
                            <asp:TemplateField HeaderText="Sl.No">
                                <ItemTemplate>
                                    <asp:Label ID="lblslno" runat="server" Text='<%# Bind("Slno") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Crop Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblcropcode" Visible="false" runat="server" Text='<%# Bind("CropCode") %>'></asp:Label>
                                    <asp:Label ID="lblCpnm" runat="server" Text='<%# Bind("CropName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Var/Hybrid">
                                <ItemTemplate>
                                    <asp:Label ID="lbltype" runat="server" Text='<%# Bind("CropType") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>                          
                            <asp:TemplateField HeaderText="Area to be considered (In acres)">
                                <ItemTemplate>
                                    <asp:Label ID="lblarea" runat="server" Text='<%# Bind("No_of_Acres") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Quantity to be issued according to packing Kgs/acre">
                                <ItemTemplate>
                                    <asp:Label ID="lblqty" runat="server" Text='<%# Bind("Quantity_in_Kgs") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>                           
                            <asp:TemplateField HeaderText="Update/Delete" ShowHeader="False">
                                <ItemTemplate>
                                    <div class=" one_half first">
                                        <asp:ImageButton ImageUrl="~/images/edit.png"  formnovalidate="formnovalidate" Width="30"  ID="btnEdit"
                                            runat="server" CommandName="Edit" Text="Edit" OnClick="lnkEdit_Click"></asp:ImageButton></div>
                                    <div class=" one_half">
                                        <asp:ImageButton ImageUrl="~/images/delete1.png" formnovalidate="formnovalidate" Width="30" ID="btnDelete"
                                            runat="server" CommandName="Dlt" OnClientClick="return Confirm(this)" Text="Delete">
                                        </asp:ImageButton>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                         <EmptyDataTemplate>
                        <asp:Label runat="server" ID="lblempty" Text="No Crops Added"></asp:Label>
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
