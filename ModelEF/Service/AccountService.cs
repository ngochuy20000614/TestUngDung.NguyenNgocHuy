using ModelEF.Model;
using System.Linq;

namespace ModelEF.Service
{
    public class AccountService
    {
        private  NguyenNgocHuyContext _Context = null;
        public AccountService()
        {
            _Context = new NguyenNgocHuyContext();
        }

        public bool Login(string username, string password)
        {
            var result = _Context.UserAccounts.SingleOrDefault(x => x.UserName.Contains(username) && x.Password.Contains(password));
            if (result == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
