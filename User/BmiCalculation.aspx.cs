using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Text.RegularExpressions;


namespace DietManagement.User
{
    public partial class BmiCalculation : System.Web.UI.Page
    {

        int weight, age, lbs, gender, ind, demo2;
        float maintananceCalories;
        double bmi, height, heightInFeets, demo3;
        String StrUsername, gen, lb, demo1;
        Boolean CH;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["Username"] != null)
            {
                loggedUser.Text = Session["Username"].ToString();
                StrUsername = Session["Username"].ToString();
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
            CH = true;


            //datadel();
        }






        protected void drop()
        {
            int ij;
            ij = weightInputTypeSelected.SelectedIndex;
            try
            {
                if (ij == 1)
                {

                    demo1 = weightInput.Text;
                    demo2 = Convert.ToInt32(demo1);
                    demo3 = Double.Parse((demo2 / 2.205).ToString());
                    lbs = (int)demo3;
                    weight = lbs;
                }
                else if (ij == 0)
                {


                    demo1 = weightInput.Text;
                    demo2 = Convert.ToInt32(demo1);
                    lbs = demo2;
                    weight = lbs;
                }
            }
            catch (FormatException)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessagee", "alert('Something went wrong please try ageain')", true);
            }
        }
        protected void drop1()
        {
            int ij, inch, feet;
            ij = heightInputTypeSelected.SelectedIndex;
            try
            {
                if (ij == 2)
                {
                    heightInFeets = Math.Round(Convert.ToDouble(heightInput.Text), 2);
                    height = heightInFeets * 0.01;
                }
                else if (ij == 1)
                {
                    height = Math.Round(Convert.ToDouble(heightInput.Text), 2);
                }

                else if (ij == 0)
                {

                    feet = Convert.ToInt32(heightInput.Text);
                    inch = Convert.ToInt32(heightInputInInches.Text);
                    inch += feet * 12;
                    height = Math.Round((inch * 2.54), 2);
                    height = Math.Round((height / 100), 2);
                }
            }
            catch (FormatException)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessagee", "alert('Something went wrong please try ageain')", true);
            }
        }
        public void Connection()
        {
            //updating or inserting BMI
            try
            {
                SqlConnection co = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
                SqlCommand cmd = new SqlCommand("select * from demo where Username =@Usrname", co);
                cmd.Parameters.AddWithValue("@Usrname", StrUsername);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    SqlCommand cd = new SqlCommand("UPDATE demo SET bmiI=@bmii,agee=@age,Catageory=@ca,Food_Catageory=@cat,maintananceCalories=@maintananceCalories WHERE Username=@usrname", co);
                    co.Open();
                    cd.Parameters.AddWithValue("usrname", StrUsername);
                    cd.Parameters.AddWithValue("@bmii", bmi);
                    cd.Parameters.AddWithValue("@maintananceCalories", maintananceCalories);
                    cd.Parameters.AddWithValue("@cat", foodCategorySelected.SelectedIndex);
                    cd.Parameters.AddWithValue("@age", age);
                    cd.Parameters.AddWithValue("@ca", categoryTypeSelected.SelectedIndex);
                    cd.ExecuteNonQuery();
                    co.Close();
                    errorSavingBmi.Text = "Saved Successfully";
                    weightInput.Text = "";
                    heightInput.Text = "";
                    ageInput.Text = "";
                    heightInputInInches.Text = "";


                }

                else
                {
                    SqlCommand cm = new SqlCommand("insert into demo" + "(Username,bmiI,agee,Catageory,Food_Catageory,maintananceCalories,weightt,heightt) values(@Usrname,@bmii,@ageE,@Catageory,@Food_Catageory,@maintananceCalories,@weightt,@heightt)", co);
                    cm.Parameters.AddWithValue("@Usrname", StrUsername);
                    cm.Parameters.AddWithValue("@bmii", bmi);
                    cm.Parameters.AddWithValue("@ageE", age);
                    cm.Parameters.AddWithValue("@Catageory", categoryTypeSelected.SelectedIndex);
                    cm.Parameters.AddWithValue("@Food_Catageory", foodCategorySelected.SelectedIndex);
                    cm.Parameters.AddWithValue("@maintananceCalories", maintananceCalories);
                    cm.Parameters.AddWithValue("@weightt", weight);
                    cm.Parameters.AddWithValue("@heightt", height);
                    DataSet bmiidetails = new DataSet();
                    co.Open();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cm);
                    dataAdapter.Fill(bmiidetails);

                    co.Close();
                    errorSavingBmi.Text = "Saved Successfully";
                    weightInput.Text = "";
                    heightInput.Text = "";
                    ageInput.Text = "";
                    heightInputInInches.Text = "";

                }
            }
            catch (Exception)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessagee", "alert('Something went wrong please try ageain')", true);
            }

            finally
            {
                Session["maintananceCalories"] = maintananceCalories.ToString();
            }

        }
        public int calculateBMI()
        {
            //calculating BMI
            if (ind == 0)
            {
                maintananceCalories = (lbs * 14) + (lbs * 16);
                maintananceCalories = maintananceCalories / 2;

            }
            else if (ind == 1)
            {
                maintananceCalories = (lbs * 14) + (lbs * 16);
                maintananceCalories = (maintananceCalories / 2);
                maintananceCalories = maintananceCalories - 500;
            }
            else
            {
                maintananceCalories = (lbs * 14) + (lbs * 16);
                maintananceCalories = (maintananceCalories / 2);
                maintananceCalories = maintananceCalories + 500;
            }
            return (int)maintananceCalories;
        }
        protected void fatt()
        {
            //check gender and convert weight to lbs


            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
            con.Open();
            SqlCommand cmd3 = new SqlCommand("select Gender from Reg where Username=@Username", con); //find gender
            cmd3.Parameters.AddWithValue("Username", StrUsername);
            SqlDataReader reader = cmd3.ExecuteReader();
            while (reader.Read())
            {
                gen = reader["Gender"].ToString();
                gender = Convert.ToInt32(gen);
            }
            reader.Close();

            if (gender == 0)
            {  //find ideal weight according to height
                SqlCommand cmd1 = new SqlCommand("select Men from Hweightt where heightt=@heightt", con);
                cmd1.Parameters.AddWithValue("@heightt", height);
                SqlDataReader reade = cmd1.ExecuteReader();
                while (reade.Read())
                {
                    lb = reade["Men"].ToString();
                }
                reade.Close();
                lbs = Convert.ToInt32(lb);
                maintananceCalories = calculateBMI();
                Connection();


            }
            else
            {
                SqlCommand cmd1 = new SqlCommand("select Women from Hweightt where heightt=@heightt", con);
                cmd1.Parameters.AddWithValue("@heightt", height);
                SqlDataReader reade = cmd1.ExecuteReader();
                while (reade.Read())
                {
                    lb = reade["Women"].ToString();
                        lbs = Int32.Parse(lb);
                }
                reade.Close();
                maintananceCalories = calculateBMI();
                Connection();
            }
            con.Close();
        } 




        protected void SaveBmi_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                   
                    if (CH == true) //check if logged
                    {
                        drop();
                        drop1();
                        age = Convert.ToInt32(ageInput.Text);
                        ind = categoryTypeSelected.SelectedIndex;
                        bmi = weight / (height * height);
                        bmiOutput.Text = bmi.ToString();
                        if (bmi <= 18.4)
                        {
                            bmiCategory.Text = "bmii shows that you are Underweightt";
                            fatt();
                        }
                        else if (bmi >= 25.0)
                        {
                            bmiCategory.Text = "bmii shows that you are Overweightt";
                            fatt();
                        }

                        if (bmi > 18.4 && bmi < 25.0)
                        {
                            demo3 = weight * 2.205;
                            lbs = (int)demo3;
                            bmiCategory.Text = "bmii normal";
                            maintananceCalories = calculateBMI();
                            Connection();

                        }
                    }
                }
            }
            catch (Exception)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessagee", "alert('Something went wrong please try ageain')", true);
            }
        }


     


       




        //protected void datadel()
        //{
        //    try
        //    {
        //        DateTime dt;
        //        dt = DateTime.Today.AddDays(-6);
        //        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
        //        con.Open();
        //        SqlCommand cmd = new SqlCommand("Delete From Intake_History where Username=@User and Datetime<@date", con);
        //        SqlCommand cmd1 = new SqlCommand("Delete From Intake where Username=@User and Datetime<@date", con);
        //        cmd.Parameters.AddWithValue("@User", StrUsername);
        //        cmd.Parameters.AddWithValue("@date", dt);
        //        cmd1.Parameters.AddWithValue("@User", StrUsername);
        //        cmd1.Parameters.AddWithValue("@date", dt);
        //        cmd.ExecuteNonQuery();
        //        cmd1.ExecuteNonQuery();
        //        con.Close();
        //    }
        //    catch
        //    {
        //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessagee", "alert('Something went wrong please try ageain')", true);
        //    }
        //}

        

       

    }
}