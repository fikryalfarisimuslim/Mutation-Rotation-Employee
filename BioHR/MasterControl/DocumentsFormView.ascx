<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DocumentsFormView.ascx.cs" Inherits="BioHR.MasterControl.DocumentsFormView" %>

<asp:Panel runat="server" ID="pnDocumentIdentifier" ClientIDMode="Static" CssClass="form-group" Visible="True" Style="display: none">
    <div class="row">
        <div class="col-lg-12">
            <section class="panel nested-panel">
                <div class="panel-body form-horizontal">
                    <div class="form-group">
                        <label class="control-label col-lg-2 col-sm-2">NIK</label>
                        <div class="col-lg-2 col-sm-2">
                            <%--<input type="text" class="form-control" disabled="disabled" value="K460" />--%>
                            <asp:TextBox runat="server" ID="tbNik" ClientIDMode="Static" CssClass="form-control" Enabled="False"></asp:TextBox>
                        </div>
                        <label class="control-label col-lg-1 col-sm-1">Nama</label>
                        <div class="col-lg-4 col-md-4 col-sm-4">
                            <%--<input type="text" class="form-control" disabled="disabled" value="Awwal Mulyana" />--%>
                            <asp:TextBox runat="server" ID="tbName" ClientIDMode="Static" CssClass="form-control" Enabled="False"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="control-label col-lg-2 col-sm-2">Posisi</label>
                        <div class="col-lg-2 col-sm-2">
                            <%--<input type="text" class="form-control" disabled="disabled" value="">--%>
                            <asp:TextBox runat="server" ID="tbPosition" ClientIDMode="Static" CssClass="form-control" Enabled="False"></asp:TextBox>
                        </div>
                        <label class="control-label col-lg-1 col-sm-1">Unit</label>
                        <div class="col-lg-4 col-sm-4">
                            <%--<input type="text" class="form-control" disabled="disabled" value="System Development Department" />--%>
                            <asp:TextBox runat="server" ID="tbUnitName" ClientIDMode="Static" CssClass="form-control" Enabled="False"></asp:TextBox>
                        </div>
                    </div>

                </div>
            </section>
        </div>
        <!-- END OF col-lg-12 -->
    </div>
    <!-- END OF ROW -->
</asp:Panel>
