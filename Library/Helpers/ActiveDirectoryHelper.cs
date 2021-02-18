using System.DirectoryServices.AccountManagement;
using System.DirectoryServices.ActiveDirectory;

namespace Library.Helpers
{
    public class ActiveDirectoryHelper
    {
        public static bool ActiveDirectoryAuthenticate(string username, string password)
        {
            Domain domain = Domain.GetComputerDomain();
            PrincipalContext principalContext = new PrincipalContext(ContextType.Domain, domain.Name);
            bool areCredentialsValid = principalContext.ValidateCredentials(username, password);
            return areCredentialsValid;
        }
    }
}
