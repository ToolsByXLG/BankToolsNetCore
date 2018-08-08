using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Cmb
{
    public class GiftInfo
    {
        public class GiftList
        {
            public string productId { get; set; }
            public string productNo { get; set; }
            public string productName { get; set; }
            public string thumbImage { get; set; }
            public string productPoint { get; set; }
            public string productPrice { get; set; }
            public string imageBseUrl { get; set; }
            public string totalQuantity { get; set; }
            public string minPayMin { get; set; }
            public string maxPayMin { get; set; }
            public string shareId { get; set; }
            public string moduleId { get; set; }
            public string cGName { get; set; }
            public string cGDisplayName { get; set; }
            public string templateNo { get; set; }
            public string redirectUrl { get; set; }
            public string sysOrderID { get; set; }
            public string giftButtonUrl { get; set; }
            public string giftButtonText { get; set; }
            public bool showDeliveryInfo { get; set; }
            public bool isCgExpired { get; set; }
            public string createDate { get; set; }
            public string orderNo { get; set; }
        }

        public class getMyGifts
        {
            public IList<GiftList> giftList { get; set; }
            public int totalSize { get; set; }
            public int totalPageSize { get; set; }
            public int currentPageSize { get; set; }
            public int paymentType { get; set; }
            public string sysCurTime { get; set; }
            public string respCode { get; set; }
            public string respMsg { get; set; }
        }
    }
}
