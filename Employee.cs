using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestKOSTA
{
    public class Employee
    {
        private int id;
        private string firstName;
        private string surName;
        private string patronymic;
        private DateTime dateOfBirth;
        private int age;
        private string docSeries;
        private string docNumber;
        private string position;
        private string department;
        private string departmentId;

        [DisplayName("#")]
        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                if(value > 0)
                {
                    id = value;
                }
                else
                {
                    id = 0;
                }
            }
        }

        [DisplayName("Имя")]
        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                try
                {
                    firstName = DataCheck.CheckAndFixString(value, 50);
                }
                catch (Exception e)
                {
                    System.Windows.Forms.MessageBox.Show("Ошибка в данных (Имя сотрудника)" + e.ToString());
                    throw;
                }
            }
        }

        [DisplayName("Фамилия")]
        public string SurName
        {
            get
            {
                return surName;
            }
            set
            {
                try
                {
                    surName = DataCheck.CheckAndFixString(value, 50);
                }
                catch (Exception e)
                {
                    System.Windows.Forms.MessageBox.Show("Ошибка в данных (Фамилия сотрудника)" + e.ToString());
                    throw;
                }
            }
        }

        [DisplayName("Отчество")]
        public string Patronymic
        {
            get
            {
                return patronymic;
            }
            set
            {
                try
                {
                    patronymic = DataCheck.CheckAndFixString(value, 50, true);
                }
                catch (Exception e)
                {
                    System.Windows.Forms.MessageBox.Show("Ошибка в данных (Отчество сотрудника)" + e.ToString());
                    throw;
                }
            }
        }

        [DisplayName("Дата рождения")]
        public DateTime DateOfBirth
        {
            get
            {
                return dateOfBirth;
            }
            set
            {
                dateOfBirth = value;
            }
        }

        [DisplayName("Возраст")]
        public int Age
        {
            get
            {
                return age;
            }
            private set
            {
                age = value;
            }
        }

        [DisplayName("Серия документа")]
        public string DocSeries
        {
            get
            {
                return docSeries;
            }
            set
            {
                try
                {
                    docSeries = DataCheck.CheckAndFixString(value, 4, true);
                }
                catch (Exception e)
                {
                    System.Windows.Forms.MessageBox.Show("Ошибка в данных (Серия документа)" + e.ToString());
                    throw;
                }
            }
        }

        [DisplayName("Номер документа")]
        public string DocNumber
        {
            get
            {
                return docNumber;
            }
            set
            {
                try
                {
                    docNumber = DataCheck.CheckAndFixString(value, 6, true);
                }
                catch (Exception e)
                {
                    System.Windows.Forms.MessageBox.Show("Ошибка в данных (Номер документа)" + e.ToString());
                    throw;
                }
            }
        }

        [DisplayName("Должность")]
        public string Position
        {
            get
            {
                return position;
            }
            set
            {
                try
                {
                    position = DataCheck.CheckAndFixString(value, 50);
                }
                catch (Exception e)
                {
                    System.Windows.Forms.MessageBox.Show("Ошибка в данных (Должность)" + e.ToString());
                    throw;
                }
            }
        }

        [DisplayName("Отдел")]
        public string Department
        {
            get
            {
                return department;
            }
            private set
            {
                department = value;
            }
        }

        [DisplayName("Идентификатор подраазделения")]
        public string DepartmentId
        {
            get
            {
                return departmentId;
            }
            set
            {
                try
                {
                    departmentId = DataCheck.CheckAndFixString(value, 50);
                }
                catch (Exception e)
                {
                    System.Windows.Forms.MessageBox.Show("Ошибка в данных (Идентификатор отдела)" + e.ToString());
                    throw;
                }
            }
        }

        




        public Employee ()
        {
            Id = 0;
            FirstName = "Empty";
            SurName = "Empty;";
            Patronymic = "";
            DateOfBirth = new DateTime();
            Age = 0;
            DocSeries = "";
            DocNumber = "";
            Position = "Empty";
            DepartmentId = "Empty";
            Department = "Empty";
        }

        public Employee (string firstName, string surName, DateTime dateOfBirth, string position, string departmentId, int id = 0, string patronimyc = "", string docSeries = "", string docNumber = "")
        {
            Id = id;
            FirstName = firstName;
            SurName = surName;
            Patronymic = patronimyc;
            DateOfBirth = dateOfBirth;
            GetAge();
            DocSeries = docSeries;
            DocNumber = docNumber;
            Position = position;
            DepartmentId = departmentId;
            GetDepartment();
        }

        private void GetAge ()
        {
            DateTime now = DateTime.Now;

            int age = now.Year - DateOfBirth.Year;

            if (now.Month < DateOfBirth.Month || (now.Month == DateOfBirth.Month && now.Day < DateOfBirth.Day))
                    age--;

            Age = age;
        }

        private void GetDepartment()
        {
            Department = Controller.GetDepartaments(id: DepartmentId).ElementAt(0).Name;
        }
        
    }
}
