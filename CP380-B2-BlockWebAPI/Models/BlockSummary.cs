using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using B1=CP380_B1_BlockList.Models;

namespace CP380_B2_BlockWebAPI.Models
{
    public class Block
    { 
        public DateTime timestamp { get; set;}
        public string? previousHash { get; set;}
        public string? hash { get; set;}
        public List<B1.Payload> data { get; set;}
        public int nonce { get; set;}

        public Block()
        { 
            List<B1.Payload> data = new() { };
            var block = new B1().Block(DateTime.Now,"",data);

            timestamp = block.TimeStamp;
            previousHash = block.PreviousHash;
            data = block.Data;
            nonce = block.Nonce;
        }
    }


    public class BlockSummary
    {
        public DateTime timestamp { get; set;}
        public string? previousHash { get; set;}
        public string? hash { get; set;}

        public BlockSummary()
        { 
            List<B1.Payload> data = new() { };
            var block = new B1().Block(DateTime.Now, null, data);
            block.Mine(2);

            timestamp = block.TimeStamp;
            previousHash = block.PreviousHash;
            hash= block.Hash;
        }
    }

    public class BlockList
    { 
        public List<Block> Blocks = new List<Block>();
        
        public BlockList()
        { 
            var block = new Block();
            Blocks.Add(block);
        }
    }

    public class BlockSummaryList
    { 
        public List<BlockSummary> Blocks = new List<BlockSummary>();

        public BlockSummaryList()
        { 
            var block = new BlockSummary();
            Blocks.Add(block);
        }
    
    }
}
