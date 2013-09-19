<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PruebaManejo.aspx.cs" Inherits="Vento.PruebaManejo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <p>        
        <h5><asp:Label ID="lblMessage" runat="server" Text=""></asp:Label></h5>
        <h5>Nombre</h5>
        <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
        <h5>Edad</h5>
        <asp:TextBox ID="txtEdad" runat="server"></asp:TextBox>
        <h5>Lugar de residencia</h5>
        <asp:TextBox ID="txtResidencia" runat="server"></asp:TextBox>
        <h5>Correo electrónico</h5>
        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
        <h5>Número telefónico</h5>
        <asp:TextBox ID="txtTelefono" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="btnNext1" CssClass="btn btn-primary" runat="server" Text="Solicitar" OnClick="btnNext1_Click" />
        </p>
    </div>
    </form>
</body>
</html>
