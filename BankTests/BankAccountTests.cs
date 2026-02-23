using BankAccountNS;

namespace BankTests
{
    [TestClass]
    public sealed class BankAccountTests
    {
        // === ТЕСТ 1: Корректное списание ===
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
        // === ТЕСТ 2: Отрицательная сумма списания ===
        [TestMethod]
        public void Debit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {
            // Arrange
            decimal beginningBalance = 11.99m;
            decimal debitAmount = -100.00m;
            BankAccount account = new BankAccount("Mr. Pelevin V.", beginningBalance);

            // Act
            try
            {
                account.Debit(debitAmount);
            }
            catch (ArgumentOutOfRangeException e)
            {
                // Assert
                StringAssert.Contains(e.Message, BankAccount.DebitAmountLessThanZeroMessage);
                return;
            }

            Assert.Fail("The expected exception was not thrown.");
        }

        // === ТЕСТ 3: Сумма списания больше баланса ===
        [TestMethod]
        public void Debit_WhenAmountIsMoreThanBalance_ShouldThrowArgumentOutOfRange()
        {
            // Arrange
            decimal beginningBalance = 11.99m;
            decimal debitAmount = 20.0m;
            BankAccount account = new BankAccount("Mr. Pelevin V.", beginningBalance);

            // Act
            try
            {
                account.Debit(debitAmount);
            }
            catch (ArgumentOutOfRangeException e)
            {
                // Assert
                StringAssert.Contains(e.Message, BankAccount.DebitAmountExceedsBalanceMessage);
                return;
            }

            Assert.Fail("The expected exception was not thrown.");
        }

        // === ТЕСТ 4: Корректное пополнение ===
        [TestMethod]
        public void Credit_WithValidAmount_UpdatesBalance()
        {
            // Arrange
            decimal beginningBalance = 11.99m;
            decimal creditAmount = 5.77m;
            decimal expected = 17.76m;
            BankAccount account = new BankAccount("Mr. Pelevin V.", beginningBalance);

            // Act
            account.Credit(creditAmount);

            // Assert
            Assert.AreEqual(expected, account.Balance, "Account not credited correctly");
        }

        // === ТЕСТ 5: Отрицательная сумма пополнения ===
        [TestMethod]
        public void Credit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {
            // Arrange
            decimal beginningBalance = 11.99m;
            decimal creditAmount = -50.00m;
            BankAccount account = new BankAccount("Mr. Pelevin V.", beginningBalance);

            // Act
            try
            {
                account.Credit(creditAmount);
            }
            catch (ArgumentOutOfRangeException e)
            {
                // Assert
                StringAssert.Contains(e.Message, "amount");
                return;
            }

            Assert.Fail("The expected exception was not thrown.");
        }
    }
}

