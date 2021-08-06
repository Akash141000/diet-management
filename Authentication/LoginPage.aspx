<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" MasterPageFile="~/Navigation/Navigation.master" Inherits="DietManagement.LoginPage" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
     <title>Login</title>
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
</asp:Content>

<asp:Content ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <script type="text/javascript">
        function preventBack() { window.history.forward(); }
        setTimeout("preventBack()", 0);
        window.onunload = function () { null };
    </script>

    <script type="text/javascript">
        $(document).ready(function () {
            $('[data-toggle="tooltip"]').tooltip();
        });
    </script>

     <div  class="container-fluid img-fluid min-vh-100" style="background-image: url('../Images/r3.jpg'); background-repeat: no-repeat; background-attachment: fixed; background-position: 100% 100%">
        <div class="row cust justify-content-around text-light">
            <div class="col-lg-4 col-sm-12 pad">
                <div class="card-transparent">
                    <div class="card-header">
                        <h2>Login</h2>
                    </div>
                    <form runat="server" class="card-body">
                        <div class="form-group row ">
                            <asp:Label ID="usernameLabel" runat="server" Text="Username" class="control-label col-lg-4" ForeColor="White"></asp:Label>
                            <div class="col-lg-8">
                                <asp:TextBox ID="usernameInput" data-placement="right" title="Enter Username" data-toggle="tooltip" runat="server" class="form-control"></asp:TextBox>

                                <span class="help-block">
                                    <asp:RequiredFieldValidator ID="R1" runat="server" ControlToValidate="usernameInput"
                                        ErrorMessage="Required!" Display="Dynamic" ForeColor="White">
                                    </asp:RequiredFieldValidator>

                                    <asp:RegularExpressionValidator ID="usernameInputRegex" runat="server"
                                        ControlToValidate="usernameInput"
                                        ErrorMessage="Enter valid Username"
                                        ValidationExpression="[0-9a-zA-Z]{6,}" Display="Dynamic" ForeColor="White">
                                    </asp:RegularExpressionValidator>

                                </span>
                            </div>
                        </div>

                        <div class="form-group row ">
                            <asp:Label ID="passwordLabel" runat="server" Text="Password" class="control-label  col-lg-4" ForeColor="White"></asp:Label>
                            <div class="col-lg-8">
                                <asp:TextBox ID="passwordInput" runat="server" data-placement="right" title="Enter password" data-toggle="tooltip" class="form-control" TextMode="Password"></asp:TextBox>
                                <span class="help-block">
                                    <asp:RequiredFieldValidator ID="R2" runat="server" ControlToValidate="passwordInput"
                                        ErrorMessage="Required!" Display="Dynamic" ForeColor="White">
                                    </asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="passwordInputRegex" runat="server" ControlToValidate="passwordInput"
                                        ErrorMessage="Enter valid password"
                                        ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!/\\#^%*?&])[A-Za-z\d@$!#/\\%*?&]{8,}$"
                                        Display="Dynamic" ForeColor="White">
                                    </asp:RegularExpressionValidator>

                                </span>
                            </div>

                        </div>
                        <div class="form-group row">
                            <div class="col-lg-6 ">
                                <asp:Button ID="loginSubmit" runat="server" Text="Login" OnClick="loginSubmit_Click" class="btn-outline-dark form-control" />
                            </div>
                            <div class="col-lg-6">
                                <asp:Button ID="changePassword" runat="server" Text="Change Password"
                                    OnClick="changePassword_Click" Style="margin-top: 2px" class="btn-outline-dark form-control" />

                            </div>
                        </div>
                        <div class="form-group row ">
                            <div class="col-lg-6 offset-lg-4">
                                <asp:Label ID="loginResult" runat="server" ForeColor="White"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group row">
                            <div class="col-lg-4 offset-lg-4">  
                                <asp:Button runat="server"  Text="ForgotPassword?" ForeColor="White" class="btn btn-link" Font-Size="Small"
                                  OnClientClick="window.open('/Authentication/ForgotPassword.aspx','FP','width=800,height=280,top=300,left=500,fullscreen=no,resizable=0');"/>
                            </div>
                        </div>

                    </form>
                </div>
            </div>
        </div>
    </div>



</asp:Content>
