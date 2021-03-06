﻿using System;
using System.Collections;
using System.Collections.Generic;
using MySql.Data.MySqlClient;


namespace BestBuyIntro
{
    class Program
    {
        static void Main(string[] args)
        {
            var departments = GetDepartments();
            foreach (var dept in departments)
            {
                Console.WriteLine(dept);
            }
        }

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
                    var currentDepartments = reader.GetString("Name");
                    allDepartments.Add(currentDepartments);
                }
                return allDepartments;
            }
        }
    }
}
