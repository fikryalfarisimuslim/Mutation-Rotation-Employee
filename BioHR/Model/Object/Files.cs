using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BioHR.Model.Object
{
    public class Files
    {
        private int _fileId;
        private string _fileOriginal;
        private string _fileName;
        private string _filePath;
        private string _fileLink;
        private int _fileSize;

        public int FileId { get; set; }
        public string FileOriginal { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string FileLink { get; set; }
        public int FileSize { get; set; }
        public string FileType { get; set; }
        public string ReferenceId { get; set; }
        public string ReferenceCode { get; set; }
    }
}