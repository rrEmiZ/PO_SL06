using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppCore
{
    public class Wallet
    {
        public int _saldo;

        public int Saldo { get => _saldo; }

        public string Test { get; set; } = "TESTOWE";

        public Wallet(int saldo)
        {
            _saldo = saldo;
        }

        public void TakeMoney(int moneyToTake)
        {
            if(_saldo - moneyToTake < 0)
            {
                throw new InvalidOperationException("ni mom tyle floty");
            }

            _saldo -= moneyToTake;
        }
    }
}
