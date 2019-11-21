<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="autocompleter.aspx.cs" Inherits="XML_inimene_Avtomobilev.computerPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Задание N1</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css">
</head>
<body>
    <div class="container">
        <div class="row">
             <div class="col-12">
                <h1 style="text-align: center;"><i class="fa fa-diamond" aria-hidden="true"></i>AutoCompleter</h1>
            </div>
            <div class="col-12">
                <hr />
              <h1>Вывод Таблицы</h1>
                <form id="form1" runat="server">
                  <div>
                    <div>
                     <asp:Xml ID="xml2" runat="server"
                        DocumentSource="~/autocomplt.xml"
                        TransformSource="~/autocompleter.xslt"/>
                    </div>
                  </div>
                </form>
            </div>
        </div>
    </div>
</body>
</html>
