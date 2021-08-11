using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CP380_B2_BlockWebAPI.Models;

namespace CP380_B2_BlockWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class PendingPayloadsController : ControllerBase
    {
        private readonly List<PendingPayloads> _payloads;
        private PendingPayloadsList _payloadList;

        public PendingPayloadsController()
        { 
            var payloads = new List<PendingPayloads>();
            var payloadsList = new PendingPayloadsList();

            _payloads = payloads;
            _payloadList = payloadsList;
        }

        [HttpGet]
        public ActionResult<List<PendingPayloads>> Get() =>
            _payloads.ToList();

        [HttpPost]
        public ActionResult<PendingPayloads> Post(PendingPayloads payload)
        {
            return _payloadList.Add(payload);
        }
    }
}
