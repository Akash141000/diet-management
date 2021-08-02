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
    public partial class CreateDietPlan : System.Web.UI.Page
    {
        string strUser;
        String abc, Maint, Weig, bcdc, str1;
        int mai, weight, cat;
        double weigh;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["Username"] != null)
            {
                Label7.Text = Session["Username"].ToString();
                strUser = Session["Username"].ToString();


            }
            else
            {
                Response.Redirect("Login.aspx");
            }
            Bmi();


        }


        protected void Bmi()
        {
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
                SqlCommand cmd = new SqlCommand("select BMI,Maintanance,Catagory,Weight,Food_Catagory from demo where Username=@user", con);
                cmd.Parameters.AddWithValue("@user", strUser);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                reader.Read();
                bmiValue.Text = reader["BMI"].ToString();
                maintananceCaloriesValue.Text = reader["Maintanance"].ToString();
                abc = reader["Catagory"].ToString();
                Weig = reader["Weight"].ToString();
                weight = Int16.Parse(Weig);
                bcdc = reader["Food_Catagory"].ToString();
                cat = Convert.ToInt32(bcdc);
                Maint = maintananceCaloriesValue.Text;
                mai = Int16.Parse(Maint);
                int bcd = Int16.Parse(abc);
                if (cat != 1)
                {
                    foodCategoryValue.Text = "veg";
                }
                else
                {
                    foodCategoryValue.Text = "Non-Veg";
                }
            }
            catch (Exception)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something went wrong please try again')", true);
                Response.Redirect("BMI.aspx");
            }
            check();
            Grid1();
            Grid2();
            Grid3();
            Grid4();
        }


        protected void generateDietPlan_Click(object sender, EventArgs e)
        {
            weigh = weight * 2.205;
            double wei = weigh * 1.3;
            int prote = (int)wei;
            int calp = prote * 4;
            int fa = ((mai * 15 % 100) + (mai * 25 % 100)) / 2;
            int fate = fa * 9;
            int calf = fate;
            int calc = mai - (calf + calp);
            int carbs = calc / 4;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
            SqlCommand cm = new SqlCommand("UPDATE demo SET Protein=@Protein,Carbs=@Carbs,Fat=@Fat WHERE Username=@Username", con);
            con.Open();
            cm.Parameters.AddWithValue("@Username", strUser);
            cm.Parameters.AddWithValue("@Protein", prote);
            cm.Parameters.AddWithValue("@Carbs", carbs);
            cm.Parameters.AddWithValue("@Fat", fa);
            cm.ExecuteNonQuery();
            con.Close();
            Response.Redirect("Cdisplay.aspx");
        }
        protected void breakfastGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            String strUser = Session["Username"].ToString();
            String Food = breakfastGridView.SelectedRow.Cells[1].Text;

            String Time = breakfastGridView.SelectedRow.Cells[7].Text;

            String Prot = breakfastGridView.SelectedRow.Cells[3].Text;

            float Protein = float.Parse(Prot);
            String car = breakfastGridView.SelectedRow.Cells[4].Text;

            float carbohydrate = float.Parse(car);
            String Fa = breakfastGridView.SelectedRow.Cells[5].Text;

            float fat = float.Parse(Fa);
            String Calor = breakfastGridView.SelectedRow.Cells[6].Text;
            float calories = float.Parse(Calor);

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Dietplan" + "(Username,Food,Time,Protein,Carbohydrate,Total_Fat,Calories) values(@Username,@Food,@Time,@Protein,@Carbohydrate,@Total_Fat,@Calories)", con);
            cmd.Parameters.AddWithValue("@Username", strUser);
            cmd.Parameters.AddWithValue("@Food", Food);
            cmd.Parameters.AddWithValue("@Time", Time);
            cmd.Parameters.AddWithValue("@Protein", Protein);
            cmd.Parameters.AddWithValue("@Carbohydrate", carbohydrate);
            cmd.Parameters.AddWithValue("@Total_Fat", fat);
            cmd.Parameters.AddWithValue("@Calories", calories);
            cmd.ExecuteNonQuery();


            con.Close();




        }
        protected void lunchGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            strUser = Session["Username"].ToString();
            String Food = lunchGridView.SelectedRow.Cells[1].Text;
            String Time = lunchGridView.SelectedRow.Cells[7].Text;
            String Prot = lunchGridView.SelectedRow.Cells[3].Text;
            float Protein = float.Parse(Prot);
            String car = lunchGridView.SelectedRow.Cells[4].Text;
            float carbohydrate = float.Parse(car);
            String Fa = lunchGridView.SelectedRow.Cells[5].Text;
            float fat = float.Parse(Fa);
            String Calor = lunchGridView.SelectedRow.Cells[6].Text; ;
            float calories = float.Parse(Calor);

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Dietplan" + "(Username,Food,Time,Protein,Carbohydrate,Total_Fat,Calories) values(@Username,@Food,@Time,@Protein,@Carbohydrate,@Total_Fat,@Calories)", con);
            cmd.Parameters.AddWithValue("@Username", strUser);
            cmd.Parameters.AddWithValue("@Food", Food);
            cmd.Parameters.AddWithValue("@Time", Time);
            cmd.Parameters.AddWithValue("@Protein", Protein);
            cmd.Parameters.AddWithValue("@Carbohydrate", carbohydrate);
            cmd.Parameters.AddWithValue("@Total_Fat", fat);
            cmd.Parameters.AddWithValue("@Calories", calories);
            cmd.ExecuteNonQuery();

            con.Close();

        }
        protected void snackGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            strUser = Session["Username"].ToString();
            String Food = snackGridView.SelectedRow.Cells[1].Text;
            String Time = snackGridView.SelectedRow.Cells[7].Text;
            String Prot = snackGridView.SelectedRow.Cells[3].Text;
            float Protein = float.Parse(Prot);
            String car = snackGridView.SelectedRow.Cells[4].Text;
            float carbohydrate = float.Parse(car);
            String Fa = snackGridView.SelectedRow.Cells[5].Text;
            float fat = float.Parse(Fa);
            String Calor = snackGridView.SelectedRow.Cells[6].Text; ;
            float calories = float.Parse(Calor);

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Dietplan" + "(Username,Food,Time,Protein,Carbohydrate,Total_Fat,Calories) values(@Username,@Food,@Time,@Protein,@Carbohydrate,@Total_Fat,@Calories)", con);
            cmd.Parameters.AddWithValue("@Username", strUser);
            cmd.Parameters.AddWithValue("@Food", Food);
            cmd.Parameters.AddWithValue("@Time", Time);
            cmd.Parameters.AddWithValue("@Protein", Protein);
            cmd.Parameters.AddWithValue("@Carbohydrate", carbohydrate);
            cmd.Parameters.AddWithValue("@Total_Fat", fat);
            cmd.Parameters.AddWithValue("@Calories", calories);
            cmd.ExecuteNonQuery();


            con.Close();


        }
        protected void dinnerGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            strUser = Session["Username"].ToString();
            String Food = dinnerGridView.SelectedRow.Cells[1].Text;
            String Time = dinnerGridView.SelectedRow.Cells[7].Text;
            String Prot = dinnerGridView.SelectedRow.Cells[3].Text;
            float Protein = float.Parse(Prot);
            String car = dinnerGridView.SelectedRow.Cells[4].Text;
            float carbohydrate = float.Parse(car);
            String Fa = dinnerGridView.SelectedRow.Cells[5].Text;
            float fat = float.Parse(Fa);
            String Calor = dinnerGridView.SelectedRow.Cells[6].Text; ;
            float calories = float.Parse(Calor);

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Dietplan" + "(Username,Food,Time,Protein,Carbohydrate,Total_Fat,Calories) values(@Username,@Food,@Time,@Protein,@Carbohydrate,@Total_Fat,@Calories)", con);
            cmd.Parameters.AddWithValue("@Username", strUser);
            cmd.Parameters.AddWithValue("@Food", Food);
            cmd.Parameters.AddWithValue("@Time", Time);
            cmd.Parameters.AddWithValue("@Protein", Protein);
            cmd.Parameters.AddWithValue("@Carbohydrate", carbohydrate);
            cmd.Parameters.AddWithValue("@Total_Fat", fat);
            cmd.Parameters.AddWithValue("@Calories", calories);
            cmd.ExecuteNonQuery();


            con.Close();
        }
        protected void Grid1()
        {
            String temp1 = "breakfast";
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(str1, con);

            cmd.Parameters.AddWithValue("@typ", temp1);
            SqlDataReader r;
            r = cmd.ExecuteReader();
            breakfastGridView.DataSource = r;
            breakfastGridView.DataBind();
            r.Close();
            con.Close();



        }
        protected void Grid2()
        {
            String temp2 = "lunch";
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
            con.Open();
            SqlCommand cmd1 = new SqlCommand(str1, con);

            cmd1.Parameters.AddWithValue("@typ", temp2);
            SqlDataReader s;
            s = cmd1.ExecuteReader();
            lunchGridView.DataSource = s;
            lunchGridView.DataBind();
            s.Close();
            con.Close();
        }
        protected void Grid3()
        {
            String temp3 = "snack";
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
            con.Open();
            SqlCommand cmd2 = new SqlCommand(str1, con);

            cmd2.Parameters.AddWithValue("@typ", temp3);
            SqlDataReader t;
            t = cmd2.ExecuteReader();
            snackGridView.DataSource = t;
            snackGridView.DataBind();
            t.Close();
            con.Close();
        }
        protected void Grid4()
        {
            String temp4 = "dinner";
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
            con.Open();
            SqlCommand cmd3 = new SqlCommand(str1, con);

            cmd3.Parameters.AddWithValue("@typ", temp4);
            SqlDataReader u;
            u = cmd3.ExecuteReader();
            dinnerGridView.DataSource = u;
            dinnerGridView.DataBind();
            u.Close();
            con.Close();
        }
        protected void check()
        {
            String gstr1, dstr1;


            gstr1 = "select Food,Serving_Size,Protein,Carbs,Fat,Calories,Time from Dplan where Time=@typ and vn='Veg'";

            dstr1 = "select Food,Serving_Size,Protein,Carbs,Fat,Calories,Time from Dplan where Time=@typ";



            if (cat != 1)
            {
                str1 = gstr1;

            }
            else
            {
                str1 = dstr1;

            }


        }

    }

}