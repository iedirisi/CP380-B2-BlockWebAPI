using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CP380_B2_BlockWebAPI.Models;
using CP380_B1_BlockList.Models;
using CP380_B2_BlockWebAPI.Services;

namespace CP380_B2_BlockWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class BlocksController : ControllerBase
    {
        private readonly BlockList ls;
        public BlocksController(BlockList list)
        {
            ls = list;
        }

        [HttpGet]                                                
        public ActionResult<List<BlockSummary>> Get()       
        {
            List<Block> list = ls.Chain.ToList();
            List<BlockSummary> blockSummary = new List<BlockSummary>();
            foreach (var block in list)
            {
                ls.AddBlock(block);
                blockSummary.Add(new BlockSummary()
                {
                    hash = block.Hash,
                    previousHash = block.PreviousHash,
                    timestamp = block.TimeStamp
                });
            }

            return blockSummary;
        }

        [HttpGet("{hash}")]                             
        public ActionResult<Block> GetBlock(string hash)
        {
            var result = ls.Chain
                         .Where(blk => blk.Hash.Equals(hash));
            int num = result.Count();
            if (result.Count() <= 0)
            {
                return NotFound();
            }
            else
            {
                return result.First();
            }
        }
        [HttpGet("{hash}/Payloads")]                    

        public ActionResult<List<Payload>> GetPayload(string hash)
        {
            var result = ls.Chain
                          .Where(blk => blk.Hash.Equals(hash));
            int num = result.Count();
            if (result.Count() <= 0)
            {
                return NotFound();
            }
            else
            {
                return (result.Select(block => block.Data)
                              .First()
                              .ToList());
            }
        }
       //Assignment Part D
        [HttpPost]
        public void PostBlock(Block block)
        {
            if (block.Hash == ls.Chain[ls.Chain.Count - 1].PreviousHash)
            {
                ls.Chain.Add(block);
            }
            else
            {
                BadRequest();
            }
        }
    }
}
