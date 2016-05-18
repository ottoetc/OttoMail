using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace OttoMail.Models
{
    public class Message
    {
        public string To { get; set;  }
        public string From { get; set; }
        public string Body { get; set; }
        public string Status { get; set; }

        private string sendNumber = "9713138534";

        public Message()
        {
            From = sendNumber;
        }

        public static List<Message> GetMessages()
        {
            var client = new RestClient("https://api.twilio.com/2010-04-01");
            var request = new RestRequest("Accounts/" + EnvironmentVariables.AccountSid + "/Messages.json", Method.GET);
            client.Authenticator = new HttpBasicAuthenticator(EnvironmentVariables.AccountSid, EnvironmentVariables.AuthToken);
            var response = client.Execute(request);
            JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(response.Content);
            var messageList = JsonConvert.DeserializeObject<List<Message>>(jsonResponse["messages"].ToString());
            return messageList;
        }

        public void Send()
        {
            var client = new RestClient("https://api.twilio.com/2010-04-01");
            var request = new RestRequest("Accounts/" + EnvironmentVariables.AccountSid + "/Messages", Method.POST);
            request.AddParameter("To", To);
            request.AddParameter("From", From);
            request.AddParameter("Body", Body);
            request.AddParameter("Status", Status);
            client.Authenticator = new HttpBasicAuthenticator(EnvironmentVariables.AccountSid, EnvironmentVariables.AuthToken);
            client.Execute(request);
        }
    }
}
