using Lab2BL.Dtos.Ticket;
using Lab2BL.Manger.Ticket;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab2API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private ITicketManger _ticketManger;
        public TicketController(ITicketManger manger)
        {
            _ticketManger= manger;
        }
        [HttpGet]
        public ActionResult<List<ReadTicketDto>> Get()
        {
            return _ticketManger.getAll();
        }

        [HttpGet]
        [Route("{id}")]

        public ActionResult<ReadTicketDto> Get(int id)
        {
            var ticket= _ticketManger.GetbyId(id);

            if(ticket == null) { 
            return NotFound();
            }
            return ticket;
        }

        [HttpPost]

        public ActionResult add(AddTicketDto ticket) {
        
        var id=_ticketManger.AddTicket(ticket);

            return Ok(id);
        }

        [HttpPut]
        public ActionResult update(UpdateTicketDto ticket)
        {
             var isfound=  _ticketManger.UpdateTicket(ticket);

            if(isfound is false)
            {
                return NotFound();
            }

            return Ok(isfound);
        }

        [HttpDelete]
        [Route("id")]
        public ActionResult delete( int id)
        {
            var ticket=_ticketManger.GetbyId(id);

            if(ticket is null)
            {
                return NotFound();
            }
            _ticketManger.DeleteTicket(id);
            return NoContent();
        }
    }
}
