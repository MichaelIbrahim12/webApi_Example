using Lab2DAL.Data.Models;
using Lab2BL.Dtos.Ticket;
using Lab2DAL.Repo.Tickets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2BL.Manger.Ticket
{
    public class TicketManger : ITicketManger
    {
        private ITicketRepo _ticketRepo;
        public TicketManger(ITicketRepo repo)
        {
            _ticketRepo = repo;
        }
        public int AddTicket(AddTicketDto addedticket)
        {
            var ticket = new Lab2DAL.Data.Models.Ticket
            {
                Description = addedticket.Description,
                Title = addedticket.Title,
                DeptId = addedticket.DeptId,

            };

            _ticketRepo.Add(ticket);
            _ticketRepo.SaveChanges();


            return ticket.Id;

        }

        public void DeleteTicket(int id)
        {
            var ticket = _ticketRepo.getById(id);

            if (ticket == null)
            {
                return;
            }
            _ticketRepo.Delete(ticket);
            _ticketRepo.SaveChanges();

        }

        public List<ReadTicketDto> getAll()
        {
            var ticketsFromDb = _ticketRepo.getAll();


            return ticketsFromDb.Select(t => new ReadTicketDto
            {
                Id = t.Id,
                Description = t.Description,
                Title = t.Title,
                DeptId = t.DeptId,
            }).ToList();
        }

        public ReadTicketDto GetbyId(int id)
        {
            var ticketFromDb = _ticketRepo.getById(id);

            if (ticketFromDb is null)
            {
                return null;
            }

            return new ReadTicketDto
            {
                Id = ticketFromDb.Id,
                Description = ticketFromDb.Description,
                Title = ticketFromDb.Title,
                DeptId = ticketFromDb.DeptId,
            };
        }

        public bool UpdateTicket(UpdateTicketDto ticket)
        {
            var ticketFromDb = _ticketRepo.getById(ticket.Id);

            if (ticketFromDb is null)
            {
                return false;
            }
            ticketFromDb.Description = ticket.Description;
            ticketFromDb.Title = ticket.Title;
            ticketFromDb.DeptId = ticket.DeptId;
            _ticketRepo.Update(ticketFromDb);
            _ticketRepo.SaveChanges();
            return true;
        }
    }
}
