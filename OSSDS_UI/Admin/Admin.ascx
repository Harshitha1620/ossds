<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Admin.ascx.cs" Inherits="Admin_Admin" %>
<nav id="mainav" class="hoc clear">
<ul id="menu-bar">
    <li><a href="DashBoard.aspx">DashBoard</a></li>
    <li><a href="#">Masters</a>
        <ul>
            <%--  <li><a href="DistMaster.aspx">District </a></li>
            <li><a href="MandalMaster.aspx">Mandal</a></li>--%>
            <li><a href="CompanyMaster.aspx">Company</a></li>
            <li><a href="CropMaster.aspx">Crop</a></li>
            <li><a href="CropVarietyMaster.aspx">Crop Variety</a></li>
            <li><a href="PackSizes.aspx">Pack Sizes</a></li>
            <li><a href="Seedprice.aspx">Seed Price</a></li>
        </ul>
    </li>
    <li><a href="#">Seed Allotment</a>
        <ul>
            <li><a href="SeedAllot.aspx">Add</a></li>
            <li><a href="EditAllotment.aspx">Update/Delete </a></li>
            <li><a href="Freeze.aspx">Freeze </a></li>
            <li><a href="ViewSeedAllotment.aspx">View Seed Allotment </a></li>
        </ul>
    </li>
    <li><a href="AllotmentTransfer.aspx">Allottment Transfer</a></li>
    <li><a href="#">Reports</a>
        <ul>
            <li><a href="ViewSalePoints.aspx">View Sale Points</a></li>
            <li><a href="ViewDistribution.aspx">View Seed Distrbution</a></li>
            <li><a href="DailyReport.aspx">Daily Report</a></li>
            <li><a href="CropWiseAbstract.aspx">Crop Wise Abstract</a></li>
            <li><a href="BenAbstract.aspx">Beneficiary Abstract</a></li>
            <li><a href="BenListFilterAdm.aspx">Beneficiary List</a></li>
            <li><a href="UC.aspx">Utilization Certificate</a></li>
            <li><a href="FarmerAbstract.aspx">Farmer Abstract</a></li>
        </ul>
    </li>

    <li><a href="#">NFSM Reports</a>
        <ul>       
            <li><a href="Nfsm_DailyReport.aspx">Daily Report</a></li>
            <li><a href="Nfsm_CropWsAbstract.aspx">Crop Wise Abstract</a></li>
            <li><a href="Nfsm_BenAbstract.aspx">Beneficiary Abstract</a></li>
            <li><a href="Nfsm_BenListFilterAdm.aspx">Beneficiary List</a></li>
            
        </ul>
    </li>

    <li><a href="Discussion.aspx">Discussion</a></li>
     <li><a href="StopSale.aspx">Issue Stop Sale</a></li>
    <li><a href="#">Account</a>
        <ul>
            <li><a href="ChangePWD.aspx">Change Password</a></li>
            <li><a href="ResetPWD.aspx">Reset Password</a></li>
            <li><a href="../Logout.aspx">Logout</a></li>
        </ul>
    </li>
</ul>
</nav> 