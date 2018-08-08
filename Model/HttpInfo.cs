using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace Model
{
    public class InInfo
    {
        public HttpClientHandler HttpHandler { get; set; }
        public Dictionary<string, string> RequestHeaders { get; set; } = new Dictionary<string, string>();
        public string Url { get; set; }
        public string UserAgent { get; set; }
        public List<string> Cookie { get; set; }
        public RequestType RequestType { get; set; }
        public OutType OutType { get; set; }
        public TaskType TaskType { get; set; }
        public HttpContent PostData { get; set; }

        /// <summary>
        ///     超时时间默认15秒
        /// </summary>
        public int Timeout { get; set; }

        public string ContentType { get; set; }
        public MediaTypeHeaderValue ContentTypeObj { get; set; }
        public string PostDataString { get; set; }
    }
    public class InInfo2
    {
        public HttpClientHandler HttpHandler { get; set; }
        public Dictionary<string, string> RequestHeaders { get; set; } = new Dictionary<string, string>();
        public string Url { get; set; }
        public string UserAgent { get; set; } = "Mozilla/5.0 (Linux; Android 4.4.2; R8207 Build/KTU84P) AppleWebKit/537.36 (KHTML, like Gecko) Version/4.0 Chrome/30.0.0.0 Mobile Safari/537.36 DKKJ/4.1.0/DKKJ_TOWER_1.0 DKKJ_TOWER_1.0";
        public List<string> Cookie { get; set; }
        public RequestType RequestType { get; set; }
        public OutType OutType { get; set; }
        public TaskType TaskType { get; set; }
        public HttpContent PostData { get; set; }

        /// <summary>
        ///     超时时间默认15秒
        /// </summary>
        public int Timeout { get; set; }

        public string ContentType { get; set; }
        public MediaTypeHeaderValue ContentTypeObj { get; set; }
        public string PostDataString { get; set; }
    }

    public class OutInfo
    {
        public HttpStatusCode StatusCode { get; set; }
        public object Result { get; set; }
        public List<string> Cookie { get; set; }
        public HttpResponseHeaders Headers { get; set; }
    }


    public enum RequestType
    {
        /// <summary>
        ///     Get方式
        /// </summary>
        Get = 0,

        /// <summary>
        ///     Post方式
        /// </summary>
        Post = 1
    }

    public enum TaskType
    {
        /// <summary>
        ///     同步,可获取返回值
        /// </summary>
        Sync = 0,

        /// <summary>
        ///     异步,无任何返回值
        /// </summary>
        Async = 1
    }

    public enum OutType
    {
        /// <summary>
        ///     返回字符串
        /// </summary>
        OutString = 0,

        /// <summary>
        ///     无返回值
        /// </summary>
        OutNull = 1,

        /// <summary>
        ///     返回字节
        /// </summary>
        OutByte = 2,

        /// <summary>
        ///     返回流
        /// </summary>
        OutStream = 3
    }
}
