using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BuisnessLayer.Controllers
{
    public class UserController
    {
    
        public IEnumerable<User> Users { get; private set; }
        private List<User>  UsersList { get; set; }
        private User User;

        public UserController(List<User> users)
        {
             UsersList = users ?? new List<User>();
             Users = UsersList;
            
        }

        public void AddNewUser(User user)
        {
            if(!UsersList.Contains(user))
            {
                UsersList.Add(user);
                User = user;
            }
        }

        public void UpdateUser(User user, int index)
        {
            if(UsersList.Where(u => u.UserName == user.UserName && u.Password == user.Password).FirstOrDefault() != null  && (index >= 0 && index <= UsersList.Count))
            {
                UsersList.RemoveAt(index);
                UsersList.Insert(index, user);
            }
        }

        public bool CheckUser(User user)
        {
            if(UsersList.Where(u => u.UserName == user.UserName && u.Password == user.Password).FirstOrDefault() != null)
            {
                User = user;
                return true;
            }
            else
            {
                AddNewUser(user);
                return false;
            }
        }

        public User GetCurrentUser()
        {
            return User;
        }
    }
}
