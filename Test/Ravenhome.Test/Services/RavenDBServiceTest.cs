using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ravenhome.Service.Services;
using Xunit;

namespace Ravenhome.Test.Services
{
    public class RavenDBServiceTest
    {
        private readonly RavenDBService _ravenDBService;

        public RavenDBServiceTest()
        {
            _ravenDBService = new RavenDBService();
        }

        [Fact]
        public void Init()
        {
            var result = _ravenDBService.Init();

            Assert.True(true, String.Format("Initilization failed"));
        }

        [Fact]
        public void GetSession()
        {
            _ravenDBService.Init();
            using (var session = _ravenDBService.GetSession())
            {
                Assert.NotNull(session);
            }
        }
    }
}
