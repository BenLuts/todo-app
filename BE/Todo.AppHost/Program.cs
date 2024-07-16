var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Todo_API>("todo-api");

builder.Build().Run();
