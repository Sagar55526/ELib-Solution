<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="adminpublishermanagement.aspx.cs" Inherits="WebApplication.adminpublishermanagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
         $(document).ready(function () {

             //$(document).ready(function () {
             //$('.table').DataTable();});
             $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
         });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="container mt-5" style="padding-bottom: 20px">    <%--optional padding is implemented here--%>
        <div class="row">
            <div class="col-md-5">

                <div class="card">
                    <div class="card-body">

                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Publisher Details</h4>
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <img width="100" src="imgs/publisher.png" />
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <hr />
                                </center>
                            </div>
                        </div>

                        


                        <div class="row">
                            <div class="col-md-4">
                                <label>Publisher ID</label>
                                    <div class="form-group">
                                        <div class="input-group">
                                            <asp:TextBox CssClass="form-control" ID="TextBox3" placeHolder="ID" runat="server"></asp:TextBox>    <%--Chances of error are in this line of code because of ID is may be same as other files--%>
                                            <asp:Button Class="btn btn-primary" ID="Button5" runat="server" Text="GO!!" OnClick="Button5_Click" />
                                        </div>
                                    </div>
                            </div>
                            <div class="col-md-8">
                                <label>Publisher Name</label>
                                    <div class="form-group">
                                        <asp:TextBox CssClass="form-control" ID="TextBox4" placeHolder="Name" runat="server"></asp:TextBox>    <%--Chances of error are in this line of code because of ID overwriting issue--%>
                                    </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-4">
                                 <asp:Button Class="btn btn-success btn-lg btn-block" ID="Button6" runat="server" Text="Add" OnClick="Button6_Click" />
                            </div>
                             <div class="col-md-4">
                                 <asp:Button Class="btn btn-primary btn-lg btn-block" ID="Button7" runat="server" Text="Update" OnClick="Button7_Click" />
                            </div>
                             <div class="col-md-4">
                                 <asp:Button Class="btn btn-danger btn-lg btn-block" ID="Button8" runat="server" Text="Delete" OnClick="Button8_Click" />
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
                                    <h4>Publisher List</h4>
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <hr />
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:elibraryDBConnectionString %>" SelectCommand="SELECT * FROM [publisher_master_tbl]"></asp:SqlDataSource>
                            <div class="col">
                                <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" DataSourceID="SqlDataSource2"></asp:GridView>
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

</asp:Content>
