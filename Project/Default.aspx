<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Project.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <div class="container text-center mt-5" style="border: 2px solid whitesmoke; background-color: #c8c8c8">
                <br />
                <br />
                <h2 class="display-4 text-seondary text-center">Login</h2>
                <br />
                <br />
                <asp:Label ID="Label1" runat="server" Text="Email:" AssociatedControlID="Email" Font-Size="XX-Large"></asp:Label>
                <asp:TextBox ID="Email" type="email" class="form-control" runat="server" placeholder="Email address"
                    Font-Size="Larger"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorEmail" runat="server" ForeColor="Red"
                    ErrorMessage="*Email is Required" ControlToValidate="Email" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidatorEmail" runat="server"
                    ForeColor="Red" ErrorMessage="*Please enter valid email" ValidationExpression="^[a-zA-Z0-9+_.-]+@[a-zA-Z0-9.-]+$"
                    ControlToValidate="Email"></asp:RegularExpressionValidator>
                <br />
                <br />

                <asp:Label ID="Label4" runat="server" Text="Password:" AssociatedControlID="Password"
                    Font-Size="XX-Large"></asp:Label>
                <asp:TextBox ID="Password" type="password" class="form-control" runat="server" placeholder="Password"
                    Font-Size="Larger"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorPassword" runat="server" ForeColor="Red"
                    ErrorMessage="*Password is Required" ControlToValidate="Password" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidatorPassword" runat="server"
                    ForeColor="Red" ErrorMessage="Password must contain atleast one uppercase letter,one lower case letter,one number and one special character and length of password must be at least 8 to 10 letters"
                    Display="Dynamic" ControlToValidate="Password" ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$"></asp:RegularExpressionValidator>
                <br />
                <br />


                <asp:Button ID="Login" class=" btn btn-lg btn-outline-primary" runat="server" Text="Login"
                    OnClick="Login_Click" />
                <asp:Button ID="SignUp" class=" btn btn-lg btn-outline-primary" runat="server" Text="SignUp"
                    OnClick="SignUp_Click" CausesValidation="false" />
                <asp:Button ID="Cancel" class="btn btn-lg btn-outline-primary " runat="server" Text="Cancel" />


            </div>



        </div>


    </form>
    <script src="Scripts/jquery-3.0.0.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
</body>
</html>
