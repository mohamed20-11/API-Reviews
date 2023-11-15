﻿using System.Text.Json.Serialization;

namespace ChrAPI1.Models
{
    public class Department
    {
        public int  Id { get; set; }
        public string Name { get; set; }
        public string ManagerName { get; set; }

        [JsonIgnore]
        public virtual List<Employee>? Emps { get; set; }
    }
}
