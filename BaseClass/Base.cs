using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using System.Web;
using Model;

namespace BaseClass
{
    public class BaseTools
    {
        /// <summary>
        ///     GMT时间转成本地时间
        /// </summary>
        /// <param name="gmt">字符串形式的GMT时间</param>
        /// <returns></returns>
        public DateTime GMT2Local(string gmt)
        {
            var dt = DateTime.MinValue;
            try
            {
                var pattern = "";
                if (gmt.IndexOf("+0") != -1)
                {
                    gmt = gmt.Replace("GMT", "");
                    pattern = "ddd, dd MMM yyyy HH':'mm':'ss zzz";
                }
                if (gmt.ToUpper().IndexOf("GMT") != -1)
                    pattern = "ddd, dd MMM yyyy HH':'mm':'ss 'GMT'";
                if (pattern != "")
                {
                    dt = DateTime.ParseExact(gmt, pattern, CultureInfo.InvariantCulture,
                        DateTimeStyles.AdjustToUniversal);
                    dt = dt.ToLocalTime();
                }
                else
                {
                    dt = Convert.ToDateTime(gmt);
                }
            }
            catch
            {
            }
            return dt;
        }

        /// <summary>
        ///     时间戳转为C#格式时间
        /// </summary>
        /// <param name="timeStamp">Unix时间戳格式</param>
        /// <returns>C#格式时间</returns>
        public DateTime GetTime(string timeStamp)
        {
            var dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            var lTime = long.Parse(timeStamp + "0000");
            var toNow = new TimeSpan(lTime);
            return dtStart.Add(toNow);
        }

        /// <summary>
        ///     DateTime时间格式转换为Unix时间戳格式
        /// </summary>
        /// <param name="time"> DateTime时间格式</param>
        /// <returns>Unix时间戳格式</returns>
        public long ConvertDateTimeInt(DateTime time)
        {
            var startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            return (long) (time - startTime).TotalMilliseconds;
        }

        public InInfo GetinInfoBySession(SessionTemp oS)
        {
            var headers = oS.headers;
            var fullUrl = oS.fullUrl;
            var body = oS.body;
            var inInfo = new InInfo();
            inInfo.RequestType = RequestType.Post;
            inInfo.Url = fullUrl;
            inInfo.PostData = new StringContent(body);
            inInfo.PostDataString = body;
            foreach (var header in headers)
            {
                var hName = header.Key;
                var hValue = header.Value;
                //AddTXT(hname);
                inInfo.RequestHeaders = headers;
                switch (hName)
                {
                    case "Connection":
                        //inInfo.
                        break;


                    case "Content-Length":

                        break;


                    case "Pragma":

                        break;


                    case "Cache-Control":

                        break;


                    case "Accep":

                        break;


                    case "Origin":

                        break;


                    case "X-Requested-With":

                        break;


                    case "User-Agent":
                        inInfo.UserAgent = hValue;
                        break;


                    case "Content-Type":
                    case "content-type":

                        try
                        {
                            var contentTypes = hValue.Split(';');
                            var contentTypeValue = contentTypes.FirstOrDefault(x => x.Contains("/"));
                            var contentTypeCharSet = contentTypes.FirstOrDefault(x => x.Contains("charset="));


                            var contenttype = MediaTypeHeaderValue.Parse(contentTypeValue);
                            if (contentTypeCharSet != null)
                                contenttype.CharSet = contentTypeCharSet.Replace("charset=", "");
                            else contenttype.CharSet = "UTF-8";
                            inInfo.ContentTypeObj = contenttype;
                            inInfo.PostData.Headers.ContentType = contenttype;
                        }
                        catch
                        {
                            //inInfo.PostData.Headers.ContentType =
                            //MediaTypeHeaderValue.Parse("application/x-www-form-urlencoded");
                            //inInfo.PostData.Headers.ContentType.CharSet = "UTF-8";

                            var contenttype = MediaTypeHeaderValue.Parse("application/x-www-form-urlencoded");
                            contenttype.CharSet = "UTF-8";
                            inInfo.ContentTypeObj = contenttype;

                            inInfo.PostData.Headers.ContentType = contenttype;
                        }
                        break;


                    case "Referer":

                        break;


                    case "Accept-Encoding":

                        break;


                    case "Accept-Language":

                        break;


                    case "Cookie":
                    case "cookie":
                        inInfo.Cookie = hValue.Split(';').ToList();
                        break;
                }
            }
            return inInfo;
        }


        public List<IPAddress> GetThisIpV4List()
        {
            string name = Dns.GetHostName();
            IPAddress[] ipadrlist = Dns.GetHostAddresses(name);
            var ips= ipadrlist.Where(x => x.AddressFamily == AddressFamily.InterNetwork).ToList();
            return ips;
        }
        /// <summary>
        /// 分析一个url将参数存入到dictionary
        /// </summary>
        /// <param name="strHref"></param>
        /// <returns></returns>
        public Dictionary<String, String> GetPostDataParam(String strHref)
        {
            Dictionary<String, String> dicInfo = new Dictionary<string, string>();
            Regex re = new Regex(@"(^|&)?(\w+)=([^&]+)(&|$)?", RegexOptions.Compiled);
            MatchCollection mc = re.Matches(strHref);
            foreach (Match m in mc)
            {
                dicInfo.Add(m.Result("$2").ToLower(), m.Result("$3"));
            }
            return dicInfo;

        }
    }
}