<%@ Page Language="C#" %>

<!DOCTYPE html>
<script runat="server">

    protected void Button1_Click(object sender, EventArgs e)
    {

    }

</script>

<html lang="en" xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta charset="utf-8" />
    <title></title>    
    <style type="text/css">
        #form1 {
            margin-top: 30px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">   
        Cafeteria<p>
            &nbsp;</p>
        <p>
            email:<asp:TextBox ID="TextBox1" runat="server"></asp:email>
        </p>
        <p>
            &nbsp;</p>
        <p>
            password<asp:TextBox ID="TextBox2" runat="server"></asp:password>
        </p>
        <p>
            <asp:Button ID="Button1" runat="server" Text="LOGIN" />
        </p>
    </form>
</body>
</html>
