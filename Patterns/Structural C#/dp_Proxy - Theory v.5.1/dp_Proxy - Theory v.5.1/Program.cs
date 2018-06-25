using System;

namespace dp_Proxy___Theory_v._5._1
{
    struct Transaction
    {
        public string transID;
        public decimal sum;

        public Transaction(string t, decimal s)
        {
            transID = t;
            sum = s;
        }
    }
    interface IBank
    {
        void SaveTransaction(Transaction tr);
    }

    class Bank : IBank
    {
        public Bank() { }

        public void SaveTransaction(Transaction tr)
        {
            Console.WriteLine("Bank received transaction:\n\t\tID: {0}\tsum {1}\n", tr.transID, tr.sum);

            tr.transID = tr.transID.Substring(3, tr.transID.Length - 3);
            tr.sum /= 2;

            Console.WriteLine("Transaction number {0} for ${1} is saved.\n", tr.transID, tr.sum);
        }
    }
    class Affiliate
    {
        IBank bank;

        public Affiliate()
        {
            bank = new BankProxy();
        }

        public void SendTransaction(Transaction tr)
        {
            Console.WriteLine("Affiliate sent transaction:\n\t\tID: {0}\tsum {1}\n", tr.transID, tr.sum);

            bank.SaveTransaction(tr);
        }
    }
    class BankProxy : IBank
    {
        Bank bank;

        public BankProxy()
        {
            bank = new Bank();
        }

        public void SaveTransaction(Transaction tr)
        {
            tr.transID = "new" + tr.transID;
            tr.sum *= 2;
            bank.SaveTransaction(tr);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Affiliate af = new Affiliate();
            af.SendTransaction(new Transaction("9123", 25.3m));
            Console.Read();
        }
    }
}