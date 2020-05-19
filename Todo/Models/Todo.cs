using System;
using SQLite;
namespace Todo
{
    public class Todo
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }

        public bool Complete { get; set; }

        public int TodoId { get; set; }

        public int UnfinishedCount { get; set; }
    }
}
