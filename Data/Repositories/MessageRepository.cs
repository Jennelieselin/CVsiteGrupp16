using Data.Contexts;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class MessageRepository
    {
        private readonly MessageDbContext _context;

        public MessageRepository(MessageDbContext context)
        {
            _context = context;
        }
        public MessageRepository()
        { }
        //public List<Message> GetAllMessages()
        //{
        //    return _context.messages
        //        .ToList();
        //}
        public bool SetRead(int id)
        {
            var message = _context.messages.FirstOrDefault(x => x.Id == id);
            if (message == null) return false;
            message.Läst = true;
            _context.SaveChanges();
            return true;
        }

        public bool SetUnRead(int id)
        {
            var message = _context.messages.FirstOrDefault(x => x.Id == id);
            if (message == null) return false;
            message.Läst = false;
            _context.SaveChanges();
            return true;
        }

        //public int UnreadMessages()
        //{
        //    var list = _context.messages.Where(x => x.Läst == false).ToList();
        //    return list.Count;
        //}

        public int UnreadMessages(string mottagare)
        {
            var list = _context.messages.Where(x => x.Läst == false && x.UserName == mottagare).ToList();
            return list.Count;
        }
    }
}

