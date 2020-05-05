<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PackSizes.aspx.cs" Inherits="Admin_PackSizes" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register TagPrefix="menu" TagName="menu" Src="~/Admin/Admin.ascx" %>
<%@ Register TagPrefix="footer" TagName="footer" Src="~/Footer.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>OSSDS-Add Seed Allotment</title>
    <link href="../layout/styles/layout.css" rel="stylesheet" type="text/css" media="all" />
    <script src="../Scripts/JQuery-min.js" type="text/javascript"></script>
    <script type="text/javascript">
        history.pushState(null, null, 'PackSizes.aspx');
        window.addEventListener('popstate', function (event) {
            history.pushState(null, null, 'PackSizes.aspx');
        });

        function Confirm(link) {
            if (confirm("Are you sure to delete the record?")) {
                return true;
            }
            else
                return false;
        }    
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
        <div class="loggedUser">
            <img src="../images/14.gif" alt="Log" />
            Logged in As ::&nbsp;
            <asp:Label ID="lblUsrName" runat="server"></asp:Label>
        </div>
        <div class="rightdate">
            <asp:Label ID="lblDate" runat="server"></asp:Label>
            <br />
        </div>
        <div id="comments">
            <fieldset>
                <h3>
                    Enter Pack Sizes
                </h3>
                <div class="one_third first ">
                    <label for="ddlAgency">
                        Scheme:<span>*</span></label>
                    <asp:DropDownList ID="ddlScheme" CssClass="fields" runat="server" OnSelectedIndexChanged="ddlScheme_SelectedIndexChanged"
                        required AutoPostBack="True">
                    </asp:DropDownList>
                </div>
                <div class="one_third ">
                    <label for="ddlAgency">
                        Agency:<span>*</span></label>
                    <asp:DropDownList ID="ddlAgency" CssClass="fields" runat="server" OnSelectedIndexChanged="ddlAgency_SelectedIndexChanged"
                        required AutoPostBack="True">
                    </asp:DropDownList>
                </div>
                <div class="one_third  ">
                    <label for="ddlcropname ">
                        Crop Name:<span>*</span></label>
                    <asp:DropDownList ID="ddlcropname" runat="server" CssClass="fields" required AutoPostBack="True"
                        OnSelectedIndexChanged="ddlcropname_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>
                <div class="one_third first">
                    <label for="seeds">
                        Seed Variety Name:<span>*</span></label>
                    <asp:DropDownList ID="seeds" CssClass="fields" runat="server" required AutoPostBack="True"
                        OnSelectedIndexChanged="seeds_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>
                <div class="one_third">
                    <label for="seeds">
                        Pack Size:<span>*</span></label><asp:TextBox ID="txtpcksz" runat="server" required></asp:TextBox>
                    <ajaxToolkit:FilteredTextBoxExtender ID="txtpcksz_extender" FilterType="Numbers"
                        ValidChars="." runat="server" TargetControlID="txtpcksz">
                    </ajaxToolkit:FilteredTextBoxExtender>
                </div>
                <div class=" two_third right ">
                    <asp:Label ID="lblaid" runat="server" Visible="false"></asp:Label><asp:HiddenField
                        runat="server" ID="hf" />
                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="Save_Click" />
                    <asp:Button ID="btnUpdate" Visible="false" runat="server" Text="Update" OnClick="btnUpdate_Click1" />
                </div>
            </fieldset>
            <fieldset>
                <div class="scrollable">
                    <asp:GridView ID="grdPckSizes" AutoGenerateColumns="false" CssClass="grid" Width="70%"
                        runat="server" OnRowCommand="grdPckSizes_RowCommand">
                        <Columns>
                            <asp:TemplateField HeaderText="SlNo">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Agency">
                                <ItemTemplate>
                                    <asp:Label ID="lblagency" runat="server" Text='<%# Eval("AgencyName")%>'></asp:Label>
                                    <asp:Label ID="lblagencycode" runat="server" Visible="false" Text='<%# Eval("agency")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Crop">
                                <ItemTemplate>
                                    <asp:Label ID="lblcrop" runat="server" Text='<%# Eval("CropName")%>'></asp:Label>
                                    <asp:Label ID="lblcropcode" runat="server" Visible="false" Text='<%# Eval("Crop")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Crop Vareity">
                                <ItemTemplate>
                                    <asp:Label ID="lblcvcode" runat="server" Visible="false" Text='<%# Eval("cropv")%>'></asp:Label>
                                    <asp:Label ID="lblcvnm" runat="server" Text='<%# Eval("CropVName")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Pack Size">
                                <ItemTemplate>
                                    <asp:Label ID="pckid" runat="server" Visible="false" Text='<%# Eval("pckid")%>'></asp:Label>
                                    <asp:Label ID="lblsize" runat="server" Text='<%# Eval("packsize")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Update/Delete" ShowHeader="False">
                                <ItemTemplate>
                                    <div class="one_half first">
                                        <asp:ImageButton ID="btnEdit" runat="server" formnovalidate="formnovalidate" ImageUrl="~/images/edit.png"
                                            Width="30" CommandName="Edt"></asp:ImageButton></div>
                                    <div class="one_half ">
                                        <asp:ImageButton ID="btnDelete" runat="server" ImageUrl="~/images/delete1.png" Width="30"
                                            CommandName="Dlt" OnClientClick="return Confirm(this)"></asp:ImageButton></div>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </fieldset>
        </div>
        </main>
    </div>
    <div class="wrapper row4 bgded overlay">
        <footer:footer ID="footer1" runat="server" />
    </div>
    <script type="text/javascript" src="../layout/scripts/jquery.min.js"></script>
    <script type="text/javascript" src="../layout/scripts/jquery.backtotop.js"></script>
    <script type="text/javascript" src="../layout/scripts/jquery.mobilemenu.js"></script>
    </form>
</body>
</html>
