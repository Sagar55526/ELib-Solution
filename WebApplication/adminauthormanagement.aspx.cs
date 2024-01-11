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
    public partial class adminauthormanagement : System.Web.UI.Page
    {
        string strcon = System.Configuration.ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                clear();
            }
        }

        //add button click
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (checkAuthorExits())
            {
                Response.Write("<script>alert('Author with same ID already exists.!!!')</script>");
            }
            else 
            {
                addNewAuthor();
                clear();
            }
        }

        //update button click
        protected void Button3_Click(object sender, EventArgs e)
        {
            if (checkAuthorExits())
            {
                updateAuthor();
                clear();
            }
            else
            {
                //addNewAuthor();
                Response.Write("<script>alert('Author does not exsits.!!!')</script>");
            }
        }

        //delete button click
        protected void Button4_Click(object sender, EventArgs e)
        {
            if (checkAuthorExits())
            {
                deleteAuthor();
                clear();
            }
            else
            {
                Response.Write("<script>alert('Author does not exsits.!!!')</script>");
            }
        }

        //go button click
        protected void Button1_Click(object sender, EventArgs e)
        {
                getAuthorById();
        }

        //user defined functions

        void getAuthorById()
        {
            SqlConnection con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("select * from author_master_tbl where author_id='" + TextBox1.Text.Trim() + "'", con);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count >= 1)
            {
                TextBox2.Text = dt.Rows[0][1].ToString();
            }
            else
            {
                Response.Write("<script>alert('Invalid author ID.!!!')</script>");
            }
        }

        void deleteAuthor()
        {
            SqlConnection con = new SqlConnection(strcon);
            if(con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("DELETE FROM author_master_tbl WHERE author_id='"+TextBox1.Text.Trim()+"'", con);

            cmd.ExecuteNonQuery();
            con.Close();
            Response.Write("<script>alert('Author deleted successfully.!!!')</script>");
            GridView1.DataBind();
        }
            

        void updateAuthor()
        {
            SqlConnection con = new SqlConnection(strcon);
            if(con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("update author_master_tbl set author_name=@author_name where author_id='"+TextBox1.Text.Trim()+"'", con);

            cmd.Parameters.AddWithValue("@author_name", TextBox2.Text.Trim());

            cmd.ExecuteNonQuery();
            con.Close();
            Response.Write("<script>alert('Author name updated successfully.!!!')</script>");
            GridView1.DataBind();
        }

        void addNewAuthor()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if(con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("insert into author_master_tbl(author_id, author_name) values(@author_id,@author_name)", con);
                        
                 cmd.Parameters.AddWithValue("@author_id", TextBox1.Text.Trim());
                 cmd.Parameters.AddWithValue("@author_name", TextBox2.Text.Trim());

                 cmd.ExecuteNonQuery();
                 con.Close();
                 Response.Write("<script>alert('New author added successfully.!!!')</script>");
                GridView1.DataBind();
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }


        bool checkAuthorExits()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if(con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("select * from author_master_tbl where author_id='"+TextBox1.Text.Trim()+"'", con);
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
            catch(Exception ex)
            {
                Response.Write("<script>alert('"+ex.Message+"')</script>");
                return false;
            }
            
        }

        void clear()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
        }
    }
}