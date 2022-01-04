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
        private readonly ApplicationDbContext _context;

        public MessageRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public MessageRepository()
        { }
        public List<Message> GetAllMessages()
        {
            return _context.messages
                .ToList();
        }

        public bool SetUnRead(int id)
        {
            var message = _context.messages.FirstOrDefault(x => x.Id == id);
            if (message == null) return false;
            message.Read = false;
            _context.SaveChanges();
            return true;
        }

        public int UnreadMessages(string username)
        {
            var list = _context.messages.Where(x => x.Read == false).ToList();
            return list.Count;
        }

        public bool SetRead(int id)
        {
            var message = _context.messages.FirstOrDefault(x => x.Id == id);
            if (message == null) return false;
            message.Read = true;
            _context.SaveChanges();
            return true;
        }


    }
}

