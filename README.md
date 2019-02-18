# AzureFileProvider
A library to use Azure File Storage as File Provider in ASP.NET Core

# How to use it?
- Add azure storage setting in the appSetting.json

```
{
  "Logging": {
    "LogLevel": {
      "Default": "Warning"
    }
  },
  "AzureStorage": {
    "ConnectionString": "DefaultEndpointsProtocol=https;AccountName=testAccountName;AccountKey=testAccountKey;EndpointSuffix=core.windows.net",
    "ShareName": "testShareName"
  },
  "AllowedHosts": "*"
}

```

- Enable the AzureFileProvider in the <code>ConfigureService</code> method

```
  public void Configure(IApplicationBuilder app, IHostingEnvironment env)
  {
      AzureStorageSetting o = new AzureStorageSetting();
      Configuration.Bind("AzureStorage", o);

      app.UseStaticFiles(new StaticFileOptions
      {
          FileProvider = new AzureFileProvider(o),
          RequestPath = "/files"
      });
      
      app.UseMvc();
  }
```

That's all. 
