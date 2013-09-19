<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Vento._Default" %>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <script src="Scripts/Own_functions.js"></script>
    <div class="videoframe">
    </div>
    <div class="middleframe">
    <h3>Revise lo siguiente</h3>
        <ol class="round">
            <li class="one">
                <h5>Participa con nosotros.</h5>
                Para poder registrarte y seguir esta aventura, o para participar en el recorrido llena la siguiente forma.
                <a href="Registro.aspx" class="chackbox_880">Dale aquí</a>
            </li>
            <li class="two">
                <h5>Pruébalo</h5>
                Solicita ya tu prueba de manejo.
                <a href="PruebaManejo.aspx" class="chackbox_880">Dale aquí</a>
            </li>
            <li class="three">
                <h5>Otro?</h5>
                Otro lorem ipsum que no me sé.
                <a href="http://go.microsoft.com/fwlink/?LinkId=245143">Dale Aquí</a>
            </li>
        </ol>
    </div>
</asp:Content>
