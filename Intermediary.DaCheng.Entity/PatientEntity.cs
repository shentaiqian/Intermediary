using Intermediary.DaCheng.Entity.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Intermediary.DaCheng.Entity
{
    /// <summary>
    /// 病人信息
    /// </summary>
    public class PatientEntity
    {
        /// <summary>
        /// HIS 中的病人 ID
        /// </summary>
        public long BRID { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string XM { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public GenderEnum XB { get; set; }
        /// <summary>
        /// 年龄
        /// </summary>
        public int NL { get; set; }
        /// <summary>
        /// 出生日期
        /// </summary>
        public DateTime CSRQ { get; set; }
        /// <summary>
        /// 身份证号
        /// </summary>
        public long SFZH { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        public long DH { get; set; }
        /// <summary>
        /// 家庭地址
        /// </summary>
        public string JTDZ { get; set; }
        /// <summary>
        /// 保险类别
        /// </summary>
        public InsuranceEnum BXLB { get; set; }
        /// <summary>
        /// 门诊预交余额
        /// </summary>
        public decimal MZYE { get; set; }
        /// <summary>
        /// 住院次数
        /// </summary>
        public int ZYCS { get; set; }
    }
}
