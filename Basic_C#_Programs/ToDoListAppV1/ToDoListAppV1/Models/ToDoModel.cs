using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ToDoListApp.Models
{
    public class ToDo
    {
        public ToDo()
        {
            ItemDate = DateTime.Now;
        }
        public int ID { get; set; }
        public string ToDoListItem { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ItemDate { get; set; }
        
    }
}