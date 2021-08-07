using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;

namespace DietManagement.Authentication
{
    /// <summary>
    /// Summary description for logout
    /// </summary>
    [WebService(Namespace = "http://microsoft.com/webservices/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
     [System.Web.Script.Services.ScriptService]
    public class logout : System.Web.Services.WebService
    {

      

        [WebMethod(EnableSession = true)]
        [ScriptMethod(UseHttpGet = true)]
        public Boolean logoutBtnClicked()
        {

            Session["Username"] = null;
            Session["UserId"] = null;
            HttpCookie cookie = new HttpCookie("userInfo");
            cookie.Expires = DateTime.Now.AddDays(-1);


            //Response.Cookies.Remove("userInfo");
            return true;
            //Response.Redirect("/");
        }
    }
}
