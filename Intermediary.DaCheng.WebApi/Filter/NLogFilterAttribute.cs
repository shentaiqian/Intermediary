using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace Intermediary.DaCheng.WebApi.Filter
{
    /// <summary>
    /// 
    /// </summary>
    public class NLogFilterAttribute : ActionFilterAttribute
    {
        private readonly ILogger<NLogFilterAttribute> _logger;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        public NLogFilterAttribute(ILogger<NLogFilterAttribute> logger)
        {
            _logger = logger;
        }
        //private readonly ILogger _logger;
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="logger"></param>
        //public NLogFilterAttribute(ILogger logger) => _logger =logger;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            _logger.LogInformation("----------日志记录完毕----------");
            base.OnActionExecuted(context);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            _logger.LogInformation("----------日志记录开始----------");
            base.OnActionExecuting(context);
        }
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="context"></param>
        //public override void OnResultExecuted(ResultExecutedContext context)
        //{
        //    _logger.Info("7.结果准备生成完成");
        //    base.OnResultExecuted(context);
        //    _logger.Info("8.结果生成完成");
        //}
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="context"></param>
        //public override void OnResultExecuting(ResultExecutingContext context)
        //{
        //    _logger.Info("5.结果准备生成完成");
        //    base.OnResultExecuting(context);
        //    _logger.Info("6.结果生成完成");
        //}
    }
}
