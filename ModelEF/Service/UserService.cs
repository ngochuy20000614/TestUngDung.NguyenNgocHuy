using ModelEF.Model;
using ModelEF.ViewModels;
using PagedList;
using System.Collections.Generic;
using System.Linq;

namespace ModelEF.Service
{
    public class UserService
    {
        private NguyenNgocHuyContext _context = null;
        public UserService()
        {
            _context = new NguyenNgocHuyContext();
        }

        public List<UserAccount> GetListUser()
        {
            return _context.UserAccounts.ToList();
        }

        public IEnumerable<UserViewModel> ListAllPaging(string keyword, int page, int pageSize)
        {
            var qr = from u in _context.UserAccounts
                     select new { u };
            if (!string.IsNullOrEmpty(keyword))
            {
                qr = qr.Where(s => s.u.UserName.Contains(keyword));
            }
            var result = qr.Select(x => new UserViewModel()
            {
                id = x.u.id,
                UserName = x.u.UserName,
                Email = x.u.Email,
                SoDienThoai = x.u.SoDienThoai,
                Password = x.u.Password,
                Status = x.u.Status == true ? Enum.UserStatusEnum.Active : x.u.Status == false ? Enum.UserStatusEnum.NoActive : Enum.UserStatusEnum.Blocked
            }).OrderBy(s => s.id).ToPagedList(page, pageSize);
            return result;
        }

        public void TaoMoi(UserViewModel userView)
        {
            
            if(userView.Status == Enum.UserStatusEnum.Active)
            {
                var user = new UserAccount()
                {
                    id = userView.id,
                    Password = userView.Password,
                    UserName = userView.UserName,
                    Email = userView.Email,
                    SoDienThoai = userView.SoDienThoai,
                    Status = true
                };
                _context.UserAccounts.Add(user);
                _context.SaveChanges();
            }
            if (userView.Status == Enum.UserStatusEnum.NoActive)
            {
                var user = new UserAccount()
                {
                    id = userView.id,
                    Password = userView.Password,
                    UserName = userView.UserName,
                    Email = userView.Email,
                    SoDienThoai = userView.SoDienThoai,
                    Status = false
                };
                _context.UserAccounts.Add(user);
                _context.SaveChanges();
            }
            if (userView.Status == Enum.UserStatusEnum.Blocked)
            {
                var user = new UserAccount()
                {
                    id = userView.id,
                    Password = userView.Password,
                    UserName = userView.UserName,
                    Email = userView.Email,
                    SoDienThoai = userView.SoDienThoai,
                    Status = null
                };
                _context.UserAccounts.Add(user);
                _context.SaveChanges();
            }
        }

        public UserAccount GetUserById(int id)
        {
            return _context.UserAccounts.Where(s => s.id == id).SingleOrDefault();
        }

        public UserViewModel GetUserViewModel(int id)
        {
            var qr = from u in _context.UserAccounts
                     where u.id == id
                     select new { u };
            var result = qr.Select(x => new UserViewModel()
            {
                id = x.u.id,
                UserName = x.u.UserName,
                Email = x.u.Email,
                SoDienThoai = x.u.SoDienThoai,
                Password = x.u.Email,
                Status = x.u.Status == true ? Enum.UserStatusEnum.Active : x.u.Status == false ? Enum.UserStatusEnum.NoActive : Enum.UserStatusEnum.Blocked
            }).SingleOrDefault();
            return result;
        }

        public bool Xoa(int id)
        {
            var user = GetUserById(id);
            if(user.Status == null) {
                _context.UserAccounts.Remove(user);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public void CapNhat(UserViewModel user)
        {
            UserAccount u = GetUserById(user.id);
            if (user.Status == Enum.UserStatusEnum.Blocked)
            {
                u.UserName = user.UserName;
                u.Password = user.Password;
                u.Email = user.Email;
                u.SoDienThoai = user.SoDienThoai;
                u.Status = null;

            }
            else
            {
                if(user.Status == Enum.UserStatusEnum.Active)
                {
                    u.UserName = user.UserName;
                    u.Password = user.Password;
                    u.Email = user.Email;
                    u.SoDienThoai = user.SoDienThoai;
                    u.Status = true;
                }
                else
                {
                    u.UserName = user.UserName;
                    u.Password = user.Password;
                    u.Email = user.Email;
                    u.SoDienThoai = user.SoDienThoai;
                    u.Status = false;
                }
            }
            _context.SaveChanges();
        }
    }
}
