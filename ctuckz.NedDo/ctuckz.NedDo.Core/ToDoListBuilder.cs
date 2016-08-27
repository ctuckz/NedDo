using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ctuckz.NedDo.Core
{
    public class ToDoListBuilder : Builder<ToDoList>
    {
        public ToDoListBuilder()
        {
            Votes = new Dictionary<TaskItem, int>();
        }

        public Dictionary<TaskItem, int> Votes
        {
            get;
        }

        public override void OnBeforeBuild()
        {
            base.OnBeforeBuild();

            if (Votes.Values.Any(v => v < 0))
            {
                throw new InvalidOperationException("Cannot have negative votes.");
            }

            if (Votes.Values.GroupBy(v => v).Any(grp => grp.Count() > 1))
            {
                throw new InvalidOperationException("Ties must be resolved before creating a ToDo list.");
            }
        }

        protected override ToDoList CreateObject()
        {
            ToDoList list = new ToDoList();
            list.AddRange(Votes.OrderByDescending(kvp => kvp.Value).Select(kvp => kvp.Key));
            return list;
        }
    }
}
