using Lab2DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2DAL.Repo.Tickets
{
    public interface ITicketRepo
    {
        IEnumerable<Ticket> getAll();

        Ticket getById(int id);

        void Add(Ticket ticket);
        void Update(Ticket ticket);
        void Delete(Ticket ticket);

        int SaveChanges();



    }
}
