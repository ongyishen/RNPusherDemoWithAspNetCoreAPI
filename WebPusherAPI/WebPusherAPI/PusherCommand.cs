using PusherServer;
using System.Threading.Tasks;

namespace WebPusherAPI
{
    public class PusherCommand
    {
        public string channelName
        {
            get
            {
                return "private-my-channel";
            }
        }

        public Pusher GetPusherInstance()
        {
            var options = new PusherOptions();
            options.Cluster = "<cluster>";
            return new Pusher("<appId>", "<appKey>", "<appSecret>", options);
        }

        public async Task<ITriggerResult> TriggerAsync(string eventName, object obj)
        {
            var pusher = GetPusherInstance();
            var result = await pusher.TriggerAsync(this.channelName, eventName, obj);
            return result;
        }

        public async Task<string> Authenticate(string channel_name, string socket_id)
        {
            string json = string.Empty;
            await Task.Run(() =>
            {

                var pusher = GetPusherInstance();

                var auth = pusher.Authenticate(channel_name, socket_id);
                json = auth.ToJson();
            });

            return json;
        }
    }
}
