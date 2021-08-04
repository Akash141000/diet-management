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
    public partial class AddNewFoodItem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            Button1.Visible = true;
            Label5.Text = "";


        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString))
                {
                    con.Open();


                    SqlCommand cmd = new SqlCommand("SELECT * FROM [Nutrition] WHERE Food=@food", con);
                    cmd.Parameters.AddWithValue("@food", TextBox1.Text);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        Label7.Text = "A food item with same name already exists";
                        Label5.Visible = true;
                    }
                    else
                    {

                        SqlCommand cd = new SqlCommand("INSERT INTO [Nutrition]" + "(Food,Protein,Carbohydrate,Total_Fat,[Serving Size]) values(@Food,@protein,@carbs,@fat,@serving)", con);

                        cd.Parameters.AddWithValue("@Food", TextBox1.Text);
                        cd.Parameters.AddWithValue("@protein", TextBox2.Text);
                        cd.Parameters.AddWithValue("@carbs", TextBox3.Text);
                        cd.Parameters.AddWithValue("@fat", TextBox4.Text);
                        cd.Parameters.AddWithValue("@serving", TextBox5.Text);
                        cd.ExecuteNonQuery();

                        Label5.Visible = true;
                        Label5.Text = "Added Successfully";

                        TextBox1.Text = "";
                        TextBox2.Text = "";
                        TextBox3.Text = "";
                        TextBox4.Text = "";
                        TextBox5.Text = "";
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