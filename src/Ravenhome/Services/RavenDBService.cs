using Raven.Client;
using Raven.Client.Document;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ravenhome.Service.Services
{
    public class RavenDBService : IRavenDBService
    {
        public RavenDBService()
        {
            Init();
        }

        private IDocumentStore _store;

        public Task Init()
        {
            _store = new DocumentStore { Url = "http://carter-box:8088", DefaultDatabase = "Ravenhome" };
            _store.Initialize();
            
            return Task.FromResult(true);
        }

        public IDocumentSession GetSession()
        {
            return _store.OpenSession();
        }
    }
}
