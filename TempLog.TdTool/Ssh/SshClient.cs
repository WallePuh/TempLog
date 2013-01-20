using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TempLog.TdTool.Result;
using TempLog.TdTool.Ssh.Deserializer;

namespace TempLog.TdTool.Ssh
{
    public class SshClient : ITdToolClient
    {
        public string Host { get { return ConfigurationManager.AppSettings["SshHost"]; } }
        public string Username { get { return ConfigurationManager.AppSettings["SshUsername"]; } }
        public string Password { get { return ConfigurationManager.AppSettings["SshPassword"]; } }

        public ListResult GetListResult()
        {
            var host = Host;
            var username = Username;
            var password = Password;
            using (var sshClient = new Renci.SshNet.SshClient(host, username, password))
            {
                sshClient.Connect();
                var cmd = sshClient.CreateCommand("tdtool --list", Encoding.UTF8);
                var commandResult = cmd.Execute();

                var listDeserializer = new ListDeserializer(new SensorListDeserializer());

                var result = listDeserializer.Deserialize(commandResult);

                return result;
            }
        }
    }
}
