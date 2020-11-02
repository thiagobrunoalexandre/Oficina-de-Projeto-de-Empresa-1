using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alge.Models.Checkout
{
    public class CheckoutProductModel
    {
        public ImageProductModel ImageProductModel { get; set; }
        public SubscriptionProductModel SubscriptionProductModel { get; set; }
    }

    public class ImageProductModel
    {
        public string ID { get; set; }
        public string LicenseKey { get; set; }
        public string ThumbUrl { get; set; }
        public string UrlDownloadKey { get; set; }
        public int DatabaseOrigin { get; set; }
        public string Description { get; set; }
        public Double Price { get; set; }
        public String ImageCode { get; set; }
    }

    public class SubscriptionProductModel
    {
        public string Description { get; set; }
        public DateTime InitialDate { get; set; }
        public DateTime FinalDate { get; set; }

    }
}
