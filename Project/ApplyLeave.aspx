<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaster.Master" AutoEventWireup="true" CodeBehind="ApplyLeave.aspx.cs" Inherits="LeaveMangaement.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="form-floating  container text-center mt-5" style="background-color:whitesmoke">
      
       <asp:Label ID="Label1" runat="server" Text="Select leave type:" AssociatedControlID="DropDownList1" Font-size="XX-Large" ></asp:Label><br />
       <asp:DropDownList class="form-select col-4 abc text-center" ID="DropDownList1" runat="server" Font-size="Larger" >
        <asp:ListItem  Text="Select your leave type" Value="-1"  ></asp:ListItem>
        <asp:ListItem  Text="Casual Leave" ></asp:ListItem>
        <asp:ListItem  Text="Medical Leave"></asp:ListItem>
        <asp:ListItem Text="Other"></asp:ListItem>
       </asp:DropDownList> <br />
       <asp:RequiredFieldValidator ID="RequiredFieldValidatorLeave" runat="server"
           ErrorMessage="Select leave type" ControlToValidate="DropDownList1" ForeColor="red" InitialValue="-1"></asp:RequiredFieldValidator>
        <br /><br />

        <asp:Label ID="Label2" runat="server" Text="From Date:" AssociatedControlID="From"  Font-size="XX-Large" ></asp:Label><br />
        <asp:TextBox class="text-center abc col-4" ID="From" runat="server" TextMode="Date" Font-size="Larger"></asp:TextBox>  <br />
       <asp:RequiredFieldValidator ID="RequiredFieldValidatorFrom" runat="server"  Display="Dynamic"
           ErrorMessage="Select From Date" ControlToValidate="From" ForeColor="red"></asp:RequiredFieldValidator>
        <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Enter date greater than equal today" ControlToValidate="From"
            Display="Dynamic" ForeColor="Red"  ValueToCompare="" Type="Date"  Operator="GreaterThanEqual"></asp:CompareValidator><br /><br />

      <asp:Label ID="Label3" runat="server" Text="To date:" AssociatedControlID="To" Font-size="XX-Large" ></asp:Label><br />
      <asp:TextBox class="text-center abc col-4" ID="To" runat="server" TextMode="Date" Font-size="Larger"></asp:TextBox><br />
       <asp:RequiredFieldValidator ID="RequiredFieldValidatorTo" runat="server"
           ErrorMessage="Select To Date" ControlToValidate="To" ForeColor="red" class="text-center" Display="Dynamic"></asp:RequiredFieldValidator>
        <asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="Enter date greater than from date" ControlToValidate="To"
            Display="Dynamic" ForeColor="Red"  ControlToCompare="From" Type="Date"  Operator="GreaterThanEqual"></asp:CompareValidator><br /><br />
        <br />

      <asp:Label ID="Label4" runat="server" Text="Description:" AssociatedControlID="desc"  Font-size="XX-Large" ></asp:Label><br />
        <asp:TextBox ID="desc" class="text-center abc col-4" Font-size="Larger"  runat="server" TextMode="MultiLine"></asp:TextBox><br/>
       <asp:RequiredFieldValidator ID="RequiredFieldValidatorDesc" runat="server"
           ErrorMessage="Plz Write a small description" ControlToValidate="desc" ForeColor="red"></asp:RequiredFieldValidator>
        <br /><br />
       <asp:Button ID="Button1" runat="server" class="btn btn-outline-primary btn-lg"  Text="Apply for leave" OnClick="Button1_Click"   />
       <br /> <br />
   </div>
</asp:Content>
