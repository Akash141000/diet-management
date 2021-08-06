using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;

namespace DietManagement.Authentication
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        string StrUsername;
        string UserId;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["Username"] != null && Session["UserId"] != null)
            {
                Label4.Visible = true;
                Label4.Text = Session["Username"].ToString();
                UserId = Session["UserId"].ToString();

    }
            else
            {
                Response.Redirect("/User/LoginPage.aspx");
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
{
    try
    {
        byte[] hs = new byte[50];
        string pass = TextBox2.Text;
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

        StrUsername = Session["Username"].ToString();
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("UPDATE [User] SET Password=@password WHERE UserId=@userId", con);
                    con.Open();
                    cmd.Parameters.AddWithValue("@password", hash_pass);
                    cmd.Parameters.AddWithValue("@userId", UserId);
                    cmd.ExecuteNonQuery();
                }
       
        Label3.Text = "Password Changed";
        Server.Transfer("/User/LoginPage.aspx");
    }
    catch (Exception)
    {
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something went wrong please try again')", true);
    }
}
    }
}