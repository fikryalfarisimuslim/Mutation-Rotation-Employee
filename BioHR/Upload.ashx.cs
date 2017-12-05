using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace BioHR
{
    /// <summary>
    /// Summary description for Upload
    /// </summary>
    public class Upload : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Expires = -1;
            context.Response.Write("Hello World");

            try
            {
                //var t = context.Request.QueryString["key"]; // cannot get the key value from front end that was send by HTTP request uploadify
                //List<HttpPostedFile> files = (List<HttpPostedFile>)context.Cache[context.Request.QueryString["key"]];

                /* Check if the Session is null (possibily because it was the first HTTP request), then create instance of object, otherwise assign value from session */
                List<HttpPostedFile> files = (List<HttpPostedFile>)context.Session["biofarma_fileAttachment"] ?? new List<HttpPostedFile>(); // null coalescing operator 
                HttpPostedFile postedFile = context.Request.Files["Filedata"];

                string savepath = "";
                string tempPath = "";
                tempPath = System.Configuration.ConfigurationManager.AppSettings["UploadPath"]; // Get corresponding path from web config with key = UploadPath
                savepath = context.Server.MapPath(tempPath);
                if (postedFile != null)
                {
                    string filename = postedFile.FileName;
                    if (!Directory.Exists(savepath))
                        Directory.CreateDirectory(savepath);

                    postedFile.SaveAs(savepath + @"\" + filename);
                    context.Response.Write(tempPath + "/" + filename);
                    files.Add(postedFile);

                    //context.Session["biofarma_fileName"] += postedFile.FileName + ";";
                    //context.Session["biofarma_fileSize"] += postedFile.ContentLength + ";";
                    //context.Session["biofarma_fileType"] += postedFile.ContentType + ";";

                    context.Session["biofarma_uploadedFileName"] = postedFile.FileName; // save filename for the recet uploaded file
                    context.Session["biofarma_fileAttachment"] = files; // Assign list of uploaded file to Session
                }
                context.Response.StatusCode = 200;
            }
            catch (Exception ex)
            {
                context.Response.Write("Error: " + ex.Message);
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}