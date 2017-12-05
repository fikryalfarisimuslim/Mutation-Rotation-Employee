using System.Configuration;
using System.DirectoryServices.AccountManagement;

namespace BioHR.Controller.Services
{
    public class AccessActiveDirectory
    {
        protected static PrincipalContext GetPrincipalContext()
        {
            return new PrincipalContext(ContextType.Domain, ConfigurationManager.AppSettings["ActiveDirectoryDomain"], ConfigurationManager.AppSettings["MailModerator"], ConfigurationManager.AppSettings["MailModeratorPassword"]);
        }

        protected static UserPrincipal GetUserPrincipal()
        {
            return new UserPrincipal(GetPrincipalContext());
        }

        protected static PrincipalSearcher GetPrincipalSearcher()
        {
            return new PrincipalSearcher(GetUserPrincipal());
        }
    }
}