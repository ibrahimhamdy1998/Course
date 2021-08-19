<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="student.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registration Form</title>
    <style type="text/css">
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
    </style>
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
            }
            if ($("#ID_LAST_NAME").val() == "") {
                alert("fill last name");
            }
            if ($("#ID_AGE").val() == "") {
                alert("fill your age");
            }
            if ($("#ID_EMAIL").val() == "") {
                alert("fill your email");
            }
         
            if (!$("input[name='GENDER']:checked").val()) {
                alert('select your gender');
            }
            if ($("ID_SPECIALIZATION").val('0')) {
                alert("select your specialization")
            }
          
        }
    </script>
    <script src="https://code.jquery.com/jquery-3.6.0.min.js">  
            
            </script>
</head>
<body class="all">
    <h1>Registration</h1>
    <div>
        <form id="form1" runat="server" class="form">
            <label>First Name</label>
            <br/>
            <asp:TextBox runat="server" ID="ID_FIRST_NAME" MaxLength="10" Style="border-radius: 25px"></asp:TextBox>
            <br/>
            <label>Last Name</label>
            <br/>
            <asp:TextBox runat="server" ID="ID_LAST_NAME" MaxLength="10" Style="border-radius: 25px"> </asp:TextBox>
            <textarea id="TextArea1" name="S1"></textarea><br/>
            <label>age</label>
            <br/>
            <asp:TextBox runat="server" ID="ID_AGE" MaxLength="2" Style="border-radius: 25px"></asp:TextBox>
            <br/>
            <label>Email</label>
            <br/>
            <asp:TextBox type="email" runat="server" ID="ID_EMAIL" MaxLength="50" Style="border-radius: 25px"></asp:TextBox>
            <br/>
            <label>Gender</label>
            <br/>
            <asp:RadioButton ID="ID_MALE" Text="male" runat="server" GroupName="GENDER" />
            <br/>
            <asp:RadioButton ID="ID_FEMALE" Text="female" runat="server" GroupName="GENDER" />
            <br/>
            <label>Spcialization</label>
            <br/>
            <asp:DropDownList runat="server" ID="ID_SPECIALIZATION" Style="border-radius: 25px">
                <asp:ListItem Text="" Selected="True" Value="0" />
                <asp:ListItem Text="computer science" Value="1"/>
                <asp:ListItem Text="IT" Value="2"/>
                <asp:ListItem Text="Accountaing" Value="3"/>
            </asp:DropDownList>
            <br />
            <label>comments</label>
            <br/>
            <textarea runat="server" id="ID_COMMENTS" maxlength="500" cols="20" rows="7" style="border-radius: 25px"> </textarea>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
            <br/>

            <asp:Button Text="Register" OnClick="Register_Click" runat="server" OnClientClick="javascript:return Check();" ID="REGISTER" Style="background-color: green; color: white; font-weight: bold" />
            <asp:Button Text="Cancel" runat="server" ID="CANCEL" Style="background-color: red; color: white; font-weight: bold" OnClick="Cancel_Click" />
            <button type="button" onclick="Clear()" id="CANCLE_JS" style="color: black; font-weight: bold; background-color: yellow; width: 75px; height: 25px">Cancel.js</button>
        </form>
    </div>
    <script>


</script>
</body>
</html>
