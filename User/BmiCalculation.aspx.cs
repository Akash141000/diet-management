using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Text.RegularExpressions;
using System.Diagnostics;


namespace DietManagement.User
{
    public partial class BmiCalculation : System.Web.UI.Page
    {

        int weight, age, lbs,  DesiredResult;
        float maintananceCalories;
        double bmi, height, heightInFeets;
        string UserId, genderFetched, lb;
        Boolean isLogged = false;
        protected void Page_Load(object sender, EventArgs e)
        {


            if (Session["Username"] != null)
            {
                loggedUser.Text = Session["Username"].ToString();
                UserId = Session["UserId"].ToString();
                isLogged = true;
            }
            else
            {
                Response.Redirect("~/Authentication/LoginPage.aspx");
            }



            //datadel();
        }






        protected void weightDropDown()
        {
            string weightSelectedValue;

            weightSelectedValue = weightInputTypeSelected.SelectedValue;
            try
            {
                if (weightSelectedValue == "lbs")
                {

                    // demo1 = weightInput.Text;
                    //demo2 = Convert.ToInt32(weightInput.Text);
                    //demo3 = Double.Parse((Convert.ToInt32(weightInput.Text) / 2.205).ToString());
                    lbs = (int)Double.Parse((Convert.ToInt32(weightInput.Text) / 2.205).ToString());
                    weight = lbs;
                }
                else if (weightSelectedValue == "Kg")
                {


                    //demo1 = weightInput.Text;
                    // demo2 = Convert.ToInt32(weightInput.Text);
                    lbs = Convert.ToInt32(weightInput.Text);
                    weight = lbs;
                }
            }
            catch (FormatException)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessagee", "alert('Something went wrong please try again.')", true);
            }
        }
        protected void heightDropDown()
        {
            int inch, feet;
           // doube heightInFeets;
            string heightSelectedValue = heightInputTypeSelected.SelectedValue;
            try
            {
                if (heightSelectedValue == "cm")
                {
                    heightInFeets = Math.Round(Convert.ToDouble(heightInput.Text), 2);
                    height = heightInFeets * 0.01;
                }
                else if (heightSelectedValue == "m")
                {
                    height = Math.Round(Convert.ToDouble(heightInput.Text), 2);
                }

                else if (heightSelectedValue == "ft")
                {

                    feet = Convert.ToInt32(heightInput.Text);
                    inch = Convert.ToInt32(heightInputInInches.Text);
                    inch += feet * 12;
                    height = Math.Round((inch * 2.54), 2);
                    height = Math.Round((height / 100), 2);
                }
            }
            catch (FormatException)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessagee", "alert('Something went wrong please try again.')", true);
            }
        }
        public void SaveBmi()
        {
            //updating or inserting BMI
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString))
                {
                    connection.Open();

                    SqlCommand cmd1 = new SqlCommand("SELECT * FROM [UserBmi] WHERE UserId=@UserId", connection);
                    
                    cmd1.Parameters.AddWithValue("@UserId", UserId);
                    var found = cmd1.ExecuteScalar();
                    
                    if (found != null)
                    {
                        SqlCommand cmd = new SqlCommand("UPDATE [UserBmi] SET BMI=@bmi,Age=@age,FoodCategory=@foodCategory,GenerateDietPlan=@generateDietPlan,MaintananceCalories=@maintananceCalories,Weight=@weight,Height=@height WHERE UserId=@UserId",connection);

                        cmd.Parameters.AddWithValue("@bmi", bmi);
                        cmd.Parameters.AddWithValue("@age", int.Parse(ageInput.Text));
                        cmd.Parameters.AddWithValue("@foodCategory", foodCategorySelected.SelectedIndex);
                        cmd.Parameters.AddWithValue("@generateDietPlan", categoryTypeSelected.SelectedIndex);
                        cmd.Parameters.AddWithValue("@maintananceCalories", maintananceCalories);
                        cmd.Parameters.AddWithValue("@weight", int.Parse(weightInput.Text));
                        cmd.Parameters.AddWithValue("@height", float.Parse(heightInput.Text));
                        cmd.Parameters.AddWithValue("@userId", UserId.ToString());
                        var executed = cmd.ExecuteNonQuery();

                        if (executed == 0)
                        {
                            errorSavingBmi.Text = "Saved Successfully";
                            
                            //throw new Exception("Unable to save data");
                            return;
                        }

                        errorSavingBmi.Text = "Saved Successfully";
                        return;


                    }

                    else
                    {
                        Debug.WriteLine("entered");

                        
                        SqlCommand cm = new SqlCommand("INSERT INTO [UserBmi] (UserId,BMI,Age,FoodCategory,GenerateDietPlan,MaintananceCalories,Weight,Height) values(@userId,@bmi,@age,@foodCategory,@generateDietPlan,@maintananceCalories,@weight,@height)", connection);
                        
                        cm.Parameters.AddWithValue("@userId", UserId);
                        
                        cm.Parameters.AddWithValue("@bmi", bmi);
                        
                        cm.Parameters.AddWithValue("@age", int.Parse(ageInput.Text));
                        
                        cm.Parameters.AddWithValue("@foodCategory", foodCategorySelected.SelectedIndex);
                        
                        cm.Parameters.AddWithValue("@generateDietPlan", categoryTypeSelected.SelectedIndex);
                            
                        cm.Parameters.AddWithValue("@maintananceCalories", maintananceCalories);
                       
                        cm.Parameters.AddWithValue("@weight",int.Parse(weightInput.Text));
                        
                       
                        cm.Parameters.AddWithValue("@height", float.Parse(heightInput.Text));
                        
                       
                        var result = cm.ExecuteNonQuery();
                        if(result != 0)
                        {
                            errorSavingBmi.Text = "Saved Successfully";
                            return;
                        }
                        errorSavingBmi.Text = "Unable to save data";
                        return;
                        

                    }
                }
            }
            catch (Exception)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessagee", "alert('Something went wrong please try again.')", true);
            }

            finally
            {
                Session["maintananceCalories"] = maintananceCalories.ToString();
            }

        }
        public int calculateMaintananceCalories()
        {
            float calculatedMaintananceCalories;
            //calculating BMI
            if (DesiredResult == 0)
            {
                //Maintian weight 
                calculatedMaintananceCalories = (lbs * 14) + (lbs * 16);
                calculatedMaintananceCalories = calculatedMaintananceCalories / 2;

            }
            else if (DesiredResult == 1)
            {
                //Weight Loss
                calculatedMaintananceCalories = (lbs * 14) + (lbs * 16);
                calculatedMaintananceCalories = (calculatedMaintananceCalories / 2);
                calculatedMaintananceCalories = calculatedMaintananceCalories - 500;
            }
            else
            {
                //Weight Gain
                calculatedMaintananceCalories = (lbs * 14) + (lbs * 16);
                calculatedMaintananceCalories = (calculatedMaintananceCalories / 2);
                calculatedMaintananceCalories = calculatedMaintananceCalories + 500;
            }
            return (int)calculatedMaintananceCalories;
        }
        protected void checkGender()
        {
            
            //check gender and convert weight to lbs

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString))
            {
                
                con.Open();
                SqlCommand cmd3 = new SqlCommand("SELECT Gender FROM [User] WHERE UserId=@UserId", con); //find gender
                cmd3.Parameters.AddWithValue("UserId", UserId);
                SqlDataReader reader = cmd3.ExecuteReader();
                while (reader.Read())
                {
                    genderFetched = reader["Gender"].ToString();
                   
                }
                reader.Close();

                if (genderFetched == "Male")
                {  //find ideal weight according to height
                    SqlCommand cmd1 = new SqlCommand("select Men from [HweightData] where Height=@heightt", con);
                    cmd1.Parameters.AddWithValue("@heightt", height);
                    SqlDataReader reade = cmd1.ExecuteReader();
                    while (reade.Read())
                    {
                        lb = reade["Men"].ToString();
                    }
                    reade.Close();
                    lbs = Convert.ToInt32(lb);
                    maintananceCalories = calculateMaintananceCalories();
                    SaveBmi();

                }
                else
                {
                    SqlCommand cmd1 = new SqlCommand("select Women from Hweightt where heightt=@heightt", con);
                    cmd1.Parameters.AddWithValue("@heightt", height);
                    SqlDataReader reade = cmd1.ExecuteReader();
                    while (reade.Read())
                    {
                        lb = reade["Women"].ToString();
                        lbs = int.Parse(lb);
                    }
                    reade.Close();
                    maintananceCalories = calculateMaintananceCalories();
                    SaveBmi();
                }
            }
        }




        protected void SaveBmi_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {

                    if (isLogged == true) //check if logged
                    {
                       
                        weightDropDown();
                        
                        heightDropDown();
                        
                        age = Convert.ToInt32(ageInput.Text);
                        

                        DesiredResult = categoryTypeSelected.SelectedIndex;

                        bmi = weight / (height * height);
                       
                        bmiOutput.Text = bmi.ToString();
                        
                        if (bmi <= 18.4)
                        {
                            bmiCategory.Text = "BMI shows that you are Underweight";
                            checkGender();
                        }
                        else if (bmi >= 25.0)
                        {
                            bmiCategory.Text = "BMI shows that you are Overweight";
                            checkGender();
                        }

                        if (bmi > 18.4 && bmi < 25.0)
                        {
                            //demo3 = weight * 2.205;
                            lbs = (int)(weight * 2.205);
                            bmiCategory.Text = "BMI normal";

                            maintananceCalories = calculateMaintananceCalories();

                            SaveBmi();


                        }
                    }
                }
            }
            catch (Exception)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessagee", "alert('Something went wrong please try again.')", true);
            }
        }










        //protected void datadel()
        //{
        //    try
        //    {
        //        DateTime dt;
        //        dt = DateTime.Today.AddDays(-6);
        //        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
        //        con.Open();
        //        SqlCommand cmd = new SqlCommand("Delete From Intake_History where Username=@User and Datetime<@date", con);
        //        SqlCommand cmd1 = new SqlCommand("Delete From Intake where Username=@User and Datetime<@date", con);
        //        cmd.Parameters.AddWithValue("@User", UserId);
        //        cmd.Parameters.AddWithValue("@date", dt);
        //        cmd1.Parameters.AddWithValue("@User", UserId);
        //        cmd1.Parameters.AddWithValue("@date", dt);
        //        cmd.ExecuteNonQuery();
        //        cmd1.ExecuteNonQuery();
        //        con.Close();
        //    }
        //    catch
        //    {
        //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessagee", "alert('Something went wrong please try ageain')", true);
        //    }
        //}





    }
}