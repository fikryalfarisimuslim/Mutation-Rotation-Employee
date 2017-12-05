<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FormPageHorizontal.Master" AutoEventWireup="true" CodeBehind="EmployeeAttendanceLogMachine.aspx.cs" Inherits="BioHR.Pages.MachineAttendance.EmployeeAttendanceLogMachine" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cpHead" runat="server">
    <link rel="stylesheet" type="text/css" href="<%: ResolveClientUrl("~/Assets/bootstrap-datepicker/css/datepicker.css") %>" />
    <link rel="stylesheet" type="text/css" href='<%: ResolveClientUrl("~/Assets/DataTables/Responsive/css/dataTables.responsive.css") %>' />
    <link rel="stylesheet" type="text/css" href='<%: ResolveClientUrl("~/Assets/chosen/css/chosen.css") %>' />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMainContent" runat="server">
    <!-- CONTENT PAGE START-->
    <!-- BEGIN Error Panel -->
    <div class="alert alert-block alert-danger fade in" runat="server" id="divFailureMessage" visible="False">
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
    <div class="alert alert-block alert-info fade in" runat="server" id="divInfoMessage" visible="False">
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
                    <a href="../HcServices/index.html"><i class="icon-home"></i>Home</a></li>
                <li><a href="#">Presensi</a></li>
                <li class="active">Data Presensi Karyawan</li>
            </ul>
            <!-- END Breadcrumbs -->
        </div>
    </div>

    <div class="row">
        <div class="col-lg-12">
            <section class="panel">
                <header class="panel-heading">
                    <span>Masukan Tanggal Presensi</span>
                    <div class="tools" style="float: right;">
                        <a href="javascript:;" class="icon-chevron-down"></a>
                        <!-- <a href="#box-config" data-toggle="modal" class="config">
                                 <i class="icon-cog"></i>
                             </a> -->
                        <a href="javascript:;" class="reload">
                            <i class="icon-refresh"></i>
                        </a>
                    </div>
                </header>
                <div class="panel-body form-horizontal">
                    <div class="form-group">
                        <label class="control-label col-lg-2 col-sm-2">NIK</label>
                        <div class="col-lg-2 col-sm-2">
                            <%--<input type="text" class="form-control" disabled="disabled" value="K460" />--%>
                            <asp:TextBox ID="tbNik" runat="server" CssClass="form-control" ClientIDMode="Static" AutoPostBack="true" OnTextChanged="tbNik_TextChanged"></asp:TextBox>
                        </div>
                        <label class="control-label col-lg-1 col-sm-1">Nama</label>
                        <div class="col-lg-4 col-md-4 col-sm-4">
                            <%--<input type="text" class="form-control" disabled="disabled" value="Awwal Mulyana" />--%>
                            <%--<asp:TextBox ID="tbName" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>--%>
                            <asp:DropDownList ID="ddlName" runat="server" CssClass="chosen-select" ClientIDMode="Static" AutoPostBack="true" OnSelectedIndexChanged="ddlName_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="control-label col-lg-2 col-sm-2">Posisi</label>
                        <div class="col-lg-2 col-sm-2">
                            <%--<input type="text" class="form-control" disabled="disabled" value="">--%>
                            <asp:TextBox ID="tbPosition" runat="server" CssClass="form-control" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                        </div>
                        <label class="control-label col-lg-1 col-sm-1">Unit</label>
                        <div class="col-lg-4 col-sm-4">
                            <%--<input type="text" class="form-control" disabled="disabled" value="System Development Department" />--%>
                            <asp:TextBox ID="tbUnitName" runat="server" CssClass="form-control" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="control-label col-lg-2 col-sm-2">Rentang Tanggal</label>
                        <div class="col-lg-7 col-sm-10">
                            <div class="input-group">
                                <asp:TextBox runat="server" ID="tbDateFrom" CssClass="form-control input-medium startDate dp6"></asp:TextBox>
                                <span class="input-group-addon">s.d</span>
                                <asp:TextBox runat="server" ID="tbDateTo" CssClass="form-control input-medium endDate dp7"></asp:TextBox>
                            </div>
                            <p class="help-block alert" style="display: none;"></p>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-2 col-sm-2"></div>
                        <div class="col-lg-7 col-sm-10">
                            <asp:Button runat="server" ID="btnViewPresence" CssClass="btn btn-info" Text="Lihat Presensi" OnClick="btnViewPresence_OnClick" />
                        </div>
                    </div>
                    <asp:SqlDataSource runat="server" ID="sdsDataKaryawan" ConnectionString='<%$ ConnectionStrings:BioFarmaConnectionString %>' SelectCommand="SELECT PERNR, CNAME, PRORG, PRPOS FROM bioumum.USER_DATA"></asp:SqlDataSource>
                    <asp:SqlDataSource runat="server" ID="sdsDataKaryawanbyPRNR" ConnectionString='<%$ ConnectionStrings:BioFarmaConnectionString %>' SelectCommand="SELECT PERNR, CNAME, PRORG, PRPOS FROM bioumum.USER_DATA where PERNR = @pPERNR">
                        <SelectParameters>
                            <asp:ControlParameter Name="pPERNR" ControlID="ddlName" PropertyName="SelectedValue" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </div>
            </section>
        </div>
        <!-- END OF col-lg-12 -->
    </div>
    <!-- END OF ROW -->

    <div class="row">
        <div class="col-lg-12">
            <section class="panel">
                <header class="panel-heading">
                    <span>Data Presensi Karyawan</span>
                    <div class="tools" style="float: right;">
                        <a href="#box-config" data-toggle="modal" class="config">
                            <i class="icon-cog"></i>
                        </a>
                        <a href="javascript:;" class="reload">
                            <i class="icon-refresh"></i>
                        </a>
                    </div>
                </header>
                <div class="panel-body">
                    <div class="form-group"></div>
                    <asp:GridView ID="gvPresenceData" ClientIDMode="Static" runat="server" CssClass="table table-striped table-bordered table-hover" OnPreRender="gvPresenceData_OnPreRender" OnRowDataBound="gvPresenceData_OnRowDataBound" AutoGenerateColumns="False" ShowHeaderWhenEmpty="True">
                        <Columns>
                            <asp:BoundField DataField="BEGDA" HeaderText="Tanggal" SortExpression="BEGDA" DataFormatString="{0:d}"></asp:BoundField>
                            <asp:BoundField DataField="ClockIn" HeaderText="Jam Masuk" SortExpression="ClockIn"></asp:BoundField>
                            <asp:BoundField DataField="ClockOut" HeaderText="Jam Pulang" SortExpression="ClockOut"></asp:BoundField>
                            <%--<asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status"></asp:BoundField>--%>
                            <asp:TemplateField HeaderText="Status">
                                <ItemTemplate>
                                    <asp:Label runat="server" CssClass='<%# GetLabel(Eval("Status")) %>' Text='<%# Eval("Status") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Catatan" HeaderText="Catatan" SortExpression="Catatan"></asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <%--<asp:HyperLink runat="server" CssClass='<%# GetLabelClass(Eval("Label")) %>' NavigateUrl='<%# GetLabelUrl(Eval("Label"),Eval("BEGDA")) %>'><i class='<%# Eval("Label")%>'></i></asp:HyperLink>--%>
                                    <button id="editable-sample_new" class="btn btn-xs btn-info" data-toggle="modal" data-target="#formEditTypeAttandance" onclick="GetDate($(this));"><i class='<%# Eval("Label")%>'></i></button>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Attendance Status" Visible="False">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lbAttendanceStatus" ClientIDMode="Static" Text='<%# Eval("Label")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            <div style="text-align: center">Data presensi tidak di temukan</div>
                        </EmptyDataTemplate>
                    </asp:GridView>
                    <asp:HiddenField ID="hdnField" runat="server" ClientIDMode="Static" />
                </div>
            </section>
        </div>
        <!-- END OF col-lg-12 -->
    </div>
    <!-- END OF ROW -->
    <asp:SqlDataSource runat="server" ID="sdsDataLogMesinAbsensi" ConnectionString='<%$ ConnectionStrings:BioFarmaConnectionString %>' SelectCommand="SELECT PERNR, CNAME, PRORG, PRPOS FROM bioumum.USER_DATA where PERNR = @pPERNR">
        <SelectParameters>
            <asp:ControlParameter Name="pPERNR" ControlID="ddlName" PropertyName="SelectedValue" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpScriptLibContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cpScriptContent" runat="server">
    <script src='<%: ResolveClientUrl("~/JS/advanced-form-components.js") %>' type="text/javascript"></script>
    <script type="text/javascript" src='<%: ResolveClientUrl("~/JS/DataTable/DataTables-Presence.js") %>'></script>
    <script type="text/javascript" src='<%: ResolveClientUrl("~/Assets/chosen/js/chosen.jquery.js") %>'></script>
    <script>
        var config = {
            '.chosen-select': {},
            '.chosen-select-deselect': { allow_single_deselect: true },
            '.chosen-select-no-single': { disable_search_threshold: 10 },
            '.chosen-select-no-results': { no_results_text: 'Oops, nothing found!' },
            '.chosen-select-width': { width: "95%" }
        };
        for (var selector in config) {
            $(selector).chosen(config[selector]);
        }

        function clearIdentity() {
            $('#ddlAbsensiStatus').attr('value', null);
            $('#tbNotesPresensi').attr('value', null);
        }

        function GetDate(obj) {
            var datePresensi = obj.closest('tr').find('td').eq(0).html();
            var x = document.getElementById('<%= hdnField.ClientID %>');
            x.value = datePresensi;
        }
    </script>
</asp:Content>
