<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="DietManagement.Authentication.ForgotPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Forgot Password</title>
      <meta
        name="viewport"
        content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <link href="../Bootstrap-5/css/bootstrap.min.css" rel="stylesheet" />
    <script
        async="async"
        defer="defer"
        src="../Bootstrap-5/css/js/bootstrap.bundle.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('[data-toggle="tooltip"]').tooltip();
        });
    </script>
</head>
<body>
     <form id="form1" runat="server">

        <div class="container-fluid wrapper ">
            <div class="row justify-content-around">
                <div class="col-lg-4">

                    <div class="form-group row">
                        <asp:Label ID="Label1" class="col-lg-4" runat="server" Text="Enter Email"></asp:Label>
                        <asp:Label ID="Label3" class="col-lg-4" runat="server" Text="Enter OTP"></asp:Label>
                        <div class="col-lg-8">
                         
                               <asp:TextBox ID="TextBox1" AutoCompleteType="Disabled" data-placement="top" title="Enter Email " data-toggle="tooltip" class="form-control" runat="server"></asp:TextBox>
                               <asp:TextBox ID="TextBox4" AutoCompleteType="Disabled" data-placement="top" title="Enter otp sent on your email" data-toggle="tooltip" class="form-control" runat="server" TextMode="Password"></asp:TextBox>
                         
                            <span class="help-block">
                                <asp:Label ID="Label4" runat="server" Text=""></asp:Label>
                                <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
                                <asp:RegularExpressionValidator ID="Rvx1" runat="server" ControlToValidate="TextBox4" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                    ErrorMessage="Invalid!"></asp:RegularExpressionValidator>
                                <asp:RegularExpressionValidator ID="Rvx2" runat="server" ControlToValidate="TextBox4" ValidationExpression="^([0-9]{6})$"
                                    ErrorMessage="Invalid!"></asp:RegularExpressionValidator>
                            </span>
                        </div>

                    </div>

                    <div class="form-group row">
                        <div class="col-lg-12">
                            <asp:Button ID="Button1" runat="server" Text="Submit" class="btn-outline-dark form-control"
                                OnClick="Button1_Click" />
                            <asp:Button ID="Button2" runat="server" Text="Check" class="btn-outline-dark form-control"
                                OnClick="Button2_Click" />
                            <span class="help-block">
                                 <asp:Label ID="Label5" runat="server" Text=""></asp:Label>
                               
                            </span>

                        </div>

                    </div>
                </div>
        </div>

        </div>
  
   
    </form>
</body>
</html>
