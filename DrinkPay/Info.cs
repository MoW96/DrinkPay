using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkPay
{
    public static class Info
    {
        private static string User = "";
        public static void setUser(string Username)
        {
            User = Username;
        }

        public static string getUser()
        {
            return User;
        }

    }
}
