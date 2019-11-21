<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="XML_inimene_Avtomobilev.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Inimeste leht</title>
</head>
<body>
    <h1>XML ja XSLT funktsioonide kasutemine</h1>
    <form id="form1" runat="server">
        <div>
            <asp:Xml ID="xml1" runat="server"
                DocumentSource="~/inimesed.xml"
                TransformSource="~/forInimesed.xslt"/>
        </div>
    </form>
</body>
</html>
