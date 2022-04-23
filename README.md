# PoshGremlin

A PowerShell binary module (.dll) to expose Gremlin.NET via a PowerShell Cmdlet. This project uses [dnMerge](https://github.com/CCob/dnMerge), a lightweight .NET assembly dependency merger, to merge multiple .NET reference assemblies into a single DLL (PowerShell binary module).

## Installation

Copy and Paste the following command to install this package using PowerShellGet:

```PowerShell
Install-Module -Name PoshGremlin
```

## Example: Gremlin and Azure CosmosDB

### Import Module

```PowerShell
Import-Module PoshGremlin
```

### Define variables

```PowerShell
$hostname = "cosmos-ENDPOINT.gremlin.cosmos.azure.com"
$authKey = ConvertTo-SecureString -AsPlainText -Force -String 'COSMOSDB-KEY'
$database = "DBNAME"
$collection = 'GRAPHCOLLECTION' 
$Credential = New-Object System.Management.Automation.PSCredential "/dbs/$database/colls/$collection", $authKey

$gremlinParames = @{
    Hostname = $hostname
    Credential = $credential
}
```

### Run Basic Gremlin query

```PowerShell
"g.V().has('label','directoryrole')" | Invoke-Gremlin @gremlinParams | convertTo-Json -Depth 10 
```

## Credits

* https://github.com/jasonchester/PSGremlin
* https://github.com/CCob/dnMerge
* https://github.com/apache/tinkerpop/tree/master/gremlin-dotnet

## References

* https://docs.microsoft.com/en-us/powershell/scripting/developer/module/how-to-write-a-powershell-binary-module?view=powershell-7.2
* https://docs.microsoft.com/en-us/powershell/scripting/developer/cmdlet/cmdlet-overview?view=powershell-7.2
* https://docs.microsoft.com/en-us/samples/azure-samples/azure-cosmos-db-graph-gremlindotnet-getting-started/azure-cosmos-db-graph-gremlindotnet-getting-started/