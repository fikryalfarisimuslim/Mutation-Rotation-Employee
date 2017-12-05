<%@ Page Title="Upload Attendance Log" Language="C#" MasterPageFile="~/MasterPages/BackEndHorizontal.Master" AutoEventWireup="true" CodeBehind="UploadAttandanceMachine.aspx.cs" Inherits="BioHR.Pages.TimeAdministration.UploadAttandanceMachine" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cpHead" runat="server">
    <link href='<%: ResolveClientUrl("~/Assets/uploadify/uploadify.css") %>' rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMainContent" runat="server">
    <!-- CONTENT PAGE START-->
    <!-- BEGIN Error Panel -->
    <div class="alert alert-block alert-danger fade in" runat="server" id="divFailureMessage" Visible="False">
        <button data-dismiss="alert" class="close close-sm" type="button">
            <i class="icon-remove"></i>
        </button>
        <h4>
            <i class="icon-warning-sign"></i>
            Error !
        </h4>
        <asp:Label runat="server" ID="lbFailureMessage"></asp:Label>
    </div>
    <!-- END Error Panel -->
    <!-- BEGIN Info Panel -->
    <div class="alert alert-block alert-info fade in" runat="server" id="divInfoMessage" Visible="False">
        <button data-dismiss="alert" class="close close-sm" type="button">
            <i class="icon-remove"></i>
        </button>
        <h4>
            <i class="icon-info-sign"></i>
            Info Message !
        </h4>
        <asp:Label runat="server" ID="lbInfoMessage"></asp:Label>
    </div>
    <!-- END Info Panel -->

    <div class="row">
        <div class="col-lg-12">
            <!-- BEGIN Breadcrumbs -->
            <ul class="breadcrumb">
                <li>
                    <a href="../OvertimeAdministration/index.html"><i class="icon-home"></i> Home</a></li>
                <li><a href="#">Attandance Data</a></li>
                <li class="active">Upload Attandance Data</li>
            </ul>
            <!-- END Breadcrumbs -->
        </div>
    </div>
    
    <div class="row">
        <div class="col-lg-8 col-md-6 col-xs-6">
            <section class="panel">
                <header class="panel-heading">
                   <span>Upload Attandance Data</span> 
                    <div class="tools" style="float: right;">
                        <a href="javascript:;" class="icon-chevron-down"></a>
                        <a href="javascript:;" class="reload">
                            <i class="icon-refresh"></i>
                        </a>
                    </div>
                </header>
                <div class="panel-body form-horizontal">
                    <div class="form-group">
                        <label class="control-label col-lg-2 col-sm-2">Upload File</label>
                        <div class="col-lg-7 col-sm-7">
                            <asp:FileUpload ID="FileUpload1" runat="server" />
                        </div>
                    </div>
                    <div>
                    </div>
                    <div class="col-lg-offset-2 col-lg-1 col-sm-1">
                        <asp:Button runat="server" ID="btnImport" Text="View Result" CssClass="btn btn-info" OnClick="btnImport_Click"/>
                    </div>
                    <div class="col-lg-offset-1 col-lg-1 col-sm-1">
                        <asp:Button runat="server" ID="btnUpload" Text="Process" CssClass="btn btn-info" OnClick="btnUpload_Click"/>
                    </div>
                </div>
            </section>
        </div>
    </div>
    
    <div class="row">
        <div class="col-lg-8 col-md-12">
            <section class="panel">
                <header class="panel-heading">
                   <span>Data Log Result</span> 
                    <div class="tools" style="float: right;">
                        <a href="javascript:;" class="icon-chevron-down"></a>
                        <a href="javascript:;" class="reload">
                            <i class="icon-refresh"></i>
                        </a>
                    </div>
                </header>
                <div class="panel-body">
                    <div class="col-lg-8">
                        <asp:GridView runat="server" ID="gvLogResult" ClientIDMode="Static" CssClass="table table-striped table-bordered table-hover" ShowHeaderWhenEmpty="true" AutoGenerateColumns="true" AllowPaging ="True" OnPageIndexChanging="gvLogResult_PageIndexChanging">
                            
                        </asp:GridView>
                        <asp:Label runat="server" ID="lblTotalRow" CssClass="control-label col-lg-4 col-sm-2" />
                    </div>
                </div>
            </section>
        </div>
    </div>
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpScriptLibContent" runat="server">
    <script src='<%: ResolveClientUrl("~/Assets/uploadify/jquery.uploadify.min.js") %>'></script>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cpScriptContent" runat="server">
   <script>
       (function () {
           $('#btnEdit').on('click', function () {
               var dataId = $(this).data('id');
               $('#' + dataId).removeAttr('disabled');
           });

           <%--$(function () {
               $("#<%= fuAttachmentFileIllness.ClientID%>").uploadify({
                   'swf': '<%: ResolveClientUrl("~/Assets/uploadify/uploadify.swf") %>',
                   'buttonText': 'Browse Files',
                   'uploader': '<%: ResolveClientUrl("~/Upload.ashx") %>',
                'removeCompleted': true,
                'multi': true,
                'auto': false,
                'formData': { 'key': 1111 }, // not used - cannot get the value through query string
                'onUploadSuccess': function (file, data, response) {
                    //$('#tbAttachedFiles').append("<tr><td><div class='uploadify-queue-item'>" + file.name + " (" + file.size + "KB) " + "</div></td><td><a href = 'javascript:;'>[x]</a></td></tr>");
                    $('#tbAttachedFiles').append("<tr><td><div class='uploadify-queue-item'><div class='cancel'><a href = 'javascript:;'></a></div><span class='filename'>" + file.name + " (" + file.size + "KB) " + "</div></div></td></tr>");
                }
               });
           });--%>

       })();
   </script> 
</asp:Content>
