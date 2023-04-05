using System;
using SQLite;
using System.Collections.Generic;
using System.Text;
// classe pojo  com especificações dos atibutos
namespace DoToo.Models
{
    public  class TodoItem
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Title { get; set; }

        public bool Completed { get; set; }

        public  DateTime Due { get; set; }

    }
}
