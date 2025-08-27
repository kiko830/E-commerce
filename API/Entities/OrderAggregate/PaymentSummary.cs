using System;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace API.Entities.OrderAggregate;

[Owned]
public class PaymentSummary
{
    public int Last4 { get; set; }
    public required string Brand { get; set; }
    [JsonProperty("exp_month")]
    public int ExpMonth { get; set; }

    [JsonProperty("exp_year")]
    public int ExpYear { get; set; }
}
