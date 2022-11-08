using Moq;

namespace DemoTry.Three;


public class MerchantPortal
{
    private readonly IPaymentProviderApi paymentProviderApi;

    public MerchantPortal(IPaymentProviderApi paymentProviderApi)
    {
        this.paymentProviderApi = paymentProviderApi;
    }

    public string MakePayment(string cardNumer, decimal paymentAmount)
    {
        var resultCode = (int)this.paymentProviderApi.MakePayment(cardNumer, paymentAmount);

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
    [Fact]
    public void AcceptedMessageShownWhenPaymentAccepted()
    {
        var paymentCard = "Card1";
        var paymentAmount = 10;
        var mockResponseCode = 1;

        var mockProvider = new Mock<IPaymentProviderApi>();
        mockProvider.Setup(m => m.MakePayment(paymentCard, paymentAmount)).Returns(mockResponseCode);

        var merchant = new MerchantPortal(mockProvider.Object);

        string responseMessage = merchant.MakePayment(paymentCard, paymentAmount);

        Assert.Equal("Payment Accepted", responseMessage);
    }

    [Fact]
    public void DeclinedMessageShownWhenPaymentHasBeenDeclined()
    {
        var paymentCard = "Card2";
        var paymentAmount = 20;
        var mockResponseCode = 2;

        var mockProvider = new Mock<IPaymentProviderApi>();
        mockProvider.Setup(m => m.MakePayment(paymentCard, paymentAmount)).Returns(mockResponseCode);

        var merchant = new MerchantPortal(mockProvider.Object);

        string responseMessage = merchant.MakePayment(paymentCard, paymentAmount);

        Assert.Equal("Payment Declined", responseMessage);
    }
}