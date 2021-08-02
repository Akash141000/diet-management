<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="BmiCalculation.aspx.cs" MasterPageFile="~/Navigation/userNavigation.master" ClientIDMode="Static"
    Inherits="DietManagement.User.BmiCalculation" %>


<asp:Content  runat="server" ContentPlaceHolderID="head">
    <title>BMI</title>
    <meta
        name="viewport"
        content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <link href="../Bootstrap-5/css/bootstrap.min.css" rel="stylesheet" />
    <script
        async="async"
        defer="defer"
        src="../Bootstrap-5/css/js/bootstrap.bundle.min.js"></script>


    

</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="MainContentPlaceHolder">
   



    <div
        class="container-fluid img-fluid min-vh-100"
        style="background-image: url('back/e1.jpg'); background-repeat: no-repeat; background-attachment: fixed; background-position: 100% 100%;">
        <form runat="server" method="post" class="row  justify-content-around">
            <div
                class="col-lg-12  justify-content-end text-light text-lg-right"
                style="font-size: 20px">
                <span class="fas fa-user">
                    <asp:Label ID="loggedUser" runat="server"></asp:Label>
                </span>
            </div>

            <div
                class="row  col-lg-4 col-sm-12 text-light justify-content-around">
                <div class="card-transparent">
                    <div class="card=header">
                        <h2>Body-Mass Index</h2>
                    </div>
                    <div class="card-body">
                        <div class="form-group row">
                            <asp:Label
                                ID="weightLabel"
                                runat="server"
                                Text="Weight"
                                class="col-lg-4"></asp:Label>
                            <div class="col-lg-8">
                                <div class="input-group">
                                    <asp:TextBox
                                        ID="weightInput"
                                        data-placement="right"
                                        title="Enter value between 30 to 250"
                                        data-toggle="tooltip"
                                        runat="server"
                                        class="form-control"></asp:TextBox>
                                    <div class="input-group-btn">
                                        <asp:DropDownList
                                            ID="weightInputTypeSelected"
                                            AutoPostBack="true"
                                            runat="server"
                                            class="text-dark form-control"
                                            OnSelectedIndexChanged="weightInputTypeSelected_SelectedIndexChanged">
                                            <asp:ListItem>Kg</asp:ListItem>
                                            <asp:ListItem>lbs</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <span>
                                    <asp:RequiredFieldValidator
                                        ID="weightInputRequiredValidator"
                                        runat="server"
                                        ControlToValidate="weightInput"
                                        Display="Dynamic"
                                        ErrorMessage="Required!">
                                    </asp:RequiredFieldValidator>

                                    <asp:RangeValidator
                                        ID="weightInputRangeValidator"
                                        runat="server"
                                        ControlToValidate="weightInput"
                                        Display="Dynamic"
                                        MinimumValue="30"
                                        MaximumValue="250"
                                        Type="Integer"
                                        ErrorMessage="Invalid values!">
                                    </asp:RangeValidator>
                                </span>
                            </div>
                        </div>

                        <div class="form-group row">
                            <asp:Label
                                ID="heightLabel"
                                runat="server"
                                Text="Height"
                                class="col-lg-4"></asp:Label>
                            <div class="col-lg-8">
                                <div class="input-group">
                                    <asp:TextBox
                                        ID="heightInput"
                                        data-placement="right"
                                        data-toggle="tooltip"
                                        runat="server"
                                        class="text-dark form-control"></asp:TextBox>
                                    <asp:TextBox
                                        ID="heightInputInInches"
                                        data-placement="right"
                                        title="Enter value between [0-11]"
                                        data-toggle="tooltip"
                                        runat="server"
                                        placeholder="inches"
                                        class="form-control"></asp:TextBox>
                                    <div class="input-group-btn">
                                        <asp:DropDownList
                                            title="heightInputTypeSelected"
                                            ID="heightInputTypeSelected"
                                            runat="server"
                                            AutoPostBack="false"
                                            class="form-control"
                                            
                                            ValidationGroup="v2">
                                            <asp:ListItem>ft</asp:ListItem>
                                            <asp:ListItem>m</asp:ListItem>
                                            <asp:ListItem>cm</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <span class="help-block">
                                    <asp:RequiredFieldValidator
                                        ID="heightInputRequiredValidator"
                                        runat="server"
                                        ControlToValidate="heightInput"
                                        Display="Dynamic"
                                        ErrorMessage="Required!">
                                    </asp:RequiredFieldValidator>

                                    <asp:RegularExpressionValidator
                                        ID="heightInputRegex1"
                                        runat="server"
                                        ControlToValidate="heightInput"
                                        ValidationExpression="^[0-9]*[1-9][0-9]*$"
                                        Display="Dynamic"
                                        ErrorMessage="Invalid Input!"
                                        SetFocusOnError="True">
                                    </asp:RegularExpressionValidator>

                                    <asp:RegularExpressionValidator
                                        ID="heightInputRegex2"
                                        Enabled="false"
                                        runat="server"
                                        ControlToValidate="heightInput"
                                        ValidationExpression="[0-9]([.,][0-9]{1,2})?$"
                                        Display="Dynamic"
                                        ErrorMessage="Invalid Input!">
                                    </asp:RegularExpressionValidator>

                                    <asp:RangeValidator
                                        ID="heightInputRangeValidatorFeetInches"
                                        runat="server"
                                        ControlToValidate="heightInputInInches"
                                        Display="Dynamic"
                                        MinimumValue="0"
                                        MaximumValue="11"
                                        Type="Integer"
                                        ErrorMessage="Invalid Input!">
                                    </asp:RangeValidator>

                                    <asp:RangeValidator
                                        ID="heightInputRangeValidatorFeet"
                                        runat="server"
                                        ControlToValidate="heightInput"
                                        MinimumValue="4"
                                        MaximumValue="6"
                                        Display="Dynamic"
                                        ErrorMessage="Invalid Input!">
                                    </asp:RangeValidator>

                                    <asp:RequiredFieldValidator
                                        ID="heightInputRequiredValidatorInches"
                                        runat="server"
                                        Display="Dynamic"
                                        ControlToValidate="heightInputInInches"
                                        ErrorMessage="Required!">
                                    </asp:RequiredFieldValidator>
                                </span>
                            </div>
                        </div>

                        <div class="form-group row">
                            <asp:Label
                                ID="AgeLabel"
                                runat="server"
                                Text="Age"
                                class="col-lg-4"></asp:Label>
                            <div class="col-lg-8">
                                <asp:TextBox
                                    ID="ageInput"
                                    data-placement="right"
                                    title="Enter age between [15-100]"
                                    data-toggle="tooltip"
                                    runat="server"
                                    class="form-control"
                                    placeholder="age"></asp:TextBox>
                                <span class="help-block">
                                    <asp:RequiredFieldValidator
                                        ID="ageInputRequiredValidator"
                                        runat="server"
                                        ControlToValidate="ageInput"
                                        ErrorMessage="Required!">
                                    </asp:RequiredFieldValidator>

                                    <asp:RangeValidator
                                        ID="ageInputRangeValidator"
                                        runat="server"
                                        ControlToValidate="ageInput"
                                        MinimumValue="15"
                                        MaximumValue="100"
                                        Type="Integer"
                                        ErrorMessage="Invalid Input!">
                                    </asp:RangeValidator>
                                </span>
                            </div>
                        </div>

                        <div class="form-group row">
                            <asp:Label
                                ID="category"
                                runat="server"
                                Text="Catagory"
                                class="col-lg-4"></asp:Label>
                            <div class="col-lg-8">
                                <asp:DropDownList
                                    ID="categoryTypeSelected"
                                    runat="server"
                                    class="form-control">
                                    <asp:ListItem>Maintain Weight</asp:ListItem>
                                    <asp:ListItem>Weight Loss</asp:ListItem>
                                    <asp:ListItem>Weight Gain</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="form-group row">
                            <asp:Label
                                ID="foodCategory"
                                runat="server"
                                Text="Food Catagory"
                                class="col-lg-4"></asp:Label>
                            <div class="col-lg-8">
                                <asp:DropDownList
                                    ID="foodCategorySelected"
                                    runat="server"
                                    class="form-control">
                                    <asp:ListItem>Veg</asp:ListItem>
                                    <asp:ListItem>Non-Veg</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="form-group row">
                            <div class="col-lg-12">
                                <asp:Button
                                    ID="saveBmi"
                                    runat="server"
                                    data-placement="right"
                                    title="Click to Save"
                                    data-toggle="tooltip"
                                    Text="Save"
                                    OnClick="SaveBmi_Click"
                                    class="btn-outline-dark form-control" />
                                <span class="help-block offset-lg-4">
                                    <asp:Label ID="errorSavingBmi" runat="server" Text=""></asp:Label>
                                </span>
                            </div>
                        </div>

                        <div class="form-group row text-dark">
                            <div class="card card-body">
                                <div class="form-group">
                                    <asp:Label
                                        ID="BmiLabel"
                                        runat="server"
                                        Text="BMI"
                                        class="cl-lg-4"></asp:Label>
                                    <asp:Label
                                        ID="bmiOutput"
                                        runat="server"
                                        Text=""
                                        class="cl-lg-4 offset-lg-1"></asp:Label>
                                </div>
                                <div class="form-group">
                                    <asp:Label
                                        ID="bmiCategory"
                                        runat="server"
                                        Text=""
                                        class="col-lg-4"></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </form>
    </div>

     <script async="async" defer="defer" type="text/javascript">
         //$(document).ready(function () {
         //    $('[data-toggle="tooltip"]').tooltip();
         //});
         //validation logic



         const heightInputType = document.getElementById("heightInputTypeSelected");
         const valid = document.getElementById("heightInputRequiredValidator");
         console.dir(heightInputType);
         function dropDownLogic() {
             console.log('val', heightInputType.value);
         };

     </script>
    

</asp:Content>
