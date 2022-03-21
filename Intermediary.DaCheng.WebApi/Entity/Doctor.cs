using Intermediary.DaCheng.WebApi.Entity.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intermediary.DaCheng.WebApi.Entity
{
    /// <summary>
    /// 医生信息
    /// </summary>
    public class Doctor
    {
        /// <summary>
        /// 医生 ID
        /// </summary>
        public long ID { get; set; }
        /// <summary>
        /// 医生姓名
        /// </summary>
        public string XM { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public GenderEnum XB { get; set; }
        /// <summary>
        /// 医生简介
        /// </summary>
        public string JJ { get; set; }
        /// <summary>
        /// 所属科室 ID
        /// </summary>
        public HashSet<Department> KSID { get; set; }
    }
}
