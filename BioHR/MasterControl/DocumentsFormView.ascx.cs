using BioHR.Controller.Function;
using BioHR.Model.Database;
using BioHR.Model.Dictionary;
using BioHR.Model.Object;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BioHR.MasterControl
{
    public partial class DocumentsFormView : System.Web.UI.UserControl
    {
        // This property will be act as user control attributest that determine what type of document panel need to be shown
        public string DocumentType
        {
            get
            {
                object documentCode = ViewState["DocumentCode"];
                return documentCode.ToString();
            }
            set { ViewState["DocumentCode"] = value; }
        }

        public int DocumentId
        {
            get
            {
                object documentId = ViewState["DocumentId"];
                return Convert.ToInt16(documentId);
            }
            set { ViewState["DocumentId"] = value; }
        }

        #region :: Page Life Cycle Events ::
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void OnPreRender(EventArgs e)
        {
            // We need to call this method within Pre Render event, in order to get access to DocumentId and DocumentType property
        }

        #endregion

        #region :: UserControl General Function ::

        #endregion

        #region :: Document Form Data Initialization Function ::
        
        #endregion

        #region :: Data Catalog Service Region ::

        #endregion

        #region :: Attachment file Function ::
        public List<Files> GetAttachmentFiles(int docId, string docCd)
        {

            var errorMessage = "";
            var listFiles = new List<Files>();

            try
            {
                listFiles = DocumentFlowDataCatalog.GetDocumentFileAttacment(docId, docCd);
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }

            return listFiles;
        }
        public List<ListItem> ConstructAttachmentLink(List<Files> listFiles)
        {
            List<ListItem> files = new List<ListItem>();
            foreach (var file in listFiles)
            {
                files.Add(new ListItem(file.FileLink));
            }
            return files;
        }

        public string GetIconByExtension(string filename)
        {
            string icon = "<i class='fa fa-file'></i>";
            string[] tokens = filename.Split('.');
            int max = tokens.Length;
            max = max - 1;

            if (tokens[max].Equals("jpg") || tokens[max].Equals("png") || tokens[max].Equals("JPG") || tokens[max].Equals("PNG") || tokens[max].Equals("JPEG"))
            {
                icon = "<i class='fa fa-file-image-o'></i>";
            }
            else if (tokens[max].Equals("pdf"))
            {
                icon = "<i class='fa fa-file-pdf-o text-danger'></i>";
            }

            return icon;
        }
        public string GetName(string filename)
        {
            string filePath = "";
            string[] tokens = filename.Split('/');
            int max = tokens.Length;
            if (max >= 2)
            {
                filePath = tokens[max - 2];
            }
            else
            {
                filePath = filename;
            }

            return filePath;
        }
        #endregion
    }
}