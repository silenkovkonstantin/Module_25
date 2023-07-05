using Module_25.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_25.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        public void Create(AppContext appContext, User user)
        {
            using (appContext)
            {
                appContext.Users.Add(user);
                appContext.SaveChanges();
            }
        }

        public void Remove(AppContext appContext, User user)
        {
            using (appContext)
            {
                appContext.Users.Remove(user);
                appContext.SaveChanges();
            }
        }

        public User FindById(AppContext appContext, int id)
        {
            using (appContext)
            {
                return (User)appContext.Users.Where(u => u.Id == id);
            }
        }

        public List<User> FindAll(AppContext appContext)
        {
            using (appContext)
            {
                return appContext.Users.ToList();
            }
        }

        public void UpdateName(AppContext appContext, int id, string name)
        {
            using (appContext)
            {
                User user = FindById(appContext, id);
                user.Name = name;
                appContext.SaveChanges();
            }
        }
    }

    public interface IUserRepository
    {
        void Create(AppContext appContext, User user);
        void Remove(AppContext appContext, User user);
        User FindById(AppContext appContext, int id);
        List<User> FindAll(AppContext appContext);
        void UpdateName(AppContext appContext, int id, string name);
    }
}
