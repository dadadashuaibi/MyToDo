using BlankApp1.Models;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;

namespace BlankApp1.Services
{
    internal class DataNote : IDataNote
    {
        // string FilePath = System.IO.Path.Combine(Environment.CurrentDirectory, @"Data\Schedule.xls");
        string FilePath = "C:\\Users\\Zzz\\Desktop\\aa\\MyToDo\\MyToDo\\Data\\Note\\Note.xlsx";

        public string AddNote(Note note)
        { 
            if (note.Content != null)
            {
                try
                {
                    using (var stream = new FileStream(FilePath, FileMode.Open))
                    {
                        XSSFWorkbook sheets = new XSSFWorkbook(stream);
                        var sheet = sheets.GetSheetAt(0);
                        var row = sheet.CreateRow(sheet.LastRowNum + 1);
                        row.CreateCell(0).SetCellValue(sheet.LastRowNum + 1);
                        row.CreateCell(1).SetCellValue(DateTime.Now.ToString("yyyy-MM-dd"));
                        row.CreateCell(2).SetCellValue(note.Tittle);
                        row.CreateCell(3).SetCellValue(0);
                        row.CreateCell(4).SetCellValue(note.Content);
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
            return"内容不能为空";
        }

        public List<Note> GetNote()
        {
            List<Note> NoteList = new List<Note>();

            try
            {
                using (var stream = new FileStream(FilePath, FileMode.Open))
                {
                    XSSFWorkbook sheets = new XSSFWorkbook(stream);
                    var sheet = sheets.GetSheetAt(0);
                    for (int row = 1; row <= sheet.LastRowNum; row++)
                    {
                        if (sheet.GetRow(row) != null)
                        {
                            NoteList.Add(new Note
                            {
                                Id = row,
                                Date = sheet.GetRow(row).GetCell(1).ToString(),
                                Tittle = sheet.GetRow(row).GetCell(2).ToString(),
                                Status = Convert.ToInt32(sheet.GetRow(row).GetCell(3).ToString()),
                                Content = sheet.GetRow(row).GetCell(4).ToString()
                            });
                        }
                    }
                }
                return NoteList;
            }
            catch { 
            return NoteList;
            }
           


        }

        public string RemoveNote(int id)
        {
            try
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
                return"删除成功";
            } catch(Exception ex) {
                return $"删除失败:{ ex.Message}";
            }
           
        }

        public string ReviseNote(Note note)
        {
            try
            {
                using (var stream = new FileStream(FilePath, FileMode.Open))
                {
                    XSSFWorkbook sheets = new XSSFWorkbook(stream);
                    var sheet = sheets.GetSheetAt(0);
                    sheet.GetRow(note.Id).GetCell(1).SetCellValue(note.Date);
                    sheet.GetRow(note.Id).GetCell(2).SetCellValue(note.Tittle);
                    sheet.GetRow(note.Id).GetCell(3).SetCellValue(note.Status);
                    sheet.GetRow(note.Id).GetCell(4).SetCellValue(note.Content);
                    using (var stream1 = new FileStream(FilePath, FileMode.Create))
                    {
                        sheets.Write(stream1);
                    }
                }
                return"修改成功";
            }
            catch { return "修改失败"; }
           
        } 
               
    }
}
