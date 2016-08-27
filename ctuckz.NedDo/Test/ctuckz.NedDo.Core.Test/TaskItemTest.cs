using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ctuckz.NedDo.Core
{
    [TestFixture]
    [TestOf(typeof(TaskItem))]
    public class TaskItemTest
    {
        [Test]
        public void DefaultConstructor__SetsID()
        {
            TaskItem ti = new TaskItem();
            Assert.That(ti.ID, Is.Not.EqualTo(default(Guid)));
        }

        [Test]
        public void DefaultConstructor__InitializesRelatedTasks()
        {
            TaskItem ti = new TaskItem();
            Assert.That(ti.RelatedTasks, Is.Not.Null);
            Assert.That(ti.RelatedTasks, Is.Empty);
        }

        [Test]
        public void GetHashCode__EqualForSameID()
        {

        }

        [Test]
        public void Equals__ComparesIDs()
        {

        }
        }
}
