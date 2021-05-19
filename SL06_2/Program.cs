using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;

namespace SL06_2
{
    public class Student
    {
        public int Id { get; set; }
        public string NrAlbumu { get; set; }
        public string Nazwisko { get; set; }
        public string Imie { get; set; }
    }

    public class StudentKeysNazwisko
    {
        public int Id { get; set; }
        public string Nazwisko { get; set; }
    }


    class Program
    {
        static void Main(string[] args)
        {
            var students = GetStudentsFromDB();


            var anyTest = students.Any();

            var studentsSelectEx = students.Where(x => x.Id % 2 == 0 || x.Nazwisko.StartsWith('K'))
                .Select(x => new StudentKeysNazwisko()
                {
                    Id = x.Id,
                    Nazwisko = x.Nazwisko
                }).ToList();


            Console.ReadLine();
        }


        static List<Student> GetStudentsFromDB()
        {
            string connectionString = @"Data source=.\SQLExpress;database=programowanieOb;Trusted_Connection=True;";
            SqlConnection connection = new SqlConnection(connectionString);
            var list = new List<Student>();
            try
            {

                connection.Open();
                //Dodawanie
                //            {
                //                var studentNrAlbumu = "12345";
                //                SqlCommand cmd = connection.CreateCommand();
                //                cmd.CommandType = CommandType.Text;
                //                string commandText = @"
                //INSERT INTO[dbo].[students]
                //       ([Nazwisko]
                //       ,[Imie]
                //       ,[NrAlbumu]
                //       ,[Grupa])
                // VALUES
                //       (@nazwisko
                //       ,@imie
                //       ,@nrAlbumu
                //       ,@grupa)";
                //                cmd.CommandText = commandText;
                //                cmd.Parameters.Add(new SqlParameter("@nazwisko", "Nowak2"));
                //                cmd.Parameters.Add(new SqlParameter("@imie", "Janusz2"));
                //                cmd.Parameters.Add(new SqlParameter("@nrAlbumu", "w500382"));
                //                cmd.Parameters.AddWithValue("@grupa", "SL062");
                //                int result = cmd.ExecuteNonQuery();
                //            }

                {
                    SqlCommand sqlCommand = new SqlCommand();// connection.CreateCommand();
                    sqlCommand.Connection = connection;
                    sqlCommand.CommandText = "SELECT * FROM students"; // WHERE Id = @jakiesId";
                                                                       //    sqlCommand.Parameters.Add(new SqlParameter("@jakiesId", 2));

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        //Console.WriteLine("Wiersze znajdujące się w tabeli students:");
                        while (reader.Read())
                        {
                            list.Add(new Student()
                            {
                                Id = (int)reader[0],
                                NrAlbumu = reader["NrAlbumu"].ToString(),
                                Nazwisko = reader["Nazwisko"].ToString(),
                                Imie = reader["Imie"].ToString()
                            });


                            // Console.WriteLine(
                            //     reader[0].ToString() + " " +
                            //     reader["Nazwisko"].ToString() + " " +
                            //reader["Imie"].ToString() + " "
                            //+ reader["NrAlbumu"].ToString() + " " +
                            //reader["Grupa"].ToString());
                        }
                    }
                }
                // reader.Close();

            }
            catch (SqlException e)
            {
                Console.WriteLine("error");
                Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }

            return list;
        }


    }
}
