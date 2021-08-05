using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Globalization;

namespace DietManagement.User
{
    public partial class IntakeHistory : System.Web.UI.Page
    {
        string loggedUser, UserId;
        int maintananceCalories;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] != null && Session["UserId"] != null)
            {
                Label2.Text = Session["Username"].ToString();
                loggedUser = Session["Username"].ToString();
                UserId = Session["UserId"].ToString();
                searchResultLbl.Visible = false;
                invalidDateLbl.Visible = false;
                work();
                statisticsBtn.Visible = false;

            }
            else
            {
                Response.Redirect("/Authentication/LoginPage.aspx");
            }

        }

        protected void work()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT MaintananceCalories FROM [UserBmi] WHERE UserId=@userId", con);
                    cmd.Parameters.AddWithValue("@userId", UserId);

                    SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (reader.Read()) {
                        maintananceCalories = int.Parse(reader["MaintananceCalories"].ToString());

                    };
                   
                }
                
            }

            catch (Exception)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something went wrong please try again')", true);
                Response.Redirect("/User/BmiCalculation.aspx");
            }
        }



        protected void bt()
        {

           
            int ma = 0, ro = 0, temp1, temp2, temp3;


            try
            {

                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT Datetime FROM [UserIntakeHistory] WHERE Username=@User", con);
                    cmd.Parameters.AddWithValue("@User", loggedUser);
                    SqlDataReader reader = cmd.ExecuteReader();
                    DataTable dte = new DataTable();
                    dte.Load(reader);
                    ViewState["dte"] = dte;
                    dte = dte.DefaultView.ToTable(true, "Datetime");
                    ro = dte.Rows.Count;


                    for (int i = 0; i < ro; i++)
                    {
                        int Totalprot = 0, Totalcarb = 0, Totalfat = 0;

                        SqlCommand cmd1 = new SqlCommand("SELECT Protein,Carbohydrate,[Total Fat] FROM [UserIntakeHistory] WHERE Username=@User AND Datetime=@date", con);
                        cmd1.Parameters.AddWithValue("@User", loggedUser);
                        string tem = dte.Rows[i][0].ToString();
                        DateTime temp = DateTime.Parse(tem);


                        cmd1.Parameters.AddWithValue("@date", temp);
                        
                        SqlDataReader read = cmd1.ExecuteReader();
                        while (read.Read())
                        {

                            temp1 = int.Parse(read["Protein"].ToString());
                            Totalprot = Totalprot + (int)temp1;
                            temp2 = int.Parse(read["Carbohydrate"].ToString());
                            Totalcarb = Totalcarb + (int)temp2;
                            temp3 = int.Parse(read["Total Fat"].ToString());
                            Totalfat = Totalfat + (int)temp3;

                        }
                        ma = (Totalprot * 4) + (Totalcarb * 4) + (Totalfat * 9);

                        SqlCommand cd = new SqlCommand("SELECT * FROM [UserIntake] WHERE Username=@Username AND Datetime=@Date", con);
                      
                        cd.Parameters.AddWithValue("@Username", loggedUser);
                        cd.Parameters.AddWithValue("@Date", temp);
                        SqlDataAdapter da = new SqlDataAdapter(cd);
                        DataTable dti = new DataTable();
                        da.Fill(dti);
                        if (dti.Rows.Count > 0)
                        {
                            SqlCommand cmdQ = new SqlCommand("UPDATE [UserIntake] SET Caloricint=@cal WHERE Username=@usrname AND Datetime=@Date", con);
                            cmdQ.Parameters.AddWithValue("@cal", ma);
                            cmdQ.Parameters.AddWithValue("@usrname", loggedUser);
                            cmdQ.Parameters.AddWithValue("@Date", temp);
                            cmdQ.ExecuteNonQuery();
                        }

                        else
                        {
                            SqlCommand cmdQ = new SqlCommand("INSERT INTO [UserIntake] (Maintanance,Caloricint,Datetime,Username) values(@main,@cal,@date,@User)", con);
                            cmdQ.Parameters.AddWithValue("@main", maintananceCalories);
                            cmdQ.Parameters.AddWithValue("@cal", ma);
                            cmdQ.Parameters.AddWithValue("@date", temp);
                            cmdQ.Parameters.AddWithValue("@User", loggedUser);
                            cmdQ.ExecuteNonQuery();

                        }

                    }
                }
            }
            catch (Exception)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something went wrong please try again')", true);
            }
        }

        protected void displayIntakeDataBtn_Click(object sender, EventArgs e)
        {

            DateTime Dt, dd, dt1;
            string txt;
            try
            {
                txt = dataInput.Text;

                Dt = DateTime.Parse(dataInput.Text);

                dt1 = DateTime.UtcNow;


                dd = DateTime.UtcNow.AddDays(-6);


                if (Dt > dt1 || Dt < dd)
                {
                    invalidDateLbl.Visible = true;
                    invalidDateLbl.Text = "Invalid date";
                }
                else
                {
                    using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString))
                    {

                        con.Open();
                        SqlCommand cm = new SqlCommand("SELECT Datetime FROM [UserIntakeHistory] WHERE Username=@user", con);
                        cm.Parameters.AddWithValue("@user", loggedUser);
                        SqlDataAdapter da = new SqlDataAdapter(cm);
                        DataTable de = new DataTable();
                        da.Fill(de);
                        if (de.Rows.Count > 0)
                        {
                            SqlCommand cmd = new SqlCommand("SELECT Food,Protein,Carbohydrate,[Total Fat] FROM [UserIntakeHistory] WHERE Datetime=@Date and Username=@user", con);
                            cmd.Parameters.AddWithValue("@Date", DateTime.Parse(dataInput.Text));
                            cmd.Parameters.AddWithValue("@user", loggedUser);
                            
                            SqlDataReader reader =  cmd.ExecuteReader();
                            displayIntakeGridView.DataSource = reader;
                            displayIntakeGridView.DataBind();
                            reader.Close();
                            bt();
                            statisticsBtn.Visible = true;
                        }
                        else
                        {
                            statisticsBtn.Visible = false;
                            searchResultLbl.Visible = true;
                            searchResultLbl.Text = "No data Entered in last 7 days";

                        }
                    }
                }
            }


            catch (FormatException)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Enter Valid Date')", true);
            }
        }
        protected void statisticsBtn_Click(object sender, EventArgs e)
        {

            Response.Redirect("/User/UserIntakeGraph.aspx");

        }
    }
}
