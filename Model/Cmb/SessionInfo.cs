using System;

namespace Model.Cmb
{
    public class SessionInfo
    {

        public string guid { get; set; } = Guid.NewGuid().ToString();
        public int number { get; set; } = 0;
        public string cookie { get; set; }
        public InInfo inInfo { get; set; }
        public int st { get; set; } = 0;
        public string goodsId { get; set; }
        public DateTime ctime { get; set; } = DateTime.Now;

        /// <summary>
        /// userId 用户ID
        /// </summary>
        public string p5 { get; set; }

        public string NickName { get; set; }
        public string cGName { get; set; }
    }

    public class LoginSessionInfo
    {
        /// <summary>
        /// userId 用户ID
        /// </summary>
        public string p5 { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        /// sessionId 登录ID
        /// </summary>
        public string p9 { get; set; }

        /// <summary>
        /// sessionId 登录ID
        /// </summary>
        public string sessionId { get; set; }

        /// <summary>
        /// cookie
        /// </summary>
        public string cookie { get; set; }

    }

    public class myInfo
    {
        public string limit { get; set; }
        public string respCode { get; set; }
        public string profit { get; set; }
        public string nickName { get; set; }
        public string respMsg { get; set; }
        public string lastDate { get; set; }
        public string bonus { get; set; }
        public string authType { get; set; }
    }

}