using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeviceCloud.Extensions;

namespace DeviceCloud.Models
{
    public class News
    {
        public int Id { get; set; }
        public string Title { get; set; }
        /// <summary>
        /// 简介
        /// </summary>
        public string Introduction { get; set; }
        /// <summary>
        /// 封面图片的url
        /// </summary>
        public string CorverUrl { get; set; }
        public string Content { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
