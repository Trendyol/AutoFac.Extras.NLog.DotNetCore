# Autofac NLog Logging Module for .NET Core

![Build status](https://peacecwz.visualstudio.com/_apis/public/build/definitions/754247a8-5944-4a93-9b64-43c260966633/16/badge)

Autofac Logging Module for NLog. Ported to .NET Standard 2.0 for .NET Core. [You can look it for .NET Framework](https://github.com/ziyasal/Autofac.Extras.NLog) Thanks [@ziyasal](https://github.com/ziyasal)

## Installing

Install with Nuget

```
Install-Package AutoFac.Extras.NLog.DotNetCore
```

or Dotnet CLI

```
dotnet add package AutoFac.Extras.NLog.DotNetCore
```

## How to Use

Register module to Autofac

```
container.RegisterModule<NLogModule>();
```

### Use NLogModule with constructor injection

```
public class LogWithConstructorDependency : ILogInterface
{
    private readonly ILogger _logger;

    public LogWithConstructorDependency(ILogger logger)
    {
      _logger = logger;
  }        
}
```

### Use NLogModule with property injection

```
public class LogWithPropertyDependency : ILogInterface
{
   public ILogger Logger { get; set; }
}
```

## Testing

You can run test with dotnet cli tool



## Contributing

* If you want to contribute to codes, create pull request
* If you find any bugs or error, create an issue

## License

This project is licensed under the MIT License
