<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="student.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>Student Data</title>
  
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"> </script>   
 <script type="text/javascript" src="https://cdn.datatables.net/1.11.0/js/jquery.dataTables.min.js"></script>
<link type="text/css" rel="stylesheet" href="https://cdn.datatables.net/1.11.0/css/jquery.dataTables.min.css" />


<script src="https://cdn.jsdelivr.net/npm/select2@4.1.0-rc.0/dist/js/select2.min.js"></script>
<link href="https://cdn.jsdelivr.net/npm/select2@4.1.0-rc.0/dist/css/select2.min.css" rel="stylesheet" />
    <script >
        // In your Javascript (external .js resource or <script> tag)
        $(document).ready(function () {
       
            $('#Student_ID').DataTable(
                {
                    bLengthChange: true,
                    lengthMenu: [[5, 10, -1], [5, 10, "All"]],
                    
                    bFilter: true,
                    bSort: true,
                    bPaginate: true
                    
                });
        });
      
           

        $(document).ready(function () {
            $('.js-example-basic-single').select2();
        });

        $(document).ready(function () {
            $('#Student_ID').DataTable();
        });
        $(document).ready(function () {
            $('.js-example-basic-multiple').select2();
        });
    </script>
 
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
                  <asp:DropDownList runat="server" ID="Filter"  Cssclass="js-example-basic-single" OnSelectedIndexChanged="Filter_SelectedIndexChanged" AutoPostBack="true">

        </asp:DropDownList>
                   <asp:DropDownList runat="server" ID="Filters"   Cssclass="js-example-basic-single" OnSelectedIndexChanged="Filters_SelectedIndexChanged"    AutoPostBack="true">

        </asp:DropDownList>
            <asp:GridView ID="Student_ID"   runat="server" AutoGenerateColumns="false" CssClass="display compact" >
                   <Columns>
                       <asp:BoundField DataField="ID" HeaderText="ID" />
                            
                       <asp:BoundField DataField="Fname" HeaderText="First Name" />
                            <asp:BoundField DataField="Lname" HeaderText="Last Name" />
                            <asp:BoundField DataField="Age" HeaderText="Age" />
                            <asp:BoundField DataField="Email" HeaderText="Email" />
                            <asp:BoundField DataField="Accpetance" HeaderText="Registration Date" />
                            <asp:BoundField DataField="Comments" HeaderText="Comments" />
                                          <asp:TemplateField HeaderText="Accepted Or Not" SortExpression="Is_accepted">
    <ItemTemplate><%# (Boolean.Parse(Eval("Is_accepted").ToString())) ? "Yes" : "No" %></ItemTemplate>
</asp:TemplateField>
                       <asp:BoundField DataField="Specialization" HeaderText="Specialization" />
                            <asp:BoundField DataField="Gender" HeaderText="Gender" />
                            <asp:BoundField DataField="Town_NAme" HeaderText="City" />
       
             
                        </Columns>
            </asp:GridView> 
                
        </div>
    </form>
</body>
</html>
