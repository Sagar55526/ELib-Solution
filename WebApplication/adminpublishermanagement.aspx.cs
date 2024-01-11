using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication
{
    public partial class adminpublishermanagement : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
            }
        }


        //add button click
        protected void Button6_Click(object sender, EventArgs e)
        {
            if (checkPublisherExits())
            {
                Response.Write("<script>alert('Publisher with same ID already exists.!!!')</script>");
            }
            else
            {
                addNewPublisher();
                clear();
            }
        }

        //update button click
        protected void Button7_Click(object sender, EventArgs e)
        {
            if (checkPublisherExits())
            {
                updatePublisher();
                clear();
            }
            else
            {
                Response.Write("<script>alert('Publisher does not exsits.!!!')</script>");
            }
        }

        //delete button click
        protected void Button8_Click(object sender, EventArgs e)
        {
            if (checkPublisherExits())
            {
                deletePublisher();
                clear();
            }
            else
            {
                Response.Write("<script>alert('Publisher does not exsits.!!!')</script>");
            }
        }

        //go button click
        protected void Button5_Click(object sender, EventArgs e)
        {
            getPublisherById();
        }


        //user defined functions

        void getPublisherById()
        {
            SqlConnection con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("select * from publisher_master_tbl where publisher_id='" + TextBox3.Text.Trim() + "'", con);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count >= 1)
            {
                TextBox4.Text = dt.Rows[0][1].ToString();
            }
            else
            {
                Response.Write("<script>alert('Invalid publisher ID.!!!')</script>");
            }
        }

        void deletePublisher()
        {
            SqlConnection con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("DELETE FROM publisher_master_tbl WHERE publisher_id='" + TextBox3.Text.Trim() + "'", con);

            cmd.ExecuteNonQuery();
            con.Close();
            Response.Write("<script>alert('Author deleted successfully.!!!')</script>");
            GridView1.DataBind();
        }


        void updatePublisher()
        {
            SqlConnection con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("update publisher_master_tbl set publisher_name=@publisher_name where publisher_id='" + TextBox3.Text.Trim() + "'", con);

            cmd.Parameters.AddWithValue("@publisher_name", TextBox4.Text.Trim());

            cmd.ExecuteNonQuery();
            con.Close();
            Response.Write("<script>alert('Author name updated successfully.!!!')</script>");
            GridView1.DataBind();
        }

        void addNewPublisher()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("insert into publisher_master_tbl(publisher_id, publisher_name) values(@publisher_id,@publisher_name)", con);

                cmd.Parameters.AddWithValue("@publisher_id", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@publisher_name", TextBox4.Text.Trim());

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('New author added successfully.!!!')</script>");
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }


        bool checkPublisherExits()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("select * from publisher_master_tbl where publisher_id='" + TextBox3.Text.Trim() + "'", con);
                //disconnected architecture approach is used as below
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }

                //connected architecture approach is used below if necessary then also ew can use it  

                //SqlDataReader dr = cmd.ExecuteReader();
                //if (dr.HasRows)
                //{
                //    while (dr.Read())
                //    {
                //        Response.Write("<script>alert('login successful..!!')</script>");
                //    }
                //    return true;
                //}
                //else
                //{
                //    return false;
                //}
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
                return false;
            }

        }

        void clear()
        {
            TextBox3.Text = "";
            TextBox4.Text = "";
        }

        
    }
}