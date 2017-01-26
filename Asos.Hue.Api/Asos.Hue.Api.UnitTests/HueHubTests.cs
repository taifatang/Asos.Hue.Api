using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Should;

namespace Asos.Hue.Api.UnitTests
{
    [TestFixture]
   public  class HueHubTests
    {
        [Test]
        public void Should_Return_An_Object_When_New()
        {
            var hueHub = new HueHub();
            hueHub.ShouldNotBeNull();
        }
    }
}
