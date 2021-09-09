using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace AutoLister
{
    class ExcelApp
    {
        public Application app;

        public ExcelApp() 
        {
            app = new Application();
        }
        ~ExcelApp()
        {
            app.Quit();
        }


        public void SaveLection(Lection lection)
        {
            lection.Groups = GetSavedGroups("Test.xlsx");//Получение списка групп
            app.Workbooks.Open("Test.xlsx");
            Workbook workbook = app.ActiveWorkbook;
            foreach (Worksheet sheet in workbook.Sheets)
            {       
                var group = lection.Groups.Find(g => g.Name == sheet.Name.ToString() );//Находим нужную группу
                var i=2;
                Range row = sheet.UsedRange.Rows[1];
                int names = row.Cells.Count;
                Range Markscolumn = sheet.UsedRange.Columns[names+1];
                Markscolumn.Cells[1] = $"{lection.Theme} {lection.Time:dd.MM.yy}" ;//Заполняем название лекции
                
                foreach(var student in group.Members)
                {
                    bool IsHere = false;
                    foreach (var s in lection.Students)
                        if (student.Equals(s))
                        {
                            IsHere = true;
                        }
                   if (IsHere == true)
                     Markscolumn.Cells[i] = "+";
                   else
                     Markscolumn.Cells[i] = "-";

                  i++;
                }
            }
            workbook.Save();
            workbook.Close();
        }

        /// <summary>
        /// Добавляет группу в список посещений
        /// </summary>
        /// <param name="group"> Список группы </param>
        public void AddGroup(Group group)
        {
            int i = 2;
            if (!File.Exists(@"C:\Users\uzver\Documents\Test.xlsx"))
            {
                app.Workbooks.Add(Missing.Value).SaveAs("Test.xlsx");

            }
            app.Workbooks.Open("Test.xlsx", ReadOnly: false, Editable: true);
            var workbook = app.ActiveWorkbook;
            var sheets = workbook.Sheets;
            var NewSheet = sheets.Add();
            NewSheet.Name = group.Name;
            _Worksheet workSheet = (_Worksheet)app.ActiveSheet;
            foreach (var student in group.Members)
            {
                workSheet.Cells[i++, "A"] = student.FullName;
            }
            workbook.Save();
            workbook.Close();
        }

        /// <summary>
        /// Получает список групп из файла отчета
        /// </summary>
        /// <param name="path"></param>
        /// <returns>Список групп</returns>
        public List<Group> GetSavedGroups(string path)
        {
            List<Group> groups = new List<Group>();
            Workbook workbook = app.Workbooks.Open(path);
            foreach (Worksheet sheet in app.ActiveWorkbook.Worksheets)
            {
                var group = new Group(sheet.Name);
                Range column = sheet.UsedRange.Columns[1];
                //column.AutoFormat(Format:XlRangeAutoFormat.xlRangeAutoFormatClassic2);
                Array values = (Array)column.Cells.Value2;
                var names = values.OfType<object>().Select(s => s.ToString()).ToList();
                group.Members = new List<Student>();
                foreach (string name in names)
                {
                    group.Members.Add(new Student(name.Trim(' ')));
                }
                groups.Add(group);             
            }
            workbook.Close();
            return groups;
        }
        /// <summary>
        /// Создает группу по списку
        /// </summary>
        /// <param name="path"></param>
        /// <returns>список группы</returns>
        public List<Student> GetGroupFromTable(string path)
        {
            var Members = new List<Student>();
            app.Workbooks.Open(path);
            Worksheet activeSheet = (Worksheet)app.ActiveWorkbook.Sheets[1];
            Range column = activeSheet.UsedRange.Columns[1];
            System.Array values = (System.Array)column.Cells.Value2;
            var names = values.OfType<object>().Select(s => s.ToString()).ToList();
            foreach (string name in names)
            {
                Members.Add(new Student(name));
            }
            return Members;
        }
    }
}
