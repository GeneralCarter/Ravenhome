using Microsoft.AspNet.Identity;
using Ravenhome.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using Ravenhome.Service;
using Ravenhome.Test.Services;

namespace Ravenhome.Test.Models
{
    public class MockUser : Service.IdentityUser
    {
       
    }

    public class MockUserManager : UserManager<MockUser>
    {
        public MockUserManager() : base(new Mock<IUserStore<MockUser>>().Object, null, null, null, null, null, null, null, null, null)
        { }   
    }

    public class MockRoleManager : RoleManager<UserRole>
    {
        public MockRoleManager() : base(new Mock<IRoleStore<UserRole>>().Object, null, null, null, null, null)
        { }
    }

    public class MockUserStore : UserStore<MockUser>
    {
        public MockUserStore() : base(new MockRavenDBService().GetSession) 
        { }
    }
}
