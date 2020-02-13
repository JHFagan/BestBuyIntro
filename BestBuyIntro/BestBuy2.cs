using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using MySql.Data.MySqlClient;

namespace BestBuyIntro
{
    class BestBuy2
    {
        
        static IEnumerable GetDepartments()
        {
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = System.IO.File.ReadAllText("ConnectionString.txt");

            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT Name FROM Departments";

            using (conn)
            {
                conn.Open();
                List<string> allDepartments = new List<string>();
                
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read() == true)
                {
                    var currentDepartment = reader.GetString("Name");
                    allDepartments.Add(currentDepartment);
                }
                return allDepartments;
            }
        }
    }
}
