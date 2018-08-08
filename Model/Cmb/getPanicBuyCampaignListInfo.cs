using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Cmb
{
    public class Product
    {
        public string productId { get; set; }
        public string goodsId { get; set; }
        public string channelCode { get; set; }
        public string productName { get; set; }
        public int productType { get; set; }
        public string productNo { get; set; }
        public string referencePrice { get; set; }
        public string salePrice { get; set; }
        public string salePoint { get; set; }
        public string inventoryInfo { get; set; }
        public string imageBaseUrl { get; set; }
        public string thumbImage { get; set; }
        public string redirectUrl { get; set; }
    }

    public class Campaign
    {
        public string title { get; set; }
        public string campaignNo { get; set; }
        public string templateNo { get; set; }
        public List<Product> products { get; set; }
    }

    public class PanicStatus
    {
        public int curQgEndTime { get; set; }
        public int status { get; set; }
        public int countdownStartMin { get; set; }
        public string qgTime { get; set; }
        public string sysCurTime { get; set; }
    }

    public class getPanicBuyCampaignListInfo
    {
        public string respCode { get; set; }
        public string moduleId { get; set; }
        public string qualifyUrl { get; set; }
        public string status { get; set; }
        public List<Campaign> campaigns { get; set; }
        public string defaultCampaignNo { get; set; }
        public string shareId { get; set; }
        public string needQualify { get; set; }
        public string defaultTemplateNo { get; set; }
        public string cGName { get; set; }
        public string respMsg { get; set; }
        public string displayName { get; set; }
        public PanicStatus panicStatus { get; set; }
    }

}
