using System;
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


        public int GetUniqueNumber()
        {
            int s;
            s = int.Parse(DateTime.Now.ToString("yyMMddHHmmss"));

            return s;

        }

        public List<Child> GetEriksChildren()
        {
            Child c;
            List<Child> childs = new List<Child>();
            using (var conn = new
               NpgsqlConnection(ConfigurationManager.ConnectionStrings["Dbconn"].ConnectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT child.child_id, child.fname, child.special_needs, child.lname FROM child INNER JOIN guardian_child ON child.child_id = guardian_child.child_id WHERE guardian_id = 1";
                    // NÄR SOLEN SKINER, VILL JAG HA GLASSAR. 
                    // SOM SOM SOMMAREN, PULSEN BÖRJAR SLÅ KAN INTE FÖRKLARA. ALLTING BÖRJAR OM OM OM IGEN, HON E SHALALA SOM SOM SOMMAREN.
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            c = new Child()
                            {
                                child_id = reader.GetInt32(0),
                                fname = reader.GetString(1),
                                special_needs = reader.GetString(2),
                                lname = reader.GetString(3)
                            };
                            childs.Add(c);
                        }
                    }
                    conn.Close();
                }
                return childs;

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
                conn.Close();
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

        public List<Child> getAllclasChildren()
        {
            string stt = "1:an";
            Child c;
            List<Child> childs = new List<Child>();
            using (var conn = new
               NpgsqlConnection(ConfigurationManager.ConnectionStrings["Dbconn"].ConnectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT child.child_id, child.fname, child.special_needs, child.lname, learn.clas FROM child INNER JOIN learn ON child.child_id = learn.child_id WHERE learn.clas = '1:an'";
                    // NÄR SOLEN SKINER, VILL JAG HA GLASSAR. 
                    // SOM SOM SOMMAREN, PULSEN BÖRJAR SLÅ KAN INTE FÖRKLARA. ALLTING BÖRJAR OM OM OM IGEN, HON E SHALALA SOM SOM SOMMAREN.
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            c = new Child()
                            {
                                child_id = reader.GetInt32(0),
                                fname = reader.GetString(1),
                                special_needs = reader.GetString(2),
                                lname = reader.GetString(3)
                            };
                            childs.Add(c);
                        }
                    }
                    conn.Close();
                }
                return childs;

            }
        }
        //metod för att lägga till nytt schema-
        public void Addschedule(bool bf, string pp, bool ga, DateTime arrivaldate, TimeSpan schedule_datecoming, TimeSpan schedule_dateleaving, Child c)
        {
            schedule s = new schedule();
            s.breakfast = bf;
            s.pick_up = pp;
            s.goalone = ga;
            s.arrivaldate = arrivaldate;
            s.schedule_datecoming = schedule_datecoming;
            s.schedule_dateleaving = schedule_dateleaving;



            string stmt = "INSERT INTO schedule(breakfast, pick_up, goalone, child_id, arrivaldate, schedule_datecoming, schedule_dateleaving) VALUES (@bf, @pp, @ga, @child_id, @arrivaldate, @schedule_datecoming, @schedule_dateleaving)";

            using (var conn = new
                 NpgsqlConnection(ConfigurationManager.ConnectionStrings["Dbconn"].ConnectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand(stmt, conn))
                {

                    cmd.Parameters.AddWithValue("bf", bf);
                    cmd.Parameters.AddWithValue("pp", pp);
                    cmd.Parameters.AddWithValue("ga", ga);
                    cmd.Parameters.AddWithValue("child_id", c.child_id);
                    cmd.Parameters.AddWithValue("arrivaldate", arrivaldate);
                    // cmd.Parameters.AddWithValue("weekday")
                    cmd.Parameters.AddWithValue("schedule_datecoming", schedule_datecoming);
                    cmd.Parameters.AddWithValue("schedule_dateleaving", schedule_dateleaving);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public List<schedule> GetSchedules(Child child)
        {
            schedule s;
            List<schedule> schedules = new List<schedule>();
            using (var conn = new
                    NpgsqlConnection(ConfigurationManager.ConnectionStrings["Dbconn"].ConnectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {

                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT schedule.schedule_id, schedule.breakfast, schedule.sickleave, schedule.pick_up, schedule.goalone, schedule.child_id, schedule.leave, schedule.weekday, schedule.schedule_datecoming, schedule_dateleaving, arrivaldate FROM schedule JOIN child ON child.child_id = schedule.child_id  WHERE child.child_id = @child.child_id ORDER BY schedule.schedule_id DESC";
                    cmd.Parameters.AddWithValue("child.child_id", child.child_id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {


                            s = new schedule();
                            s.schedule_id = reader.GetInt32(0);
                            s.breakfast = reader.GetBoolean(1);
                            if ((!reader.IsDBNull(2)))
                            {
                                s.sickleave = reader.GetDateTime(2);
                            }
                            s.pick_up = reader.GetString(3);
                            s.goalone = reader.GetBoolean(4);
                            s.child_id = reader.GetInt32(5);
                            if ((!reader.IsDBNull(6)))
                            {
                                s.leave = reader.GetDateTime(6);
                            }
                            if ((!reader.IsDBNull(7)))
                            {
                                s.weekday = reader.GetString(7);
                            }
                            s.schedule_datecoming = reader.GetTimeSpan(8);
                            s.schedule_dateleaving = reader.GetTimeSpan(9);
                            if ((!reader.IsDBNull(10)))
                            {
                                s.arrivaldate = reader.GetDateTime(10);
                            }

                            schedules.Add(s);
                        }
                    }
                }
                return schedules;
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

        public void Sick(int schedule_id, DateTime sl)
        {
            schedule s = new schedule();
            s.schedule_id = schedule_id;
            s.sickleave = sl;



            string stmt = "UPDATE schedule(schedule_id, sickleave) VALUES (@schedule_id, @sl)";

            using (var conn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Dbconn"].ConnectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand(stmt, conn))
                {
                    cmd.Parameters.AddWithValue("schedule_id", schedule_id);
                    cmd.Parameters.AddWithValue("sl", sl);
                    cmd.ExecuteNonQuery();
                }
            }
        }




        ///*public List<schedule> ReportSick(Child child)
        //{
        //    List<schedule> schedules = new List<schedule>();
        //    DateTime sl = new DateTime();
        //    schedule s = new schedule();        
        //    s.sickleave = sl;

        //    string stmt = "UPDATE schedule(sickleave VALUES (@sl)";

        //    using (var conn = new
        //         NpgsqlConnection(ConfigurationManager.ConnectionStrings["Dbconn"].ConnectionString))
        //    {
        //        conn.Open();
        //        using (var cmd = new NpgsqlCommand(stmt, conn))
        //        {                  
        //            cmd.Parameters.AddWithValue("sl", sl);                  
        //            cmd.ExecuteNonQuery();
        //        }
        //        schedules.Add(s);
        //    }
        //    return schedules;*/

        //}
        public void Attendence(int s_id, Child ch_id, DateTime departure, bool attending)
        {
            attendence a = new attendence();
            a.staff_id = s_id;
            a.departure = departure;
            a.attending = attending;

            string stmt = "INSERT INTO attendence(staff_id, child_id, departure, attending) VALUES (@s_id, @ch_id, @departure, @attending)";

            // jag orkar inte mer, vill inte vara kvar, jag längtar efter er min kära mor och far. 
            //maten smakar skit

            using (var conn = new
                 NpgsqlConnection(ConfigurationManager.ConnectionStrings["Dbconn"].ConnectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand(stmt, conn))
                {

                    cmd.Parameters.AddWithValue("s_id", s_id);
                    cmd.Parameters.AddWithValue("ch_id", ch_id.child_id);
                    cmd.Parameters.AddWithValue("departure", departure);
                    cmd.Parameters.AddWithValue("attending", attending);
                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}


