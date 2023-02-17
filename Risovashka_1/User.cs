using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Risovashka_1
{
    public class User
    {
        public int ID { get; set; }
        public string Full_name, Login, Password, Role;
        public string full_name
        {
            get { return Full_name; }
            set { Full_name = value; }
        }

        public string login
        {
            get { return Login; }
            set { Login = value; }
        }

        public string password
        {
            get { return Password; }
            set { Password = value; }
        }
        public string role
        {
            get { return Role; }
            set { Role = value; }
        }
        public User() { }
        public User(string Full_name, string Login, string Password, string Role)
        {
            this.Full_name = Full_name;
            this.Login = Login;
            this.Password = Password;
            this.Role = Role;
        }

        public override string ToString()
        {
            return "Пользователь:" + ID + "Role" + role + "Password" + password;
        }
    }
}
