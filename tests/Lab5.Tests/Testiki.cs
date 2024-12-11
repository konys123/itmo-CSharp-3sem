using Itmo.ObjectOrientedProgramming.Lab5.Domain;
using Moq;
using Xunit;

namespace Lab5.Tests;

public class Testiki
{
    [Fact]
    public void Deposit()
    {
        var acc = new Account("1", "1", 0);

        var acrep = new Mock<IAccountRepository>();
        acrep.Setup(a => a.GetByNumber("1")).Returns(acc);

        var trrep = new Mock<ITransactionRepository>();
        var acserv = new AccountService(acrep.Object, trrep.Object);

        acserv.Deposit("1", 52);

        Assert.Equal(52, acc.Balance);
    }

    [Fact]
    public void Withdraw()
    {
        var acc = new Account("1", "1", 52);

        var acrep = new Mock<IAccountRepository>();
        acrep.Setup(a => a.GetByNumber("1")).Returns(acc);

        var trrep = new Mock<ITransactionRepository>();
        var acserv = new AccountService(acrep.Object, trrep.Object);

        acserv.Withdraw("1", 2);

        Assert.Equal(50, acc.Balance);
    }

    [Fact]
    public void WithdrawWithLowBalance()
    {
        var acc = new Account("1", "1", 52);

        var acrep = new Mock<IAccountRepository>();
        acrep.Setup(a => a.GetByNumber("1")).Returns(acc);

        var trrep = new Mock<ITransactionRepository>();
        var acserv = new AccountService(acrep.Object, trrep.Object);

        Assert.Throws<InvalidOperationException>(() => acserv.Withdraw("1", 552));
    }
}