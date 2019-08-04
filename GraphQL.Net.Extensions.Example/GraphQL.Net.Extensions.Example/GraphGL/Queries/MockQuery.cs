using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Net.Extensions.Example.Extensions;
using GraphQL.Net.Extensions.Example.GraphGL.Types;
using GraphQL.Net.Extensions.Example.Models;
using GraphQL.Net.Extensions.Example.Services;
using GraphQL.Types;

namespace GraphQL.Net.Extensions.Example.GraphGL.Queries
{
    public class MockQuery : ObjectGraphType
    {
        private readonly IMockService _mockService;

        public MockQuery(IMockService mockService)
        {
            _mockService = mockService;

            //Field<ListGraphType<MockType>>(
            //    "MockList",
            //    resolve:
            //    context =>
            //    {
            //        try
            //        {
            //            return GetData();
            //        }
            //        catch (NullReferenceException e)
            //        {
            //            throw new ExecutionError(e.Message);
            //        }
            //        catch (ArgumentException e)
            //        {
            //            throw new ExecutionError(e.Message);
            //        }
            //        catch (Exception e)
            //        {
            //            throw new ExecutionError(e.Message);
            //        }
            //    });

            //Code commented above can be changed with this code using extension method Execute of class GraphQLExt
            Field<ListGraphType<MockType>>(
                "MockList",
                resolve:
                context => context.Execute(GetData)
            );

            //Field<MockType>(
            //    "Mock",
            //    arguments: new QueryArguments(
            //        new QueryArgument<IdGraphType> { Name = "id" }
            //    ),
            //    resolve:
            //    context =>
            //    {
            //        try
            //        {
            //            var id = context.GetArgument<int>("id");
            //            return GetDataById(id);
            //        }
            //        catch (NullReferenceException e)
            //        {
            //            throw new ExecutionError(e.Message);
            //        }
            //        catch (ArgumentException e)
            //        {
            //            throw new ExecutionError(e.Message);
            //        }
            //        catch (Exception e)
            //        {
            //            throw new ExecutionError(e.Message);
            //        }
            //    });

            //Code commented above can be changed with this code using extension method Execute of class GraphQLExt
            Field<MockType>(
                "Mock",
                arguments: new QueryArguments(
                    new QueryArgument<IdGraphType> {Name = "id"}
                ),
                resolve:
                context => context.Execute(GetDataById));
        }

        private async Task<List<MockModel>> GetData(ResolveFieldContext<object> context)
        {
            return await _mockService.GetMockData();
        }

        private async Task<MockModel> GetDataById(ResolveFieldContext<object> context)
        {
            var id = context.GetArgument<int>("id");
            return await _mockService.GetMockDataById(id);
        }
    }
}
