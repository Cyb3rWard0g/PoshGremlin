using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Management.Automation;
using Gremlin.Net.Driver;
using Gremlin.Net.Structure.IO.GraphSON;

namespace PoshGremlin
{
    [Cmdlet(VerbsLifecycle.Invoke, "Gremlin")]
    public class InvokeGremlin : PSCmdlet
    {
        [Parameter(Mandatory = true)]
        public string Hostname { get; set; }

        [Parameter]
        public int Port { get; set; } = 443;

        [Parameter]
        public SwitchParameter EnableSsl { get; set; } = true;

        [Parameter(Mandatory = true)]
        public PSCredential Credential { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        public string Query;

        private GremlinClient Client;

        protected override void BeginProcessing()
        {
            WriteVerbose("Connecting GremlinClient");

            var server = new GremlinServer(Hostname, Port, EnableSsl, Credential.UserName, Credential.GetNetworkCredential().Password);

            Client = new GremlinClient(server, new GraphSON2MessageSerializer());
        }

        protected override void ProcessRecord()
        {
            var sw = new Stopwatch();
            WriteVerbose($"Executing GremlinQuery {Query}");
            sw.Start();
            var results = ExecuteQuery<dynamic>(Query).Result;
            sw.Stop();
            WriteVerbose($"Query Complete. {sw.Elapsed}");

            foreach (var result in results)
            {
                PSObject output;

                switch (result)
                {
                    default:
                        WriteVerbose($"Processing default case: {result.GetType()}");
                        output = new PSObject(result);
                        break;
                }

                WriteObject(output, true);
            }
        }

        protected override void EndProcessing()
        {
            WriteVerbose("Disconnecting GremlinClient");
            Client.Dispose();
        }

        protected async Task<IReadOnlyCollection<T>> ExecuteQuery<T>(string query) => await Client.SubmitAsync<T>(query);
    }
}