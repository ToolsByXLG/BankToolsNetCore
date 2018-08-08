using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Model;

namespace BaseClass
{
    public class HttpHelper
    {
        public OutInfo GetHtml(InInfo ininfo)
        {
            var hch = new HttpClientHandler
            {
                Proxy = new WebProxy(),
                UseProxy = false,
                AllowAutoRedirect = false,
                UseCookies = true,
                AutomaticDecompression = DecompressionMethods.GZip
            };
            var outinfo = new OutInfo();
            var hr = new HttpRequestMessage();
            hr.RequestUri = new Uri(ininfo.Url);

            var httphandler = ininfo.HttpHandler ?? hch;
            if (ininfo.Cookie != null && ininfo.Cookie.Count > 0)
                ininfo.Cookie.ForEach(x =>
                {
                    var ckas = x.Split(';');
                    string cka;
                    if (ckas.Length == 1)
                        cka = ckas[0] + ";Path=/";
                    else
                        cka = string.Join(";", ckas);
                    httphandler.CookieContainer.SetCookies(new Uri(ininfo.Url), cka);
                });

            var hc = new HttpClient(httphandler);
            //hc.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*"));
            if (string.IsNullOrWhiteSpace(ininfo.UserAgent))
                ininfo.UserAgent = "Jakarta Commons-HttpClient/3.1";
            try
            {
                hc.DefaultRequestHeaders.UserAgent.ParseAdd(ininfo.UserAgent.Replace("/DKKJ_TOWER_1.0 DKKJ_TOWER_1.0",""));
            }
            catch
            {
                hc.DefaultRequestHeaders.UserAgent.ParseAdd(
                    "Mozilla/5.0 (Linux; Android 7.0; KNT-AL10 Build/HUAWEIKNT-AL10; wv) AppleWebKit/537.36 (KHTML, like Gecko) Version/4.0 Chrome/59.0.3071.125 Mobile Safari/537.36");
            }





            if (ininfo.RequestHeaders != null)
                foreach (var entry in ininfo.RequestHeaders)
                {
                    if (entry.Key.ToLower() == "authorization")
                    {
                        hc.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", entry.Value);
                    }
                    if (entry.Key.ToLower() == "user-agent" || entry.Key.ToLower() == "content-length" || entry.Key.ToLower() == "content-type"|| entry.Key.ToLower() == "authorization")
                        continue;
                    try
                    {
                        hc.DefaultRequestHeaders.Add(entry.Key, entry.Value);
                    }
                    catch
                    {
                        //hc.DefaultRequestHeaders.Add(entry.Key,
                        //    "Mozilla/5.0 (Linux; Android 7.0; KNT-AL10 Build/HUAWEIKNT-AL10; wv) AppleWebKit/537.36 (KHTML, like Gecko) Version/4.0 Chrome/59.0.3071.125 Mobile Safari/537.36");
                    }
                }
            hc.DefaultRequestHeaders.ExpectContinue = false;

            ininfo.Timeout = ininfo.Timeout == 0 ? 15000 : ininfo.Timeout;
            hc.Timeout = DateTime.Now.AddMilliseconds(ininfo.Timeout) - DateTime.Now;
            Task<HttpResponseMessage> tres = null;
            HttpContent postDataTemp = null;
            try
            {
                if (ininfo.RequestType == RequestType.Post)
                {
                    //ininfo.PostData = new StringContent(ininfo.PostDataString);
                    //ininfo.PostData.Headers.ContentType = ininfo.ContentTypeObj;

                    HttpContent postdata =  new StringContent(ininfo.PostDataString);
                    postdata.Headers.ContentType = ininfo.ContentTypeObj;
                    tres = hc.PostAsync(hr.RequestUri, postdata);
                }
                else
                {
                    tres = hc.SendAsync(hr);
                }
            }
            catch (Exception ee)
            {
                outinfo.Result = ee + "-发送错误";
            }
            if (ininfo.TaskType == TaskType.Sync)
                try
                {
                    if (tres != null)
                    {
                        var res = tres.Result;
                        outinfo.StatusCode = res.StatusCode;
                        if (res.StatusCode == HttpStatusCode.OK)
                            switch (ininfo.OutType)
                            {
                                case OutType.OutString:
                                    outinfo.Result = res.Content.ReadAsStringAsync().Result;
                                    break;
                                case OutType.OutByte:
                                    outinfo.Result = res.Content.ReadAsByteArrayAsync().Result;
                                    break;
                                case OutType.OutStream:
                                    outinfo.Result = res.Content.ReadAsStreamAsync().Result;
                                    break;
                            }
                        outinfo.Headers = res.Headers;
                        try
                        {
                            outinfo.Cookie = res.Headers.GetValues("Set-Cookie").ToList();
                        }
                        catch
                        {
                            // ignored
                        }
                    }
                }
                catch (Exception ee)
                {
                    outinfo.Result = ee + "-接收错误";
                }
            ininfo.PostData = postDataTemp;
            return outinfo;
        }
    }
}