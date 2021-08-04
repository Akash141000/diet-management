using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DietManagement.User
{
    public partial class UserIntakeGraph : System.Web.UI.Page
    {
        string loggedUser;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["Username"] != null && Session["UserId"] != null)
            {
                Label1.Text = Session["Username"].ToString();
                loggedUser = Session["Username"].ToString();

                fu();
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void fu()
        {
            try
            {
                String mai;
                int main = 0;

                Chart1.Visible = true;

                Chart1.ChartAreas["ChartArea1"].AxisX.Title = "Intake";
                Chart1.ChartAreas["ChartArea1"].AxisY.Title = "Total Calories";
                SqlConnection co = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
                co.Open();

                SqlCommand cm = new SqlCommand("SELECT Caloricint,Datetime FROM [UserIntake] WHERE  Username=@User", co);
                cm.Parameters.AddWithValue("@User", loggedUser);
                SqlDataAdapter rd = new SqlDataAdapter(cm);
                DataTable dte = new DataTable();
                rd.Fill(dte);
                co.Close();

                for (int i = 0; i < dte.Rows.Count; i++)
                {
                    String temi = dte.Rows[i][1].ToString();
                    DateTime tempi = DateTime.Parse(temi);
                    mai = dte.Rows[i][0].ToString();
                    main = Convert.ToInt32(mai);
                    this.Chart1.Series["Main"].Points.AddXY((tempi), (main));
                }
            }
            catch (Exception)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something went wrong please try again')", true);
            }

        }
    }
}