# PoshGremlin

PowerShell module to expose Gremlin.NET

## Testing

**Define variables**

```PowerShell
$hostname = "cosmos-ENDPOINT.gremlin.cosmos.azure.com"
$authKey = ConvertTo-SecureString -AsPlainText -Force -String 'COSMOSDB-KEY'
$database = "DBNAME"
$collection = 'GRAOHCOLLECTION' 
$Credential = New-Object System.Management.Automation.PSCredential "/dbs/$database/colls/$collection", $authKey

$gremlinParames = @{
    Hostname = $hostname
    Credential = $credential
}
```

**Import Module (DLL)**

```PowerShell
Import-Module PoshGremlin\bin\Release\PoshGremlin.dll 
```

**Run basic Gremlin query**

```PowerShell
"g.V().has('label','directoryrole')" | Invoke-Gremlin @gremlinParams | convertTo-Json -Depth 10 
```

## Credits

* https://github.com/jasonchester/PSGremlin
* https://github.com/CCob/dnMerge
* https://github.com/apache/tinkerpop/tree/master/gremlin-dotnet