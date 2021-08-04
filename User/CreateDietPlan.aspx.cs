using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Security;
using System.Data;
using System.Diagnostics;

namespace DietManagement.User
{
    public partial class CreateDietPlan : System.Web.UI.Page
    {
        string loggedUser, UserId;
        string generateDietPlanId, DietPlanType;
        int maintananceCalories, weight, foodCategory;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["Username"] != null && Session["UserId"] != null)
            {
                Label7.Text = Session["Username"].ToString();
                UserId = Session["UserId"].ToString();
                loggedUser = Session["Username"].ToString();
            }
            else
            {
                Response.Redirect("/Authentication/LoginPage.aspx");
            }
            checkBmi();


        }

        protected void checkBmi()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM [UserBmi] WHERE UserId=@userId ", con);
                cmd.Parameters.AddWithValue("@userId", UserId);
                var found = cmd.ExecuteScalar();
                if (found != null)
                {
                    //If UserBmi is not saved
                    Bmi();
                    return;
                }
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please calculate your BMI first')", true);
                Response.Redirect("/User/BmiCalculation.aspx");
            }
        }

        protected void Bmi()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT BMI,MaintananceCalories,GenerateDietPlan,Weight,FoodCategory FROM [UserBmi] WHERE UserId=@userId", con);
                    cmd.Parameters.AddWithValue("@userId", UserId);
                    SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    reader.Read();

                    bmiValue.Text = reader["BMI"].ToString();
                    maintananceCaloriesValue.Text = reader["MaintananceCalories"].ToString();
                    generateDietPlanId = reader["GenerateDietPlan"].ToString();
                    weight = int.Parse(reader["Weight"].ToString());
                    foodCategory = int.Parse(reader["FoodCategory"].ToString());
                    maintananceCalories = int.Parse(maintananceCaloriesValue.Text);
                    
                    if (foodCategory == 0)
                    {
                        foodCategoryValue.Text = "veg";
                    }
                    else
                    {
                        foodCategoryValue.Text = "Non-Veg";
                    }
                }
                checkFoodCategory();
                GridOutput();
            }
            catch (Exception)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something went wrong please try again')", true);
                
            }

        }

        protected void checkFoodCategory()
        {
            string dietTypeNonVeg, dietTypeVeg;
            dietTypeNonVeg = "SELECT Food,Serving_Size,Protein,Carbs,Fat,Calories,Time FROM [Dplan] WHERE Time=@type and vn='Veg'";
            dietTypeVeg = "SELECT Food,Serving_Size,Protein,Carbs,Fat,Calories,Time FROM [Dplan] WHERE Time=@type";
            if (foodCategory != 1)
            {
                DietPlanType = dietTypeNonVeg;
                return;
            }
            DietPlanType = dietTypeVeg;

        }

        protected void GridOutput()
        {
            string[] timeArray = new string[] { "breakfast", "lunch", "snack", "dinner" };
            GridView gridView;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString))
            {
                
                foreach (string time in timeArray)
                {
                    if (time == "breakfast")
                    {
                        gridView = breakfastGridView;
                    }
                    else if (time == "lunch")
                    {
                        gridView = lunchGridView;
                    }
                    else if (time == "snack")
                    {
                        gridView = snackGridView;
                    }
                    else
                    {
                        gridView = dinnerGridView;
                    }
                    con.Open();
                    SqlCommand cmd = new SqlCommand(DietPlanType, con);
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@type", time);
                    SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    gridView.DataSource = reader;
                    gridView.DataBind();
                }
            }
        }

        protected void generateDietPlan_Click(object sender, EventArgs e)
        {
            int protein = (int)((weight * 2.205) * 1.3);
            int caloriesForProtein = protein * 4;
            int fats = ((maintananceCalories * 15 % 100) + (maintananceCalories * 25 % 100)) / 2;
            int caloriesForFats = fats * 9;
            int caloriesForCarbs = maintananceCalories - (caloriesForFats + caloriesForProtein);
            int carbs = caloriesForCarbs / 4;

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE [UserBmi] SET ProteinRequired=@Protein,CarbsRequired=@Carbs,FatsRequired=@Fat WHERE UserId=@userId", con);

                cmd.Parameters.AddWithValue("@userId", UserId);
                cmd.Parameters.AddWithValue("@Protein", protein);
                cmd.Parameters.AddWithValue("@Carbs", carbs);
                cmd.Parameters.AddWithValue("@Fat", fats);
                cmd.ExecuteNonQuery();
            }
            Response.Redirect("/User/customDietPlanDisplay.aspx"); 

            
        }
        protected void breakfastGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Food = breakfastGridView.SelectedRow.Cells[1].Text;

            string Time = breakfastGridView.SelectedRow.Cells[7].Text;

            float Protein = float.Parse(breakfastGridView.SelectedRow.Cells[3].Text);

            float carbohydrate = float.Parse(breakfastGridView.SelectedRow.Cells[4].Text);

            float fat = float.Parse(breakfastGridView.SelectedRow.Cells[5].Text);

            float calories = float.Parse(breakfastGridView.SelectedRow.Cells[6].Text);

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO [Dietplan] (Username,Food,Time,Protein,Carbohydrate,Total_Fat,Calories) values(@Username,@Food,@Time,@Protein,@Carbohydrate,@Total_Fat,@Calories)", con);
                cmd.Parameters.AddWithValue("@Username", loggedUser);
                cmd.Parameters.AddWithValue("@Food", Food);
                cmd.Parameters.AddWithValue("@Time", Time);
                cmd.Parameters.AddWithValue("@Protein", Protein);
                cmd.Parameters.AddWithValue("@Carbohydrate", carbohydrate);
                cmd.Parameters.AddWithValue("@Total_Fat", fat);
                cmd.Parameters.AddWithValue("@Calories", calories);
                cmd.ExecuteNonQuery();
            }

        }
        protected void lunchGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Food = lunchGridView.SelectedRow.Cells[1].Text;
            string Time = lunchGridView.SelectedRow.Cells[7].Text;

            float Protein = float.Parse(lunchGridView.SelectedRow.Cells[3].Text);

            float carbohydrate = float.Parse(lunchGridView.SelectedRow.Cells[4].Text);

            float fat = float.Parse(lunchGridView.SelectedRow.Cells[5].Text);

            float calories = float.Parse(lunchGridView.SelectedRow.Cells[6].Text);

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO [Dietplan] (Username,Food,Time,Protein,Carbohydrate,Total_Fat,Calories) values(@Username,@Food,@Time,@Protein,@Carbohydrate,@Total_Fat,@Calories)", con);
                cmd.Parameters.AddWithValue("@Username", loggedUser);
                cmd.Parameters.AddWithValue("@Food", Food);
                cmd.Parameters.AddWithValue("@Time", Time);
                cmd.Parameters.AddWithValue("@Protein", Protein);
                cmd.Parameters.AddWithValue("@Carbohydrate", carbohydrate);
                cmd.Parameters.AddWithValue("@Total_Fat", fat);
                cmd.Parameters.AddWithValue("@Calories", calories);
                cmd.ExecuteNonQuery();
            }

        }
        protected void snackGridView_SelectedIndexChanged(object sender, EventArgs e)
        {

            string Food = snackGridView.SelectedRow.Cells[1].Text;
            string Time = snackGridView.SelectedRow.Cells[7].Text;

            float Protein = float.Parse(snackGridView.SelectedRow.Cells[3].Text);

            float carbohydrate = float.Parse(snackGridView.SelectedRow.Cells[4].Text);

            float fat = float.Parse(snackGridView.SelectedRow.Cells[5].Text);

            float calories = float.Parse(snackGridView.SelectedRow.Cells[6].Text);

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO [Dietplan] (Username,Food,Time,Protein,Carbohydrate,Total_Fat,Calories) values(@Username,@Food,@Time,@Protein,@Carbohydrate,@Total_Fat,@Calories)", con);
                cmd.Parameters.AddWithValue("@Username", loggedUser);
                cmd.Parameters.AddWithValue("@Food", Food);
                cmd.Parameters.AddWithValue("@Time", Time);
                cmd.Parameters.AddWithValue("@Protein", Protein);
                cmd.Parameters.AddWithValue("@Carbohydrate", carbohydrate);
                cmd.Parameters.AddWithValue("@Total_Fat", fat);
                cmd.Parameters.AddWithValue("@Calories", calories);
                cmd.ExecuteNonQuery();
            }

        }
        protected void dinnerGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Food = dinnerGridView.SelectedRow.Cells[1].Text;
            string Time = dinnerGridView.SelectedRow.Cells[7].Text;

            float Protein = float.Parse(dinnerGridView.SelectedRow.Cells[3].Text);

            float carbohydrate = float.Parse(dinnerGridView.SelectedRow.Cells[4].Text);

            float fat = float.Parse(dinnerGridView.SelectedRow.Cells[5].Text);

            float calories = float.Parse(dinnerGridView.SelectedRow.Cells[6].Text);

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO [Dietplan] (Username,Food,Time,Protein,Carbohydrate,Total_Fat,Calories) values(@Username,@Food,@Time,@Protein,@Carbohydrate,@Total_Fat,@Calories)", con);
                cmd.Parameters.AddWithValue("@Username", loggedUser);
                cmd.Parameters.AddWithValue("@Food", Food);
                cmd.Parameters.AddWithValue("@Time", Time);
                cmd.Parameters.AddWithValue("@Protein", Protein);
                cmd.Parameters.AddWithValue("@Carbohydrate", carbohydrate);
                cmd.Parameters.AddWithValue("@Total_Fat", fat);
                cmd.Parameters.AddWithValue("@Calories", calories);
                cmd.ExecuteNonQuery();
            }
        }


    }

}