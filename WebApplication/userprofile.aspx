<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="userprofile.aspx.cs" Inherits="WebApplication.userprofile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


          <div class="container-fluid">
        <div class="row">
            <div class="col-md-5">      <%--mx-auto is used to align it in center--%>
                 
                <div class="card">
                    <div class="card-body">
                        
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img src="imgs/generaluser.png" width="100"/>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>User Profile</h4>
                                    <span>Account Status: </span>
                                     <asp:Label ID="Label10" class="badge badge-pill badge-info" runat="server" Text="Active"></asp:Label>
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <hr /> 
                            </div>
                        </div>


                        <div class="row">
                            <div class="col-md-6">
                                <asp:Label ID="Label1" runat="server" Text="Full Name"></asp:Label>
                                <div class="form-group">
                                    <%--in-built class for designed text-boxes--%>
                                    <asp:TextBox ID="TextBox1" class="form-control" placeholder="Full Name" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <asp:Label ID="Label2" runat="server" Text="Date"></asp:Label>
                                <div class="form-group">
                                     <%--in-built class for designed text-boxes i.e. form-group--%>
                                    <asp:TextBox ID="TextBox2" class="form-control" placeholder="Member ID" runat="server" TextMode="Date"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <asp:Label ID="Label3" runat="server" Text="Contact Number"></asp:Label>
                                <div class="form-group">
                                    <%--in-built class for designed text-boxes i.e. form-group--%>
                                    <asp:TextBox ID="TextBox3" class="form-control" placeholder="Contact Number" runat="server" TextMode="Number"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <asp:Label ID="Label4" runat="server" Text="Email ID"></asp:Label>
                                <div class="form-group">
                                    <%--in-built class for designed text-boxes--%>
                                    <asp:TextBox ID="TextBox4" class="form-control" placeholder="Email ID" runat="server" TextMode="Email"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-4">
                                <asp:Label ID="Label5" runat="server" Text="State"></asp:Label>
                                <div class="form-group">
                                    <%--in-built class for designed text-boxes--%>
                                    <asp:DropDownList ID="TextBox5" class="form-control" placeholder="State" runat="server" TextMode="Number">
                                        <asp:ListItem>Maharashtra</asp:ListItem>
                                        <asp:ListItem>Goa</asp:ListItem>
                                        <asp:ListItem>Punjab</asp:ListItem>
                                        <asp:ListItem>Gujrat</asp:ListItem>
                                        <asp:ListItem>Uttar Pradesh</asp:ListItem>
                                        <asp:ListItem>Madhya Pradesh</asp:ListItem>
                                        <asp:ListItem>Arunachal Pradesh</asp:ListItem>
                                        <asp:ListItem>Andrah Pradesh</asp:ListItem>
                                        <asp:ListItem>Jharkhand</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <asp:Label ID="Label6" runat="server" Text="City"></asp:Label>
                                <div class="form-group">
                                    <%--in-built class for designed text-boxes--%>
                                    <asp:TextBox ID="TextBox6" class="form-control" placeholder="City" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <asp:Label ID="Label7" runat="server" Text="Pin-Code"></asp:Label>
                                <div class="form-group">
                                    <%--in-built class for designed text-boxes--%>
                                    <asp:TextBox ID="TextBox7" class="form-control" placeholder="Pin-Code" runat="server" TextMode="Number"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-12">
                                <label>Full Address</label>
                                <asp:TextBox ID="TextBox8" runat="server" class="form-control" PlaceHolder="Full Address" TextMode="MultiLine" Rows="2"></asp:TextBox>
                            </div>
                        </div>

                            <%--<hr />--%>
                        
                        <div class="row">
                            <div class="col">
                                <center>
                                   <%-- <span class="badge rounded-pill text-bg-info"></span>--%>
                                    <h6><span class="badge bg-warning">Login Credentials</span></h6>
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-4">
                                <asp:Label ID="Label8" runat="server" Text="User Name"></asp:Label>
                                <div class="form-group">
                                    <%--in-built class for designed text-boxes--%>
                                    <asp:TextBox ID="TextBox9" class="form-control" placeholder="User Name" runat="server" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <asp:Label ID="Label9" runat="server" Text="Old Password"></asp:Label>
                                <div class="form-group">
                                    <%--in-built class for designed text-boxes--%>
                                    <asp:TextBox ID="TextBox10" class="form-control" placeholder="Old Password" runat="server" TextMode="Password" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <asp:Label ID="Label11" runat="server" Text="New Password"></asp:Label>
                                <div class="form-group">
                                    <%--in-built class for designed text-boxes--%>
                                    <asp:TextBox ID="TextBox11" class="form-control" placeholder="New Password" runat="server" TextMode="Password"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-8 mx-auto">
                                <center>
                                    <div class="form-group">        <%--in-built class for capturing whole width of the container--%>
                                      <asp:Button Class="btn btn-success btn-lg btn-block" ID="Button1" runat="server" Text="Update" OnClick="Button1_Click" />
                                    </div>
                                 </center>
                            </div>
                        </div>

                    </div>
                </div>

                    <div>
                        <a href="homepage.aspx"><< Go back to home page</a>
                    </div>

            </div>
        
              <div class="col-md-7">
                   <div class="card">
                    <div class="card-body">
                        
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img src="imgs/books.png" width="100"/>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Your Issued Books</h4>
                                     <asp:Label ID="Label12" class="badge badge-pill badge-info" runat="server" Text="Your Books Info"></asp:Label>
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <hr /> 
                            </div>
                        </div>

                        <div class="row">
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:elibraryDBConnectionString %>" SelectCommand="SELECT * FROM [book_issue_tbl]"></asp:SqlDataSource>
                            <div class="col">
                                <asp:GridView ID="GridView1" class="table table-striped table-bordered" runat="server" AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound">
                                    <Columns>
                                        <asp:BoundField DataField="member_id" HeaderText="member_id" SortExpression="member_id" />
                                        <asp:BoundField DataField="member_name" HeaderText="member_name" SortExpression="member_name" />
                                        <asp:BoundField DataField="book_id" HeaderText="book_id" SortExpression="book_id" />
                                        <asp:BoundField DataField="book_name" HeaderText="book_name" SortExpression="book_name" />
                                        <asp:BoundField DataField="issue_date" HeaderText="issue_date" SortExpression="issue_date" />
                                        <asp:BoundField DataField="due_date" HeaderText="due_date" SortExpression="due_date" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>

                    </div>
                </div>
              </div>
        </div>
    </div>


</asp:Content>
