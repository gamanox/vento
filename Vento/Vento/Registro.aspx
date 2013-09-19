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
        <h5>Nombre</h5>
        <h5>
            <asp:Label ID="lblNombre" runat="server" Text=""></asp:Label>
        </h5>
        <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
        <h5>Fecha de nacimiento</h5>
        <h5>
            <asp:Label ID="lblEdad" runat="server" Text=""></asp:Label>
        </h5>
        <!--<cc1:DatePicker ID="DatePicker1" runat="server" AutoPostBack="true" 
	        Width="100px" PaneWidth="150px">
            <PaneTableStyle BorderColor="#707070" BorderWidth="1px" BorderStyle="Solid" />
            <PaneHeaderStyle BackColor="#0099FF" />
            <TitleStyle ForeColor="White" Font-Bold="true" />
            <NextPrevMonthStyle ForeColor="White" Font-Bold="true" />
            <NextPrevYearStyle ForeColor="#E0E0E0" Font-Bold="true" />
            <DayHeaderStyle BackColor="#E8E8E8" />
            <TodayStyle BackColor="#FFFFCC" ForeColor="#000000" 
	        Font-Underline="false" BorderColor="#FFCC99"/>
            <AlternateMonthStyle BackColor="#F0F0F0" 
	        ForeColor="#707070" Font-Underline="false"/>
            <MonthStyle BackColor="" ForeColor="#000000" Font-Underline="false"/>
        </cc1:DatePicker>-->
        <asp:TextBox ID="txtEdad" runat="server"></asp:TextBox>
        <h5>Lugar de residencia</h5>
        <h5>
            <asp:Label ID="lblResidencia" runat="server" Text=""></asp:Label>
        </h5>
        <asp:TextBox ID="txtResidencia" runat="server"></asp:TextBox>
        <h5>Ocupación</h5>
        <h5>
            <asp:Label ID="lblOcupacion" runat="server" Text=""></asp:Label>
        </h5>
        <asp:TextBox ID="txtOcupacion" runat="server"></asp:TextBox>
        <h5>¿Por qué te gustaría vivir la experiencia?</h5>
        <h5>
            <asp:Label ID="lblExperiencia" runat="server" Text=""></asp:Label>
        </h5>
        <asp:TextBox ID="txtExperiencia" onkeyup="checkLenght();" TextMode="multiline" Columns="50" Rows="8" runat="server"></asp:TextBox>
        <asp:Label ID="lblLimit" runat="server" Text="400"></asp:Label>
        <h5>Correo electrónico</h5>
        <h5>
            <asp:Label ID="lblEmail" runat="server" Text=""></asp:Label>
        </h5>
        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
        <h5>Número telefónico</h5>
        <h5>
            <asp:Label ID="lblTelefono" runat="server" Text=""></asp:Label>
        </h5>
        <asp:TextBox ID="txtTelefono" runat="server"></asp:TextBox>
        </p>
        <br/>
        <p><b>Registro para participar</b><br />
            <asp:CheckBox ID="chbActivo" runat="server" />
        </p>
        <p><b>Registro para seguir las actividades</b><br />
            <asp:CheckBox ID="CheckBox2" runat="server" />
        </p>
        <p>
            <!--<asp:Button ID="btnNext1" CssClass="btn btn-primary" runat="server" Text="Registrar" OnClick="btnNext1_Click" />-->
            <input type="submit" value="Submit" /></p> 

        </p>
    </div>
    </form>
    <script>
        function checkLenght() {
            //$('#lblLimit').html(parseInt($("#lblLimit").html())-1);
            //$('#lblLimit').html(parseInt($("#txtExperiencia").html().length));
            var limit = 0;
            limit = 400 - parseInt($('textarea#txtExperiencia').val().length);
            if(limit < 0)
                limit=0;
            $('#lblLimit').html(limit);
            $('textarea#txtExperiencia').val($('textarea#txtExperiencia').val().substring(0,400));
        }
    </script>
</body>
</html>
