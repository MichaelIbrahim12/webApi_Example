using Lab2DAL.Data.Context;
using Lab2DAL.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2DAL.Repo.Tickets
{
    public class TicketRepo : ITicketRepo
    {
        private Lab2Context _context; 
        public TicketRepo( Lab2Context context )
        {
                _context= context;
        }
        public void Add(Ticket ticket)
        {
            _context.Tickets.Add(ticket);
        }

        public void Delete(Ticket ticket)
        {
            _context.Tickets.Remove(ticket);
        }

        public IEnumerable<Ticket> getAll()
        {
            return _context.Tickets.AsNoTracking();
        }

        public Ticket getById(int id)
        {
           
            return _context.Tickets.FirstOrDefault(i => i.Id == id);
        }

        public int SaveChanges()
        {
           return _context.SaveChanges();
        }

        public void Update(Ticket ticket)
        {
            
        }
    }
}
