namespace BioHR.Model.Object
{
    public class MaintainObject
    {
    }

    public class BasicObject
    {
        public string BeginDate { get; set; }
        public string EndDate { get; set; }
        public string Nik { get; set; }
        public string NikPanjang { get; set; }
        public string Name { get; set; }
        public string UnitName { get; set; }
        public string PositionName { get; set; }
    }

    public class BankData : BasicObject
    {
        public string BankGroup { get; set; }
        public string BankCode { get; set; }
        public string BankName { get; set; }
        public string StreetAddress { get; set; }
        public string RegionAddress { get; set; }
        public string CountryAddress { get; set; }
        public string PostalCode { get; set; }
    }

    public class PersonData : BasicObject
    {
        public string NickName { get; set; }
        public string BirthPlace { get; set; }
        public string BirthDate { get; set; }
        public string Gender { get; set; }
        public string Religion { get; set; }
        public string Language { get; set; }
        public string Nationality { get; set; }
        public string Tribe { get; set; }
        public string BloodType { get; set; }
        public string BloodRhesus { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public string MaritalStatus { get; set; }
        public string MaritalDate { get; set; }
        public string PersonalNumberReference { get; set; }
    }

    public class FamilyData : BasicObject
    {
        public string FamilyType { get; set; }
        public string FamilyNumber { get; set; }
        public string FamilyName { get; set; }
        public string NickName { get; set; }
        public string BirthPlace { get; set; }
        public string BirthDate { get; set; }
        public string Gender { get; set; }
        public string Nationality { get; set; }
        public string Religion { get; set; }
        public string TaxFlag { get; set; }
        public string MedicFlag { get; set; }
        public string FamilyStatus { get; set; }
        public string FamilyDate { get; set; }
        public string ReportDate { get; set; }
        public string JobTitle { get; set; }
        public string JobPlace { get; set; }
    }

    public class FamilyAddressData : BasicObject
    {
        public string FamilyType { get; set; }
        public int FamilyNumber { get; set; }
        public string AddressType { get; set; }
        public string AddressNumber { get; set; }
        public string Street { get; set; }
        public string PostCode { get; set; }
        public string AddressCity { get; set; }
        public string AddressRegion { get; set; }
        public string AddressCountry { get; set; }
    }

    public class FamilyIdentity : BasicObject
    {
        public string FamilyType { get; set; }
        public int FamilyNumber { get; set; }
        public string IdentityType { get; set; }
        public string IdentityNumber { get; set; }
        public string ReleaseDate { get; set; }
        public string ExpiredDate { get; set; }
        public string ReleasePlace { get; set; }

        public string IdNo { get; set; }
    }

    public class EmployeeInsurance : BasicObject
    {
        public string InsuranceType { get; set; }
        public string InsuranceNumber { get; set; }
        public string InsuranceSequence { get; set; }
        public string InsuranceCompany { get; set; }
        public string PercentEmployer { get; set; }
        public string AmountEmployer { get; set; }
        public string PercentEmployee { get; set; }
        public string AmountEmployee { get; set; }

    }

    public class EmployeeJamsostek : BasicObject
    {
        public string JamsostekId { get; set; }
        public string JamsostekDate { get; set; }
        public string JamsostekMarriedStatus { get; set; }
    }

    public class EmployeeBpjs : BasicObject
    {
        public string BpjsId { get; set; }
        public string BpjsDate { get; set; }
    }

    public class EmployeeIdentity : BasicObject
    {
        public string IdentityType { get; set; }
        public string IdentityNumber { get; set; }
        public string ReleaseDate { get; set; }
        public string ExpiredDate { get; set; }
        public string ReleasePlace { get; set; }

    }

    public class EmployeeAddress : BasicObject
    {

        public string AddressType { get; set; }
        public string AddressNumber { get; set; }
        public string Street { get; set; }
        public string PostCode { get; set; }
        public string AddressCity { get; set; }
        public string AddressRegion { get; set; }
        public string AddressCountry { get; set; }

    }

    public class BankEmployee : BankData
    {
        public string AccountName { get; set; }
        public string AccountNumber { get; set; }
        public string BankType { get; set; }
        public string BankAccount { get; set; }
        public string PaymentType { get; set; }
        public string Balance { get; set; }
        public string Percentage { get; set; }
    }

    public class ContractDetailData : BasicObject
    {
        public string ReferenceNumber { get; set; }
        public string ContractType { get; set; }
        public string ContractTypeName { get; set; }
        public string ContractNumber { get; set; }
        public string ContractDescription { get; set; }
        public string ContractDate { get; set; }
        public string PersonalNumberSignedContract { get; set; }
        public string PersonalNameSignedContract { get; set; }
        public string PositionSignedContract { get; set; }
        public string OrganizationalName { get; set; }
        public string EffectiveDate { get; set; }
    }

    public class ContractData : ContractDetailData
    {
        public int SequenceNumber { get; set; }
    }

    public class SpecificationDate : BasicObject
    {
        public string DateType { get; set; }
    }


    public class DailyWorkingScheduleObject : BasicObject
    {
        public string DailyWorkingScheduleCode { get; set; }
        public string DailyWorkingScheduleName { get; set; }
        public string WorkTimeBegin { get; set; }
        public string WorkTimeEnd { get; set; }
        public string ToleranceTimeCome { get; set; }
        public string ToleranceTimeGo { get; set; }
        public string WorkTimeMinimum { get; set; }
        public string WorkTimeMaximum { get; set; }
        public string OverTimeBegin { get; set; }
        public string OverTimeEnd { get; set; }
        public string OverTimeMaximum { get; set; }
        public string BreakTimeBegin { get; set; }
        public string BreakTimeEnd { get; set; }

    }

    public class WeeklyWorkingSchedule : BasicObject
    {
        public string CountryCode { get; set; }
        public string WorkingSchedule { get; set; }
        public string DayCode { get; set; }
        public string DailyWorkingScheduleCode { get; set; }
    }

    public class EmployeeWorkingTime : BasicObject
    {
        public string WorkingSchedule { get; set; }
        public string TimeManagementStatus { get; set; }
        public string PartTimeEmployeeFlag { get; set; }
    }

    public class BasicPayData : BasicObject
    {
        public string WagesType { get; set; }
        public int Nilai { get; set; }
        public string PayFlag { get; set; }
    }

    public class AdditionalPayment : BasicObject
    {
        public string WagesType { get; set; }
        public string Nilai { get; set; }
        public string ChangeReason { get; set; }
        public string OffcycleType { get; set; }
    }

    public class OffCycle : BasicObject
    {
        public string WagesType { get; set; }
        public string Nilai { get; set; }
        public string ChangeReason { get; set; }
        public string OffcycleType { get; set; }
    }

    public class RecurringObject : BasicObject
    {
        public string WagesType { get; set; }
        public double Nilai { get; set; }
        public string ChangeReason { get; set; }

    }

    public class ExceptionObject : BasicObject
    {
        public string WagesType { get; set; }

        public string WagesName { get; set; }

        public double Nilai { get; set; }

    }

    public class TaxObject : BasicObject
    {
        public string TaxId { get; set; }
        public string TaxDate { get; set; }
        public string TaxMarried { get; set; }
        public string TaxNumberFamily { get; set; }
        public string TaxPtkp { get; set; }
        public string SpouseBenefit { get; set; }
    }

    public class AssignmentOrganizational : BasicObject
    {
        public string CostCenter { get; set; }
        public string OrganizationalId { get; set; }
        public string JobId { get; set; }
        public string PositionId { get; set; }
        public string BussinessArea { get; set; }
        public string PersonalGroup { get; set; }
        public string PersonalSubGroup { get; set; }
        public string PersonalArea { get; set; }
        public string PersonalSubArea { get; set; }
        public string PayrollArea { get; set; }
        public string ReferenceNumber { get; set; }
        //coba
        public string CostCenterName { get; set; }
        public string OrganizationalName { get; set; }
        public string JobName { get; set; }
        public string PositionName { get; set; }
        public string BussinessAreaName { get; set; }
    }

    public class EducationObject : BasicObject
    {
        public string RecordId { get; set; }
        public string EducationLevel { get; set; }
        public string EducationCode { get; set; }
        public string EducationDepartment { get; set; }
        public string EducationMajor { get; set; }
        public string EducationSubMajor { get; set; }
        public string PositionId { get; set; }
        public string EducationFaculty { get; set; }
        public string EducationInstitution { get; set; }
        public string InstitutionName { get; set; }
        public string EducationCity { get; set; }
        public string EducationRegion { get; set; }
        public string EducationCountry { get; set; }
        public string EducationCertificate { get; set; }
        public string EducationFound { get; set; }
        public string EducationNumber { get; set; }
        public string EducationDate { get; set; }
        public string EducationRecognition { get; set; }

    }

    public class CommunicationObject : BasicObject
    {
        public string CommunicationType { get; set; }
        public string CommunicationNumber { get; set; }
        public string CommunicationSequenceNumber { get; set; }

    }
    public class LevelBasic : BasicObject
    {
        public string EmployeeSubGroup { get; set; }
        public string PayScaleType { get; set; }
        public string PayScaleArea { get; set; }
        public string PayScaleGroup { get; set; }
        public string PayScaleLevel { get; set; }

    }

    public class Chosen
    {
        public string Text { get; set; }
        public string Value { get; set; }
    }
}