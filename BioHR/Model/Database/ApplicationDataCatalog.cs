using System;
using System.Collections.Generic;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Xml.Linq;
using BioHR.Controller.Function;
using BioHR.Controller.Database;
using BioHR.Model.Object;
using System.Globalization;

namespace BioHR.Model.Database
{

    public class ApplicationDataCatalog : DatabaseSql
    {
        public static DataTable GetParameterRelationData(string relationType, string parentCode, string childCode)
        {
            SqlConnection conn = GetConnectionMaster();
            SqlCommand cmd = GetCommand();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dtParameterRelation = new DataTable();

            try
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = "EXEC bioumum.sp_GetDataParameterRelation @pRELTY,@pPRTKD,@pCLDKD;";
                cmd.CommandTimeout = 200;

                cmd.Parameters.AddWithValue("@pRELTY", relationType);
                cmd.Parameters.AddWithValue("@pPRTKD", parentCode);
                cmd.Parameters.AddWithValue("@pCLDKD", childCode);

                adapter.SelectCommand = cmd;
                adapter.Fill(dtParameterRelation);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                conn.Close();
                cmd.Dispose();
                conn.Dispose();
            }
            return dtParameterRelation;
        }

        public static DataTable GetParameterData(string parameterType)
        {
            SqlConnection conn = GetConnectionMaster();
            SqlCommand cmd = GetCommand();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dtParameter = new DataTable();

            try
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = "EXEC bioumum.sp_GetDataParameter @pPRMTY;";
                cmd.CommandTimeout = 200;

                cmd.Parameters.AddWithValue("@pPRMTY", parameterType);

                adapter.SelectCommand = cmd;
                adapter.Fill(dtParameter);
            }
            finally
            {
                conn.Close();
                cmd.Dispose();
                conn.Dispose();
            }
            return dtParameter;
        }

        internal static object GetConfigMachine()
        {
            throw new NotImplementedException();
        }
    }

    public class DocumentFlowDataCatalog : DatabaseSql
    {
        public static void CreateDocumentDraft(int documentId, string documentCode)
        {
           
        }

        public static void ChangeDocumentStatus(string nik, int documentId, string documentCode, string action)
        {
            SqlConnection conn = GetConnection();
            SqlCommand cmd = GetCommand();

            try
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = "EXEC biohr.sp_WORKFLOW_MAINTAIN_DOCSTATUS @pBEGDA, @pENDDA, @pPERNR, @pDOCID, @pDOCCD, @pACTION ;";
                cmd.CommandTimeout = 200;

                cmd.Parameters.Add("@pBEGDA", SqlDbType.Date);
                cmd.Parameters.Add("@pENDDA", SqlDbType.Date);
                cmd.Parameters.Add("@pPERNR", SqlDbType.VarChar, 30);
                cmd.Parameters.Add("@pDOCID", SqlDbType.Int);
                cmd.Parameters.Add("@pDOCCD", SqlDbType.VarChar, 30);
                cmd.Parameters.Add("@pACTION", SqlDbType.VarChar, 30);

                cmd.Parameters["@pBEGDA"].Value = DateTimeReferences.GetTodayDate().ToString();
                cmd.Parameters["@pENDDA"].Value = DateTimeReferences.GetMaxDate().ToString();
                cmd.Parameters["@pPERNR"].Value = nik;
                cmd.Parameters["@pDOCID"].Value = documentId;
                cmd.Parameters["@pDOCCD"].Value = documentCode;

                cmd.ExecuteNonQuery(); 
            }
            finally
            {
                conn.Close();
                cmd.Dispose();
                conn.Dispose();
            }
        }

        public static void SetDocumentFileAttacment(int documentId, string documentCode, XDocument xmlDataDocument)
        {
            SqlConnection conn = GetConnection();
            SqlCommand cmd = GetCommand();

            try
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = @"biohr.sp_SET_DOC_FILE_ATTACHMENT";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 200;

                cmd.Parameters.Add("@pBEGDA", SqlDbType.Date);
                cmd.Parameters.Add("@pENDDA", SqlDbType.Date);
                cmd.Parameters.Add("@pDOCID", SqlDbType.Int);
                cmd.Parameters.Add("@pDOCCD", SqlDbType.VarChar, 30);
                //cmd.Parameters.Add("@pFILNM", SqlDbType.VarChar, 200);
                //cmd.Parameters.Add("@pFILOR", SqlDbType.VarChar, 250);
                //cmd.Parameters.Add("@pFLPTH", SqlDbType.VarChar, 300);
                //cmd.Parameters.Add("@pFILSZ", SqlDbType.VarChar, 20);
                cmd.Parameters.AddWithValue("@pUSRDT", HttpContext.Current.Session["biofarma_userid"]);

                cmd.Parameters["@pBEGDA"].Value = DateTimeReferences.GetTodayDate().ToString();
                cmd.Parameters["@pENDDA"].Value = DateTimeReferences.GetMaxDate().ToString();
                cmd.Parameters["@pDOCID"].Value = documentId;
                cmd.Parameters["@pDOCCD"].Value = documentCode;
                cmd.Parameters.Add("@pDETDOC", SqlDbType.Xml).Value = xmlDataDocument.ToString();
                //cmd.Parameters["@pFILNM"].Value = fileOriginal;
                //cmd.Parameters["@pFILOR"].Value = fileName;
                //cmd.Parameters["@pFLPTH"].Value = filePath;
                //cmd.Parameters["@pFILSZ"].Value = fileSize.ToString();

                cmd.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
                cmd.Dispose();
                conn.Dispose();
            }

        }

        public static List<Files> GetDocumentFileAttacment(int documentId, string documentCode)
        {
            SqlConnection conn = GetConnection();
            SqlCommand cmd = GetCommand();
            List<Files> listFiles = new List<Files>();

            try
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = @"biohr.sp_GET_DOC_FILE_ATTACHMENT";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 200;

                cmd.Parameters.Add("@pDOCID", SqlDbType.Int);
                cmd.Parameters.Add("@pDOCCD", SqlDbType.VarChar, 30);

                cmd.Parameters["@pDOCID"].Value = documentId;
                cmd.Parameters["@pDOCCD"].Value = documentCode;

                SqlDataReader reader = GetDataReader(cmd);

                while (reader.Read())
                {
                    var value = new Files();
                    value.FileId = Convert.ToInt16(reader["FILID"]);
                    value.FileOriginal = reader["FILNM"].ToString();
                    value.FileName = reader["FILOR"].ToString();
                    value.FilePath = reader["FLPTH"].ToString();
                    value.FileLink = reader["FLATM"].ToString();

                    listFiles.Add(value);
                }

            }
            finally
            {
                conn.Close();
                cmd.Dispose();
                conn.Dispose();
            }

            return listFiles;

        }

        public static List<Files> GetDocumentFileAttacmentEss(int documentId, string documentCode)
        {
            SqlConnection conn = GetConnectionEss();
            SqlCommand cmd = GetCommand();
            List<Files> listFiles = new List<Files>();

            try
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = @"bioess.sp_GET_DOC_FILE_ATTACHMENT";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 200;

                cmd.Parameters.Add("@pDOCID", SqlDbType.Int);
                cmd.Parameters.Add("@pDOCCD", SqlDbType.VarChar, 30);

                cmd.Parameters["@pDOCID"].Value = documentId;
                cmd.Parameters["@pDOCCD"].Value = documentCode;

                SqlDataReader reader = GetDataReader(cmd);

                while (reader.Read())
                {
                    var value = new Files();
                    value.FileId = Convert.ToInt16(reader["FILID"]);
                    value.FileOriginal = reader["FILNM"].ToString();
                    value.FileName = reader["FILOR"].ToString();
                    value.FilePath = reader["FLPTH"].ToString();
                    value.FileLink = reader["FLATM"].ToString();

                    listFiles.Add(value);
                }

            }
            finally
            {
                conn.Close();
                cmd.Dispose();
                conn.Dispose();
            }

            return listFiles;

        }
    }

    public class OvertimeCatalog : DatabaseSql
    {
        public static DataTable GetDocOvertimeProposal(int docid, string doccd)
        {
            SqlConnection conn = GetConnectionEss();
            SqlCommand cmd = GetCommand();

            var adapter = new SqlDataAdapter();
            var dataDocOvertimeProposal = new DataTable();

            try
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = @"bioess.sp_GET_DOC_OVERTIME_PROPOSAL";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@pDOCID", SqlDbType.Int, int.MaxValue).Value = docid;
                cmd.Parameters.Add("@pDOCCD", SqlDbType.VarChar, 30).Value = doccd;

                adapter.SelectCommand = cmd;
                adapter.Fill(dataDocOvertimeProposal);
            }
            finally
            {
                conn.Close();
                cmd.Dispose();
                conn.Dispose();
            }

            return dataDocOvertimeProposal;
        }
        public static DataTable GetDataOverTimeUserMonthly(string period, string pyare)
        {
            SqlConnection conn = GetConnection();
            SqlCommand cmd = GetCommand();

            var adapter = new SqlDataAdapter();
            var data = new DataTable();

            try
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = @"[bioPayroll].[sp_GET_OvertimeUserMonthly]";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@pPRIOD", SqlDbType.VarChar, 7).Value = period;
                cmd.Parameters.Add("@pPYARE", SqlDbType.VarChar, 3).Value = pyare;

                adapter.SelectCommand = cmd;
                adapter.Fill(data);
            }
            finally
            {
                conn.Close();
                cmd.Dispose();
                conn.Dispose();
            }

            return data;
        }
        public static DataTable GetDocOvertimeProcess(int docid, string doccd)
        {
            SqlConnection conn = GetConnectionEss();
            SqlCommand cmd = GetCommand();

            var adapter = new SqlDataAdapter();
            var dataDocOvertimeProcess = new DataTable();

            try
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = @"bioess.sp_GET_DOC_OVERTIME_PROCESS";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@pDOCID", SqlDbType.Int, int.MaxValue).Value = docid;
                cmd.Parameters.Add("@pDOCCD", SqlDbType.VarChar, 30).Value = doccd;

                adapter.SelectCommand = cmd;
                adapter.Fill(dataDocOvertimeProcess);
            }
            finally
            {
                conn.Close();
                cmd.Dispose();
                conn.Dispose();
            }

            return dataDocOvertimeProcess;
        }
        public static DataTable GetDataRecapPayroll(string period, string pYare)
        {
            SqlConnection conn = GetConnection();
            SqlCommand cmd = GetCommand();

            var adapter = new SqlDataAdapter();
            var data = new DataTable();

            try
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = @"bioPayroll.[sp_GET_DataRecapPayroll]";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@pPYARE", SqlDbType.VarChar, 3).Value = pYare;
                cmd.Parameters.Add("@pPRIOD", SqlDbType.VarChar, 7).Value = period;
                cmd.Parameters.Add("@pWTYPE", SqlDbType.VarChar, 7).Value = "S559";

                adapter.SelectCommand = cmd;
                adapter.Fill(data);
            }
            finally
            {
                conn.Close();
                cmd.Dispose();
                conn.Dispose();
            }

            return data;
        }
        public static DataTable GetRecapOvertimeProcess(string tglMulai, string tglAkhir)
        {
            SqlConnection conn = GetConnectionHr();
            SqlCommand cmd = GetCommand();

            var adapter = new SqlDataAdapter();
            var dtRecapOvertime = new DataTable();

            try
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = @"biohr.usp_Get_OvertimeRecap";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@pDETFR", SqlDbType.VarChar, 30).Value = tglMulai;
                cmd.Parameters.Add("@pDETTO", SqlDbType.VarChar, 30).Value = tglAkhir;

                adapter.SelectCommand = cmd;
                adapter.Fill(dtRecapOvertime);
            }
            finally
            {
                conn.Close();
                cmd.Dispose();
                conn.Dispose();
            }

            return dtRecapOvertime;
        }
    }
    /* End of Manual Document Processing Part */

    public class PresenceCatalog : DatabaseSql
    {
        public static string ProcessAttendanceLog()
        {
            SqlConnection conn = GetConnection();
            SqlCommand cmd = GetCommand();
            string result;

            try
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = @"biopresensi.sp_PROCESS_ATTENDANCE_LOG";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 3600;

                cmd.Parameters.AddWithValue("@pUSRDT", HttpContext.Current.Session["biofarma_userid"]);

                //cmd.ExecuteNonQuery();
                result = cmd.ExecuteScalar().ToString();
            }
            finally
            {
                conn.Close();
                cmd.Dispose();
                conn.Dispose();
            }

            return result;
        }
    }

    public class GeneralDataCatalog : DatabaseSql
    {
        public static string[] GetEmployeeIdentity(string nik)
        {
            SqlConnection conn = GetConnectionMaster();
            SqlCommand cmd = GetCommand();
            string[] identity = null;

            try
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = @"SELECT BEGDA, ENDDA, PERNR, CNAME, PRPOS, PRORG  
                                    FROM   bioumum.USER_DATA
                                    WHERE  PERNR = @pPERNR";

                cmd.Parameters.Add("@pPERNR", SqlDbType.VarChar, 15).Value = nik;

                SqlDataReader reader = GetDataReader(cmd);
                while (reader.Read())
                {
                    string[] values = { reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString() };
                    identity = values;
                }
            }
            finally
            {
                conn.Close();
                cmd.Dispose();
                conn.Dispose(); 
            }

            return identity; 
        }

    }

    /* Emil Part */
    public class DataPersonal : DatabaseSql
    {
        public static string MaintainPersonalData(string PERNR, string CNAME, string NICNM, string BRNCT, string BRNDT, string GENDR, string RELIG, string LANGU, string NATIO, string TRIBE, string BLOOD, string BLDRH, string HEIGH, string WEIGH, string MRTST, string MRTDT, string PERRF, string USRDT, string ACTIO)
        {
            SqlConnection conn = GetConnection();
            SqlCommand cmd = GetCommand();
            string outputMessage = null;

            try
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = @"bioHR.SP_Maintain_Pribadi";
                cmd.CommandType = CommandType.StoredProcedure;

                //cmd.Parameters.AddWithValue("@pBEGDA", BEGDA);
                //cmd.Parameters.AddWithValue("@pENDDA", ENDDA);
                cmd.Parameters.AddWithValue("@pPERNR", PERNR);
                cmd.Parameters.AddWithValue("@pCNAME", CNAME);
                cmd.Parameters.AddWithValue("@pNICNM", NICNM);
                cmd.Parameters.AddWithValue("@pBRNCT", BRNCT);
                cmd.Parameters.AddWithValue("@pBRNDT", BRNDT);
                cmd.Parameters.AddWithValue("@pGENDR", GENDR);
                cmd.Parameters.AddWithValue("@pRELIG", RELIG);
                cmd.Parameters.AddWithValue("@pLANGU", LANGU);
                cmd.Parameters.AddWithValue("@pNATIO", NATIO);
                cmd.Parameters.AddWithValue("@pTRIBE", TRIBE);
                cmd.Parameters.AddWithValue("@pBLOOD", BLOOD);
                cmd.Parameters.AddWithValue("@pBLDRH", BLDRH);
                cmd.Parameters.AddWithValue("@pHEIGH", HEIGH);
                cmd.Parameters.AddWithValue("@pWEIGH", WEIGH);
                cmd.Parameters.AddWithValue("@pMRTST", MRTST);
                cmd.Parameters.AddWithValue("@pMRTDT", MRTDT);
                cmd.Parameters.AddWithValue("@pPERRF", PERRF);
                cmd.Parameters.AddWithValue("@pACTIO", ACTIO);
                cmd.Parameters.AddWithValue("@pUSRDT", USRDT);
                cmd.Parameters.Add("@pPESAN", SqlDbType.VarChar, 300).Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();
                
                outputMessage = cmd.Parameters["@pPESAN"].Value.ToString();
            }
            finally
            {
                conn.Close();
                cmd.Dispose();
                conn.Dispose();
            }

            return outputMessage;
        }

        public static PersonData GetDataFormPersonalData(string nik)
        {
            SqlConnection conn = GetConnection();
            SqlCommand cmd = GetCommand();
            var dtPersonData = new PersonData();

            try
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = @"biohr.sp_GET_Data_PersonalData";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@pPERNR", nik);

                SqlDataReader reader = GetDataReader(cmd);
                while (reader.Read())
                {
                    dtPersonData.BeginDate = reader["BEGDA"].ToString();
                    dtPersonData.EndDate = reader["ENDDA"].ToString();
                    dtPersonData.Nik = reader["PERNR"].ToString();
                    dtPersonData.Name = reader["CNAME"].ToString();
                    dtPersonData.NickName = reader["NICNM"].ToString();
                    dtPersonData.BirthPlace = reader["BRNCT"].ToString();
                    dtPersonData.BirthDate = reader["BRNDT"].ToString();
                    dtPersonData.Gender = reader["GENDR"].ToString();
                    dtPersonData.Religion = reader["RELIG"].ToString();
                    dtPersonData.Language = reader["LANGU"].ToString();
                    dtPersonData.Nationality = reader["NATIO"].ToString();
                    dtPersonData.Tribe = reader["TRIBE"].ToString();
                    dtPersonData.BloodType = reader["BLOOD"].ToString();
                    dtPersonData.BloodRhesus = reader["BLDRH"].ToString();
                    dtPersonData.Height = reader["HEIGH"].ToString();
                    dtPersonData.Weight = reader["WEIGH"].ToString();
                    dtPersonData.MaritalStatus = reader["MRTST"].ToString();
                    dtPersonData.MaritalDate = reader["MRTDT"].ToString();
                    dtPersonData.PersonalNumberReference = reader["PERRF"].ToString();
                    
                }
            }
            finally
            {
                conn.Close();
                cmd.Dispose();
                conn.Dispose();}
            return dtPersonData;
        }
        public static DataTable GetDataTableFormPersonalData(string nik)
        {
            SqlConnection conn = GetConnection();
            SqlCommand cmd = GetCommand();
            var adapter = new SqlDataAdapter();
            var dtPersonData = new DataTable();

            try
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = @"biohr.sp_GET_Data_PersonalData";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@pPERNR", nik);

                adapter.SelectCommand = cmd;
                adapter.Fill(dtPersonData);
                
            }
            finally
            {
                conn.Close();
                cmd.Dispose();
                conn.Dispose();
            }
            return dtPersonData;
        }
        public static DataTable GetDataFormCurriculumVitae(string nik)
        {
            SqlConnection conn = GetConnection();
            SqlCommand cmd = GetCommand();
            var adapter = new SqlDataAdapter();
            var dtPersonData = new DataTable();

            try
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = @"biohr.usp_Get_RiwayatKarir_Print";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@pPERNR", nik);

                adapter.SelectCommand = cmd;
                adapter.Fill(dtPersonData);
            }
            finally
            {
                conn.Close();
                cmd.Dispose();
                conn.Dispose();
            }
            return dtPersonData;
        }
    }

    public class DataIdentity : DatabaseSql
    {

        public static Files GetEmployeePhoto(string nik)
        {
            SqlConnection conn = GetConnection();
            SqlCommand cmd = GetCommand();
            Files filePhoto = new Files();

            try
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = @"biohr.sp_GET_Data_EmployeePhoto";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@pPERNR", nik);

                SqlDataReader reader = GetDataReader(cmd);

                while (reader.Read())
                {
                    filePhoto.FileId = Convert.ToInt32(reader["FILID"]);
                    filePhoto.FileName = reader["FILNM"].ToString();
                    filePhoto.FileOriginal = reader["FILOR"].ToString();
                    filePhoto.FilePath = reader["FLPTH"].ToString();
                    filePhoto.FileSize = Convert.ToInt32(reader["FILSZ"]);
                    filePhoto.FileType = reader["FLTYP"].ToString();
                    filePhoto.ReferenceId = reader["REFID"].ToString();
                    filePhoto.ReferenceCode = reader["REFCD"].ToString();
                }

            }
            finally
            {
                conn.Close();
                cmd.Dispose();
                conn.Dispose();
            }

            return filePhoto;
        }
    }

    public class DataTax : DatabaseSql
    {
        public static TaxObject GetTaxEmployee(string nik)
        {
            SqlConnection conn = GetConnection();
            SqlCommand cmd = GetCommand();
            var dt = new TaxObject();

            try
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = @"biohr.sp_GET_EmployeeTax";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@pPERNR", nik);

                SqlDataReader reader = GetDataReader(cmd);
                while (reader.Read())
                {
                    dt.BeginDate = reader["BEGDA"].ToString();
                    dt.EndDate = reader["ENDDA"].ToString();
                    dt.Nik = reader["PERNR"].ToString();
                    dt.TaxId = reader["TAXID"].ToString();
                    dt.TaxDate = reader["TAXDT"].ToString();
                    dt.TaxMarried = reader["TAXMR"].ToString();
                    dt.SpouseBenefit = reader["SPOBN"].ToString();
                    dt.TaxNumberFamily = reader["TAXKP"].ToString();

                }
            }
            finally
            {
                conn.Close();
                cmd.Dispose();
                conn.Dispose();
            }
            return dt;
        }
    }

    public class DataEducation : DatabaseSql
    {

        public static DataTable GetDataGvEducation(string PERNR)
        {
            SqlConnection conn = GetConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dtEducation = new DataTable();

            try
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = @"bioHR.sp_GET_Gridview_Pendidikan";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@pPERNR", PERNR);

                adapter.SelectCommand = cmd;
                adapter.Fill(dtEducation);
            }
            finally
            {
                conn.Close();
                cmd.Dispose();
                conn.Dispose();
            }

            return dtEducation;
        }

        public static EducationObject GetDataFormEducation(string nik, string begda, string endda, string edulv)
        {
            SqlConnection conn = GetConnection();
            SqlCommand cmd = GetCommand();
            var dtEducation = new EducationObject();

            try
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = @"biohr.sp_GET_Data_Education";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@pPERNR", nik);
                cmd.Parameters.AddWithValue("@pBEGDA", begda);
                cmd.Parameters.AddWithValue("@pENDDA", endda);
                cmd.Parameters.AddWithValue("@pEDULV", edulv);

                SqlDataReader reader = GetDataReader(cmd);
                while (reader.Read())
                {
                    dtEducation.BeginDate = reader["BEGDA"].ToString();
                    dtEducation.EndDate = reader["ENDDA"].ToString();
                    dtEducation.EducationCertificate = reader["EDUCR"].ToString();
                    dtEducation.EducationDate = reader["EDUDT"].ToString();

                    dtEducation.EducationFaculty = reader["EDUFC"].ToString();
                    dtEducation.EducationFound = reader["EDUFE"].ToString();
                    dtEducation.EducationInstitution = reader["EDUIN"].ToString();
                    dtEducation.EducationCity = reader["EDUCT"].ToString();
                    dtEducation.EducationLevel = reader["EDULV"].ToString().Trim();
                    dtEducation.EducationMajor = reader["EDUBR"].ToString().Trim();
                    dtEducation.EducationRecognition = reader["EDUNO"].ToString();
                    dtEducation.InstitutionName = reader["INTNM"].ToString().Trim();
                    dtEducation.EducationSubMajor = reader["EDUMR"].ToString().Trim();
                }
            }
            finally
            {
                conn.Close();
                cmd.Dispose();
                conn.Dispose();
            }
            return dtEducation;
        }

    }
    /* End of Willy Part */    

    /* Payroll Processing Part */

    /* End of Payroll Processing Part */

    /* Overtime Processing Part */
    public class OverTimeProcessing : DatabaseSql
    {
        public static DataTable GetDataRecapOverTime(string period, string pYare)
        {
            SqlConnection conn = GetConnection();
            SqlCommand cmd = GetCommand();

            var adapter = new SqlDataAdapter();
            var data = new DataTable();

            try
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = @"bioPayroll.[sp_GET_DataRecapOverTime]";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@pPYARE", SqlDbType.VarChar, 3).Value = pYare;
                cmd.Parameters.Add("@pPRIOD", SqlDbType.VarChar, 7).Value = period;

                adapter.SelectCommand = cmd;
                adapter.Fill(data);
            }
            finally
            {
                conn.Close();
                cmd.Dispose();
                conn.Dispose();
            }

            return data;
        }
    }

    /* End of Overtime Processing Part */
    public class ReportCatalog : DatabaseSql
    {

        public static DataSet GetDataReportCurriculumVitae(string nik)
        {
            DataSet data = new DataSet();
            DataTable dtCurriculumVitae = DataPersonal.GetDataFormCurriculumVitae(nik);
            DataTable dtPersonalData = DataPersonal.GetDataTableFormPersonalData(nik);
            TaxObject tax = DataTax.GetTaxEmployee(nik);
            Files file = DataIdentity.GetEmployeePhoto(nik);

            data.Tables.Add("PersonalData");
            data.Tables["PersonalData"].Columns.Add("PERNR", typeof(string));
            data.Tables["PersonalData"].Columns.Add("NNIK", typeof(string));
            data.Tables["PersonalData"].Columns.Add("CNAME", typeof(string));
            data.Tables["PersonalData"].Columns.Add("PRORG", typeof(string));
            data.Tables["PersonalData"].Columns.Add("DIVNM", typeof(string));
            data.Tables["PersonalData"].Columns.Add("BRNCT", typeof(string));
            data.Tables["PersonalData"].Columns.Add("BRNDT", typeof(string));
            data.Tables["PersonalData"].Columns.Add("AKUI", typeof(string));
            data.Tables["PersonalData"].Columns.Add("AGE", typeof(string));
            data.Tables["PersonalData"].Columns.Add("GENDR", typeof(string));
            data.Tables["PersonalData"].Columns.Add("AGAMA", typeof(string));
            data.Tables["PersonalData"].Columns.Add("BLOOD", typeof(string));
            data.Tables["PersonalData"].Columns.Add("MRTST", typeof(string));
            data.Tables["PersonalData"].Columns.Add("NATIO", typeof(string));
            data.Tables["PersonalData"].Columns.Add("TRIBE", typeof(string));
            data.Tables["PersonalData"].Columns.Add("TAXID", typeof(string));
            data.Tables["PersonalData"].Columns.Add("ADDRS", typeof(string));
            data.Tables["PersonalData"].Columns.Add("KODEPOS", typeof(string));
            data.Tables["PersonalData"].Columns.Add("NUMHP", typeof(string));
            data.Tables["PersonalData"].Columns.Add("EMAIL", typeof(string));
            data.Tables["PersonalData"].Columns.Add("WEIGH", typeof(string));
            data.Tables["PersonalData"].Columns.Add("HEIGH", typeof(string));
            data.Tables["PersonalData"].Columns.Add("PHOTO", typeof(string));

            DateTime today = DateTime.Today;
            DateTime bornDate = Convert.ToDateTime(dtPersonalData.Rows[0]["BRNDT"]);
            int months = today.Month - bornDate.Month;
            int years = today.Year - bornDate.Year;

            if (today.Day < bornDate.Day)
            {
                months--;
            }

            if (months < 0)
            {
                years--;
                months += 12;
            }

            string tglLahir = Convert.ToDateTime(dtPersonalData.Rows[0]["BRNDT"]).ToString("d-MMM-yyyy", CultureInfo.CreateSpecificCulture("id-ID"));
            string umur = years.ToString()+" Thn | "+months.ToString()+" Bln";
            string gender = dtPersonalData.Rows[0]["GENDR"].ToString() == "L" ? "Laki-Laki" : "Perempuan";
            data.Tables["PersonalData"].Rows.Add(new object[] { dtCurriculumVitae.Rows[0]["PERNR"].ToString(), dtCurriculumVitae.Rows[0]["NNIK"].ToString(), dtPersonalData.Rows[0]["CNAME"].ToString(), dtCurriculumVitae.Rows[0]["PRPOS"].ToString(), dtCurriculumVitae.Rows[0]["DIVISI"].ToString(), dtPersonalData.Rows[0]["BRNCT"].ToString(), tglLahir, dtCurriculumVitae.Rows[0]["AKUI"].ToString(), umur, gender, dtPersonalData.Rows[0]["AGAMA"].ToString(), dtPersonalData.Rows[0]["BLOOD"].ToString() + dtPersonalData.Rows[0]["BLDRH"].ToString(), dtPersonalData.Rows[0]["MARITAL"].ToString(), dtPersonalData.Rows[0]["BANGSA"].ToString(), dtPersonalData.Rows[0]["SUKU"].ToString(), tax.TaxId, dtCurriculumVitae.Rows[0]["ALAMAT"].ToString(), dtCurriculumVitae.Rows[0]["KODEPOS"].ToString(), dtCurriculumVitae.Rows[0]["NUMHP"].ToString(), dtCurriculumVitae.Rows[0]["EMAIL"].ToString(), dtCurriculumVitae.Rows[0]["WEIGH"].ToString() + "kg", dtCurriculumVitae.Rows[0]["HEIGH"].ToString() + "cm",file.FilePath+"/"+file.FileName });

            DataTable dtEducation = DataEducation.GetDataGvEducation(nik);
            data.Tables.Add("Education");
            data.Tables["Education"].Columns.Add("EDULV", typeof(string));
            data.Tables["Education"].Columns.Add("EDUJR", typeof(string));
            data.Tables["Education"].Columns.Add("EDUNM", typeof(string));
            data.Tables["Education"].Columns.Add("YEAR", typeof(string));
            data.Tables["Education"].Columns.Add("IPK", typeof(string));
            data.Tables["Education"].Columns.Add("AKREDITASI", typeof(string));

            for (int i = 0; i < dtEducation.Rows.Count; i++)
            {
                string year = Convert.ToDateTime(dtEducation.Rows[i]["BEGDA"]).Year.ToString();
                data.Tables["Education"].Rows.Add(new object[] { dtEducation.Rows[i]["EDULV"].ToString(), dtEducation.Rows[i]["EDUJR"].ToString(), dtEducation.Rows[i]["EDUNM"].ToString(), year, "-","-" });
            }

            DataTable dtRiwayat = GetDataCurriculumVitae(nik);
            data.Tables.Add("riwayat");
            data.Tables["riwayat"].Columns.Add("BEGDA", typeof(string));
            data.Tables["riwayat"].Columns.Add("SKNUM", typeof(string));
            data.Tables["riwayat"].Columns.Add("SKNME", typeof(string));
            data.Tables["riwayat"].Columns.Add("PSGRP", typeof(string));
            data.Tables["riwayat"].Columns.Add("EDULV", typeof(string));
            data.Tables["riwayat"].Columns.Add("PSTLV", typeof(string));
            data.Tables["riwayat"].Columns.Add("SEKSI", typeof(string));
            data.Tables["riwayat"].Columns.Add("BAGNM", typeof(string));
            data.Tables["riwayat"].Columns.Add("DVSNM", typeof(string));
            data.Tables["riwayat"].Columns.Add("DIRKT", typeof(string));

            for (int i = 0; i < dtRiwayat.Rows.Count; i++)
            {
                string date = Convert.ToDateTime(dtRiwayat.Rows[i]["BEGDA"]).ToString("dd-MMM-yyyy", CultureInfo.CreateSpecificCulture("id-ID"));
                data.Tables["riwayat"].Rows.Add(new object[] { date, dtRiwayat.Rows[i]["SKNUM"].ToString(), dtRiwayat.Rows[i]["SKNME"].ToString(), dtRiwayat.Rows[i]["PSGRP"].ToString(), dtRiwayat.Rows[i]["EDULV"].ToString(), dtRiwayat.Rows[i]["PSTNM"].ToString(), "Seksi: " + dtRiwayat.Rows[i]["SEKSI"].ToString(), "Bagian: " + dtRiwayat.Rows[i]["BAGNM"].ToString(), "Divisi: " + dtRiwayat.Rows[i]["DVSNM"].ToString(), "Direktorat: " + dtRiwayat.Rows[i]["DIRKT"].ToString() });
            }
                
            


            return data;
        }
        public static DataTable GetDataCurriculumVitae(string nik)
        {
            SqlConnection conn = GetConnection();
            SqlCommand cmd = GetCommand();
            var adapter = new SqlDataAdapter();
            var dtPersonData = new DataTable();

            try
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = @"biohr.usp_Get_RiwayatKarir";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@pPERNR", nik);

                adapter.SelectCommand = cmd;
                adapter.Fill(dtPersonData);
            }
            finally
            {
                conn.Close();
                cmd.Dispose();
                conn.Dispose();
            }
            return dtPersonData;
        }
    }

    public class TravelCatalog : DatabaseSql
    {
        
        public static string[] GetDocEmployeeTravel(int docid, string doccd)
        {
            SqlConnection conn = GetConnectionEss();
            SqlCommand cmd = GetCommand();
            string[] dataDoc = null;

            try
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = @"biosppd.sp_GET_DOC_SPPD_FORM";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@pDOCID", SqlDbType.Int, int.MaxValue).Value = docid;
                cmd.Parameters.Add("@pDOCCD", SqlDbType.VarChar, 30).Value = doccd;

                SqlDataReader reader = GetDataReader(cmd);
                while (reader.Read())
                {
                    string[] results =
                    {
                        reader["PERNR"].ToString(), reader["CNAME"].ToString(), reader["PRPOS"].ToString(), 
                        reader["PRORG"].ToString(), reader["PSGRP"].ToString(), reader["TRVTY"].ToString(), 
                        reader["TRVNM"].ToString(), reader["PLACE"].ToString(), reader["REASN"].ToString(), 
                        reader["ORIGN"].ToString(), reader["DSTNT"].ToString(), reader["BEGDT"].ToString(), 
                        reader["ENDDT"].ToString(), reader["INNTY"].ToString(), reader["INNNM"].ToString(), 
                        reader["TRSTY"].ToString(), reader["TRSNM"].ToString(), reader["NOTES"].ToString(), 
                        reader["EXPNS"].ToString(), reader["CMBNT"].ToString(), reader["TRVNO"].ToString(),
                        reader["ORGID"].ToString(), reader["STRDT"].ToString(), reader["FNSDT"].ToString(),
                        reader["PRSGR"].ToString(), reader["EXPND"].ToString(), reader["EXCHG"].ToString()
                    };

                    dataDoc = results;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                //ErrorDataCatalog.IsError = true;
                //ErrorDataCatalog.ErrorMessage = ex.ToString();
            }
            finally
            {
                conn.Close();
                cmd.Dispose();
                conn.Dispose();
            }

            return dataDoc;
        }
        public static string[] GetDocGuestTravel(int docid, string doccd)
        {
            SqlConnection conn = GetConnectionEss();
            SqlCommand cmd = GetCommand();
            string[] dataDoc = null;

            try
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = @"biosppd.sp_GET_DOC_SPPD_GUEST_FORM";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@pDOCID", SqlDbType.Int, int.MaxValue).Value = docid;
                cmd.Parameters.Add("@pDOCCD", SqlDbType.VarChar, 30).Value = doccd;

                SqlDataReader reader = GetDataReader(cmd);
                while (reader.Read())
                {
                    string[] results =
                    {
                        reader["PERNR"].ToString(), reader["CNAME"].ToString(), reader["PSTYP"].ToString(), 
                        reader["ORGID"].ToString(), reader["TRVTY"].ToString(), reader["TRVNM"].ToString(), 
                        reader["PLACE"].ToString(), reader["REASN"].ToString(), reader["ORIGN"].ToString(), 
                        reader["DSTNT"].ToString(), reader["BEGDT"].ToString(), reader["ENDDT"].ToString(), 
                        reader["INNTY"].ToString(), reader["INNNM"].ToString(), reader["TRSTY"].ToString(), 
                        reader["TRSNM"].ToString(), reader["NOTES"].ToString(), reader["EXPNS"].ToString(), 
                        reader["CMBNT"].ToString(), reader["TRVNO"].ToString(), reader["PRPOS"].ToString(),
                        reader["ORGNM"].ToString(), reader["GSTYP"].ToString(), reader["GSTNM"].ToString(),
                        reader["STRDT"].ToString(), reader["FNSDT"].ToString(), reader["EXPND"].ToString(), 
                        reader["EXCHG"].ToString()
                    };

                    dataDoc = results;
                }
            }
            finally
            {
                conn.Close();
                cmd.Dispose();
                conn.Dispose();
            }

            return dataDoc;
        }
        public static DataTable GetDocTravelTransport(int docid, string doccd)
        {
            SqlConnection conn = GetConnectionEss();
            SqlCommand cmd = GetCommand();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dtTravelTransport = new DataTable();

            try
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = "EXEC biosppd.sp_GET_DOC_SPPD_TRANSPORT @pDOCID,@pDOCCD;";
                cmd.CommandTimeout = 200;

                cmd.Parameters.AddWithValue("@pDOCID", docid);
                cmd.Parameters.AddWithValue("@pDOCCD", doccd);

                adapter.SelectCommand = cmd;
                adapter.Fill(dtTravelTransport);
            }
            finally
            {
                conn.Close();
                cmd.Dispose();
                conn.Dispose();
            }

            return dtTravelTransport;
        }

        public static int GetTravelBudget(int orgid, string account, string dateBegin)
        {
            SqlConnection conn = GetConnectionEss();
            SqlCommand cmd = GetCommand();
            int budgetValue = 0;

            try
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = @"EXEC biosppd.usp_Get_TravelBudget @pORGID, @pACCOU, @pBEGDT;";

                cmd.Parameters.Add("@pORGID", SqlDbType.Int);
                cmd.Parameters.Add("@pACCOU", SqlDbType.VarChar, 15);
                cmd.Parameters.Add("@pBEGDT", SqlDbType.Date);

                cmd.Parameters["@pORGID"].Value = orgid;
                cmd.Parameters["@pACCOU"].Value = account;
                cmd.Parameters["@pBEGDT"].Value = dateBegin;
                //cmd.ExecuteNonQuery();
                budgetValue = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                //ErrorDataCatalog.IsError = true;
                //ErrorDataCatalog.ErrorMessage = ex.ToString();
            }
            finally
            {
                conn.Close();
                cmd.Dispose();
                conn.Dispose();
            }

            return budgetValue;
        }

    }
}