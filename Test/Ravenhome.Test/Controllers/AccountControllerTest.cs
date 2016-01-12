using Ravenhome.Service.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.Extensions.DependencyInjection;
using Ravenhome.Test.Models;
using Ravenhome.Service.Models;
using Xunit;

namespace Ravenhome.Test.Controllers
{
    public class AccountControllerTest
    {
        IServiceCollection services;

        private AccountController _controller;
        public AccountControllerTest()
        {
            services = new ServiceCollection()
                    .AddTransient<IUserStore<MockUser>, MockUserStore>();
            services.AddIdentity<MockUser, UserRole>();

            var manager = services.BuildServiceProvider().GetRequiredService<UserManager<MockUser>>();
            Assert.NotNull(manager);

            _controller = new AccountController(manager, null);
        }

        [Fact]
        public void RegisterUserTest()
        {
            
        }



    }
}
