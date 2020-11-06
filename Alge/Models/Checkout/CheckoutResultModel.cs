using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Alge.Models.Checkout
{
    public class CheckoutResultModel
    {
        public List<CheckoutProductModel> CheckoutProducts { get; set; }
        public ProductsType CheckoutType { get; set; }
        public int OrderID { get; set; }
        public CheckoutResultStatus CheckoutResultStatus { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public Double TotalValue { get; set; }
        public CheckoutResultModel()
        {
            this.CheckoutProducts = new List<CheckoutProductModel>();
        }
    }

    public enum PaymentMethod
    {
        paypal = 1,
        debit = 2,
        credit_card = 3,
        bank_transfer = 4,
        boleto = 5
    }

    public enum CheckoutResultStatus
    {
        canceled = 1,
        completed = 2,
        awaiting_payment = 3,
        payment_denied = 4,
        awaiting_billing_data = 5
    }
}
