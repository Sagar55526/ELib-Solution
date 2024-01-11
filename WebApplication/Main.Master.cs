using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication
{
    public partial class Main : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if(Session["role"].Equals(""))
                {
                    LinkButton1.Visible = true;     /*btn for user sign up*/
                    LinkButton2.Visible = true;     /*btn for user login up*/
                    LinkButton3.Visible = false;    /*btn for log-out up*/
                    LinkButton7.Visible = false;    /*btn for hello user up*/
                    LinkButton6.Visible = true;     /*btn for admin login up*/
                    LinkButton11.Visible = false;   /*btn for author management up*/
                    LinkButton12.Visible = false;   /*btn for publisher management up*/
                    LinkButton8.Visible = false;    /*btn for book invetory up*/
                    LinkButton9.Visible = false;    /*btn for book issuing up*/
                    LinkButton10.Visible = false;   /*btn for book management up*/
                }
                else if (Session["role"].Equals("user"))
                {
                    LinkButton1.Visible = false;     /*btn for user sign up*/
                    LinkButton2.Visible = false;     /*btn for user login up*/
                    LinkButton3.Visible = true;    /*btn for log-out up*/
                    LinkButton7.Visible = true;    /*btn for hello user up*/
                    LinkButton7.Text = "Hello " + Session["username"].ToString();
                    LinkButton6.Visible = true;     /*btn for admin login up*/
                    LinkButton11.Visible = false;   /*btn for author management up*/
                    LinkButton12.Visible = false;   /*btn for publisher management up*/
                    LinkButton8.Visible = false;    /*btn for book invetory up*/
                    LinkButton9.Visible = false;    /*btn for book issuing up*/
                    LinkButton10.Visible = false;   /*btn for book management up*/
                }
                else if (Session["role"].Equals("admin"))
                {
                    LinkButton1.Visible = false;     /*btn for user sign up*/
                    LinkButton2.Visible = false;     /*btn for user login up*/
                    LinkButton3.Visible = true;    /*btn for log-out up*/
                    LinkButton7.Visible = true;    /*btn for hello user up*/
                    LinkButton7.Text = "Hello admin";
                    LinkButton6.Visible = false;     /*btn for admin login up*/
                    LinkButton11.Visible = true;   /*btn for author management up*/
                    LinkButton12.Visible = true;   /*btn for publisher management up*/
                    LinkButton8.Visible = true;    /*btn for book invetory up*/
                    LinkButton9.Visible = true;    /*btn for book issuing up*/
                    LinkButton10.Visible = true;   /*btn for book management up*/
                }
            }
            catch(Exception ex)
            {

            }
        }

        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminlogin.aspx");
        }

        protected void LinkButton11_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminauthormanagement.aspx");
        }

        protected void LinkButton12_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminpublishermanagement.aspx");
        }

        protected void LinkButton8_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminbookinventory.aspx");
        }

        protected void LinkButton9_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminissue.aspx");
        }

        protected void LinkButton10_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminusermanagement.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("userlogin.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("usersignup.aspx");
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Session["username"] = "";
            Session["fullname"] = "";
            Session["role"] = "";
            Session["status"] = "";

            LinkButton1.Visible = true;     /*btn for user sign up*/
            LinkButton2.Visible = true;     /*btn for user login up*/
            LinkButton3.Visible = false;    /*btn for log-out up*/
            LinkButton7.Visible = false;    /*btn for hello user up*/
            LinkButton6.Visible = true;     /*btn for admin login up*/
            LinkButton11.Visible = false;   /*btn for author management up*/
            LinkButton12.Visible = false;   /*btn for publisher management up*/
            LinkButton8.Visible = false;    /*btn for book invetory up*/
            LinkButton9.Visible = false;    /*btn for book issuing up*/
            LinkButton10.Visible = false;   /*btn for book management up*/
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Response.Redirect("viewbook.aspx");
        }

        protected void LinkButton7_Click(object sender, EventArgs e)
        {
            Response.Redirect("userprofile.aspx");
        }
    }
}