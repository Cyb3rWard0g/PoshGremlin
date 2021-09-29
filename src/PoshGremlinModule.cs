using System.Management.Automation;
using Gremlin.Net.Driver;
using Gremlin.Net.Structure.IO.GraphSON;

namespace MyModule
{
    [Cmdlet(VerbsCommunications.Connect, "CosmosDBGraph")]
    public class ConnectCosmosDBGraph : PSCmdlet
    {
        [Parameter(Position = 0, Mandatory = true)]
        public string Hostname { get; set; }

        [Parameter]
        public int Port { get; set; } = 443;

        [Parameter]
        public SwitchParameter EnableSsl { get; set; } = true;

        [Parameter(Mandatory = true)]
        public PSCredential Credential { get; set; }

        private GremlinClient Client;

        protected override void BeginProcessing()
        {
            WriteVerbose("Connecting GremlinClient");

            var server = new GremlinServer(Hostname, Port, EnableSsl, Credential.UserName, Credential.GetNetworkCredential().Password);

            Client = new GremlinClient(server, new GraphSON2MessageSerializer());
        }
    }
}