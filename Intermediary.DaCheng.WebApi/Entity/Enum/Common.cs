using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Intermediary.DaCheng.WebApi.Entity.Enum
{
    /// <summary>
    /// 性别
    /// </summary>
    public enum GenderEnum
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("男")]
        Male = 1,

        /// <summary>
        /// 
        /// </summary>
        [Description("女")]
        Female = 0,

        /// <summary>
        /// 
        /// </summary>
        [Description("未知")]
        Unknown = -1
    }

    /// <summary>
    /// 保险类别
    /// </summary>
    public enum InsuranceEnum
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("启用")]
        Yes = 1,

        /// <summary>
        /// 
        /// </summary>
        [Description("禁用")]
        No = 0
    }
}
