using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Instrumentation;
using GraphQL.Net.Extensions.Example.Models;
using GraphQL.Types;

namespace GraphQL.Net.Extensions.Example.GraphGL.Types
{
    public class MockType : ObjectGraphType<MockModel>
    {
        public MockType()
        {
            Field(x => x.Id).Description("The Id of the Mock.");
            Field(x => x.Name).Description("The name of the Mock.");
            Field(x => x.Description).Description("The name of the Mock.");
        }
    }
}
