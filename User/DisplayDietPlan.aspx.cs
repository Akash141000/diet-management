using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Diagnostics;

namespace DietManagement.User
{
    public partial class DisplayDietPlan : System.Web.UI.Page
    {
        int ma = 0, calorie;
        GridView gridView;
        string loggedUser, UserId, def;
        string[] timeArray = new string[] { "Breakfast", "Lunch", "Snack", "Dinner" };
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["Username"] != null && Session["UserId"] != null)
                {

                    loggedUser = Session["Username"].ToString();
                    UserId = Session["UserId"].ToString();
                    
                }
                else
                {
                    Response.Redirect("/Authentication/LoginPage.aspx");
                }

                checkDietType();

                ca();
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(def, con);
                    
                    foreach(string time in timeArray)
                    {
                        
                        if(time == "Breakfast")
                        {
                            gridView = breakFastGridView;
                        }
                        else if (time == "Lunch")
                        {
                            gridView = lunchGridView;
                        }
                        else if (time == "Snack")
                        {
                            gridView = snackGridView;
                        }
                        else
                        {
                            gridView = dinnerGridView;
                        }
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@cal", calorie);
                        cmd.Parameters.AddWithValue("@time", time);
                        SqlDataReader reader = cmd.ExecuteReader();
                        gridView.DataSource = reader;
                        gridView.DataBind();
                        reader.Close();
                    }
                }
            }
            catch (NullReferenceException)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something went wrong please try again')", true);
                //Response.Redirect("/User/BmiCalculation.aspx");
            }

        }
        protected void ca()
        {
            if (ma >= 1400 && ma <= 1450)
            {
                calorie = 1400;
            }
            else if (ma > 1450 && ma <= 1500)
            {
                calorie = 1500;
            }
            else if (ma > 1500 && ma <= 1650)
            {
                calorie = 1650;
            }
            else if (ma > 1650 && ma <= 1800)
            {
                calorie = 1800;
            }
            else if (ma > 1800 && ma <= 2000)
            {
                calorie = 2000;
            }
            else if (ma > 2000 && ma <= 2200)
            {
                calorie = 2200;
            }
            else if (ma > 2200 && ma <= 2300)
            {
                calorie = 2300;
            }
            else if (ma > 2300 && ma <= 2400)
            {
                calorie = 2400;
            }
            else if (ma > 2400 && ma <= 2600)
            {
                calorie = 2600;
            }
            else if (ma > 2600 && ma <= 2800)
            {
                calorie = 2800;
            }
            else if (ma > 2800 && ma <= 3000)
            {
                calorie = 3000;
            }
        }
        protected void checkDietType()
        {
            try
            {
                string d, e;
                int i;
                ;
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM [UserBmi] WHERE UserId=@userId ", con);
                    cmd.Parameters.AddWithValue("@userId", UserId);
                    var found = cmd.ExecuteNonQuery();

                    //SqlDataAdapter da = new SqlDataAdapter(cmd);
                    //DataTable dt = new DataTable();
                    //da.Fill(dt);
                    //con.Close();
                    if (found != 0)
                    {
                        SqlCommand cmd1 = new SqlCommand("SELECT MaintananceCalories,FoodCategory FROM [UserBmi] WHERE UserId=@userId ", con);
                        cmd1.Parameters.AddWithValue("@userId", UserId);

                        SqlDataReader read = cmd1.ExecuteReader();
                        read.Read();
                        d = read["MaintananceCalories"].ToString();
                        e = read["FoodCategory"].ToString();
                        i = Convert.ToInt32(e);
                        ma = Convert.ToInt32(d);

                        if (i == 0)
                        {
                            def = "SELECT Food,Quantity FROM [SavedVegDiet] WHERE calories=@cal AND Time=@time";
                        }
                        else
                        {
                            def = "SELECT Food,Quantity FROM [SavedNonVegDiet] WHERE calories=@cal AND Time=@time";
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please calculate your BMI first')", true);
                        Response.Redirect("/User/BmiCalculation.aspx");
                    }
                }
            }
            catch (Exception)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something went wrong please try again')", true);
            }
        }
    }
}