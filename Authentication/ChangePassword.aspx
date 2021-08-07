<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" MasterPageFile="~/Navigation/userNavigation.master" ClientIDMode="Static" Inherits="DietManagement.Authentication.ChangePassword" %>




<asp:Content  runat="server" ContentPlaceHolderID="head">
    <title>Change Password</title>
    <meta
        name="viewport"
        content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="MainContentPlaceHolder">
    
    <div class="container-fluid wrapper " style="background-image: url('back/r3.jpg'); background-repeat: no-repeat; background-attachment: fixed; background-position: 100% 100%">
        <div class="row justify-content-around">
            <form runat="server">
            <div class="col-lg-12 cust justify-content-end text-light text-lg-right">
                <span class="fas fa-user">
                    <asp:Label ID="Label4" runat="server"></asp:Label>
                </span>
            </div>

            <div class="col-lg-4 padd">
                <div class="form-group row justify-content-around">
                    <asp:Label ID="Label1" runat="server" class="col-lg-4 text-light" Text="Enter New Password"></asp:Label>
                    <div class="col-lg-8">
                        <asp:TextBox ID="TextBox1" runat="server" class="form-control" data-placement="right" title="Password must contain Minimum 8 characters,at least 1 uppercase,lowercase letter,number and 1 special character" data-toggle="tooltip" TextMode="Password"></asp:TextBox>
                    </div>
                    <span class="help-block">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Required!" ControlToValidate="TextBox1"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="Rx1"
                            runat="server" ControlToValidate="TextBox1" ErrorMessage="Invalid Password!"
                            ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!/\\#^%*?&])[A-Za-z\d@$!#/\\%*?&]{8,}$"></asp:RegularExpressionValidator>
                    </span>

                </div>

                <div class="form-group row justify-content-around">
                    <asp:Label ID="Label2" runat="server" class="col-lg-4 text-light" Text="Confirm New Password"></asp:Label>
                    <div class="col-lg-8">
                        <asp:TextBox ID="TextBox2" data-placement="right" class="form-control" title="Confirm password" data-toggle="tooltip" runat="server" TextMode="Password"></asp:TextBox>
                    </div>
                    <span class="help-block">
                        <asp:CompareValidator ID="CompareValidator1"
                            ControlToValidate="TextBox1"
                            ControlToCompare="TextBox2"
                            Type="String"
                            Operator="Equal"
                            Text="Passwords must match!"
                            runat="Server" />
                    </span>

                </div>

                <div class="form-group row justify-content-around">

                    <asp:Button ID="Button1" runat="server" Text="Save" data-placement="right" title="Click to save new password" data-toggle="tooltip" class="btn-outline-dark form-control" OnClick="Button1_Click" />
                   
                    <span class="help-block">
                        <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
                    </span>

                </div>
            </div>


</form>
        </div>

    </div>




<script type="text/javascript">
    $(document).ready(function () {
        $('[data-toggle="tooltip"]').tooltip();
    });
</script>
</asp:Content>