using System.DirectoryServices.AccountManagement;
using BioHR.Controller.Services;

namespace BioHR.Controller.Function
{
    public class ActiveDirectoryManager : AccessActiveDirectory
    {
        public static string GetUserEmailByNik(string personNumber)
        {
            bool isFound = false;
            string email = null;

            foreach (var principal in GetPrincipalSearcher().FindAll())
            {
                var result = (UserPrincipal) principal;

                if ( (result.Enabled == true && !string.IsNullOrEmpty(result.EmailAddress)) && (result.Description == personNumber && !string.IsNullOrEmpty(result.DisplayName)) )
                {
                    email = result.EmailAddress;
                    isFound = true;
                    break;
                }
            }

            return isFound ? email : null;
        }

        public static string GetUserNumberByEmail(string email)
        {
            bool isFound = false;
            string personalNumber = null;

            foreach (var principal in GetPrincipalSearcher().FindAll())
            {
                var result = (UserPrincipal) principal;
                if ( ( result.Enabled == true && !string.IsNullOrEmpty(result.Description) ) && ( result.EmailAddress == email && !string.IsNullOrEmpty(result.DisplayName) ) )
                {
                    personalNumber = result.Description;
                    isFound = true;
                    break;
                }
            }

            return isFound ? personalNumber : null;
        }

        public static bool ValidateUser(string username, string password)
        {
            PrincipalContext principalContext = GetPrincipalContext();
            bool result = principalContext.ValidateCredentials(username, password);
            return result;
        }
    }
}