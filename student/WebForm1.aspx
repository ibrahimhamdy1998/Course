<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="student.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title>Registration Form</title>
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
    <%--<style type="text/css">
        .all {
            font-family: Tahoma;
        }

        label {
            font-weight: bold;
        }

        h1 {
            text-align: center;
            color: white;
            background-color: red;
            margin: 1px;
        }

        .form {
            text-align: left;
        }

        #TextArea1 {
            height: 94px;
            width: 269px;
        }
    </style>--%>
    <script type="text/javascript"> 
        /*function Clear() {
            document.getElementById("fname").value = "";
            $('#lname').val('');
            document.getElementById("age").value = "";
            document.getElementById("email").value = "";
            document.getElementById("male").checked = false;
            document.getElementById("female").checked = false;
            document.getElementById("textarea").value = "";

        }


        function Check() {

            var x = document.getElementById("fname").value.length;
            var y = document.getElementById("lname").value.length;
            var z = document.getElementById("age").value.length;
            var u = document.getElementById("email").value.length;

            if (x > 10) {
                alert("you exceed max length");
                return false;
            }
            if (y > 10) {
                alert("you exceed max length");

            }
            if (z > 2) {
                alert("you exceed max length");
            }
            if (u > 50) {
                alert("you exceed max length");
            }
        }

        */
        function Clear() {
            $("#ID_FIRST_NAME").val('');
            $("#ID_LAST_NAME").val('');
            $("#ID_AGE").val('');
            $("#ID_EMAIL").val('');
            $("#ID_COMMENTS").val('');
            $('input[name="GENDER"]').prop('checked', false);
        }
        function Check() {
            if ($("#ID_FIRST_NAME").val() == "") {
                alert("fill first name");
                return false;
            }
            if ($("#ID_LAST_NAME").val() == "") {
                alert("fill last name");
                return false;
            }
            if ($("#ID_AGE").val() == "") {
                alert("fill your age");
                return false;
            }
            if ($("#ID_EMAIL").val() == "") {
                alert("fill your email");
                return false;
            }
            if (!$("input[name='GENDER']:checked").val()) {
                alert('select your gender');
                return false;

            }
            if ($("#ID_SPECIALIZATION").val() == '0') {
                alert("select your specialization")
                return false;
            }
                    
        }
    </script>
    <script src="https://code.jquery.com/jquery-3.6.0.min.js">  
            
    </script>
</head>
<body class="bg-light text-dark">
    <nav class="navbar navbar-default">
  <div class="container-fluid">
    <div class="navbar-header">
      <a class="navbar-brand" href="#">Registration Form</a>
    </div>
    <ul class="nav navbar-nav">
      <li class="active"><a href="#">Home</a></li>
      <li><a href="#">Contact</a></li>
    </ul>
  </div>
</nav>
    <div>
        <form id="form1" runat="server" class="form">
            <label class="label label-primary">First Name</label>
            
            <asp:TextBox runat="server" class="form-control" ID="ID_FIRST_NAME" MaxLength="10" Style="border-radius: 25px"></asp:TextBox>
            <br />
            <label class="label label-primary">Last Name</label>
            <br />
            <asp:TextBox runat="server" class="form-control" ID="ID_LAST_NAME" MaxLength="10" Style="border-radius: 25px"> </asp:TextBox>
          <br />
            <label class="label label-primary">age</label>
            <br />
            <asp:TextBox runat="server" class="form-control" ID="ID_AGE" MaxLength="2" Style="border-radius: 25px"></asp:TextBox>
            <br />
            <label class="label label-primary">Email</label>
            <br />
            <asp:TextBox type="email" class="form-control" runat="server" ID="ID_EMAIL" MaxLength="50" Style="border-radius: 25px"></asp:TextBox>
            <br />
            <label class="label label-primary">Gender</label>
            <br />
            <asp:RadioButton ID="ID_MALE" Text="male" runat="server" GroupName="GENDER" />
            <br />
            <asp:RadioButton ID="ID_FEMALE" Text="female" runat="server" GroupName="GENDER" />
            <br />
            <label class="label label-primary">Spcialization</label>
            <br />
            <asp:DropDownList  runat="server" ID="ID_SPECIALIZATION" Style="border-radius: 25px">
                <%-- <asp:ListItem Text="" Selected="True" Value="0" />
                <asp:ListItem Text="computer science" Value="1"/>
                <asp:ListItem Text="IT" Value="2"/> 
                <asp:ListItem Text="Accountaing" Value="3"/>--%>
            </asp:DropDownList>
            <br />
            <label class="label label-primary">City</label>
            <br />
            <asp:DropDownList runat="server" ID="ID_CITY" Style="border-radius: 25px">
            </asp:DropDownList>

            <br />
            <label class="label label-primary">comments</label>
            <br />
            <textarea runat="server" class="form-control" id="ID_COMMENTS" maxlength="500" cols="20" rows="7" style="border-radius: 25px"> </textarea>
            <br />
            <asp:Button Text="Register" OnClick="Register_Click" runat="server" OnClientClick="javascript:return Check();" ID="REGISTER"  class="btn btn-success"/>
            <asp:Button Text="Cancel" runat="server" ID="CANCEL" class="btn btn-danger" OnClick="Cancel_Click" />
        </form> 
    </div>
</body>
</html>
