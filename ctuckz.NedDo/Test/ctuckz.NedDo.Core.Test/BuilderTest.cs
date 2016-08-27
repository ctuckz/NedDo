using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using Moq.Protected;

namespace ctuckz.NedDo.Core
{
    [TestFixture]
    [TestOf(typeof(Builder<>))]
    public class BuilderTest
    {
        [Test]
        public void OnBeforeBuild__CalledBeforeCreateObject()
        {
            Mock<Builder<object>> mockBuilder = new Mock<Builder<object>>();
            mockBuilder.Protected().Setup<object>("CreateObject").Returns(null)
                .Callback(() => mockBuilder.Verify(b => b.OnBeforeBuild(), Times.Once));

            mockBuilder.Object.Build();
        }

        [Test]
        public void OnAfterBuild__CalledAfterCreateObject()
        {
            Mock<Builder<object>> mockBuilder = new Mock<Builder<object>>();
            mockBuilder.Protected().Setup<object>("CreateObject").Returns(null)
                .Callback(() => mockBuilder.Verify(b => b.OnAfterBuild(), Times.Never));

            mockBuilder.Object.Build();

            mockBuilder.Verify(b => b.OnAfterBuild(), Times.Once);
        }
    }
}
