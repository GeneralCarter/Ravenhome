using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Raven.Client;
using Raven.Client.Embedded;
using Raven.Client.Indexes;
using Ravenhome.Service;

namespace Ravenhome.Test.Services
{
    public class MockRavenDBService : Service.Services.IRavenDBService
    {
        private IDocumentStore _store;

        public IDocumentSession GetSession()
        {
            return _store.OpenSession();
        }

        public Task Init()
        {
            _store = new EmbeddableDocumentStore
            {
                Configuration =
                {
                    RunInMemory = true,
                    RunInUnreliableYetFastModeThatIsNotSuitableForProduction = true
                }
            };

            _store.Initialize();

            new RavenDocumentsByEntityName().Execute(_store);

            return Task.FromResult(true);
        }

        protected EmbeddableDocumentStore NewDocStore()
        {
            var embeddedStore = new EmbeddableDocumentStore
            {
                Configuration =
                {
                    RunInMemory = true,
                    RunInUnreliableYetFastModeThatIsNotSuitableForProduction = true
                }
            };

            embeddedStore.Initialize();

            new RavenDocumentsByEntityName().Execute(embeddedStore);

            return embeddedStore;
        }
    }
}
