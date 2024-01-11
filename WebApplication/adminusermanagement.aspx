<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="adminusermanagement.aspx.cs" Inherits="WebApplication.adminusermanagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <%--<script type="text/javascript">
      $(document).ready(function () {
          $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
      });
    </script>--%>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid mt-5">
        <div class="row">

            <div class="col-md-5">
                <div class="card">
                    <div class="card-body">

                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Member Details</h4>
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <img src="imgs/generaluser.png" width="100" />
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>

                        <div class="row">

                            <div class="col-md-3">
                                <label>Member ID</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox ID="TextBox1" class="form-control" placeholder="ID" runat="server"></asp:TextBox>
                                        <asp:LinkButton ID="LinkButton4" CssClass="btn btn-primary" runat="server" OnClick="LinkButton4_Click"><i class="fa-solid fa-arrow-right"></i></asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>Full Name</label>
                                <div class="form-group">
                                    <asp:TextBox ID="TextBox2" class="form-control" placeholder="Full Name" ReadOnly="true" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-5">
                                <label>Account Status</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox ID="TextBox3" class="form-control mr-1" placeholder="Status" ReadOnly="true" runat="server"></asp:TextBox>
                                        <asp:LinkButton ID="LinkButton1" CssClass="btn btn-success mr-1" runat="server" OnClick="LinkButton1_Click"><i class="fa-solid fa-circle-check"></i></asp:LinkButton>
                                        <asp:LinkButton ID="LinkButton2" CssClass="btn btn-warning mr-1" runat="server" OnClick="LinkButton2_Click"><i class="fa-solid fa-pause-circle"></i></asp:LinkButton>
                                        <asp:LinkButton ID="LinkButton3" CssClass="btn btn-danger mr-1" runat="server" OnClick="LinkButton3_Click"><i class="fa-solid fa-times-circle"></i></asp:LinkButton>
                                    </div>
                                </div>
                            </div>

                        </div>

                        <div class="row">
                            <div class="col-md-3">
                                <label>DOB</label>
                                <asp:TextBox ID="TextBox4" class="form-control" placeholder="DOB" ReadOnly="true" TextMode="Date" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-md-4">
                                <label>Contact Number</label>
                                <asp:TextBox ID="TextBox5" class="form-control" placeholder="Contact Number" ReadOnly="true" TextMode="Number" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-md-5">
                                <label>Email ID</label>
                                <asp:TextBox ID="TextBox8" class="form-control" placeholder="Email ID" ReadOnly="true" TextMode="Email" runat="server"></asp:TextBox>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-4">
                                <label>State</label>
                                <asp:TextBox ID="TextBox6" class="form-control" placeholder="State" ReadOnly="true" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-md-4">
                                <label>City</label>
                                <asp:TextBox ID="TextBox7" class="form-control" placeholder="City" ReadOnly="true" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-md-4">
                                <label>Pin Code</label>
                                <asp:TextBox ID="TextBox9" class="form-control" placeholder="Pin Code" TextMode="Number" ReadOnly="true" runat="server"></asp:TextBox>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-12">
                                <label>Full Portal Address</label>
                                <asp:TextBox ID="TextBox10" class="form-control" placeholder="Address" TextMode="MultiLine" ReadOnly="true" runat="server"></asp:TextBox>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-12">
                                <asp:Button Class="btn btn-block btn-danger mt-4" ID="Button5" runat="server" Text="Delete User Permanantly" OnClick="Button5_Click" />
                            </div>
                        </div>

                    </div>
                </div>
            </div>

            <div class="col-md-7">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Member List</h4>
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>

                        <div class="row">
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:elibraryDBConnectionString %>" SelectCommand="SELECT * FROM [member_master_tbl]"></asp:SqlDataSource>
                            <div class="col">
                                <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="member_id" DataSourceID="SqlDataSource1">
                                    <Columns>
                                        <asp:BoundField DataField="member_id" HeaderText="Member ID" ReadOnly="True" SortExpression="member_id" />
                                        <asp:BoundField DataField="full_name" HeaderText="Name" SortExpression="full_name" />
                                        <asp:BoundField DataField="account_status" HeaderText="Account Status" SortExpression="account_status" />
                                        <asp:BoundField DataField="contact_no" HeaderText="Contact No." SortExpression="contact_no" />
                                        <asp:BoundField DataField="email" HeaderText="E-mail" SortExpression="email" />
                                        <asp:BoundField DataField="state" HeaderText="State" SortExpression="state" />
                                        <asp:BoundField DataField="city" HeaderText="City" SortExpression="city" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>

                    </div>
                </div>
            </div>

        </div>
        <div>
            <a href="homepage.aspx"><< Go back to home page</a>
        </div>
    </div>

    </label>

</asp:Content>
