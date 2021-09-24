- Ensure the startup project is __TestAvroToKafkaConsoleApp__ (right-click the project and select _Set as Startup Project_)
- Right-click the project and select _Manage User Secrets_
- Modify the file content as shown below (replacing the connection string as appropriate)

**secrets.json**
```json
{
  "AvroStreamerOptions": {
    "SourceConnectionString": "Data Source={SERVER};Initial Catalog=MI_WAREHOUSE;User={USERNAME};Password={PASSWORD}"
  }
}
```

- Check the values in `appsettings.json` are correct

**appsettings.json**
```json
{
  "AvroStreamerOptions": {
    "BootstrapServers": "localhost:9092",
    "SchemaRegistryUrl": "localhost:8081"
  }
}
```

- Run the application with F5
- Review status changes on screen
- Review times & status changes in Visual Studio output tab
