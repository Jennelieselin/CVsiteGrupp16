using Data.Contexts;
using Data.Models;
using Data.Repositories;
using Microsoft.AspNet.Identity.Owin;
using Services;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;



namespace CVsiteGrupp16.Controllers
{
    public class MessageApiController : ApiController
    {
        public MessageRepository messageRepository
        {
            get { return new MessageRepository(Request.GetOwinContext().Get<ApplicationDbContext>()); }
        }
        MessageService messageService = new MessageService(System.Web.HttpContext.Current);

        [HttpGet]
        [Route("/read/{id}")]
        public IHttpActionResult setRead(int id)
        {
            try
            {
                var messageOk = messageRepository.SetRead(id);

                if (messageOk)
                {
                    return Ok();
                }

                return BadRequest();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("/unread/{id}")]
        public IHttpActionResult setUnRead(int id)
        {
            try
            {
                var messageOk = messageRepository.SetUnRead(id);

                if (messageOk)
                {
                    return Ok();
                }

                return BadRequest();
            }
            catch
            {
                return BadRequest();
            }
        }


        // Använda för att sätta siffran till notiser??
        [HttpGet]
        [Route("countmessages")]
        public int CountUnreadMessages()
        {
            string username = User.Identity.Name;
            int count = messageRepository.UnreadMessages(username);
            return count;
        }


        [HttpPost]
        [Route("api/message/create")]
        public IHttpActionResult CreateMessage(MessageModel model)
        {
            var sender = "";
            if (User.Identity.IsAuthenticated)
            {
                sender = User.Identity.Name;
            }
            else
            {
                sender = model.Avsändare;
            }
            var succeded = messageService.SaveNewMessage(model, sender);

            if (succeded == 0)
            {
                return BadRequest();
            }
            else
            {
                return Ok();
            }


        }


    }
}

