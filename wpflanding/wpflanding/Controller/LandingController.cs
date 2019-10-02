using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using wpflanding.Context;
using wpflanding.Models;

namespace wpflanding.Controller
{
    class LandingController
    {
        public void AddUser(string email, string fullname, string username, string password)
        {
            var Result = 0;
            Login login = new Login();
            User user = new User();
            MyContext _context = new MyContext();

            login.Email = email;
            login.Username = username;
            login.Password = password;
            _context.Logins.Add(login);

            user.Fullname = fullname;
            _context.Users.Add(user);

            Result = _context.SaveChanges();

            if (Result > 0)
            {
                MessageBox.Show("Register Successful!");
            }
            else
            {
                MessageBox.Show("Register Failed!");
            }
        }

        public bool login(string email, string password)
        {
            var status = true;
            Login login = new Login();
            MyContext _context = new MyContext();

            var get = _context.Logins.Where(u => u.Email == email || u.Username == email).FirstOrDefault<Login>();

            if (get == null)
            {
                MessageBox.Show("You are not Registered yet!");
                status = false;
            }
            else
            {
                if (get.Password != password)
                {
                    MessageBox.Show("Your Password is Incorrect!");
                    status = false;
                }
                else
                {
                    MessageBox.Show("Login Successful!");
                }
            }
            return status;
        }

        public void ChangePass(string username, string password)
        {
            var result = 0;

            Login login = new Login();
            MyContext _context = new MyContext();

            var get = _context.Logins.Where(u => u.Username == username).FirstOrDefault<Login>();
            if(get==null)
            {
                MessageBox.Show("Your Username is Incorrect");
            }
            else
            {
                if(get.Password != password)
                {
                    get.Password = password;
                    result = _context.SaveChanges();
                    if(result >0)
                    {
                        MessageBox.Show("Update Success");
                    }
                    else
                    {
                        MessageBox.Show("Update Failed");
                    }
                }
                else
                {
                    MessageBox.Show("Your Password can't be the same!");
                }
            }
        }
    }
}
