using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace DietManagement.User
{
    public partial class DisplayDietPlan : System.Web.UI.Page
    {
        int ma = 0, calorie;
        String Struser, def;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["Username"] != null)
                {

                    Struser = Session["Username"].ToString();
                    Label5.Text = Struser;
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }

                check();

                ca();

                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
                SqlCommand cmd = new SqlCommand(def, con);
                SqlCommand cd = new SqlCommand(def, con);
                SqlCommand cm = new SqlCommand(def, con);
                SqlCommand cmd1 = new SqlCommand(def, con);
                cmd.Parameters.AddWithValue("@cal", calorie);
                cmd.Parameters.AddWithValue("@time", "Breakfast");
                cd.Parameters.AddWithValue("@cal", calorie);
                cd.Parameters.AddWithValue("@time", "Lunch");
                cm.Parameters.AddWithValue("@cal", calorie);
                cm.Parameters.AddWithValue("@time", "Snack");
                cmd1.Parameters.AddWithValue("@cal", calorie);
                cmd1.Parameters.AddWithValue("@time", "Dinner");
                con.Open();
                SqlDataReader r;
                SqlDataReader s;
                SqlDataReader t;
                SqlDataReader u;
                r = cmd.ExecuteReader();
                breakFastGridView.DataSource = r;
                breakFastGridView.DataBind();
                r.Close();
                s = cd.ExecuteReader();
                lunchGridView.DataSource = s;
                lunchGridView.DataBind();
                s.Close();
                t = cm.ExecuteReader();
                snackGridView.DataSource = t;
                snackGridView.DataBind();
                t.Close();
                u = cmd1.ExecuteReader();
                dinnerGridView.DataSource = u;
                dinnerGridView.DataBind();
                u.Close();
                con.Close();
            }
            catch (NullReferenceException)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something went wrong please try again')", true);
                Response.Redirect("BMI.aspx");
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
        protected void check()
        {
            try
            {
                String d, e;
                int i;
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from demo where Username=@Username ", con);
                cmd.Parameters.AddWithValue("@Username", Struser);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                if (dt.Rows.Count > 0)
                {
                    SqlCommand cmd1 = new SqlCommand("select Maintanance,Food_Catagory from demo where Username=@Username ", con);
                    cmd1.Parameters.AddWithValue("@Username", Struser);
                    con.Open();
                    SqlDataReader read = cmd1.ExecuteReader();
                    read.Read();
                    d = read["Maintanance"].ToString();
                    e = read["Food_Catagory"].ToString();
                    i = Convert.ToInt32(e);
                    ma = Convert.ToInt32(d);

                    con.Close();
                    if (i == 0)
                    {
                        def = "select Food,Quantity from Diet where calories=@cal and Time=@time;";
                    }
                    else
                    {
                        def = "select Food,Quantity from NDiet where calories=@cal and Time=@time;";
                    }
                }

                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please calculate your BMI first')", true);
                    Response.Redirect("BMI.aspx");
                }
            }
            catch (Exception)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something went wrong please try again')", true);
            }
        }
    }
}