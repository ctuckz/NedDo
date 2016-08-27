using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ctuckz.NedDo.Core
{
    public class TaskItem : IEquatable<TaskItem>
    {
        public TaskItem()
        {
            ID = Guid.NewGuid();
            CreatedUTC = DateTime.UtcNow;
            RelatedTasks = new TaskItemList();
        }

        public Guid ID
        {
            get;
        }

        public DateTime Created => CreatedUTC.ToLocalTime();

        public string Name
        {
            get;
            set;
        }
        
        public string Notes
        {
            get;
            set;
        }

        public TaskItemList RelatedTasks
        {
            get;
        }

        private DateTime CreatedUTC
        {
            get;
        }

        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as TaskItem);
        }

        public bool Equals(TaskItem other)
        {
            return Guid.Equals(ID, other.ID);
        }
    }
}
