using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoAppMAUI.Models
{
    public class Todo(string name,bool isCompleted)
    {
        public string Name { get; set; } = name;
        public int Id { get; set; }
        public bool IsCompleted { get; set; } = isCompleted;
    }
}
