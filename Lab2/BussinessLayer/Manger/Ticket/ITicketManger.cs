using Lab2BL.Dtos.Ticket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2BL.Manger.Ticket
{
    public interface ITicketManger
    {
        List<ReadTicketDto> getAll();

        ReadTicketDto GetbyId(int id);

        int AddTicket(AddTicketDto ticket);

        bool UpdateTicket(UpdateTicketDto ticket);

        void DeleteTicket(int id);
    }
}
