using Raven.Client;
using Raven.Client.Document;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ravenhome.Services
{
    public class RavenDBService : IRavenDBService
    {
        private IDocumentStore _store;

        public Task Init()
        {
            _store = new DocumentStore { Url = "http://carter-box:8088" };
            _store.Initialize();

            return Task.FromResult(true);
        }

        public IDocumentSession getSession()
        {
            return _store.OpenSession();
        }
    }
}
