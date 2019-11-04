using Entity;
using Manager;
using Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
//using System.Web.Mvc;

namespace TaskProject.Controllers
{
    public class TasksController : ApiController
    {
        TaskManager tm = new TaskManager();

        [ResponseType(typeof(Task))]
        [BasicAuthentication]
        public IHttpActionResult PostTask(TaskModel task)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            task.CreateId = Security.AuthId;
            tm.Add(task);
            return CreatedAtRoute("DefaultApi", new { id = task }, task);
        }

        [System.Web.Http.Route("api/Task/Delete")]
        [System.Web.Http.HttpPut]
        [BasicAuthentication]
        public IHttpActionResult DeleteTask(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            tm.Delete(id);
            return Ok();
        }

        [HttpGet]
        public IHttpActionResult DownloadTaskList(int scheduleId)
        {
            Microsoft.Office.Interop.Excel.Application oXL;
            Microsoft.Office.Interop.Excel._Workbook oWB;
            Microsoft.Office.Interop.Excel._Worksheet oSheet;
            object misvalue = System.Reflection.Missing.Value;
            try
            {
                oXL = new Microsoft.Office.Interop.Excel.Application();
                oXL.Visible = true;

                oWB = (Microsoft.Office.Interop.Excel._Workbook)(oXL.Workbooks.Add(""));
                oSheet = (Microsoft.Office.Interop.Excel._Worksheet)oWB.ActiveSheet;

                oSheet.Cells[1, 3] = "First Name";
                oSheet.Cells[1, 4] = "Last Name";
                oSheet.Cells[1, 1] = "Title";
                oSheet.Cells[1, 2] = "Description";
                oSheet.Cells[1, 5] = "Create Date";
                oSheet.Cells[1, 6] = "Count";
                oSheet.Cells[1, 7] = "Status";

                TaskInfoModel[] model = tm.Get(scheduleId);

                for (int i = 1; i <= model.Length; i++)
                {
                    oSheet.Cells[i + 1, 1] = model[i - 1]._Title;
                    oSheet.Cells[i + 1, 2] = model[i - 1]._Description;
                    oSheet.Cells[i + 1, 3] = model[i - 1]._FirstName;
                    oSheet.Cells[i + 1, 4] = model[i - 1]._LastName;
                    oSheet.Cells[i + 1, 5] = model[i - 1]._CreateDate;
                    oSheet.Cells[i + 1, 6] = model[i - 1]._ExpireDate;
                    oSheet.Cells[i + 1, 7] = model[i - 1]._AttCount;
                    oSheet.Cells[i + 1, 8] = model[i - 1]._Status;
                }
                oSheet.get_Range("A1", "F1").Font.Bold = true;
                oSheet.get_Range("A1", "F1").VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;

                oXL.Visible = false;
                oXL.UserControl = false;
                oWB.SaveAs(@"C:\Users\santr\OneDrive\Рабочий стол\EntityFiles\Some.xls", Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing,
                    false, false, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

                oWB.Close();
                oXL.Quit();
                return Ok();

            }
            catch (Exception e)
            {
                return BadRequest();
            }

        }

    }
}
