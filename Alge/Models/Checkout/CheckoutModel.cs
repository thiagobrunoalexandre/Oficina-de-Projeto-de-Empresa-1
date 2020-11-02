
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Web;


namespace Alge.Models.Checkout
{
    public class CheckoutModel
    {
        public string UserID { get; set; }
        
        public int PaymentMethodID { get; set; }
        public bool DiscountCouponToggle { get; set; }
        public String DiscountCoupon { get; set; }
        public bool OneCostTime { get; set; }
        public bool GroupAccount { get; set; }
        public bool Cumulated { get; set; }
    }

}