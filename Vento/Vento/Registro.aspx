<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="Vento.Registro" %>
<%@ Register Assembly="SlimeeLibrary" Namespace="SlimeeLibrary" TagPrefix="cc1" %>

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
        <h5>Ocupación</h5>
        <asp:TextBox ID="txtOcupacion" runat="server"></asp:TextBox>
        <h5>¿Por qué te gustaría vivir la experiencia?</h5>
        <asp:TextBox ID="txtExperiencia" TextMode="multiline" Columns="50" Rows="5" runat="server"></asp:TextBox>
        <h5>Correo electrónico</h5>
        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
        <h5>Número telefónico</h5>
        <asp:TextBox ID="txtTelefono" runat="server"></asp:TextBox>
<!--        
        <h5>Fecha Nacimiento</h5>
         <cc1:DatePicker ID="DatePicker1" runat="server" AutoPostBack="true" Width="100px" PaneWidth="150px" EnableViewState="true">
            <PaneTableStyle BorderColor="#707070" BorderWidth="1px" BorderStyle="Solid" />
            <PaneHeaderStyle BackColor="#0099FF" />
            <TitleStyle ForeColor="White" Font-Bold="true" />
            <NextPrevMonthStyle ForeColor="White" Font-Bold="true" />
            <NextPrevYearStyle ForeColor="#E0E0E0" Font-Bold="true" />
            <DayHeaderStyle BackColor="#E8E8E8" />
            <TodayStyle BackColor="#FFFFCC" ForeColor="#000000" Font-Underline="false" BorderColor="#FFCC99"/>
            <AlternateMonthStyle BackColor="#F0F0F0" ForeColor="#707070" Font-Underline="false"/>
            <MonthStyle BackColor="" ForeColor="#000000" Font-Underline="false"/>
        </cc1:DatePicker>
-->
        </p>
        <br/>
        <p><b>Registro para participar</b><br />
            <asp:CheckBox ID="chbActivo" runat="server" />
        </p>
        <p><b>Registro para seguir las actividades</b><br />
            <asp:CheckBox ID="CheckBox2" runat="server" />
        </p>
        <p>
            <asp:Button ID="btnNext1" CssClass="btn btn-primary" runat="server" Text="Registrar" OnClick="btnNext1_Click" />

        </p>
    </div>
    </form>
</body>
</html>
