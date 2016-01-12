using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Raven.Client;
using Ravenhome.Service.Models;

namespace Ravenhome.Service
{
    public class UserStore<TUser> : IUserStore<TUser> where TUser : IdentityUser
    {
        private Func<IDocumentSession> getSessionFunc;  
        private IDocumentSession _session;
        private IDocumentSession session
        {
            get
            {
                if (_session == null)
                {
                    _session = getSessionFunc();
                    _session.Advanced.DocumentStore.Conventions.RegisterIdConvention<TUser>((dbname, commands, user) => "TUsers/" + user.Id);
                }
                return _session;
            }
        }

        public UserStore(Func<IDocumentSession> getSession)
        {
            getSessionFunc = getSession;
        }

        public Task<IdentityResult> CreateAsync(TUser user, CancellationToken cancellationToken)
        {
            if (user == null)
                throw new ArgumentNullException("user");
            if (string.IsNullOrEmpty(user.Id))
                throw new InvalidOperationException("user.Id property must be specified before calling CreateAsync");

            session.Store(user);

            // This model allows us to lookup a user by name in order to get the id
            var userByName = new IdentityUserByUserName(user.Id, user.UserName);
            session.Store(userByName, Util.GetIdentityUserByUserNameId(user.UserName));
            
            return Task.FromResult(new IdentityResult());
        }

        public Task<IdentityResult> DeleteAsync(TUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<TUser> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            var user = this.session.Load<TUser>(userId);
            return Task.FromResult(user);
        }

        public Task<TUser> FindByNameAsync(string userName, CancellationToken cancellationToken)
        {
            var userByName = this.session.Load<IdentityUserByUserName>(Util.GetIdentityUserByUserNameId(userName));
            if (userByName == null)
                return Task.FromResult(default(TUser));

            return FindByIdAsync(userByName.UserId, cancellationToken);
        }

        public Task<string> GetNormalizedUserNameAsync(TUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetUserIdAsync(TUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetUserNameAsync(TUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetNormalizedUserNameAsync(TUser user, string normalizedName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetUserNameAsync(TUser user, string userName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> UpdateAsync(TUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
