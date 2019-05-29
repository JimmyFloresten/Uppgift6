﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Npgsql;

namespace WpfApp1
{
    class dbOperations
    {
        //NpgsqlConnection conn = new
        //    NpgsqlConnection("server=studentpsql.miun.se; Port=5432; Database=ik102g_db02; User Id=ik102g_1902; Password=databas19;SslMode=Require;/>");
        // Kallar på anslutningen till databasen


       public List<guardian_child> GetEriksChildren()
        {
            guardian_child c;
            List<guardian_child> guardian_s = new List<guardian_child>();
            using (var conn = new
               NpgsqlConnection(ConfigurationManager.ConnectionStrings["Dbconn"].ConnectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT child.fname FROM child INNER JOIN guardian_child ON child.child_id = guardian_child.child_id WHERE guardian_id = 1";

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            c = new guardian_child()
                            {
                                guardian_id = reader.GetInt32(0),
                                child_id = reader.GetInt32(1),
                                
                            };
                            guardian_s.Add(c);
                        }
                    }
                    conn.Close();
                }
                return guardian_s;

            }

        }
      public List<Child> GetAllChildren()
        {
            Child c;
            List<Child> childs = new List<Child>();
            string stmt = "SELECT * FROM child SORT BY ASC";
            var conn = new
                NpgsqlConnection(ConfigurationManager.ConnectionStrings["Dbconn"].ConnectionString);
            conn.Open();

            var cmd = new NpgsqlCommand(stmt, conn);
            
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                c = new Child()
                {
                    child_id = reader.GetInt32(0),
                    fname = reader.GetString(1),
                    lname = reader.GetString(3),
                    special_needs = reader.GetString(2)
                };
                childs.Add(c);
              //  conn.Close();
            }
            return childs;
        }

        public List<guardian> GetAllGuardians()
        {
            guardian g;
            List<guardian> guardians = new List<guardian>();
           // string stmt = "SELECT * FROM child SORT BY ASC";
            using (var conn = new
                 NpgsqlConnection(ConfigurationManager.ConnectionStrings["Dbconn"].ConnectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT * FROM guardian ORDER BY guardian_id ASC";
                 
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            g = new guardian()
                            {
                                guardian_id = reader.GetInt32(0),
                                fname = reader.GetString(1),
                                phone = reader.GetInt32(2)
                            };
                        guardians.Add(g);
                        }
                    }
                    conn.Close();
                }
                return guardians;
                
            }

        }
        public List<staff> GetAllStaff()
        {
            staff s;
            List<staff> staffs = new List<staff>();
            // string stmt = "SELECT * FROM child SORT BY ASC";
            using (var conn = new
                 NpgsqlConnection(ConfigurationManager.ConnectionStrings["Dbconn"].ConnectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT * FROM staff ORDER BY staff_id ASC";

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            s = new staff()
                            {
                                staff_id = reader.GetInt32(0),
                                fname = reader.GetString(1),
                                phone = reader.GetInt32(2)
                            };
                            staffs.Add(s);
                        }
                    }
                }
                return staffs;
            }

        }


    }
}

