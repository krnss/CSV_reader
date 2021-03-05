using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CVS_data_reader.Models
{
    public class Person
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }       
        public bool Married { get; set; }
        public string Phone { get; set; }
        public decimal Salary { get; set; }
    }
}