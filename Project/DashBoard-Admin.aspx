<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="DashBoard-Admin.aspx.cs" Inherits="LeaveMangaement.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid row"  >
        
              <div class="card text-white bg-dark  col-3" style="margin:25px;max-height:15rem">
              <div class="card-header">Total Employee</div>
              <div class="card-body">
                <h4 class="card-title" ID="totalEmployees" runat="server"></h4>
                <p class="card-text">
                     <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="all-employee-list-admin.aspx">see all employees</asp:HyperLink>
                </p>
              </div>
            </div>
        
            <div class="card text-dark bg-light  col-3" style="margin:25px ;max-height:15rem" >
              <div class="card-header">Pending for approval/denial</div>
              <div class="card-body">
                <h4 class="card-title" ID="totalPendings" runat="server"></h4>
                <p class="card-text" >
                  <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/leaves-list-admin.aspx">Manage Pending Leaves</asp:HyperLink>
                    </p>
              </div>
            </div>
        
            <div class="card text-white bg-dark  col-3" style="margin:12px 25px;max-height:15rem">
              <div class="card-header">delete Employee</div>
              <div class="card-body">
                <h5 class="card-title">delete button</h5>
                <p class="card-text">backend code for deletion</p>
              </div>
            </div>
        </div>

</asp:Content>

