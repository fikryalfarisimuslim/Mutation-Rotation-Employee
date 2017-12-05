<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/MasterPages/BackEndHorizontal.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BioHR.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cpHead" runat="server">
    <link href="Pages/../Assets/morris.js-0.4.3/morris.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cpMainContent" runat="server">
    <div class="row">
        <div class="col-lg-12">
            <section class="panel">
                <header class="panel-heading">
                    <span> Welcome to BioHR - Human Capital Management System (HCMS)</span>
                </header>
                <div class="panel-body form-horizontal">
                    <%--<asp:Image runat="server" ImageUrl="~/Images/Employee2-Big.jpg" Width="100%"/>--%>
                    <div class="col-lg-6">
                        <%--<div id="hero-bar" class="custom-bar-chart"></div>--%>
                        <div id="hero-bar" class="graph"></div>
                    </div>
                </div>
            </section>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cpScriptLibContent" runat="server">
     <!-- FOR GRAPH -->
    <script src="Pages/../Assets/morris.js-0.4.3/morris.min.js" type="text/javascript"></script>
    <script src="Pages/../Assets/morris.js-0.4.3/raphael-min.js" type="text/javascript"></script>
    <!-- END GRAPH -->
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="cpScriptContent" runat="server">
    <script>
        $(document).ready(function () {
            $.ajax({
                type: "POST",
                url: "Default.aspx/GetGraph",
                async: false,
                data: {},
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (r) {
                    console.log(r.d);
                    var listPosisi = JSON.parse(r.d);
                    $(function () {
                        Morris.Bar({
                            element: 'hero-bar',
                            data: listPosisi,
                            xkey: 'NamaJabatan',
                            ykeys: ['Jumlah'],
                            labels: ['Jumlah'],
                            barRatio: 0.4,
                            xLabelAngle: 35,
                            hideHover: 'auto',
                            barColors: ['#F77B6F']
                        });
                    });
                },
                error: function (xhr, status, error) {
                    console.log(error);
                    console.log(status);
                    console.log(xhr);
                }
            });
        });
    </script>
</asp:Content>
