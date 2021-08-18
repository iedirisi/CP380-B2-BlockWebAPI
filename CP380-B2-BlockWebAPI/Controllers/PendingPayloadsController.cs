using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
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
        private readonly PendingPayloadsList _pendingPayloads;

        public PendingPayloadsController(PendingPayloadsList LiPayloads)
        {
            _pendingPayloads = LiPayloads;
        }

        [HttpGet]
        public ActionResult<List<Payload>> Get() =>
            _pendingPayloads.payloads.ToList();

        [HttpPost]
        public ActionResult<Payload> Post(Payload pLoad)
        {
            _pendingPayloads.payloads.Add(pLoad);
            return pLoad;
        }
    }
}
