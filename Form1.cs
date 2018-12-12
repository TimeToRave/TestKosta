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
    public partial class Form1 : Form
    {

        private List<Departament> departaments;

        public Form1()
        {
            InitializeComponent();
        }

        private void DataBind()
        {
            departaments = Controller.GetDepartaments();

            DepartamentsTreeView.Nodes.Clear();
            TreeNode node = new TreeNode(departaments.ElementAt(0).Name);
            CreateNode(ref node, ref departaments, 0);
            DepartamentsTreeView.Nodes.Add(node);

            List<Employee> allEmployees = Controller.GetEmployees();
            EmployeeDataGridView.DataSource = allEmployees;


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataBind();
        }


        /// <summary>
        /// Составление дерева подчиненных отделов для заданного отдела
        /// </summary>
        /// <param name="node">Корневой элемент</param>
        /// <param name="allDepartaments">Список дочерних отделов на данном уровне вложенности</param>
        /// <param name="index">Порядковый номер отела в списке</param>
        private void CreateNode (ref TreeNode node, ref List<Departament> allDepartaments, int index)
        {
            //TODO Сделать пропуск добавления пустых полей
            TreeNode infoNode = new TreeNode("Подробная информация");
            infoNode.Nodes.Add("ID подразделения: " + allDepartaments.ElementAt(index).Id);
            infoNode.Nodes.Add("Мнемокод: " + allDepartaments.ElementAt(index).Code);
            infoNode.Nodes.Add("ID родительского подразделения: " + allDepartaments.ElementAt(index).ParentDepartamenId);
            node.Nodes.Add(infoNode);

            
            List<Departament> childrenDepartments = Controller.GetDepartaments(parentId: allDepartaments.ElementAt(index).Id);
            if (childrenDepartments.Count > 0)
            {
                TreeNode structureNode = new TreeNode("Структура");
                node.Nodes.Add(structureNode);
                for (int i = 0; i < childrenDepartments.Count; i++)
                {
                    TreeNode childNode = new TreeNode(childrenDepartments.ElementAt(i).Name);
                    structureNode.Nodes.Add(childNode);

                    CreateNode(ref childNode, ref childrenDepartments, i);

                }
            }

        }

        //Позволяет выделять только те ноды, которые содержат название отдела 
        //для последующего отображения списка сотрудников данного отдела
        private void DepartamentsTreeView_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {

            if(e.Node.FirstNode is null)
            {
                e.Cancel = true;
            }
            else
            {
                if (e.Node.FirstNode.Text == "Подробная информация")
                {
                    e.Cancel = false;
                }
                else
                {
                    e.Cancel = true;
                }
            }
            
        }

        //Поиск и вывод сотрудников отдела (выделенного в TreeView) и его подчиненных отделов
        private void DepartamentsTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.IsSelected)
            {
                foreach (Departament departament in departaments)
                {
                    if(departament.Name == e.Node.Text)
                    {
                        List <Departament> childDepartaments = new List<Departament> ();
                        CreateListOfClildrenDepartments(ref childDepartaments, ref departaments, departaments.IndexOf(departament));

                        List<Employee> employeesFromChildDepartments = new List<Employee>();
                        foreach(Departament child in childDepartaments)
                        {
                            employeesFromChildDepartments.AddRange(Controller.GetEmployees(departmentId: child.Id));
                        }
                        EmployeeDataGridView.DataSource = employeesFromChildDepartments;
                    }
                }
            }
        }

        /// <summary>
        /// Поиск всех подчиненных отделов для заданного отдела
        /// </summary>
        /// <param name="allChildDepartments">Список, который хранит все дочерние отделы</param>
        /// <param name="allDepartaments">Список дочерних отделов одного уровня</param>
        /// <param name="index">Порядковый номер отдела в списке</param>
        private void CreateListOfClildrenDepartments(ref List<Departament> allChildDepartments, ref List<Departament> allDepartaments, int index)
        {
            allChildDepartments.Add(allDepartaments.ElementAt(index));
                       
            List<Departament> childrenDepartments = Controller.GetDepartaments(parentId: allDepartaments.ElementAt(index).Id);
            if (childrenDepartments.Count > 0)
            {
                for (int i = 0; i < childrenDepartments.Count; i++)
                {
                    CreateListOfClildrenDepartments(ref allChildDepartments, ref childrenDepartments, i);
                }
            }
        }

        private void AddEmployeeButton_Click(object sender, EventArgs e)
        {
            AddEmployeeForm form = new AddEmployeeForm();
            form.ShowDialog();
            DataBind();
        }

        private void EditButtonToolStrip_Click(object sender, EventArgs e)
        {

            int index = int.Parse(EmployeeDataGridView.Rows[EmployeeDataGridView.CurrentRow.Index].Cells[0].Value.ToString());
            AddEmployeeForm form = new AddEmployeeForm(index);
            form.ShowDialog();
            DataBind();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            int index = int.Parse(EmployeeDataGridView.Rows[EmployeeDataGridView.CurrentRow.Index].Cells[0].Value.ToString());
            Controller.DeleteEmployee(index);
            DataBind();
        }
    }
}
