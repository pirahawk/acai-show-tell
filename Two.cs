namespace DemoTry.Two;


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
    [Fact]
    public void AcceptedMessageShownWhenPaymentAccepted()
    {
        var paymentProviderApi = new PaymentProviderApi();
        var merchant = new MerchantPortal(paymentProviderApi);

        string responseMessage = merchant.MakePayment("Card1", 10);

        Assert.Equal("Payment Accepted", responseMessage);
    }

    [Fact]
    public void DeclinedMessageShownWhenPaymentHasBeenDeclined()
    {
        var paymentProviderApi = new PaymentProviderApi();
        var merchant = new MerchantPortal(paymentProviderApi);

        string responseMessage = merchant.MakePayment("Card2", 20);

        Assert.Equal("Payment Declined", responseMessage);
    }
}