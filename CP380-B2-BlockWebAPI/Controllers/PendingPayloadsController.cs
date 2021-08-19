using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CP380_B1_BlockList.Models;
using CP380_B2_BlockWebAPI.Models;

namespace CP380_B2_BlockWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class PendingPayloadsController : ControllerBase
    {
        private readonly PendingPayloadsList PL;

        public PendingPayloadsController(PendingPayloadsList payloads)
        {
            PL = payloads;
        }

        [HttpGet]                                  
        public ActionResult<List<Payload>> Get()
        {
            var item = PL.payloads;
            var payld=item.ToList();
            return (payld);
        }
        [HttpPost]                              
        public ActionResult<Payload> Post(Payload data)
        {
            PL.payloads.Add(data);
            return data;
        }
    }
}