using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestKOSTA
{
    public partial class AddEmployeeForm : Form
    {
        private int editedEmployeeId = 0;

        public AddEmployeeForm()
        {
            InitializeComponent();
            
            try
            {
                List<Departament> departaments = Controller.GetDepartaments();
                DepartmentComboBox.DataSource = departaments;
                DepartmentComboBox.DisplayMember = "Name";
                DepartmentComboBox.ValueMember = "Id";
            }
            catch(Exception e)
            {
                MessageBox.Show("Ошибка при загрузке данных об отделах " + e.Message);
                return;
            }

            CreateButton.Visible = true;

        }

        public AddEmployeeForm(int id)
        {
            InitializeComponent();
            HeaderLabel.Text = "Редактирование сотрудника";
            
            try
            {
                List<Departament> departaments = Controller.GetDepartaments();
                DepartmentComboBox.DataSource = departaments;
                DepartmentComboBox.DisplayMember = "Name";
                DepartmentComboBox.ValueMember = "Id";
            }
            catch (Exception e)
            {
                MessageBox.Show("Ошибка при загрузке данных об отделах " + e.Message);
                return;
            }

            Employee currentEmployee = new Employee();
            try
            {
                currentEmployee = Controller.GetEmployees(id: id).ElementAt(0);
            }
            catch (Exception e)
            {
                MessageBox.Show("Ошибка при загрузке данных о сотрудниках" + e.Message);
                return;
            }

            FirstNameTextBox.Text = currentEmployee.FirstName;
            SurNameTextBox.Text = currentEmployee.SurName;
            PatronimycTextBox.Text = currentEmployee.Patronymic;
            DateOfBirthDatePicker.Value = currentEmployee.DateOfBirth;
            DocSeriesTextBox.Text = currentEmployee.DocSeries;
            DocNumberTextBox.Text = currentEmployee.DocNumber;
            PositionTextBox.Text = currentEmployee.Position;
            DepartmentComboBox.SelectedValue = currentEmployee.DepartmentId;
            editedEmployeeId = currentEmployee.Id;

            EditButton.Visible = true;
        }


        private void CreateButton_Click(object sender, EventArgs e)
        {
            if ((FirstNameTextBox.Text.Length > 0) && (SurNameTextBox.Text.Length > 0 ) 
                && (PositionTextBox.Text.Length >0) && (DateOfBirthDatePicker.Value < DateTime.Now))
            {
                string firstName = FirstNameTextBox.Text;
                string surName = SurNameTextBox.Text;
                string patronimyc = PatronimycTextBox.Text;
                DateTime dateOfBirth = DateOfBirthDatePicker.Value;
                string docSeries = DocSeriesTextBox.Text;
                string docNumber = DocNumberTextBox.Text;
                string position = PositionTextBox.Text;
                string departmentId = DepartmentComboBox.SelectedValue.ToString();

                Employee newEmployee = new Employee(firstName, surName, dateOfBirth, position, departmentId, patronimyc: patronimyc, docSeries: docSeries, docNumber: docNumber);

                try
                {
                    Controller.AddEmployee(newEmployee);
                    MessageBox.Show("Добавление сотрудника выполнено успешно");
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Добавление сотрудника было прервано " + ex.Message);
                    return;
                }
                    
            }
            else
            {
                MessageBox.Show("Проверьте правильность заполнения полей");
            }
            
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            if ((FirstNameTextBox.Text.Length > 0) && (SurNameTextBox.Text.Length > 0)
                && (PositionTextBox.Text.Length > 0) && (DateOfBirthDatePicker.Value < DateTime.Now))
            {
                string firstName = FirstNameTextBox.Text;
                string surName = SurNameTextBox.Text;
                string patronimyc = PatronimycTextBox.Text;
                DateTime dateOfBirth = DateOfBirthDatePicker.Value;
                string docSeries = DocSeriesTextBox.Text;
                string docNumber = DocNumberTextBox.Text;
                string position = PositionTextBox.Text;
                string departmentId = DepartmentComboBox.SelectedValue.ToString();

                Employee editedEmployee = new Employee(firstName, surName, dateOfBirth, position, departmentId, id: editedEmployeeId, patronimyc: patronimyc, docSeries: docSeries, docNumber: docNumber);

                try
                {
                    Controller.EditEmployee(editedEmployee);
                    MessageBox.Show("Редактирование сотрудника выполнено успешно");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Редактирование сотрудника было прервано " + ex.Message);
                    return;
                }

            }
            else
            {
                MessageBox.Show("Проверьте правильность заполнения полей");
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
