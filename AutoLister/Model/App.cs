using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;

namespace AutoLister
{
    class ExcelApp
    {
        Application app = new Application();
        
      
        public void AddLection(string Theme,DateTime date,List<Student> students)
        {
            int i = 1;
            app.Visible = true;
            app.Workbooks.Add();
            _Worksheet workSheet = (_Worksheet)app.ActiveSheet;
            foreach (var student in students) 
            {
                workSheet.Cells[i,"A"]= student.FullName ;
                i++;
            }
            
            
        }
        public void SaveBook(string path,string Name) 
        {
            string FullName = path+"\\"+Name;
            app.ActiveWorkbook.SaveAs(FullName);
        }

        public void AddGroup(string Name,List<Student> members)
        {
            int i = 1;
            _Worksheet workSheet = (_Worksheet)app.ActiveSheet;
            foreach (var student in members)
            {
                workSheet.Cells[i, "A"] = student.FullName;
                i++;
            }

        }
    }
}
