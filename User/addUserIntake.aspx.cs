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
    public partial class addUserIntake : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] != null)
            {
                userLoggedLabel.Text = Session["Username"].ToString();
                String StrUsername = Session["Username"].ToString();
                Binddata();
            }
            else
            {
                Response.Redirect("/Authentication/LoginPage.aspx");
            }
            addNewFoodItemBtn.Visible = false;
            carbohydrateLbl.Visible = false;
            fiberLbl.Visible = false;
            totalFatLbl.Visible = false;
            saturatedFatLbl.Visible = false;
            mononsaturatedFatLbl.Visible = false;
            polyunsaturatedLbl.Visible = false;
            proteinLbl.Visible = false;
            Label19.Visible = false;
            Label20.Visible = false;
            Label21.Visible = false;
            Label22.Visible = false;
            Label23.Visible = false;
            Label24.Visible = false;
            Label25.Visible = false;
            sodiumLbl.Visible = false;
            potassiumLbl.Visible = false;
            cholesterolLbl.Visible = false;
            vitaminALabel.Visible = false;
            vitaminCLbl.Visible = false;
            calciumLbl.Visible = false;
            ironLbl.Visible = false;
            Label34.Visible = false;
            Label35.Visible = false;
            Label36.Visible = false;
            Label37.Visible = false;
            Label38.Visible = false;
            Label39.Visible = false;
            Label40.Visible = false;
            Label41.Visible = false;
            Label42.Visible = false;
            Label43.Visible = false;
            Label44.Visible = false;
            Label45.Visible = false;
            Label46.Visible = false;
            Label47.Visible = false;
            Label49.Visible = false;
            Label50.Visible = false;
            Label51.Visible = false;
            Label52.Visible = false;
            Label53.Visible = false;
            Label54.Visible = false;
            Label55.Visible = false;
            nutritionContentLbl.Visible = false;
            Label58.Visible = false;
            Label59.Visible = false;
            userAddFoodBtn.Visible = false;
            userAddFoodResultLbl.Visible = false;

        }


        protected void SearchFoodBtn_Click(object sender, EventArgs e)
        {

            if (TextBox1.Text == "")
            {
                Binddata();
            }
            else
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("Select Food,[Serving Size],Protein,Carbohydrate,Total_Fat,[Food type] from Nutrition where Food like @fd + '%'", con);
                cmd.Parameters.AddWithValue("@fd", TextBox1.Text);
                SqlDataAdapter sqa = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sqa.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    addNewFoodItemBtn.Visible = false;
                    gridView.DataSource = dt;
                    gridView.DataBind();


                }

                else
                {

                    addNewFoodItemBtn.Visible = true;

                    userAddFoodResultLbl.Visible = false;
                }
                con.Close();
            }
        }
        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {


            String Food = gridView.SelectedRow.Cells[1].Text;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT Carbohydrate,Fiber,Total_Fat,[Saturate Fat (g)],[Monosat Fat (g)],[Polyunsat Fat (g)],Protein,[Sodium (mg)],[Potassium (mg)],[Cholesterol (mg)],[Vit A (RE)],[Vit C (mg)],[Calcium (mg)],[Iron (mg)]  FROM [Nutrition] WHERE Food=@Searched", con);

            cmd.Parameters.AddWithValue("@Searched", Food);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {

                Label19.Text = reader["Carbohydrate"].ToString();
                Label20.Text = reader["Fiber"].ToString();
                Label21.Text = reader["Total_Fat"].ToString();
                Label22.Text = reader["Saturate Fat (g)"].ToString();
                Label23.Text = reader["Monosat Fat (g)"].ToString();
                Label24.Text = reader["Polyunsat Fat (g)"].ToString();
                Label25.Text = reader["Protein"].ToString();
                Label34.Text = reader["Sodium (mg)"].ToString();
                Label35.Text = reader["Potassium (mg)"].ToString();
                Label36.Text = reader["Cholesterol (mg)"].ToString();
                Label37.Text = reader["Vit A (RE)"].ToString();
                Label38.Text = reader["Vit C (mg)"].ToString();
                Label39.Text = reader["Calcium (mg)"].ToString();
                Label40.Text = reader["Iron (mg)"].ToString();

                carbohydrateLbl.Visible = true;
                fiberLbl.Visible = true;
                totalFatLbl.Visible = true;
                saturatedFatLbl.Visible = true;
                mononsaturatedFatLbl.Visible = true;
                polyunsaturatedLbl.Visible = true;
                proteinLbl.Visible = true;
                Label19.Visible = true;
                Label20.Visible = true;
                Label21.Visible = true;
                Label22.Visible = true;
                Label23.Visible = true;
                Label24.Visible = true;
                Label25.Visible = true;
                sodiumLbl.Visible = true;
                potassiumLbl.Visible = true;
                cholesterolLbl.Visible = true;
                vitaminALabel.Visible = true;
                vitaminCLbl.Visible = true;
                calciumLbl.Visible = true;
                ironLbl.Visible = true;
                Label34.Visible = true;
                Label35.Visible = true;
                Label36.Visible = true;
                Label37.Visible = true;
                Label38.Visible = true;
                Label39.Visible = true;
                Label40.Visible = true;
                Label41.Visible = true;
                Label42.Visible = true;
                Label43.Visible = true;
                Label44.Visible = true;
                Label45.Visible = true;
                Label46.Visible = true;
                Label47.Visible = true;
                Label49.Visible = true;
                Label50.Visible = true;
                Label51.Visible = true;
                Label52.Visible = true;
                Label53.Visible = true;
                Label54.Visible = true;
                Label55.Visible = true;
                nutritionContentLbl.Visible = true;
                Label58.Visible = true;
                Label59.Visible = true;
                userAddFoodBtn.Visible = true;
                Label59.Text = Food;
                userAddFoodResultLbl.Visible = false;

            }
            reader.Close();
            con.Close();

        }
        protected void userAddFoodBtn_Click(object sender, EventArgs e)
        {
            DateTime d2 = DateTime.Today;
            String Str = Session["Username"].ToString();
            String Fo = Label59.Text;
            float pro = float.Parse(Label25.Text);
            float carbs = float.Parse(Label19.Text);
            float fat = float.Parse(Label21.Text);
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
            cn.Open();
            SqlCommand cm = new SqlCommand("INSERT INTO [Intake_History] (Username,Food,Datetime,Protein,Carbohydrate,[Total Fat]) values(@Username,@Food,@Datetime,@Protein,@Carbohydrate,@Fat)", cn);

            cm.Parameters.AddWithValue("@Username", Str);
            cm.Parameters.AddWithValue("@Datetime", DateTime.Today);
            cm.Parameters.AddWithValue("@Food", Fo);
            cm.Parameters.AddWithValue("@Protein", pro);
            cm.Parameters.AddWithValue("@Carbohydrate", carbs);
            cm.Parameters.AddWithValue("@Fat", fat);
            cm.ExecuteNonQuery();


            cn.Close();
            userAddFoodResultLbl.Visible = true;

        }

        protected void Binddata()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("Select Food,[Serving Size],Protein,Carbohydrate,Total_Fat,[Food type] from Nutrition ", con);
            SqlDataAdapter sqa = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sqa.Fill(dt);
            gridView.DataSource = dt;
            gridView.DataBind();
            con.Close();

        }






        protected void gridView_Selected(object sender, GridViewPageEventArgs e)
        {
            gridView.PageIndex = e.NewPageIndex;
            DataBind();

        }

    }
}

    