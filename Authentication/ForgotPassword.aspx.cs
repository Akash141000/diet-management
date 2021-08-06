using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing;
using System.Web.Security;
using System.Net;
using System.Net.Mail;

namespace DietManagement.Authentication
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        static int otptemp;
        readonly string email ="", password="";
        protected void Page_Load(object sender, EventArgs e)
        {
            Rvx1.Enabled = true;
            Rvx2.Enabled = false;
            Button2.Visible = false;
            TextBox4.Visible = false;
            Label3.Visible = false;
            Label4.Visible = false;

        }
        protected void otp()
        {
            try
            {

                int Rannum;
                Random rnd = new Random();
                Rannum = Convert.ToInt32(rnd.Next(100000, 999999));
                otptemp = Rannum;
                MailMessage mm = new MailMessage(email, TextBox1.Text);
                mm.Subject = "OTP Dtrack";
                mm.Body = String.Format("Hello : Your OTP is : <h1>{0}</h1>", Rannum);
                mm.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                NetworkCredential nc = new NetworkCredential();
                nc.UserName = email;
                nc.Password = password;
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = nc;
                smtp.Port = 587;
                smtp.Send(mm);
                Label4.Visible = true;
                Label4.Text = "Please enter the OTP sent on your email address";
                Button2.Visible = true;
                TextBox4.Visible = true;
                Label3.Visible = true;
            }
            catch (Exception)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Internet not connected.')", true);
            }

        }
        protected void check()
        {
            try
            {
                int val;
                val = Convert.ToInt32(TextBox4.Text);
                if (val == otptemp)
                {
                    otptemp = 0;
                    Response.Redirect("Forgot1.aspx");
                }
                else
                {
                    Button2.Visible = true;
                    TextBox4.Visible = true;
                    Label3.Visible = true;
                    Label4.Visible = true;
                    Label4.Text = "Wrong OTP";
                }
            }
            catch (Exception)
            {
                Label4.Text = "Wrong OTP";
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("select Email,Password from Reg Where Email=@Emai", con);
                cmd.Parameters.AddWithValue("@Emai", TextBox1.Text);
                SqlDataReader da = cmd.ExecuteReader();
                if (da.Read())
                {

                    string Email = da["Email"].ToString();
                    Session["Email"] = Email;
                    Label1.Visible = false;
                    Label2.Visible = false;
                    Button1.Visible = false;
                    TextBox1.Visible = false;
                    Rvx1.Enabled = false;
                    otp();
                }

                else
                {

                    Label2.Visible = true;
                    Label2.Text = "Invalid Email";
                }
            }
            catch (Exception)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something went wrong please try again')", true);
            }
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            Rvx1.Enabled = false;
            Rvx2.Enabled = true;
            check();
        }
    }
}
