
namespace CP380_B1_BlockList.Models
{
    public enum TransactionTypes
    {
        BUY, SELL, GRANT
    }

    public class Payload
    {
        public string user { get; set;}
        public TransactionTypes tType { get; set;}
        public int amount { get; set; }
        public string item { get;set; }

        public Payload(string uname, TransactionTypes transacTy, int amt, string item)
        { 
            this.user=uname;
            this.tType=transacTy;
            this.amount=amt;
            this.item=item;
        
        }
    }
}
