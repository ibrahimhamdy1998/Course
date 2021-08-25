<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="student.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Student Data</title>
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">

</head>
<body>
   <nav class="navbar navbar-default">
  <div class="container-fluid">
    <div class="navbar-header">
      <a class="navbar-brand" href="#">Student'S Data</a>
    </div>
    <ul class="nav navbar-nav">
      <li class="active"><a href="#">Home</a></li>
      <li><a href="#">Registration</a></li>
    </ul>
  </div>
</nav>
    <form id="form1" runat="server">
        <div style="margin-left:100px; margin-right:100px;">
            <asp:GridView ID="Student_ID" CssClass="table table-hover table-striped"   GridLines="None" AutoGenerateColumns="false" runat="server" >
                   <Columns>
                            <asp:BoundField DataField="ID" HeaderText="Sudent ID" />
                            <asp:BoundField DataField="Fname" HeaderText="First Name" />
                            <asp:BoundField DataField="Lname" HeaderText="Last Name" />
                            <asp:BoundField DataField="Age" HeaderText="Age" />
                            <asp:BoundField DataField="Email" HeaderText="Email" />
                            <asp:BoundField DataField="Accpetance" HeaderText="Registration Date" />
                            <asp:BoundField DataField="Is_accepted" HeaderText="Accepted Or Not" />
                        </Columns>
            </asp:GridView>
                       <asp:GridView runat="server" ID="ss"  CssClass="table table-hover table-striped"    GridLines="None" ></asp:GridView>
            
            
        </div>
    </form>
</body>
</html>
