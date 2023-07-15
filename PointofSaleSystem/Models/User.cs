using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointofSaleSystem.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

       /* public User(int userID,string userName,string password)
        {
            UserID = userID;
            UserName = userName;
            Password = password;
        }*/

        public void User1(string userName,string password)
        {
            UserName = userName;
            Password = password;
        }
    }
}
