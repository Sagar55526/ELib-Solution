using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication
{
    public partial class adminissue : System.Web.UI.Page
    {
        readonly string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind(); 
        }

        //Go button functionallity
        protected void Button5_Click(object sender, EventArgs e)
        {
            getBookAndMemberNames();
        }

        //Issue button functionallity
        protected void Button8_Click(object sender, EventArgs e)
        {
            if(checkIfBookExists() && checkIfMemberExists())
            {
                if (checkIfIssueEntryExists())
                {
                    Response.Write("<script>alert('This member already has same book.!!!')</script>");
                }
                else
                {
                    insertIssueDetails();
                }
                
            }
            else
            {
                Response.Write("<script>alert('Either member or book does not exists.!!!')</script>");
            }
        }

        //Return button functionallity
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (checkIfIssueEntryExists())
            {
                updateBookReturn();
            }
            else
            {
                Response.Write("<script>alert('Member does not taken such a book earlier.!!!')</script>");
            }
        }


        //user defined function 

        void updateBookReturn()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }


                SqlCommand cmd = new SqlCommand("Delete from book_issue_tbl WHERE book_id='" + TextBox3.Text.Trim() + "' AND member_id='" + TextBox1.Text.Trim() + "'", con);
                int result = cmd.ExecuteNonQuery();

                if (result > 0)
                {

                    cmd = new SqlCommand("update book_master_tbl set current_stock = current_stock+1 WHERE book_id='" + TextBox3.Text.Trim() + "'", con);
                    cmd.ExecuteNonQuery();
                    con.Close();

                    Response.Write("<script>alert('Book Returned Successfully');</script>");
                    GridView1.DataBind();

                    con.Close();

                }
                else
                {
                    Response.Write("<script>alert('Error - Invalid details');</script>");
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }


        void insertIssueDetails()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    if(con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                        SqlCommand cmd = new SqlCommand("insert into book_issue_tbl(member_id, member_name, book_id, book_name, issue_date, due_date) " +
                         "values(@member_id, @member_name, @book_id, @book_name, @issue_date, @due_date)", con);
                    
                        cmd.Parameters.AddWithValue("@member_id", TextBox1.Text.Trim()); 
                        cmd.Parameters.AddWithValue("@member_name", TextBox2.Text.Trim());
                        cmd.Parameters.AddWithValue("@book_id", TextBox3.Text.Trim());
                        cmd.Parameters.AddWithValue("@book_name", TextBox4.Text.Trim());
                        cmd.Parameters.AddWithValue("@issue_date", TextBox5.Text.Trim());
                        cmd.Parameters.AddWithValue("@due_date", TextBox6.Text.Trim());

                        cmd.ExecuteNonQuery();

                        cmd = new SqlCommand("update book_master_tbl set current_stock = current_stock-1 where book_id='"+TextBox3.Text.Trim()+"'", con);
                        cmd.ExecuteNonQuery();

                        con.Close();
                        GridView1.DataBind();
                        Response.Write("<script>alert('Book issued successfully to "+ TextBox1.Text.Trim() + ".!!!')</script>");
                    
                }
            }
            catch (Exception ex)
            {

            }
        }


        bool checkIfBookExists()
        {
            using (SqlConnection con = new SqlConnection(strcon))
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                using (SqlCommand cmd = new SqlCommand("select * from book_master_tbl where book_id='" + TextBox3.Text.Trim() + "' and current_stock>0 ", con))
                {
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
                }
            }
        }

        bool checkIfIssueEntryExists()
        {
            using (SqlConnection con = new SqlConnection(strcon))
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                using (SqlCommand cmd = new SqlCommand("select * from book_issue_tbl where book_id='" + TextBox3.Text.Trim() + "' and book_id='"+TextBox3.Text.Trim()+"' ", con))
                {
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
                }
            }
        }


        bool checkIfMemberExists()
        {
            try {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    using (SqlCommand cmd = new SqlCommand("select * from member_master_tbl where member_id='" + TextBox1.Text.Trim() + "'", con))
                    {
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
                    }
                }
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('"+ex.Message+"')</script>");
                return false;
            }
            }
        

        void getBookAndMemberNames()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("select book_name from book_master_tbl where book_id='" + TextBox3.Text.Trim() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    TextBox4.Text = dt.Rows[0]["book_name"].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Invalid Book ID');</script>");
                }

                cmd = new SqlCommand("select full_name from member_master_tbl where member_id='" + TextBox1.Text.Trim() + "'", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    TextBox2.Text = dt.Rows[0]["full_name"].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Invalid User ID');</script>");
                }


            }
            catch (Exception ex)
            {

            }
        }

        void clear()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
            TextBox6.Text = "";
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if(e.Row.RowType == DataControlRowType.DataRow)
                {
                    DateTime dt = Convert.ToDateTime(e.Row.Cells[5].Text);
                    DateTime today = DateTime.Today;
                    if(today > dt)
                    {
                        e.Row.BackColor = System.Drawing.Color.PaleVioletRed;
                    }
                }
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('"+ex.Message+"');</script>");
            }
        }
    }
}