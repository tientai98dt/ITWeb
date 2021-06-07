using ITWebDB.Concrete;
using ITWebDB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITWebDB.Dao
{
   public class UserDao
    {
        ITWebEntities db = null;

        public UserDao()
        {
            db = new ITWebEntities();
        }

        public long Insert(User entity)
        {
            db.Users.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }

        public User GetById(string userName)
        {
            return db.Users.SingleOrDefault(x => x.UserName == userName);
        }

        public int Login(string userName, string passWord)
        {
            var result = db.Users.SingleOrDefault(x => x.UserName == userName && x.Password == passWord);
            if (result == null)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
    }
}