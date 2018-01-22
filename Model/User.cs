using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravelAgency.Model
{
    //要先将User类先设为可以序列化(即在类的前面加[Serializable])
    [Serializable]
    public class User
    {
        //public User(string username, string password)
        //{
        //    this.userName = username;
        //    this.passWord = password;
        //}

        private string _userName;
        public string Username
        {
            get { return _userName; }
            set { _userName = value; }
        }

        private string _passWord;
        public string Password
        {
            get { return _passWord; }
            set { _passWord = value; }
        }
    }
}
