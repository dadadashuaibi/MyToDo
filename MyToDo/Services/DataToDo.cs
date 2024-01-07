using BlankApp1.Models;
using ImTools;
using NPOI.HSSF.UserModel;
using NPOI.SS.Formula.Functions;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using Org.BouncyCastle.Pqc.Crypto.Lms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlankApp1.Services
{
    internal class DataToDo : IDataToDos
    {
        //string FilePath = System.IO.Path.Combine(Environment.CurrentDirectory, @"Data\Schedule.xls");
        string FilePath = "C:\\Users\\Zzz\\Desktop\\aa\\MyToDo\\MyToDo\\Data\\Schedule\\ToDo.xlsx";
        public string AddToDo(string Content,string Date)
        {
            if (Content != null) {
                try
                {
                    using (var stream = new FileStream(FilePath, FileMode.Open))
                    {
                        XSSFWorkbook sheets = new XSSFWorkbook(stream);
                        var sheet = sheets.GetSheetAt(0);
                        var row = sheet.CreateRow(sheet.LastRowNum + 1);

                        row.CreateCell(0).SetCellValue(sheet.LastRowNum);
                        row.CreateCell(1).SetCellValue(Date);
                        row.CreateCell(2).SetCellValue(Content);
                        row.CreateCell(3).SetCellValue(0);
                        row.CreateCell(4).SetCellValue(0);

                        using (var stream1 = new FileStream(FilePath, FileMode.Create))
                        {
                            sheets.Write(stream1);
                        }
                    }
                    return "添加成功";
                }catch (Exception ex)
                {
                    return $"添加失败: {ex.Message}";
                }
               
               
            }
            return "内容不能为空";
        }

        public List<ToDo> GetToDos()
        {
            List<ToDo> ToDoList = new List<ToDo>();

            try
            {
                using (var stream = new FileStream(FilePath, FileMode.Open))
                {
                    XSSFWorkbook sheets = new XSSFWorkbook(stream);
                    sheets.MissingCellPolicy = MissingCellPolicy.CREATE_NULL_AS_BLANK;
                    var sheet = sheets.GetSheetAt(0);
                    for (int row = 1; row <= sheet.LastRowNum; row++)
                    {
                        if (sheet.GetRow(row) != null)
                        {
                            ToDoList.Add(new ToDo
                            {
                                Id = int.Parse(sheet.GetRow(row).GetCell(0).ToString()),
                                Date = sheet.GetRow(row).GetCell(1).ToString(),
                                Content = sheet.GetRow(row).GetCell(2).ToString(),
                                Iscompleted = int.Parse(sheet.GetRow(row).GetCell(3).ToString()),
                                Status = int.Parse(sheet.GetRow(row).GetCell(4).ToString())
                            });
                        }
                    }
                }
                return ToDoList;
            }
            catch (Exception ex) { 
                return new List<ToDo>();
            }
           
        }

        public void IsCompleted(int id)
        {
            using (var stream = new FileStream(FilePath, FileMode.Open))
            {
                XSSFWorkbook sheets = new XSSFWorkbook(stream);
                var sheet = sheets.GetSheetAt(0);
                sheet.GetRow(id).GetCell(3).SetCellValue(1);
                using (var stream1 = new FileStream(FilePath, FileMode.Create))
                {
                    sheets.Write(stream1);
                }
            }
        }

        public string RemoveToDo(int id)
        {
            try {
                using (var stream = new FileStream(FilePath, FileMode.Open))
                {
                    XSSFWorkbook sheets = new XSSFWorkbook(stream);
                    var sheet = sheets.GetSheetAt(0);
                    sheet.GetRow(id).GetCell(4).SetCellValue(1);
                    using (var stream1 = new FileStream(FilePath, FileMode.Create))
                    {
                        sheets.Write(stream1);
                    }
                }
                return "删除成功";
            } catch(Exception ex) {
                return $"删除失败: {ex.Message}";
            }
          
        }

        public string ReviseToDo(ToDo todo)
        {
            try
            {
                using (var stream = new FileStream(FilePath, FileMode.Open))
                {
                    XSSFWorkbook sheets = new XSSFWorkbook(stream);
                    var sheet = sheets.GetSheetAt(0);
                    sheet.GetRow(todo.Id).GetCell(1).SetCellValue(todo.Date);
                    sheet.GetRow(todo.Id).GetCell(2).SetCellValue(todo.Content);
                    sheet.GetRow(todo.Id).GetCell(3).SetCellValue(todo.Iscompleted);
                    sheet.GetRow(todo.Id).GetCell(4).SetCellValue(todo.Status);
                    using (var stream1 = new FileStream(FilePath, FileMode.Create))
                    {
                        sheets.Write(stream1);
                    }
                }
                return "修改成功";
            }
            catch
            {

                return "修改失败";

            }
        }
    }
          
}
