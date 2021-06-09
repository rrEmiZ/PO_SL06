using ConsoleAppCore;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitTestProject
{
    public class Wallet_Tests
    {



        [Fact]
        public void TakeMoney_ForSaldo200Take100_SaldoIs100()
        {
            var wallet = new Wallet(200);

            wallet.TakeMoney(100);

            Assert.Equal(100, wallet.Saldo);
        }

        [Fact]
        public void TakeMoney_ForSaldo100Take200_ThrowEx()
        {
            var wallet = new Wallet(100);

            Assert.Throws<InvalidOperationException>(() => wallet.TakeMoney(200));
        }
    }
}
