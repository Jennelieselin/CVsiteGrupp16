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

    public class MessageAPIController : ApiController
    {
        MessageService messageService = new MessageService();

        public MessageRepository messageRepository
        {
          
           get { return new MessageRepository(Request.GetOwinContext().Get<MessageDbContext>()); }
        }
        
         [Route("read/{id}")]
        [HttpGet]
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

        [Route("unread/{id}")]
        [HttpGet] 
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


        [Route("api/countmessages/")]
        [HttpGet]
        public int CountUnreadMessages()
        {
            string mottagare = User.Identity.Name;
            int count = messageRepository.UnreadMessages(mottagare);
            return count;
        }

        [Route("api/CreateMessage/")]
     
        [HttpPost]
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
