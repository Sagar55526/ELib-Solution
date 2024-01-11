<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="adminlogin.aspx.cs" Inherits="WebApplication.adminlogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="row">
            <div class="col-md-6 mx-auto">      <%--mx-auto is used to align it in center--%>
                 
                <div class="card">
                    <div class="card-body">
                        
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img src="imgs/adminuser.png" width="150"/>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h3>Admin Login</h3>
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <hr /> 
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                
                                <asp:Label ID="Label1" runat="server" Text="Admin ID"></asp:Label>
                                <div class="form-group">        <%--in-built class for designed text-boxes--%>
                                    <asp:TextBox ID="TextBox1" class="form-control" placeholder="Admin ID" runat="server"></asp:TextBox>
                                </div>

                                <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
                                <div class="form-group">        <%--in-built class for designed text-boxes--%>
                                    <asp:TextBox ID="TextBox2" class="form-control" placeholder="Member ID" runat="server" TextMode="Password"></asp:TextBox>
                                </div>

                                 <div class="form-group">        <%--in-built class for capturing whole width of the container--%>
                                    <asp:Button ID="Button1" runat="server" Text="Login" class="btn btn-success btn-block btn-lg" OnClick="Button1_Click"/>
                                 </div>

                                 

                            </div>
                        </div>

                    </div>
                </div>

                <div>
                    <a href="homepage.aspx"><< Go back to home page</a>
                </div><br /><br /><br />        <%--remove if required--%>

            </div>
        </div>
    </div>
</asp:Content>


