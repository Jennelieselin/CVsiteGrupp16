using Data.Contexts;
using Data.Models;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Services
{
        public class MessageService
        {
            //private readonly HttpContext _httpcontext;
            //private MessageDbContext db = new MessageDbContext();
            //public MessageService(HttpContext httpContext)
            //{
            //    _httpcontext = httpContext;
            //}

            public int SaveNewMessage(MessageModel model, string sender)
            {
                try
                {
                    using (var context = new MessageDbContext())
                    {

                        var newMessage = new Message()
                        {
                            Avsändare = sender,
                            Datum = DateTime.Now,
                            Läst = model.Läst,
                            Content = model.Content,
                            //UserName = "xxx"
                            UserName = model.Mottagare
                        };


                        context.messages.Add(newMessage);
                        context.SaveChanges();
                        return 1;
                    }
                }
                catch
                {
                    return 0;
                }
            }

        }
    }

