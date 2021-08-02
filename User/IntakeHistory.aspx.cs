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
        String Struser;
        int maintanan;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] != null)
            {
                Label2.Text = Session["Username"].ToString();
                Struser = Session["Username"].ToString();
                searchResultLbl.Visible = false;
                invalidDateLbl.Visible = false;
                work();
                statisticsBtn.Visible = false;

            }
            else
            {
                Response.Redirect("Login.aspx");
            }

        }

        protected void work()
        {
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
                SqlCommand cmd = new SqlCommand("Select Maintanance from demo where Username=@user", con);
                cmd.Parameters.AddWithValue("@user", Struser);
                con.Open();
                SqlDataReader read = cmd.ExecuteReader();
                read.Read();
                maintanan = Convert.ToInt32(read["Maintanance"].ToString());
                read.Close();
                con.Close();
            }

            catch (Exception)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something went wrong please try again')", true);
                Response.Redirect("BMI.aspx");
            }
        }



        protected void bt()
        {

            float temp1, temp2, temp3;
            int ma = 0, ro = 0;


            try
            {

                SqlConnection cone = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
                SqlCommand cmde = new SqlCommand("select Datetime from Intake_History where Username=@User", cone);
                cmde.Parameters.AddWithValue("@User", Struser);
                cone.Open();
                SqlDataReader reader = cmde.ExecuteReader();
                DataTable dte = new DataTable();
                dte.Load(reader);
                ViewState["dte"] = dte;
                dte = dte.DefaultView.ToTable(true, "Datetime");
                ro = dte.Rows.Count;


                cone.Close();
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
                for (int i = 0; i < ro; i++)
                {
                    int Totalprot = 0, Totalcarb = 0, Totalfat = 0;

                    SqlCommand cmd1 = new SqlCommand("select Protein,Carbohydrate,[Total Fat] from Intake_History where Username=@User and Datetime=@date", con);
                    cmd1.Parameters.AddWithValue("@User", Struser);
                    String tem = dte.Rows[i][0].ToString();
                    DateTime temp = DateTime.Parse(tem);


                    cmd1.Parameters.AddWithValue("@date", temp);
                    con.Open();
                    SqlDataReader read = cmd1.ExecuteReader();
                    while (read.Read())
                    {

                        temp1 = float.Parse(read["Protein"].ToString());
                        Totalprot = Totalprot + (int)temp1;
                        temp2 = float.Parse(read["Carbohydrate"].ToString());
                        Totalcarb = Totalcarb + (int)temp2;
                        temp3 = float.Parse(read["Total Fat"].ToString());
                        Totalfat = Totalfat + (int)temp3;

                    }
                    con.Close();
                    ma = (Totalprot * 4) + (Totalcarb * 4) + (Totalfat * 9);

                    SqlCommand cd = new SqlCommand("select * from Intake where Username=@Username and Datetime=@Date", con);
                    con.Open();
                    cd.Parameters.AddWithValue("@Username", Struser);
                    cd.Parameters.AddWithValue("@Date", temp);
                    SqlDataAdapter da = new SqlDataAdapter(cd);
                    DataTable dti = new DataTable();
                    da.Fill(dti);
                    if (dti.Rows.Count > 0)
                    {
                        SqlCommand cd1 = new SqlCommand("UPDATE Intake SET Caloricint=@cal WHERE Username=@usrname and Datetime=@Date", con);
                        cd1.Parameters.AddWithValue("@cal", ma);
                        cd1.Parameters.AddWithValue("@usrname", Struser);
                        cd1.Parameters.AddWithValue("@Date", temp);
                        cd1.ExecuteNonQuery();
                        con.Close();

                    }

                    else
                    {
                        SqlCommand cd1 = new SqlCommand("insert into Intake" + "(Maintanance,Caloricint,Datetime,Username) values(@main,@cal,@date,@User)", con);
                        cd1.Parameters.AddWithValue("@main", maintanan);
                        cd1.Parameters.AddWithValue("@cal", ma);
                        cd1.Parameters.AddWithValue("@date", temp);
                        cd1.Parameters.AddWithValue("@User", Struser);
                        cd1.ExecuteNonQuery();
                        con.Close();

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
            String txt;
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
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
                    con.Open();
                    SqlCommand cm = new SqlCommand("Select Datetime from Intake_History where Username=@user", con);
                    cm.Parameters.AddWithValue("@user", Struser);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable de = new DataTable();
                    da.Fill(de);
                    con.Close();
                    if (de.Rows.Count > 0)
                    {
                        SqlCommand cmd = new SqlCommand("select Food,Protein,Carbohydrate,[Total Fat] from Intake_History where Datetime=@Date and Username=@user", con);
                        cmd.Parameters.AddWithValue("@Date", DateTime.Parse(dataInput.Text));
                        cmd.Parameters.AddWithValue("@user", Struser);
                        con.Open();
                        SqlDataReader r;
                        r = cmd.ExecuteReader();
                        displayIntakeGridView.DataSource = r;
                        displayIntakeGridView.DataBind();
                        r.Close();
                        con.Close();
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


            catch (FormatException)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Enter Valid Date')", true);
            }
        }
        protected void statisticsBtn_Click(object sender, EventArgs e)
        {

            Response.Redirect("Graph.aspx");



        }
    }
}
