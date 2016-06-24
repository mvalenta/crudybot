using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using CrudyBot.Models;
using Microsoft.Bot.Connector;
using Microsoft.Bot.Connector.Utilities;
using Newtonsoft.Json;

namespace CrudyBot
{
    //[BotAuthentication]
    public class MessagesController : ApiController
    {
        /// <summary>
        /// POST: api/Messages
        /// Receive a message from a user and reply to it
        /// </summary>
        public async Task<Message> Post([FromBody]Message message)
        {
            if (message.Type == "Message")
            {
                // calculate something for us to return
                List<BotComm> list;
                using (var db = new BotCommsContext())
                {
                    list = db.BotComms.ToList();
                }

                if (message.Text.ToLower().Contains("commands"))
                {
                    return
                        message.CreateReplyMessage(
                            list.Select(x => x.MessageText)
                                .ToList()
                                .Aggregate((current, next) => current + "\n\n" + next));
                }

                var responseText = list.FirstOrDefault(x => message.Text.ToLower().Contains(x.MessageText.ToLower()))?.ResponseText.Replace("\\n", "\n");

                if (!string.IsNullOrEmpty(responseText))
                {
                    return message.CreateReplyMessage(responseText);
                }

                // fetch our state associated with a user in a conversation. If we don't have state, we get default(T)
                var counter = message.GetBotPerUserInConversationData<int>("counter");

                // create a reply message   
                Message replyMessage = message.CreateReplyMessage($"{++counter} You said: {message.Text}");

                // save our new counter by adding it to the outgoing message
                replyMessage.SetBotPerUserInConversationData("counter", counter);

                // return our reply to the user
                return replyMessage;
            }
            else
            {
                return HandleSystemMessage(message);
            }
        }

        private Message HandleSystemMessage(Message message)
        {
            if (message.Type == "Ping")
            {
                Message reply = message.CreateReplyMessage();
                reply.Type = "Ping";
                return reply;
            }
            else if (message.Type == "DeleteUserData")
            {
                // Implement user deletion here
                // If we handle user deletion, return a real message
            }
            else if (message.Type == "BotAddedToConversation")
            {
            }
            else if (message.Type == "BotRemovedFromConversation")
            {
            }
            else if (message.Type == "UserAddedToConversation")
            {
            }
            else if (message.Type == "UserRemovedFromConversation")
            {
            }
            else if (message.Type == "EndOfConversation")
            {
            }

            return null;
        }
    }
}