using System;
using System.ComponentModel;

namespace Intermediary.DaCheng.Entity.Enum
{
    /// <summary>
    /// 性别
    /// </summary>
    public enum GenderEnum
    {
        [Description("男")]
        Male = 1,

        [Description("女")]
        Female = 0,

        [Description("未知")]
        Unknown = -1
    }

    /// <summary>
    /// 保险类别
    /// </summary>
    public enum InsuranceEnum
    {
        [Description("启用")]
        Yes = 1,

        [Description("禁用")]
        No = 0
    }
}
