using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace M120Projekt.Data
{
    public class Task
    {
        #region Datenbankschicht
        [Key]
        public Int64 TaskID { get; set; }
        [Required]
        public String Title { get; set; }
        [Required]
        public DateTime Due_Date { get; set; }
        [Required]
        public DateTime Creation_Date { get; set; }
        public String Description { get; set; }
        public Boolean Checked { get; set; }
        public Int16 Importance { get; set; }
        public String Category { get; set; }
        #endregion
        #region Applikationsschicht
        public Task() { }
        [NotMapped]
        public String calculatedAttribute
        {
            get
            {
                return "You can insert code into the getter to get the calculated attribute";
            }
        }
        public static IEnumerable<Data.Task> ReadAll()
        {
            return (from record in Data.Global.context.Task select record);
        }
        public static Data.Task ReadID(Int64 taskID)
        {
            return (from record in Data.Global.context.Task where record.TaskID == taskID select record).FirstOrDefault();
        }
        public static IEnumerable<Data.Task> ReadTitle(String query)
        {
            return (from record in Data.Global.context.Task where record.Title == query select record);
        }
        public static IEnumerable<Data.Task> ReadTitleLike(String query)
        {
            return (from record in Data.Global.context.Task where record.Title.Contains(query) select record);
        }
        public Int64 Create()
        {
            if (this.Title == null || this.Title == "") this.Title = "clear";
            if (this.Due_Date == null) this.Due_Date = DateTime.MinValue;
            if (this.Creation_Date == null) this.Creation_Date = DateTime.MinValue;
            if (this.Category == null || this.Category == "") this.Category = "default";
            if (this.Description == null || this.Description == "") this.Description = "no description";
            
            Data.Global.context.Task.Add(this);
            Data.Global.context.SaveChanges();
            return this.TaskID;
        }
        public Int64 Update()
        {
            Data.Global.context.Entry(this).State = System.Data.Entity.EntityState.Modified;
            Data.Global.context.SaveChanges();
            return this.TaskID;
        }
        public void Delete()
        {
            Data.Global.context.Entry(this).State = System.Data.Entity.EntityState.Deleted;
            Data.Global.context.SaveChanges();
        }
        public override string ToString()
        {
            return TaskID.ToString(); // For better Coded UI Test recognition
        }
        #endregion
    }
}
