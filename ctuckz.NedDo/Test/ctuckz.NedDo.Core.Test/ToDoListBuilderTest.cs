using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ctuckz.NedDo.Core
{
    [TestFixture]
    [TestOf(typeof(ToDoListBuilder))]
    public class ToDoListBuilderTest
    {
        [Test]
        public void NoVotes__ReturnsEmptyList()
        {
            ToDoListBuilder builder = new ToDoListBuilder();
            Assert.That(builder.Build(), Is.Empty);
        }

        [Test]
        public void NegativeVotes__Throws()
        {
            ToDoListBuilder builder = new ToDoListBuilder();
            builder.Votes.Add(new TaskItem(), -1);

            Assert.That(() => builder.Build(), Throws.InvalidOperationException);
        }

        [Test]
        public void TiedVotes__Throws()
        {
            ToDoListBuilder builder = new ToDoListBuilder();
            builder.Votes.Add(new TaskItem(), 1);
            builder.Votes.Add(new TaskItem(), 1);

            Assert.That(() => builder.Build(), Throws.InvalidOperationException);
        }

        [Test]
        public void Build__OrdersTasksByVotes()
        {
            ToDoListBuilder builder = new ToDoListBuilder();
            TaskItem t1 = new TaskItem();
            TaskItem t2 = new TaskItem();
            TaskItem t3 = new TaskItem();
            builder.Votes.Add(t1, 10);
            builder.Votes.Add(t2, 0);
            builder.Votes.Add(t3, 1);

            ToDoList list = builder.Build();

            Assert.That(list.Count, Is.EqualTo(3));
            Assert.That(list[0], Is.EqualTo(t1));
            Assert.That(list[1], Is.EqualTo(t3));
            Assert.That(list[2], Is.EqualTo(t2));
        }
    }
}
