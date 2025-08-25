using API.Entities;
using Microsoft.Extensions.Options;
using Stripe;

namespace API.Services;

public class PaymentService
{
    private readonly StripeClient _stripeClient;

    public PaymentService(IConfiguration config)
    {
        var apiKey = Environment.GetEnvironmentVariable("STRIPE_SECRET_KEY");

        if (string.IsNullOrEmpty(apiKey))
        {
            throw new InvalidOperationException("Stripe API Key is missing.");
        }

        _stripeClient = new StripeClient(apiKey); 
    }

    public async Task<PaymentIntent> CreateOrUpdatePaymentIntent(Basket basket)
    {

        var service = new PaymentIntentService(_stripeClient);

        var intent = new PaymentIntent();

        var subtotal = basket.Items.Sum(x => x.Quantity * x.Product.Price);

        var deliveryFee = subtotal > 10000 ? 0 : 500;

        if (string.IsNullOrEmpty(basket.PaymentIntentId))
        {
            var options = new PaymentIntentCreateOptions
            {
                Amount = subtotal + deliveryFee,
                Currency = "nzd",
                PaymentMethodTypes = ["card"]
            };
            intent = await service.CreateAsync(options);
        }
        else
        {
            await service.UpdateAsync(basket.PaymentIntentId, new PaymentIntentUpdateOptions
            {
                Amount = subtotal + deliveryFee
            });
        }

        return intent;
    }

}
