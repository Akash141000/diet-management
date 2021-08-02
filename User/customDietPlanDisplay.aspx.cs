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

        String strUser, prote, carbses, fates, caloric, protein1, carbs1, fats1, mai1, ap, bc, cf, dm;
        int Totalprot = 0, Totalcarb = 0, Totalfat = 0, Totalcal = 0, p, c, f, m, bt = 0, chk = 0;
        float temp1, temp2, temp3, temp4;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] != null)
            {
                userLoggedLbl.Text = Session["Username"].ToString();
                strUser = Session["Username"].ToString();
            }
            else
            {
                Response.Redirect("Login.aspx");
            }

            try
            {


                fuchk();
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("Select Maintanance,Protein,Carbs,Fat  from demo Where Username=@Username", con);
                cmd.Parameters.AddWithValue("@Username", strUser);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    mai1 = reader["Maintanance"].ToString();
                    protein1 = reader["Protein"].ToString();
                    carbs1 = reader["Carbs"].ToString();
                    fats1 = reader["Fat"].ToString();
                }
                reader.Close();

                m = Int16.Parse(mai1);
                p = Int16.Parse(protein1);
                c = Int16.Parse(carbs1);
                f = Int16.Parse(fats1);

                Grid1();
                Grid1();
                Grid2();
                Grid3();
                Grid4();
            }
            catch (Exception)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something went wrong please try again')", true);
            }

        }
        public void pi()
        {
            if (p / 2 > Totalprot)
            {
                ap = "low";
            }
            else if (p + p / 2 < Totalprot)
            {
                ap = "high";
            }
            else if (p / 2 < Totalprot && Totalprot < p + p / 2)
            {
                ap = "perfect";
            }

        }
        public void ci()
        {
            if (c / 2 > Totalcarb)
            {
                bc = "low";
            }
            else if (c + c / 2 < Totalcarb)
            {
                bc = "high";
            }
            else if (c / 2 < Totalcarb && Totalcarb < c + c / 2)
            {
                bc = "perfect";
            }
        }
        public void fi()
        {
            if (f / 2 > Totalfat)
            {
                cf = "low";
            }
            else if (f + f / 2 < Totalfat)
            {
                cf = "high";
            }
            else if (f / 2 < Totalfat && Totalfat < f + f / 2)
            {
                cf = "perfect";
            }
        }
        public void mai()
        {
            if (m - 50 < Totalcal && Totalcal < m + 50)
            {
                dm = "Perfect";
            }
            else if (m - 50 > Totalcal)
            {
                dm = "Low";
            }
            else if (m + 50 < Totalcal)
            {
                dm = "High";
            }
        }

        protected void fuchk()
        {
            try
            {

                chk = chk + 1;
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString); ;
                SqlCommand cmd1 = new SqlCommand("select Protein,Carbohydrate,Total_Fat,Calories from Dietplan where Username=@User", con);
                cmd1.Parameters.AddWithValue("@User", strUser);
                con.Open();
                SqlDataReader r = cmd1.ExecuteReader();
                while (r.Read())
                {
                    prote = r["Protein"].ToString();
                    temp1 = float.Parse(prote);
                    Totalprot = Totalprot + (int)temp1;
                    carbses = r["Carbohydrate"].ToString();
                    temp2 = float.Parse(carbses);
                    Totalcarb = Totalcarb + (int)temp2;
                    fates = r["Total_Fat"].ToString();
                    temp3 = float.Parse(fates);
                    Totalfat = Totalfat + (int)temp3;
                    caloric = r["Calories"].ToString();
                    temp4 = float.Parse(caloric);
                    Totalcal = Totalcal + (int)temp4;
                }

                if (Totalcal == 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please select food to create a Dietplan')", true);
                    Response.Redirect("CreatePlan.aspx");
                }
                else
                {
                    proteinAmountLbl.Text = Totalprot.ToString();
                    carbohydrateAmountLbl.Text = Totalcarb.ToString();
                    fatsAmountLbl.Text = Totalfat.ToString();
                    totalCaloriesLbl.Text = Totalcal.ToString();
                    pi();
                    ci();
                    fi();
                    mai();
                    displayMaintananceCaloriesLbl.Text = "Maintanance calories" + " " + "is" + " " + dm + "<br>" + "protein" + " " + "is" + " " + ap + "<br>" + "Carbohydrate" + " " + "is" + " " + bc + "<br>" + "Total Fat" + " " + "is" + " " + cf;
                    Totalprot = 0;
                    Totalcarb = 0;
                    Totalfat = 0;
                    Totalcal = 0;
                }
            }
            catch
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something went wrong please try again')", true);
            }
        }

        protected void checkBtn_Click(object sender, EventArgs e)
        {
            fuchk();


        }
        protected void addMoreFoodBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateDPlan.aspx");
        }
        protected void removeFoodBtn_Click(object sender, EventArgs e)
        {
            try
            {
                bt = bt + 1;
                if (bt > 1)
                {
                    removeFoodBtn.Visible = false;
                }
                else
                {
                    removeFoodBtn.Visible = true;
                }
                if (chk > 1)
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
                breakfastGridView.Columns.Add(cField);
                lunchGridView.Columns.Add(cField);
                snackGridView.Columns.Add(cField);
                dinnerGridView.Columns.Add(cField);
                Grid1();
                Grid2();
                Grid3();
                Grid4();
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

                int temp = 0;

                temp = Convert.ToInt32(this.breakfastGridView.DataKeys[e.RowIndex].Value);

                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
                Response.Write(temp);
                con.Open();
                SqlCommand cm = new SqlCommand("Delete From Dietplan where id=@id and Username=@User", con);
                cm.Parameters.AddWithValue("@id", temp);
                cm.Parameters.AddWithValue("@User", strUser);
                cm.ExecuteNonQuery();
                con.Close();
                Grid1();
            }
            catch (Exception)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something went wrong please try again')", true);
            }
        }
        protected void lunchGridView_OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int temp = 0;

            temp = Convert.ToInt32(lunchGridView.DataKeys[e.RowIndex].Value);

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
            Response.Write(temp);
            con.Open();
            SqlCommand cm = new SqlCommand("Delete From Dietplan where id=@id and Username=@User", con);
            cm.Parameters.AddWithValue("@id", temp);
            cm.Parameters.AddWithValue("@User", strUser);
            cm.ExecuteNonQuery();
            con.Close();
            Grid2();
        }
        protected void snackGridView_OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int temp = 0;

            temp = Convert.ToInt32(this.snackGridView.DataKeys[e.RowIndex].Value);

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
            Response.Write(temp);
            con.Open();
            SqlCommand cm = new SqlCommand("Delete From Dietplan where id=@id and Username=@User", con);
            cm.Parameters.AddWithValue("@id", temp);
            cm.Parameters.AddWithValue("@User", strUser);
            cm.ExecuteNonQuery();
            con.Close();
            Grid3();
        }
        protected void dinnerGridView_OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int temp = 0;

            temp = Convert.ToInt32(this.dinnerGridView.DataKeys[e.RowIndex].Value);

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
            Response.Write(temp);
            con.Open();
            SqlCommand cm = new SqlCommand("Delete From Dietplan where id=@id and Username=@User", con);
            cm.Parameters.AddWithValue("@id", temp);
            cm.Parameters.AddWithValue("@User", strUser);
            cm.ExecuteNonQuery();
            con.Close();
            Grid4();
        }
        protected void OnRowDataBound(object sender, GridViewCommandEventArgs e)
        {

        }
        protected void Grid1()
        {
            String temp1 = "breakfast";
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("select id,Food,Protein,Carbohydrate,Total_Fat,Calories from Dietplan where Time=@typ and Username=@Username", con);
            cmd.Parameters.AddWithValue("@typ", temp1);
            cmd.Parameters.AddWithValue("@Username", strUser);
            SqlDataReader r;
            r = cmd.ExecuteReader();
            breakfastGridView.DataSource = r;
            breakfastGridView.DataBind();
            breakfastGridView.Columns[0].Visible = false;
            r.Close();
            con.Close();



        }
        protected void Grid2()
        {
            String temp2 = "lunch";
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
            con.Open();
            SqlCommand cmd1 = new SqlCommand("select id,Food,Protein,Carbohydrate,Total_Fat,Calories from Dietplan where Time=@typ and Username=@Username", con);
            cmd1.Parameters.AddWithValue("@typ", temp2);
            cmd1.Parameters.AddWithValue("@Username", strUser);
            SqlDataReader s;
            s = cmd1.ExecuteReader();
            lunchGridView.DataSource = s;
            lunchGridView.DataBind();
            lunchGridView.Columns[0].Visible = false;
            s.Close();
            con.Close();
        }
        protected void Grid3()
        {
            String temp3 = "snack";
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
            con.Open();
            SqlCommand cmd2 = new SqlCommand("select id,Food,Protein,Carbohydrate,Total_Fat,Calories from Dietplan where Time=@typ and Username=@Username", con);
            cmd2.Parameters.AddWithValue("@typ", temp3);
            cmd2.Parameters.AddWithValue("@Username", strUser);
            SqlDataReader t;
            t = cmd2.ExecuteReader();
            snackGridView.DataSource = t;
            snackGridView.DataBind();
            snackGridView.Columns[0].Visible = false;
            t.Close();
            con.Close();
        }
        protected void Grid4()
        {
            String temp4 = "dinner";
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
            con.Open();
            SqlCommand cmd3 = new SqlCommand("select id,Food,Protein,Carbohydrate,Total_Fat,Calories from Dietplan where Time=@typ and Username=@Username", con);
            cmd3.Parameters.AddWithValue("@typ", temp4);
            cmd3.Parameters.AddWithValue("@Username", strUser);
            SqlDataReader u;
            u = cmd3.ExecuteReader();
            dinnerGridView.DataSource = u;
            dinnerGridView.DataBind();
            dinnerGridView.Columns[0].Visible = false;
            u.Close();
            con.Close();
        }


    }
}