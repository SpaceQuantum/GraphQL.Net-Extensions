# GraphQL.Net-Extensions
Extensions for GraphQL .Net

Extension method for catch exceptions in one place.

## Usage
Copy GraphQLExt.cs to your project
and then you can change, for example:

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

by this, for catch exceptions in one place.

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
