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

    class Program
    {
        static void Main(string[] args)
        {
            var students = GetStudentsFromDB();

            Export(students);

            var studentsImported = Import();


            Console.ReadLine();
        }

        private static List<Student> Import()
        {
            bool useXlsx = false;
            var students = new List<Student>();
            try
            {
                using (FileStream stream = new FileStream("export.xls", FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    IWorkbook workbook;
                    if (useXlsx)
                        workbook = new XSSFWorkbook(stream);
                    else
                        workbook = new HSSFWorkbook(stream);

                    var sheet = workbook.GetSheet("Ark1");

                    for (int row = 0; row <= sheet.LastRowNum; row++)
                    {
                        var rowObj = sheet.GetRow(row);
                        if(rowObj != null)
                        {
                            students.Add(new Student()
                            {
                                Id = Convert.ToInt32(rowObj.GetCell(0).NumericCellValue),
                                Nazwisko = rowObj.GetCell(1).StringCellValue
                            });
                        }

                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return students;
        }

        private static void Export(List<Student> students)
        {
            bool useXlsx = false;

            IWorkbook workbook;
            if (useXlsx)
                workbook = new XSSFWorkbook();
            else
                workbook = new HSSFWorkbook();

            var sheet = workbook.CreateSheet("Ark1");

            int rowIdx = 0;
            foreach (var student in students)
            {
                var row = sheet.CreateRow(rowIdx++);
                int colIdx = 0;
                {
                    var cell = row.CreateCell(colIdx++);
                    cell.SetCellValue(student.Id);
                }
                {
                    var cell = row.CreateCell(colIdx++);
                    cell.SetCellValue(student.Nazwisko);
                }
                {
                    var cell = row.CreateCell(colIdx++);
                    cell.SetCellValue(student.Imie);
                }
                {
                    var cell = row.CreateCell(colIdx++);
                    cell.SetCellValue(student.NrAlbumu);
                }

            }


            using (FileStream stream = new FileStream("export.xls", FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                workbook.Write(stream);
            }
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
