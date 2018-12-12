using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestKOSTA
{
    public static class Controller
    {
        private static string connectionString = @"Data Source=DESKTOP-M37KRRP\SQL2017;Initial Catalog=TestDB;Integrated Security=True";

        public static List<Departament> GetDepartaments(string id = "", string parentId = "")
        {
           
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
            }
            catch(Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Ошибка при соединении с базой данных\n" + e.Message);
                throw;
            }

            string query = "";

            SqlCommand command = new SqlCommand();
            SqlDataReader dataReader;

            if ((id.Length == 0) && (parentId.Length == 0))
            {
                query = "SELECT * FROM Department";
                command = new SqlCommand(query, connection);

            }
            if((id.Length == 0) && (parentId.Length > 0))
            {
                query = "SELECT * FROM Department WHERE ParentDepartmentID = @pid";
                command = new SqlCommand(query, connection);
                command.Parameters.Add("@pid", SqlDbType.NVarChar).Value = parentId;
            }
            if((id.Length > 0) && (parentId.Length == 0))
            {
                query = "SELECT * FROM Department WHERE ID = @id";
                command = new SqlCommand(query, connection);
                command.Parameters.Add("@id", SqlDbType.NVarChar).Value = id;
            }
            if ((id.Length > 0) && (parentId.Length > 0))
            {
                query = "SELECT * FROM Department WHERE ID = @id AND ParentDepartmentID = @pid";
                command = new SqlCommand(query, connection);
                command.Parameters.Add("@id", SqlDbType.NVarChar).Value = id;
                command.Parameters.Add("@pid", SqlDbType.NVarChar).Value = parentId;
            }

            List<Departament> departmentsFromDB = new List<Departament>();

            try  
            {
                dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    string idDB = dataReader.GetValue(0).ToString();
                    string nameDB = dataReader.GetValue(1).ToString();
                    string codeDB = dataReader.GetValue(2).ToString();
                    string parentIdDB = dataReader.GetValue(3).ToString();

                    departmentsFromDB.Add(new Departament(idDB, nameDB, codeDB, parentIdDB));

                    
                }
                dataReader.Close();

            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Ошибка в чтении данных из базы данных\n" + e.Message);
                throw;
            }
            finally
            {
                connection.Close();
            }

            return departmentsFromDB;
        }

        public static List<Employee> GetEmployees(int id = 0, string departmentId = "")
        {
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();
            }
            catch(Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Ошибка при соединении с базой данных\n" + e.Message);
                throw;
            }

            string query = "";

            SqlCommand command = new SqlCommand();
            SqlDataReader dataReader;

            if ((id == 0) && (departmentId.Length == 0))
            {
                query = "SELECT * FROM Empoyee";
                command = new SqlCommand(query, connection);

            }
            if ((id == 0) && (departmentId.Length > 0))
            {
                query = "SELECT * FROM Empoyee WHERE DepartmentID = @depId";
                command = new SqlCommand(query, connection);
                command.Parameters.Add("@depId", SqlDbType.NVarChar).Value = departmentId;
            }
            if ((id > 0) && (departmentId.Length == 0))
            {
                query = "SELECT * FROM Empoyee WHERE ID = @id";
                command = new SqlCommand(query, connection);
                command.Parameters.Add("@id", SqlDbType.Int).Value = id;
            }
            if ((id > 0) && (departmentId.Length > 0))
            {
                query = "SELECT * FROM Empoyee WHERE ID = @id AND DepartmentID = @depId";
                command = new SqlCommand(query, connection);
                command.Parameters.Add("@id", SqlDbType.Int).Value = id;
                command.Parameters.Add("@depId", SqlDbType.NVarChar).Value = departmentId;
            }

            List<Employee> employeesFromDB = new List<Employee>();

            try
            {
                dataReader = command.ExecuteReader();

                while(dataReader.Read())
                {
                    int idDB = int.Parse(dataReader.GetValue(0).ToString());
                    string firstNameDB = dataReader.GetValue(1).ToString();
                    string surNameDB = dataReader.GetValue(2).ToString();
                    string patronymicDB = dataReader.GetValue(3).ToString();
                    DateTime dateOfBirthDB = DateTime.Parse(dataReader.GetValue(4).ToString());
                    string docSeriesDB = dataReader.GetValue(5).ToString();
                    string docNumberDB = dataReader.GetValue(6).ToString();
                    string positionDB = dataReader.GetValue(7).ToString();
                    string departmanetIdDB = dataReader.GetValue(8).ToString();                    

                    employeesFromDB.Add(new Employee(firstNameDB, surNameDB, dateOfBirthDB, positionDB, departmanetIdDB, idDB, patronymicDB, docSeriesDB, docNumberDB));

                }
                dataReader.Close();
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Ошибка в чтении данных из базы данных\n" + e.Message);
                throw;
            }
            finally
            {
                connection.Close();
            }

            return employeesFromDB;

        }

        public static void AddEmployee(Employee newEmployee)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
            }
            catch(Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Ошибка при подключении к базе данных" + e.Message);
                throw;
            }
            

            SqlCommand command;
            string query = "INSERT INTO Empoyee VALUES (@firstName, @surName, @patronimyc, @dateOfBirth, @docSeries, @DocNumber, @position, @departmentId)";
            command = new SqlCommand(query, connection);
            command.Parameters.Add("@firstName", SqlDbType.NVarChar).Value = newEmployee.FirstName;
            command.Parameters.Add("@surName", SqlDbType.NVarChar).Value = newEmployee.SurName;
            command.Parameters.Add("@patronimyc", SqlDbType.NVarChar).Value = newEmployee.Patronymic;
            command.Parameters.Add("@dateOfBirth", SqlDbType.Date).Value = newEmployee.DateOfBirth;
            command.Parameters.Add("@docSeries", SqlDbType.NVarChar).Value = newEmployee.DocSeries;
            command.Parameters.Add("@docNumber", SqlDbType.NVarChar).Value = newEmployee.DocNumber;
            command.Parameters.Add("@position", SqlDbType.NVarChar).Value = newEmployee.Position;
            command.Parameters.Add("@departmentID", SqlDbType.NVarChar).Value = newEmployee.DepartmentId;

            try
            { 
                command.ExecuteNonQuery();
            }
            catch(Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Ошибка при выполнении запроса к базе данных" + e.Message);
                throw;
            }
            finally
            {
                connection.Close();
            }
            
        }

        public static void EditEmployee(Employee editedEmployee)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Ошибка при подключении к базе данных" + e.Message);
                throw;
            }

            SqlCommand command;
            string query = "UPDATE Empoyee SET FirstName=@firstName, SurName=@surName, Patronymic=@patronimyc, DateOfBirth=@dateOfBirth, DocSeries=@docSeries, DocNumber=@docNumber, Position=@position, DepartmentId=@departmentId WHERE ID=@id";
            command = new SqlCommand(query, connection);
            command.Parameters.Add("@firstName", SqlDbType.NVarChar).Value = editedEmployee.FirstName;
            command.Parameters.Add("@surName", SqlDbType.NVarChar).Value = editedEmployee.SurName;
            command.Parameters.Add("@patronimyc", SqlDbType.NVarChar).Value = editedEmployee.Patronymic;
            command.Parameters.Add("@dateOfBirth", SqlDbType.Date).Value = editedEmployee.DateOfBirth;
            command.Parameters.Add("@docSeries", SqlDbType.NVarChar).Value = editedEmployee.DocSeries;
            command.Parameters.Add("@docNumber", SqlDbType.NVarChar).Value = editedEmployee.DocNumber;
            command.Parameters.Add("@position", SqlDbType.NVarChar).Value = editedEmployee.Position;
            command.Parameters.Add("@departmentID", SqlDbType.NVarChar).Value = editedEmployee.DepartmentId;
            command.Parameters.Add("@id", SqlDbType.Int).Value = editedEmployee.Id;


            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Ошибка при выполнении запроса к базе данных" + e.Message);
                throw;
            }
            finally
            {
                connection.Close();
            }

        }

        public static void DeleteEmployee(int id)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Ошибка при подключении к базе данных" + e.Message);
                throw;
            }

            SqlCommand command;
            string query = "DELETE FROM Empoyee WHERE id=@id";
            command = new SqlCommand(query, connection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;


            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Ошибка при выполнении запроса к базе данных" + e.Message);
                throw;
            }
            finally
            {
                connection.Close();
            }

        }



    }


}
