using BankAccountNS;

namespace BankTests
{
    [TestClass]
    public sealed class BankAccountTests
    {
        [TestMethod]
        public void Debit_WithValidAmount_UpdatesBalance()
        {
            // Arrange
            decimal beginningBalance = 11.99m;
            decimal debitAmount = 4.55m;
            decimal expected = 7.44m;
            BankAccount account = new BankAccount("Mr. Pelevin V.", beginningBalance);

            // Act
            account.Debit(debitAmount);

            // Assert
            decimal actual = account.Balance;
            Assert.AreEqual(expected, actual, "Account not debited correctly");
        }

    }
}
