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


namespace DietManagement.User
{
    public partial class customDietPlanDisplay : System.Web.UI.Page
    {

        string loggedUser,UserId,amountOfProtein,amountOfCarbs,amountOfFats,amountOfCalories;
        int proteinRequired, carbsRequired, fatsRequired, maintananceCalories, totalProtein = 0, totalCarbs = 0, totalfats = 0, Totalcal = 0, removeBtnPressed = 0, checkBtnPressed = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] != null && Session["UserId"] != null)
            {
                UserId = Session["UserId"].ToString();
                loggedUser = Session["Username"].ToString();
            }
            else
            {
                Response.Redirect("/Authentication/LoginPage.aspx");
            }

            try
            {

                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT MaintananceCalories,ProteinRequired,CarbsRequired,FatsRequired  FROM [UserBmi] WHERE UserID=@userId", con);
                    cmd.Parameters.AddWithValue("@userId", UserId);
                    SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (reader.Read())
                    {
                        maintananceCalories = int.Parse(reader["MaintananceCalories"].ToString());
                        proteinRequired = int.Parse(reader["ProteinRequired"].ToString());
                        carbsRequired = int.Parse(reader["CarbsRequired"].ToString());
                        fatsRequired = int.Parse(reader["FatsRequired"].ToString());
                    }


                }
                calculateDiet();

                GridDisplay();
            }
            catch (Exception)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something went wrong please try again')", true);
            }

        }
        private void analyseDiet() {
            proteinAmount();
            carbsAmount();
            fatsAmount();
            maintananceCaloriesAmount();


             void proteinAmount()
            {
                if (proteinRequired / 2 > totalProtein)
                {
                    amountOfProtein = "low";
                }
                else if (proteinRequired + proteinRequired / 2 < totalProtein)
                {
                    amountOfProtein = "high";
                }
                else if (proteinRequired / 2 < totalProtein && totalProtein < proteinRequired + proteinRequired / 2)
                {
                    amountOfProtein = "perfect";
                }

            }
             void carbsAmount()
            {
                if (carbsRequired / 2 > totalCarbs)
                {
                    amountOfCarbs = "low";
                }
                else if (carbsRequired + carbsRequired / 2 < totalCarbs)
                {
                    amountOfCarbs = "high";
                }
                else if (carbsRequired / 2 < totalCarbs && totalCarbs < carbsRequired + carbsRequired / 2)
                {
                    amountOfCarbs = "perfect";
                }
            }
             void fatsAmount()
            {
                if (fatsRequired / 2 > totalfats)
                {
                    amountOfFats = "low";
                }
                else if (fatsRequired + fatsRequired / 2 < totalfats)
                {
                    amountOfFats = "high";
                }
                else if (fatsRequired / 2 < totalfats && totalfats < fatsRequired + fatsRequired / 2)
                {
                    amountOfFats = "perfect";
                }
            }
             void maintananceCaloriesAmount()
            {
                if (maintananceCalories - 50 < Totalcal && Totalcal < maintananceCalories + 50)
                {
                    amountOfCalories = "Perfect";
                }
                else if (maintananceCalories - 50 > Totalcal)
                {
                    amountOfCalories = "Low";
                }
                else if (maintananceCalories + 50 < Totalcal)
                {
                    amountOfCalories = "High";
                }
            }
        }
       

        protected void calculateDiet()
        {
            try
            {

                checkBtnPressed = checkBtnPressed + 1;
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT Protein,Carbohydrate,Total_Fat,Calories FROM [Dietplan] WHERE Username=@User", con);
                    cmd.Parameters.AddWithValue("@User", loggedUser);
                    SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                    while (reader.Read())
                    {
                        float protein = float.Parse(reader["Protein"].ToString());
                        totalProtein = totalProtein + (int)protein;
                        float carbs = float.Parse(reader["Carbohydrate"].ToString());
                        totalCarbs = totalCarbs + (int)carbs;
                        float fats = float.Parse(reader["Total_Fat"].ToString());
                        totalfats = totalfats + (int)fats;
                        float calories = float.Parse(reader["Calories"].ToString());
                        Totalcal = Totalcal + (int)calories;
                    }

                    
                }

                if (Totalcal == 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please select food to create a Dietplan')", true);
                    Response.Redirect("/User/CreateDietPlan.aspx");
                    return;
                }
                proteinAmountLbl.Text = totalProtein.ToString();
                carbohydrateAmountLbl.Text = totalCarbs.ToString();
                fatsAmountLbl.Text = totalfats.ToString();
                totalCaloriesLbl.Text = Totalcal.ToString();
                analyseDiet(); // check diet info
                displayMaintananceCaloriesLbl.Text = "Maintanance calories" + " " + "is" + " " + amountOfCalories + "<br>" + "protein" + " " + "is" + " " + amountOfProtein + "<br>" + "Carbohydrate" + " " + "is" + " " + amountOfCarbs + "<br>" + "Total Fat" + " " + "is" + " " + amountOfFats;
                totalProtein = 0;
                totalCarbs = 0;
                totalfats = 0;
                Totalcal = 0;

            }
            catch
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something went wrong please try again')", true);
            }
        }

        protected void checkBtn_Click(object sender, EventArgs e)
        {
            calculateDiet();


        }
        protected void addMoreFoodBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("/User/CreateDietPlan.aspx");
        }
        protected void removeFoodBtn_Click(object sender, EventArgs e)
        {
            try
            {
                removeBtnPressed = removeBtnPressed + 1;
                if (removeBtnPressed > 1)
                {
                    removeFoodBtn.Visible = false;
                }
                else
                {
                    removeFoodBtn.Visible = true;
                }
                if (checkBtnPressed > 1)
                {
                    removeFoodBtn.Visible = false;
                }
                else
                {
                    removeFoodBtn.Visible = true;
                }


                CommandField cField = new CommandField();
                cField.ShowDeleteButton = true;
                cField.DeleteText = "Delete";

                List<GridView> gridViews = new List<GridView>() { breakfastGridView, lunchGridView, snackGridView, dinnerGridView };
                foreach (GridView grid in gridViews)
                {
                    grid.Columns.Add(cField);
                }
                GridDisplay();

                if (cField.ShowDeleteButton == true)
                {
                    removeFoodBtn.Visible = false;
                }
                else
                {
                    removeFoodBtn.Visible = true;
                }
            }
            catch
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something went wrong please try again')", true);
            }
        }
        protected void breakfastGridView_OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {

                int rowId = 0;

                rowId = Convert.ToInt32(this.breakfastGridView.DataKeys[e.RowIndex].Value);

                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM [Dietplan] WHERE id=@id AND Username=@User", con);
                    cmd.Parameters.AddWithValue("@id", rowId);
                    cmd.Parameters.AddWithValue("@User", loggedUser);
                    cmd.ExecuteNonQuery();
                    GridDisplay("breakfast");
                }
                
            }
            catch (Exception)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('4Something went wrong please try again')", true);
            }
        }
        protected void lunchGridView_OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int rowId = 0;

            rowId = Convert.ToInt32(lunchGridView.DataKeys[e.RowIndex].Value);

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM [Dietplan] WHERE id=@id AND Username=@User", con);
                cmd.Parameters.AddWithValue("@id", rowId);
                cmd.Parameters.AddWithValue("@User", loggedUser);
                cmd.ExecuteNonQuery();
                GridDisplay("lunch");
            }
           

        }
        protected void snackGridView_OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int rowId = 0;

            rowId = Convert.ToInt32(this.snackGridView.DataKeys[e.RowIndex].Value);

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM [Dietplan] WHERE id=@id AND Username=@User", con);
                cmd.Parameters.AddWithValue("@id", rowId);
                cmd.Parameters.AddWithValue("@User", loggedUser);
                cmd.ExecuteNonQuery();
                GridDisplay("snack");
            }
        }
        protected void dinnerGridView_OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int rowId = 0;

            rowId = Convert.ToInt32(this.dinnerGridView.DataKeys[e.RowIndex].Value);

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString))
            {
                con.Open();
                SqlCommand cm = new SqlCommand("DELETE FROM [Dietplan] WHERE id=@id AND Username=@User", con);
                cm.Parameters.AddWithValue("@id", rowId);
                cm.Parameters.AddWithValue("@User", loggedUser);
                cm.ExecuteNonQuery();
                GridDisplay("dinner");
            }
        }

        protected void GridDisplay(string gridTimeArgs = null)
        {
            string[] timeArray = new string[] { "breakfast", "lunch", "snack", "dinner" };
            GridView gridView;

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString))
            {

                if (gridTimeArgs != null)
                {
                    setTime(gridTimeArgs);
                    displayGrid(gridTimeArgs);
                    return;
                }
                else
                {
                    foreach (string timeElement in timeArray)
                    {
                        setTime(timeElement);
                        displayGrid(timeElement);
                    }
                }


                void setTime(string timeArgs)
                {
                    if (timeArgs == "breakfast")
                    {
                        gridView = breakfastGridView;
                    }
                    else if (timeArgs == "lunch")
                    {
                        gridView = lunchGridView;
                    }
                    else if (timeArgs == "snack")
                    {
                        gridView = snackGridView;
                    }
                    else
                    {
                        gridView = dinnerGridView;
                    }
                }

                void displayGrid(string timeArgs)
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT id,Food,Protein,Carbohydrate,Total_Fat,Calories FROM [Dietplan] WHERE Time=@type AND Username=@Username", con);

                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@type", timeArgs);
                    cmd.Parameters.AddWithValue("@Username", loggedUser);
                    SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    gridView.DataSource = reader;
                    gridView.DataBind();
                }
            }
        }
       
    }
}