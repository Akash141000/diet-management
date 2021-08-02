using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Security;
using System.Security.Cryptography;
using System.Text;


namespace DietManagement
{
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["Username"] = null;
            Session["Admin"] = null;
        }


        protected void loginSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (usernameInput.Text == "Admin14" && passwordInput.Text == "January@2000")
                {
                    Session["Admin"] = "Admin";
                    Response.Redirect("AdminBmi.aspx");
                }
                else
                {
                    byte[] hs = new byte[50];
                    string pass = passwordInput.Text;
                    MD5 md5 = MD5.Create();
                    byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(pass);
                    byte[] hash = md5.ComputeHash(inputBytes);
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < hash.Length; i++)
                    {
                        hs[i] = hash[i];
                        sb.Append(hs[i].ToString("x2"));
                    }
                    var hash_pass = sb.ToString();

                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);

                    con.Open();
                    SqlCommand cmd = new SqlCommand("select * from Reg where Username =@Username and Password=@Password", con);
                    cmd.Parameters.AddWithValue("@Username", usernameInput.Text);
                    cmd.Parameters.AddWithValue("@Password", hash_pass);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        Session["Username"] = usernameInput.Text.ToString();
                        Response.Redirect("~/BMI.aspx");
                        con.Close();

                    }

                    else
                    {

                        loginResult.Visible = true;
                        loginResult.Text = "Wrong Details";
                        con.Close();
                    }
                }
            }
            catch (Exception)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something went wrong please try again')", true);
            }
        }

        protected void changePassword_Click(object sender, EventArgs e)
        {

            try
            {
                byte[] hs = new byte[50];
                string pass = passwordInput.Text;
                MD5 md5 = MD5.Create();
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(pass);
                byte[] hash = md5.ComputeHash(inputBytes);
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hash.Length; i++)
                {
                    hs[i] = hash[i];
                    sb.Append(hs[i].ToString("x2"));
                }
                var hash_pass = sb.ToString();

                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from Reg where UserName =@Username and Password=@Password", con);
                cmd.Parameters.AddWithValue("@Username", usernameInput.Text);
                cmd.Parameters.AddWithValue("@Password", hash_pass);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Session["Username"] = usernameInput.Text.ToString();
                    Response.Redirect("~/ChangePassword.aspx");
                    con.Close();
                }

                else
                {


                    loginResult.Visible = true;
                    loginResult.Text = "Wrong Details";
                    con.Close();
                }
            }
            catch (Exception)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something went wrong please try again')", true);
            }

        }


    }
}