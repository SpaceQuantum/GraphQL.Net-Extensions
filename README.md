# GraphQL.Net-Extensions
Extensions for GraphQL .Net

## GraphQL Extension method for catch exceptions in one place:

```csharp
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
        
```

## Usage
Copy GraphQLExt.cs to your project
and you can change this code in Query class:

```csharp
Field<ListGraphType<MockType>>(
    "MockList",
    resolve:
    context =>
    {
        try
        {
            return GetData();
        }
        catch (NullReferenceException e)
        {
            throw new ExecutionError(e.Message);
        }
        catch (ArgumentException e)
        {
            throw new ExecutionError(e.Message);
        }
        catch (Exception e)
        {
            throw new ExecutionError(e.Message);
        }
    });
    
private async Task<List<MockModel>> GetData(ResolveFieldContext<object> context)
{
    return await _mockService.GetMockData();
}
```

by this:

```csharp
Field<ListGraphType<MockType>>(
               "MockList",
               resolve:
               context => context.Execute(GetData)
           );
            
private async Task<List<MockModel>> GetData(ResolveFieldContext<object> context)
{
    return await _mockService.GetMockData();
}
```

See Example project in repository.
