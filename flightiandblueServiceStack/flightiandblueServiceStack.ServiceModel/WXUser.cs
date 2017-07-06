using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flightiandblueServiceStack.ServiceModel
{
    [Route("/WXUser")]
    public class WXUser : IReturn<WXUserResponse>
    {
        public string Code { get; set; }
        public string IV { get; set; }
        public string EncryptedData { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }  
    }

    public class WXUserResponse //: BaseResponseType
    {
        public int Id { get; set; }
        public string OpenId { get; set; }
        public string UnionId { get; set; }
        public string avatarUrl { get; set; }
    }

    public class WXjscode2sessionResponseType
    {
        public string openid { get; set; }
        public string session_key { get; set; }
        public string errcode { get; set; }
        public string errmsg { get; set; }
    }

    public class WXGetUserInfoResponseType
    {
        public string openId { get; set; }
        public string nickName { get; set; }
        public int gender { get; set; }
        public string city { get; set; }
        public string province { get; set; }
        public string country { get; set; }
        public string avatarUrl { get; set; }
        public string unionId { get; set; }
    }

    #region TXMap
    public class TXMapResponseType
    {
        public int status { get; set; }
        public string message { get; set; }
        public TXMapResult result { get; set; }
    }

    public class TXMapResult
    {
        public string address { get; set; }
        public TXMapFormattedAddresses formatted_addresses { get; set; }
        public TXMapAddressComponent address_component { get; set; }
        public TXMapAdInfo ad_info { get; set; }
        public TXMapAddressReference address_reference { get; set; }
        public TXMapPOI[] pois { get; set; }
    }
    public class TXMapFormattedAddresses
    {
        public string recommend { get; set; }
        public string rough { get; set; }
    }
    public class TXMapAddressComponent
    {
        public string nation { get; set; }
        public string province { get; set; }
        public string city { get; set; }
        public string district { get; set; }
        public string street { get; set; }
        public string street_number { get; set; }
    }
    public class TXMapAdInfo
    {
        public string adcode { get; set; }
        public string name { get; set; }
        public TXMapLocation location { get; set; }
        public string nation { get; set; }
        public string province { get; set; }
        public string city { get; set; }
        public string district { get; set; }
    }
    public class TXMapLocation
    {
        public decimal lat { get; set; }
        public decimal lng { get; set; }
    }
    public class TXMapAddressReference
    {
        public TXMapFamousAreaAndTown famous_area { get; set; }
        public TXMapFamousAreaAndTown town { get; set; }
        public TXMapFamousAreaAndTown landmark_l1 { get; set; }
        public TXMapFamousAreaAndTown landmark_l2 { get; set; }
        public TXMapFamousAreaAndTown street { get; set; }
        public TXMapFamousAreaAndTown street_number { get; set; }
        public TXMapFamousAreaAndTown crossroad { get; set; }
        public TXMapFamousAreaAndTown water { get; set; }
    }
    public class TXMapFamousAreaAndTown
    {
        public string title { get; set; }
        public TXMapLocation location { get; set; }
        public decimal _distance { get; set; }
        public string _dir_desc { get; set; }
    }
    public class TXMapPOI
    {
        public string id { get; set; }
        public string title { get; set; }
        public string address { get; set; }
        public string category { get; set; }
        public TXMapLocation location { get; set; }
        public decimal _distance { get; set; }
    }

    #endregion TXMap
}
