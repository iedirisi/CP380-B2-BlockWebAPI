using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CP380_B2_BlockWebAPI.Models;
using CP380_B1_BlockList.Models;

namespace CP380_B2_BlockWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    //
    public class BlocksController : ControllerBase
    {
      //  private readonly BlockSummaryList _blockSum;
       private readonly BlockList _blocks;

        public BlocksController(BlockList blocks)
        { 
          //  _blockSum = blockSummaries;
           _blocks = blocks;
        }
        [HttpGet]
        public ActionResult<List<BlockSummaries>> Get()
        {
            List<Block> blocks = _blocks.Chain.ToList();
            List<BlockSummaries> blockSummary = new List<BlockSummaries>();

            foreach (var a in blocks)
            {
                _blocks.AddBlock(a);
                blockSummary.Add(new BlockSummaries()
                {
                    hash = a.Hash,
                    prevHash = a.PreviousHash,
                    timestamp = a.Timestamp

                }) ; 
            }
            return blockSummary;
        }

        [HttpGet("{hash}")]
        public ActionResult<Block> GetBlock(string hash)
        {
            var result = _blocks.Chain.Where(a => a.Hash == hash).First();
            if (result.Hash.Length > 0)
            {
                return result;
            }
            else
            {
                retrun NotReturn();
            }
        }

        [HttpGet("{hash}/Payloads")]
        public ActionResult<List<Payload>> GetPayload(string hash) =>
            _blocks.Blocks.Where(a => a.Hash == hash).Select(row => row.data).First().ToList();
    }
}
