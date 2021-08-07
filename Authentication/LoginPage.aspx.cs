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
using System.Diagnostics;


namespace DietManagement
{
    public partial class LoginPage : System.Web.UI.Page
    {
        readonly string _machineKey = "cookieMachineKey";
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie userInfo = Request.Cookies["userInfo"];
            if (userInfo != null)
            {
               
                var userId = Convert.FromBase64String(Request.Cookies["userInfo"].Value);
                var decryptedUserId = MachineKey.Unprotect(userId, _machineKey);                
               
                getUser(null, decryptedUserId);
                Response.Redirect("/User/BmiCalculation.aspx");

                return;
            }
            Session.Clear();
            return;
        }

        protected string hashPassword()
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
            return hash_pass;

        }

        protected Boolean getUser(string hashedPassword = null, byte[] protectedUserId = null)
        {
            if (protectedUserId == null)
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString))
                {

                    connection.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM [User] WHERE Username=@Username AND Password=@Password", connection);
                    cmd.Parameters.AddWithValue("@Username", usernameInput.Text);
                    cmd.Parameters.AddWithValue("@Password", hashedPassword);
                    var logged = cmd.ExecuteScalar();

                    if (logged == null)
                    {
                        loginResult.Visible = true;
                        loginResult.Text = "Wrong Details";
                        return false;

                    }

                    string username = usernameInput.Text.ToString();
                    string userId = logged.ToString();
                    Session["Username"] = username;
                    Session["UserId"] = userId;

                    var cookieUserId = Encoding.UTF8.GetBytes(userId);

                    var encryptedUserId = Convert.ToBase64String(MachineKey.Protect(cookieUserId, _machineKey));

                    HttpCookie userInfo = new HttpCookie("userInfo", encryptedUserId);
                    //userInfo["UserId"] = ;
                    userInfo.Expires.Add(new TimeSpan(1, 0, 0));
                    Response.Cookies.Add(userInfo);
                    Response.Redirect("../User/BmiCalculation.aspx");
                    return true;
                }

            }
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString))
            {
                string usernameFound = null;
                connection.Open();
                var unprotectedUserId = Encoding.UTF8.GetString(protectedUserId);
                SqlCommand cmd = new SqlCommand("SELECT Username FROM [User] WHERE UserId=@userId", connection);
                cmd.Parameters.AddWithValue("@userId", unprotectedUserId);
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while(reader.Read()){
                    usernameFound = reader["Username"].ToString();
                }
                if (usernameFound != null)
                {
                    Session["UserId"] = unprotectedUserId;
                    Session["Username"] = usernameFound;
                    return true;
                }
                return false;

            }
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
                    string hash_pass = hashPassword();
                    getUser(hash_pass);
                }
            }
            catch (Exception)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something went wrong please try again.')", true);
            }
        }

        protected void changePassword_Click(object sender, EventArgs e)
        {

            try
            {
                string hash_pass = hashPassword();

                Boolean found = getUser(hash_pass);
                if (found)
                {
                    Response.Redirect("/Authentication/ChangePassword.aspx");
                    return;
                }

               
            }
            catch (Exception)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something went wrong please try again.')", true);
            }

        }


    }
}