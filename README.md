# PoshGremlin

PowerShell module to expose Gremlin.NET

## Testing

```PowerShell
$hostname = "cosmos-ENDPOINT.gremlin.cosmos.azure.com"
$authKey = ConvertTo-SecureString -AsPlainText -Force -String 'COSMOSDB-KEY'
$database = "DBNAME"
$collection = 'GRAOHCOLLECTION' 
$Credential = New-Object System.Management.Automation.PSCredential "/dbs/$database/colls/$collection", $authKey

Import-Module PoshGremlin\bin\Debug\PoshGremlin.dll 

Connect-CosmosDBGraph -Hostname $hostname -Port 443 -Credential $Credential 
```

## Credits

* https://github.com/jasonchester/PSGremlin
* https://github.com/CCob/dnMerge
* https://github.com/apache/tinkerpop/tree/master/gremlin-dotnet