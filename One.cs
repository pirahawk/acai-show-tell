namespace DemoTry.One;

public class MerchantPortal
{
    public string MakePayment(string cardNumer, decimal paymentAmount)
    {
        PaymentProviderApi paymentProvider = new PaymentProviderApi();
        var resultCode = (int)paymentProvider.MakePayment(cardNumer, paymentAmount);

        var responseMessage = resultCode switch
        {
            1 => "Payment Accepted",
            2 => "Payment Declined",
            _ => "Error Processing Payment"
        };

        return responseMessage;
    }
}

public class PaymentProviderApi
{
    /*
        Assume this method "should" return:
        * 1 - if Payment was successfully accepted.
        * 2 - if Payment was declined.
        * 3 - if there was an error processing the payment.
    */
    public int MakePayment(string cardNumer, decimal paymentAmount)
    {
        return 1;
    }
}


public class TestMyMerchantPortal
{
    // [Facts] are tests which are always true. They test invariant conditions.- XUnit

    [Fact]
    public void AcceptedMessageShownWhenPaymentAccepted()
    {
        var merchant = new MerchantPortal();

        string responseMessage = merchant.MakePayment("Card1", 10);

        Assert.Equal("Payment Accepted", responseMessage);
    }


    [Fact]
    public void DeclinedMessageShownWhenPaymentHasBeenDeclined()
    {
        var merchant = new MerchantPortal();

        string responseMessage = merchant.MakePayment("Card2", 20);

        Assert.Equal("Payment Declined", responseMessage);
    }
}