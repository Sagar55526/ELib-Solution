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
    public partial class adminbookinventory : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        static string global_filepath;
        static int global_actual_stock, global_current_stock, global_issued_books;                      

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["username"].ToString() == "" || Session["username"] == null)
                {
                    Response.Write("<script>alert('Session Expired Login Again');</script>");
                    Response.Redirect("userlogin.aspx");
                }
                else
                {
                   
                }
            }
            catch (Exception ex)
            {

                Response.Write("<script>alert('"+ex.Message+"');</script>");
                Response.Redirect("userlogin.aspx");
            }
            GridView1.DataBind();
        }

        //add button event
        protected void Button5_Click(object sender, EventArgs e)
        {
            if (checkIfBookExists())
            {
                Response.Write("<script>alert('Book already exists, add another one.!!!')</script>");
            }
            else
            {
                addNewBook();
            }
        }

        //update button event
        protected void Button1_Click(object sender, EventArgs e)
        {
            updateBookById();
        }

        //delete button event
        protected void Button2_Click(object sender, EventArgs e)
        {
            deleteBookById();
        }

        //go button event
        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            if (checkIfBookExists())
            {
                getBookByID();
            }
            else
            {
                Response.Write("<script>alert('Invalid book Id.!!!');</script>");
            }
        }

        //user defined functions

        void deleteBookById()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    if(con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    using(SqlCommand cmd = new SqlCommand("DELETE FROM book_master_tbl WHERE book_id='"+TextBox1.Text.Trim()+"'", con))
                    {
                        cmd.ExecuteNonQuery();
                        con.Close();
                        GridView1.DataBind();
                        Response.Write("<script>alert('Book deleted successfully.!!!');</script>");
                    }
                }
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert("+ ex.Message +"');</script>");
            }
        }


        void updateBookById()
        {
            try
            {
                int actual_stock = Convert.ToInt32(TextBox8.Text.Trim());
                int current_stock = Convert.ToInt32(TextBox9.Text.Trim());
                if (global_actual_stock == actual_stock)
                {

                }
                else
                {
                    if(actual_stock < global_issued_books)
                    {
                        Response.Write("<script>alert('Actual stock value can not be less than the issued books.!!!')</script>");
                    }
                    else
                    {
                        current_stock = actual_stock - global_issued_books;
                        TextBox9.Text ="" + current_stock;
                    }
                }

                string genres = "";
                foreach(int i in ListBox1.GetSelectedIndices())
                {
                    genres = genres + ListBox1.Items[i] + ",";
                }
                genres = genres.Remove(genres.Length - 1);

                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }
                SqlCommand cmd = new SqlCommand("UPDATE book_master_tbl set book_name=@book_name, genre=@genre, author_name=@author_name, publisher_name=@publisher_name," +
                    " publish_date=@publish_date, language=@language, edition=@edition, book_cost=@book_cost, no_of_pages=@no_of_pages, book_description=@book_description, " +
                    "actual_stock=@actual_stock, current_stock=@current_stock where book_id='" + TextBox1.Text.Trim() + "'", con);

                cmd.Parameters.AddWithValue("@book_id", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@book_name", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@genre", genres);
                cmd.Parameters.AddWithValue("@author_name", DropDownList1.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@publisher_name", DropDownList2.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@publish_date", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@language", TextBox5.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@edition", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@book_cost", TextBox6.Text.Trim());
                cmd.Parameters.AddWithValue("@no_of_pages", TextBox7.Text.Trim());
                cmd.Parameters.AddWithValue("@book_description", TextBox11.Text.Trim());
                cmd.Parameters.AddWithValue("@actual_stock", actual_stock); 
                cmd.Parameters.AddWithValue("@current_stock", current_stock);

                cmd.ExecuteNonQuery();
                con.Close();
                GridView1.DataBind();
                Response.Write("<script>alert('Book updated successfully.!!!');</script>");


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }


        void getBookByID()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    using (SqlCommand cmd = new SqlCommand("select * from book_master_tbl where book_id='" + TextBox1.Text.Trim() + "'", con))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        if (dt.Rows.Count >= 1)
                        {
                            TextBox2.Text = dt.Rows[0]["book_name"].ToString();
                            TextBox5.SelectedValue = dt.Rows[0]["language"].ToString().Trim();
                            DropDownList2.SelectedValue = dt.Rows[0]["publisher_name"].ToString().Trim();
                            DropDownList1.SelectedValue = dt.Rows[0]["author_name"].ToString().Trim();
                            TextBox3.Text = dt.Rows[0]["publish_date"].ToString().Trim();
                            TextBox4.Text = dt.Rows[0]["edition"].ToString().Trim();
                            TextBox6.Text = dt.Rows[0]["book_cost"].ToString().Trim();
                            TextBox7.Text = dt.Rows[0]["no_of_pages"].ToString().Trim();
                            TextBox8.Text = dt.Rows[0]["actual_stock"].ToString().Trim();
                            TextBox9.Text = dt.Rows[0]["current_stock"].ToString().Trim();
                            TextBox11.Text = dt.Rows[0]["book_description"].ToString().Trim();
                            TextBox10.Text = "" + (Convert.ToInt32(dt.Rows[0]["actual_stock"].ToString()) -
                                (Convert.ToInt32(dt.Rows[0]["current_stock"].ToString())));

                            string[] genre = dt.Rows[0]["genre"].ToString().Trim().Split(',');
                            for (int i=0; i<genre.Length; i++)
                            {
                                for (int j=0; j<ListBox1.Items.Count; j++)
                                {
                                    if(ListBox1.Items[j].ToString() == genre[i])
                                    {
                                        ListBox1.Items[j].Selected = true;
                                    }
                                }
                            }
                            global_actual_stock = Convert.ToInt32(dt.Rows[0]["actual_stock"].ToString().Trim());
                            global_current_stock = Convert.ToInt32(dt.Rows[0]["current_stock"].ToString().Trim());
                            global_issued_books = global_actual_stock - global_current_stock ;
                        }
                        else
                        {
                            Response.Write("<script>alert('Invalid book ID.!!!');</script>");
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }



        void fillAuthorPublisherValues()
        {
            try
            {
                using(SqlConnection con = new SqlConnection(strcon))
                {
                    if(con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    using (SqlCommand cmd = new SqlCommand("select author_name from author_master_tbl", con))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        DropDownList1.DataSource = dt;
                        DropDownList1.DataValueField = "author_name";
                        DropDownList1.DataBind();
                    }
                    using (SqlCommand cmd = new SqlCommand("select publisher_name from publisher_master_tbl", con))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        DropDownList2.DataSource = dt;
                        DropDownList2.DataValueField = "publisher_name";
                        DropDownList2.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
 
            }
        }

        bool checkIfBookExists()
        {
            using(SqlConnection con = new SqlConnection(strcon))
            {
                if(con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                using(SqlCommand cmd = new SqlCommand("select * from book_master_tbl where book_id='"+TextBox1.Text.Trim()+"' or book_name='"+TextBox2.Text.Trim()+"'", con))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if(dt.Rows.Count >= 1)
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

        void addNewBook()
        {
            //    SqlCommand cmd = new SqlCommand("insert into boom_master_tbl(book_id, book_name, genre, author_name, publisher_name, publish_date, language, edition, book_cost, no_of_pages, book_description, actual_stock, current_stock, book_img_link) " +
            //        "vlaues (@book_id, @book_name, @genre, @author_name, @publisher_name, @publish_date, @language, @edition, @book_cost, @no_of_pages, @book_description, @actual_stock, @current_stock, @book_img_link)", con);
            //    //genre and img link is remaining
            //    cmd.Parameters.AddWithValue("@book_id", TextBox1.Text.Trim());
            //    cmd.Parameters.AddWithValue("@book_name", TextBox2.Text.Trim()); 
            //    cmd.Parameters.AddWithValue("@genre", genres);
            //    cmd.Parameters.AddWithValue("@language", TextBox5.SelectedItem.Value);
            //    cmd.Parameters.AddWithValue("@publisher_name", DropDownList2.SelectedItem.Value);
            //    cmd.Parameters.AddWithValue("@author_name", DropDownList1.SelectedItem.Value);
            //    cmd.Parameters.AddWithValue("@publish_date", TextBox3.Text.Trim());
            //    cmd.Parameters.AddWithValue("@edition", TextBox4.Text.Trim());
            //    cmd.Parameters.AddWithValue("@book_cost", TextBox6.Text.Trim());
            //    cmd.Parameters.AddWithValue("@no_of_pages", TextBox7.Text.Trim());
            //    cmd.Parameters.AddWithValue("@actual_stock", TextBox8.Text.Trim());
            //    cmd.Parameters.AddWithValue("@current_stock", TextBox8.Text.Trim());
            //    cmd.Parameters.AddWithValue("@book_description", TextBox11.Text.Trim());




            try
            {
                string genres = "";
                foreach (int i in ListBox1.GetSelectedIndices())
                {
                    genres = genres + ListBox1.Items[i] + ",";
                }
               genres = genres.Remove(genres.Length - 1);

                //string filepath = "~/book_inventory/books1.png";
                //string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                //FileUpload1.SaveAs(Server.MapPath("book_inventory/" + filename));
                //filepath = "~/book_inventory/" + filename;


                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO book_master_tbl(book_id,book_name,genre,author_name,publisher_name,publish_date,language,edition,book_cost,no_of_pages,book_description,actual_stock,current_stock) " +
                    "values(@book_id,@book_name,@genre,@author_name,@publisher_name,@publish_date,@language,@edition,@book_cost,@no_of_pages,@book_description,@actual_stock,@current_stock)", con);

                cmd.Parameters.AddWithValue("@book_id", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@book_name", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@genre", genres);
                cmd.Parameters.AddWithValue("@author_name", DropDownList1.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@publisher_name", DropDownList2.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@publish_date", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@language", TextBox5.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@edition", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@book_cost", TextBox6.Text.Trim());
                cmd.Parameters.AddWithValue("@no_of_pages", TextBox7.Text.Trim());
                cmd.Parameters.AddWithValue("@book_description", TextBox11.Text.Trim());
                cmd.Parameters.AddWithValue("@actual_stock", TextBox8.Text.Trim());
                cmd.Parameters.AddWithValue("@current_stock", TextBox8.Text.Trim());
                //cmd.Parameters.AddWithValue("@book_img_link", filepath);

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Book added successfully.!!!');</script>");
                clear();
                GridView1.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }

        }

        void clear()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox5.Text = "";
            TextBox4.Text = "";
            TextBox6.Text = "";
            TextBox7.Text = "";
            TextBox11.Text = "";
            TextBox8.Text = "";
        }
    }
}