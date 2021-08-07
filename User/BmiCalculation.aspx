<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="BmiCalculation.aspx.cs" MasterPageFile="~/Navigation/userNavigation.master" ClientIDMode="Static"
    Inherits="DietManagement.User.BmiCalculation" %>


<asp:Content runat="server" ContentPlaceHolderID="head">
    <title>BMI</title>
    <meta
        name="viewport"
        content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    




</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="MainContentPlaceHolder">




    <div
        class="container-fluid img-fluid min-vh-100"
        style="padding:0px;margin:0px;background-image: url('/Images/e1.jpg'); background-repeat: no-repeat; background-attachment: fixed; background-position: 100% 100%;">
        <form runat="server" method="post" class="row  justify-content-around">
            
            
            <div
                class="row  col-lg-4 col-sm-12 mt-5 pt-5 text-dark justify-content-around">
                <div class="card">
                    <div class="card=header text-dark mt-4">
                        <h2>Body-Mass Index</h2>
                    </div>
                    <div class="card-body">
                        <div class="form-group row mb-2">
                            <asp:Label
                                ID="weightLabel"
                                runat="server"
                                Text="Weight"
                                class="col-lg-4"></asp:Label>
                            <div class="col-lg-8">
                                <div class="input-group">
                                    <asp:TextBox
                                        ID="weightInput"
                                        placeholder="kg"
                                        data-placement="right"
                                        title="Enter value between 30 to 250"
                                        data-toggle="tooltip"
                                        runat="server"
                                        class="form-control"></asp:TextBox>
                                    <div class="input-group-btn">
                                        <asp:DropDownList
                                            ID="weightInputTypeSelected"
                                            runat="server"
                                            class="text-dark form-control">
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

                        <div class="form-group row mb-2">
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
                                        placeholder="ft"
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
                                            <asp:ListItem Selected="True">ft</asp:ListItem>
                                            <asp:ListItem>m</asp:ListItem>
                                            <asp:ListItem>cm</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <span class="help-block">
                                    <asp:RequiredFieldValidator
                                        ID="heightInputRequiredValidator"
                                        Enabled="true"
                                        runat="server"
                                        ControlToValidate="heightInput"
                                        Display="Dynamic"
                                        ErrorMessage="Required!">
                                    </asp:RequiredFieldValidator>
                                    <asp:RequiredFieldValidator
                                        ID="heightInputRequiredValidatorInches"
                                        Enabled="true"
                                        runat="server"
                                        Display="Dynamic"
                                        ControlToValidate="heightInputInInches"
                                        ErrorMessage="Required!">
                                    </asp:RequiredFieldValidator>

                                    <asp:CustomValidator ID="heightInputCustomValidator" runat="server" ClientValidationFunction="customValidatorHeight" Display="Dynamic" ControlToValidate="heightInput" ErrorMessage="Invalid Input!" SetFocusOnError="true"></asp:CustomValidator>

                                  

                                    <asp:RangeValidator
                                        ID="heightInputRangeValidatorInches"
                                        runat="server"
                                        ControlToValidate="heightInputInInches"
                                        Display="Dynamic"
                                        MinimumValue="0"
                                        MaximumValue="11"
                                        Type="Integer"
                                        ErrorMessage="Invalid Input!">
                                    </asp:RangeValidator>


                                </span>
                            </div>
                        </div>

                       <div class="form-group row mb-2">
                            <asp:Label
                                ID="AgeLabel"
                                runat="server"
                                Text="Age"
                                class="col-lg-4"></asp:Label>
                            <div class="col-lg-8">
                                <div class="input-group">
                                    <asp:TextBox
                                        ID="ageInput"
                                        placeholder="age"
                                        data-placement="right"
                                        title="Enter age between [15-100]"
                                        data-toggle="tooltip"
                                        runat="server"
                                        class="form-control"></asp:TextBox>
                                    
                                </div>
                               <span class="help-block">
                                    <asp:RequiredFieldValidator
                                        ID="ageInputRequiredValidator"
                                        runat="server"
                                        display="Dynamic"
                                        ControlToValidate="ageInput"
                                        ErrorMessage="Required!">
                                    </asp:RequiredFieldValidator>

                                    <asp:RangeValidator
                                        ID="ageInputRangeValidator"
                                        runat="server"
                                         display="Dynamic"
                                        ControlToValidate="ageInput"
                                        MinimumValue="15"
                                        MaximumValue="100"
                                        Type="Integer"
                                        ErrorMessage="Invalid Input!">
                                    </asp:RangeValidator>
                                </span>
                            </div>
                        </div>

                        <div class="form-group row mb-2">
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

                        <div class="form-group row mb-2">
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

                        <div class="form-group row mt-3 mb-3">
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

                        <div class="form-group row text-dark mb-2">
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
        
        //weightInputType
        
        const weightInputSelector = document.getElementById("weightInputTypeSelected");
        weightInputSelector.addEventListener("change", weightInputHandler);
        const weightInput = document.getElementById("weightInput");

        function weightInputHandler() {
            if (weightInputSelector.value == "Kg") {
                weightInput.placeholder = "kg";
                return;
            }
            weightInput.placeholder = "lbs";
        }


        //heightInputType ft m cm
        const heightInputSelector = document.getElementById("heightInputTypeSelected");
        heightInputTypeSelected.addEventListener("change", heightInputHandler);
        //input Fields
        const heightInput = document.getElementById("heightInput");
        const heightInputInInches = document.getElementById("heightInputInInches");
        //required Validator
        const heightInputReqV = document.getElementById("heightInputRequiredValidator");
        const heightInputInchesReqV = document.getElementById("heightInputRequiredValidatorInches");
        //regex validator
        const heightInputRgx = document.getElementById("heightInputCustomValidator");
        //range validator
       // const heightInputRngV = document.getElementById("heightInputRangeValidator");
        const heightInputFeetsRngV = document.getElementById("heightInputRangeValidatorFeetInches");

        function heightInputHandler() {
            if (heightInputSelector.value == "ft") {
                heightInput.placeholder = "ft";
                heightInputInInches.style.visibility = "visible";
                heightInputInchesReqV.enabled = true;
               
                //heightInputRegex.ValidateExpression = "^[0-9]*[1-9][0-9]*$";
                
                return;
            }
            else if (heightInputSelector.value == "m") {
                heightInput.placeholder = "m";
                heightInputInInches.style.visibility = "hidden";
                heightInputInchesReqV.enabled = false;
               
                //heightInputRegex.ValidateExpression = "[0-9]([.,][0-9]{1,2})?$";
                return;
            }
            heightInput.placeholder = "cm";
            heightInputInInches.style.visibility = "hidden";
            heightInputInchesReqV.enabled = false;
            
            //heightInputRegex.ValidateExpression = "[0-9]([.,][0-9]{1,2})?$";
            return;
        }


        function customValidatorHeight(source, arguments) {
            var heightInputFeetsRgx = new RegExp("^[0 - 9]*[1 - 9][0 - 9]*$");
            var heightInputRgx = new RegExp("[0 - 9]([.,][0 - 9]{ 1, 2})?$");
            if (heightInputSelector.value == "ft") {
                const input = parseInt(arguments.Value);
                if (input >= 4 && input <= 6) {
                    arguments.IsValid = true;
                    return;
                }
                arguments.IsValid = false;
                return;


                //if (heightInputFeetsRgx.test(arguments.Value)) {
                //    arguments.IsValid = true;

                //}
                //arguments.IsValid = false;
            }
            else {
                if (heightInputSelector.value == "m") {
                    const input = parseFloat(arguments.Value);
                  
                    if (input >= 1.47 && input <= 1.98) {

                        arguments.IsValid = true;
                        return;
                    }
                    arguments.IsValid = false;
                    return;
                }
                else {
                    const input = parseInt(arguments.Value);
                    if (input > 147 && input <= 198) {
                        arguments.IsValid = true;
                        return;
                    }
                    arguments.IsValid = false;
                    return;}
                
                
                //if (heightInputRgx.test(arguments.Value)) {
                //    arguments.IsValid = true;

                //}
                //arguments.IsValid = false;
            }
            
        }

    </script>


</asp:Content>
