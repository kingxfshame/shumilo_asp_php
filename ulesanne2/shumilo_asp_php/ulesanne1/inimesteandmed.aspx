<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="inimesteandmed.aspx.cs" Inherits="xmlShumilo.inimesteandmed" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Inimeste Andmed</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Xml ID="xml1" runat="server" DocumentSource="~/autocompleter.xml" TransformSource="~/auto.xslt" />
        </div>
    </form>
</body>
</html>
