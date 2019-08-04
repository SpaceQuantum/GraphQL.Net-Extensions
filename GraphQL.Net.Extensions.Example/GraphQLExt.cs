using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Types;

namespace GraphQL.Net.Extensions.Example.Extensions
{
    public static class GraphQLExt
    {
        public static async Task<TResult> Execute<TResult, T>(this ResolveFieldContext<T> context,
            Func<ResolveFieldContext<T>, Task<TResult>> func)
        {
            try
            {
                return await func(context);
            }
            catch (ArgumentNullException ex)
            {
                //TODO Log
                context.Errors.Add(new ExecutionError(ex.Message) { Code = "500" });
            }
            catch (ArgumentException ex)
            {
                //TODO Log
                context.Errors.Add(new ExecutionError(ex.Message) { Code = "500" });
            }
            catch (NullReferenceException ex)
            {
                //TODO Log
                context.Errors.Add(new ExecutionError(ex.Message) { Code = "500" });
            }
            catch (Exception ex)
            {
                //TODO Log
                context.Errors.Add(new ExecutionError(ex.Message) { Code = "500" });
            }

            return default(TResult);
        }

    }
}
