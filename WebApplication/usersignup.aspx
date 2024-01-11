<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="usersignup.aspx.cs" Inherits="WebApplication.usersignup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="container">

          <div class="row">
              <div class="col-md-8 mx-auto">
                  <asp:Label ID="msglabel" runat="server" forecolor="Green" Text=""></asp:Label>
              </div>
          </div>

        <div class="row">
            <div class="col-md-8 mx-auto">      <%--mx-auto is used to align it in center--%>
                 
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
                                    <h4>Member Sign Up</h4>
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
                                    <%--in-built class for designed text-boxes--%>
                                    <asp:TextBox ID="TextBox2" class="form-control" placeholder="Member ID" runat="server" TextMode="Date"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <asp:Label ID="Label3" runat="server" Text="Contact Number"></asp:Label>
                                <div class="form-group">
                                    <%--in-built class for designed text-boxes--%>
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
                                    <asp:DropDownList ID="DropDownList1" class="form-control" placeholder="State" runat="server" TextMode="Number">
                                        <asp:ListItem Selected="True">Select One</asp:ListItem>
                                        <asp:ListItem>Maharashtra</asp:ListItem>
                                        <asp:ListItem>Goa</asp:ListItem>
                                        <asp:ListItem>Punjab</asp:ListItem>
                                        <asp:ListItem>Gujrat</asp:ListItem>
                                        <asp:ListItem>Uttar Pradesh</asp:ListItem>
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
                                    <span class="badge bg-warning">Login Credentials</span>
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <asp:Label ID="Label8" runat="server" Text="User ID"></asp:Label>
                                <div class="form-group">
                                    <%--in-built class for designed text-boxes--%>
                                    <asp:TextBox ID="TextBox9" class="form-control" placeholder="User ID" runat="server"></asp:TextBox>
<%--                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox9" ErrorMessage="User ID required.!!!" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <asp:Label ID="Label9" runat="server" Text="Password"></asp:Label>
                                <asp:Label ID="Label10" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                <div class="form-group">
                                    <%--in-built class for designed text-boxes--%>
                                    <asp:TextBox ID="TextBox10" class="form-control" placeholder="Password" runat="server" TextMode="Password"></asp:TextBox>
<%--                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox10" ErrorMessage="Password is essential.!!" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                 <div class="form-group">        <%--in-built class for capturing whole width of the container--%>
                                     <asp:Button CssClass="btn btn-success btn-block btn-lg" ID="Button1" runat="server" Text="sign-up" OnClick="Button1_Click" />
                                 </div>

                            </div>
                        </div>

                    </div>
                </div>

                <div>
                    <a href="homepage.aspx"><< Go back to home page</a>
                </div>

            </div>
        </div>
    </div>
</asp:Content>
