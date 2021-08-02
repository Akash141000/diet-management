using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Configuration;
using System.Diagnostics;

namespace DietManagement
{
    public partial class RegisterPage : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {

        }
       
        //SqlCommand cmd = new SqlCommand();
        //SqlConnection connection = new SqlConnection();
        //protected void checkIfAdmin()
        //{
        //    if (usernameInput.Text == "Admin14")
        //    {
        //        throw new Exception();
        //    }
        //}

        protected void registrationSubmit_Click(object sender, EventArgs e)
        {
            byte[] hs = new byte[50];
            string oldPassword = passwordInput.Text;
            MD5 md5 = MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(oldPassword);
            byte[] hash = md5.ComputeHash(inputBytes);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                hs[i] = hash[i];
                sb.Append(hs[i].ToString("x2"));
            }
            var hashedPassword = sb.ToString();


            //checkIfAdmin();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString))
            {
                try
                {

                    connection.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO [User] (Name,Gender,Email,Username,Password) values(@Name,@Gender,@Email,@Username,@Password)", connection);
                    cmd.Parameters.AddWithValue("@Name", fullNameInput.Text);
                    cmd.Parameters.AddWithValue("@Gender", genderTypeSelected.SelectedValue);
                    cmd.Parameters.AddWithValue("@Email", emailIdInput.Text);
                    cmd.Parameters.AddWithValue("@Username", usernameInput.Text);
                    cmd.Parameters.AddWithValue("@Password", hashedPassword);

                    var success = cmd.ExecuteNonQuery();
                    if (success == 0)
                    {
                        registrationResult.Text = "Unable to Register";
                        registrationResult.Visible = true;
                        return;
                    }
                    registrationResult.Text = "Registration Done Successfully.";
                }
                catch (Exception)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something went wrong please try again.')", true);
                }
            }




        }
    }
}





