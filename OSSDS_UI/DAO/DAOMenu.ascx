<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DAOMenu.ascx.cs" Inherits="DAO_DAOMenu" %>
<nav id="mainav" class="hoc clear">
<ul class="clear">
    <li><a href="Dashboard.aspx">DashBoard</a></li>
    <li><a href="#">Subsidy Seed Allotment</a>
        <ul>
            <li><a href="ViewAllotment.aspx">View Alloted</a></li>
            <li><a href="EditAllotment.aspx">Delete/Update </a></li>
            <li><a href="FreezeAllotment.aspx">Freeze Allottment</a></li>
            <li><a href="ViewSeedAllotment.aspx">View Seed Allotment </a></li>
        </ul>
    </li>
     <li><a href="#">Private Seed Allotment</a>
        <ul>            
            <li><a href="PvtSeedAllotment.aspx">Seed Allot</a></li>
            <li><a href="EditPvtSeed.aspx">Delete</a></li>
            <li><a href="FreezePvtSeed.aspx">Freeze</a></li>
             <li><a href="DealerDetails_DAO.aspx">Dealer Details</a></li>
             <li><a href="PvtSalesReport.aspx">View Stock Position</a></li>
             <li><a href="PvtStockPositionRpt.aspx">View Stock Details</a></li>
             <%--<li><a href="ReleaseAllot.aspx">Release Allotment</a></li>--%>
             <li><a href="PvtAllotTransfer.aspx">Allotment Transfer</a></li>
        </ul>
    </li>
   
    <li><a href="#">Reports</a>
        <ul>
        
            <li><a href="ViewSalePoints.aspx">View Sale Points</a></li>
            <li><a href="ViewDistribution.aspx">View Seed Distrbution</a></li>
            <li><a href="AllotmentSales.aspx">View Stock Position</a></li>
            <li><a href="DailyReport.aspx">Daily Report</a></li>
            <li><a href="NFSM_DailyReport.aspx">Daily Report NFSM</a></li>
            <li><a href="CropWiseAbstract.aspx">Crop Wise Abstract</a></li>
            <%--<li><a href="BenAbstract.aspx">Beneficiary Abstract</a></li>--%>
            <li><a href="ViewBeneficiaryList.aspx">Beneficiary List</a></li>
            <li><a href="BenListFilter.aspx">Beneficiary List Filter</a></li>
            <li><a href="UC.aspx">Utilization Certificate</a></li>
            <li><a href="Nfsm_UC.aspx">NFSM-UC</a></li>
           
        </ul>
    </li>
   
    <li><a href="#">Transfers</a>
        <ul>
            <li><a href="AllotmentTransfer.aspx">Allotment Transfer</a></li>
            <li><a href="StockTransfer.aspx">Stock Transfer</a></li>
        </ul>
    </li>
    <li><a href="#">Others</a>
    <ul>
     <li><a href="SalePoint.aspx">Add Sale Point</a></li>
         <li><a href="ViewRequests.aspx">Seed Request</a></li>
         <li><a href="Discussion.aspx">Discussion</a></li>
    </ul>
    </li>
    
    <li><a href="#">Account</a>
        <ul>
            <li><a href="ResetPwd.aspx">Password Reset</a></li>
            <li><a href="ChangePWD.aspx">Change Password</a></li>
            <li><a href="../Logout.aspx">Logout</a></li>
        </ul>
    </li>
</ul>
</nav>
