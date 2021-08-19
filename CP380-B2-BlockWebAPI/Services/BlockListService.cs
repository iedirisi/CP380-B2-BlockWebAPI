using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using CP380_B1_BlockList.Models;
using CP380_B2_BlockWebAPI.Models;
using Microsoft.Extensions.Configuration;

namespace CP380_B2_BlockWebAPI.Services
{
    public class BlockListService
    {
        private PendingPayloadsList PL;
        private BlockList BL;
        private readonly IConfiguration conf;
        private readonly JsonSerializerOptions conf = new JsonSerializerOptions(JsonSerializerDefaults.Web);

        public BlockListService(IConfiguration configuration, BL blockList, PendingPayloadsList pendingPayloads) {
            BL = blockList;
            PL = pendingPayloads;
            conf = configuration;
        }
        public Block SubmitNewBlock(string hash, int nonce, DateTime timestamp)
        {

            Block block = new Block(timestamp, BL.Chain[BL.Chain.Count - 1].Hash, PL.payloads);
            block.CalculateHash(); 

            if (block.Hash == hash)
            {
                BL.Chain.Add(block);   
                PL.removePendingPayloads();
                return block;
            }

            return null;
        }
    }
}
