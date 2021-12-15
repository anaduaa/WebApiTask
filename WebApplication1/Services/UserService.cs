using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Iservice;


namespace WebApplication1.Services
{
    
    public  class UserService :IUserService
    {
        private readonly WebApplication1Context _context;
       public string type = "Admin";
        public   projectRole role = new projectRole();
      // public static string role = User.Role;
        public bool ValidateCredentials(string username, string password)
        {
                       
            bool f = GetUsers(password, username);
            bool w = GetWorkers(password, username);

            if (f == true)
            {
               // type = "User";
               role.RoleName="User";
                return f;
            }
            else
            {
                if(w==true)
                role.RoleName="Worker";
                
                return w;
            }
        }
        public bool GetUsers(String password, string username)
        {
            string connectionString = "server=IMAD; database=WebApiSanayee;Trusted_Connection=True;";
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string sqlQuery = "SELECT TOP (1000) [ID],[nname],[pass],[CoPassword],[phone],[token],[country],[NameFirst],[NameLast]FROM[WebApiSanayee].[dbo].[User]";
            SqlCommand cmd = new SqlCommand(sqlQuery, con);
            SqlDataReader dr = cmd.ExecuteReader();
            List<User> users = new List<User>();
            while (dr.Read())
            {
                User user = new User();
                user.nname = dr["nname"].ToString();
                user.pass = dr["pass"].ToString();
                if (user.nname.Equals(username) && user.pass.Equals(password))
                {
                    return true;
                }
                users.Add(user);
            }
            con.Close();

            return false;
        }
        public bool GetWorkers(String password, string username)
            {
                string connectionString = "server=IMAD; database=WebApiSanayee;Trusted_Connection=True;";
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                string sqlQuery = "SELECT TOP (1000) [phone],[nname],[pass],[Work],[Experience],[Information],[token],[country],[NameFirst],[NameLast],[Available] FROM[WebApiSanayee].[dbo].[Worker] ";
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                SqlDataReader dr = cmd.ExecuteReader();
                List<Worker> users = new List<Worker>();
                while (dr.Read())
                {
                    Worker worker = new Worker();
                    worker.nname = dr["nname"].ToString();
                    worker.pass = dr["pass"].ToString();
                    if (worker.nname.Equals(username) && worker.pass.Equals(password))
                    {
                        return true;
                    }
                    users.Add(worker);
                }
                con.Close();

                return false;
            }
        }

    }
