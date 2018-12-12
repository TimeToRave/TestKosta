using System;

namespace TestKOSTA
{
    public class Departament
    {
        private string id;
        private string name;
        private string code;
        private string parentDepartamentId;

        public string Id
        {
            get
            {
                return id;
            }
            set
            {
                try
                {
                    id = DataCheck.CheckAndFixString(value);
                }
                catch (Exception e)
                {
                    System.Windows.Forms.MessageBox.Show("Ошибка в данных (Идентификатор отдела)" + e.ToString());
                    throw;
                }
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                try
                {
                    name = DataCheck.CheckAndFixString(value, 50);
                }
                catch(Exception e)
                {
                    System.Windows.Forms.MessageBox.Show("Ошибка в данных (Наименование отдела)" + e.ToString());
                    throw;
                }
            }
        }

        public string Code
        {
            get
            {
                return code;
            }
            set
            {
                try
                {
                    code = DataCheck.CheckAndFixString(value, 10, true);
                }
                catch(Exception e)
                {
                    System.Windows.Forms.MessageBox.Show("Ошибка в данных (Код отдела)" + e.ToString());
                    throw;
                }
            }
        }

        public string ParentDepartamenId
        {
            get
            {
                return parentDepartamentId;
            }
            set
            {
                try
                {
                    parentDepartamentId = DataCheck.CheckAndFixString(value, NULL:true);
                }
                catch(Exception e)
                {

                    System.Windows.Forms.MessageBox.Show("Ошибка в данных (Код отдела)" + e.ToString());
                    throw;
                }
            }
        }

        public Departament ()
        {
            Id = "Empty";
            Name = "Empty";

        }

        public Departament (string id, string name, string code = "", string parentDepartamentId = "")
        {
            Id = id;
            Name = name;
            Code = code;
            ParentDepartamenId = parentDepartamentId;
        }
        
    }
}
