using Moq;

namespace DemoTry.Four;


public class MerchantPortal
{
    private readonly IPaymentProviderApi paymentProviderApi;

    public MerchantPortal(IPaymentProviderApi paymentProviderApi)
    {
        this.paymentProviderApi = paymentProviderApi;
    }

    public string MakePayment(string cardNumer, decimal paymentAmount)
    {
        var resultCode = this.paymentProviderApi.MakePayment(cardNumer, paymentAmount);

        var responseMessage = resultCode switch
        {
            1 => "Payment Accepted",
            2 => "Payment Declined",
            _ => "Error Processing Payment"
        };

        return responseMessage;
    }
}

public interface IPaymentProviderApi
{
    int MakePayment(string cardNumer, decimal paymentAmount);
}

public class PaymentProviderApi : IPaymentProviderApi
{
    public int MakePayment(string cardNumer, decimal paymentAmount)
    {
        return 1;
    }
}


public class TestMyMerchantPortal
{
    // [Theory] are tests which are only true for a particular set of data. - XUnit

    [Theory]
    [InlineData("Card1", 10, 1 ,"Payment Accepted")]
    [InlineData("Card2", 20, 2 ,"Payment Declined")]
    [InlineData("Card3", 30, 3 ,"Error Processing Payment")]
    public void AcceptedMessageShownWhenPaymentAccepted(string paymentCard, decimal paymentAmount, int mockResponseCode, string expectedMessage)
    {
        var mockProvider = new Mock<IPaymentProviderApi>();
        mockProvider.Setup(m => m.MakePayment(paymentCard, paymentAmount)).Returns(mockResponseCode);

        var merchant = new MerchantPortal(mockProvider.Object);

        string responseMessage = merchant.MakePayment(paymentCard, paymentAmount);

        Assert.Equal(expectedMessage, responseMessage);
    }
}