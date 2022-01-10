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
           

            public int SaveNewMessage(MessageModel model, string avsändare)
            {
                try
                {
                    using (var context = new MessageDbContext())
                    {

                        var newMessage = new Message()
                        {
                            Avsändare = avsändare,
                            Datum = DateTime.Now,
                            Läst = model.Läst,
                            Content = model.Content,
                            UserName = model.UserName
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

