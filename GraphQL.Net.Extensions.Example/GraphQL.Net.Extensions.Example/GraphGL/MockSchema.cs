using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Net.Extensions.Example.GraphGL.Queries;
using GraphQL.Types;

namespace GraphQL.Net.Extensions.Example.GraphGL
{
    public class MockSchema : Schema
    {
        public MockSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<MockQuery>();
        }
    }
}
