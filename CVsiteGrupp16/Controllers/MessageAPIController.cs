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
using System.Web.Mvc;
using System.Web.Http;


namespace CVsiteGrupp16.Controllers
{
    //[System.Web.Http.RoutePrefix("api/message")]
    public class MessageAPIController : ApiController
    {
        MessageService messageService = new MessageService();

        public MessageRepository messageRepository
        {
            get { return new MessageRepository(Request.GetOwinContext().Get<MessageDbContext>()); }
        }
        

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("/read/{id}")]
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

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("/unread/{id}")]
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


        //Använda för att sätta siffran till notiser??
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("countmessages")]
        public int CountUnreadMessages()
        {
            string mottagare = User.Identity.Name;
            int count = messageRepository.UnreadMessages(mottagare);
            return count;
        }


        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/message/create")]
        public IHttpActionResult CreateMessage(MessageModel model)
        {
            var avsändare = "";
            if (User.Identity.IsAuthenticated)
            {
                avsändare = User.Identity.Name;
            }
            else
            {
                avsändare = model.Avsändare;
            }
            var succeded = messageService.SaveNewMessage(model, avsändare);

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
