using System.Diagnostics;

namespace Minecraft离线UUID生成器
{
    internal class Error_list: Exception
    {
        /// <summary>
        /// 错误码映射表
        /// 十位：错误类型
        /// 个位：错误信息
        /// 错误列表只能用“[错误等级]错误信息，错误提示” 注：错误提示为可选项
        /// 错误等级：
        ///     Serious error：严重至影响 其他程序/系统 运行 或 此类无法处理的错误
        ///     Error：影响此程序运行的错误
        ///     Warning：不会影响任何程序运行但没用 或 仅影响其他应用程序的次要功能
        ///     unknown：可能是以上任意一个
        /// </summary>
        public static readonly Dictionary<int,string> Errors = new()
        {
            {0 , "[unknow]未知错误" },
            {1 , "[Error]系统IO操作失败"},
            {2 , "[Serious error]Error list is Not working"},

            {10 , "[Error]白名单文件路径不能为空" },
            {11 , "[Warning]白名单文件不存在"},
            {12 , "[Error]读取白名单文件失败"},
            {13 , "[Error]写入白名单文件失败"},
            {14 , "[Warning]你没有选择任何一个白名单进行写入"},

            {20 , "[Error]玩家名称不能为空"},
            {21 , "[Error]玩家UUID不能为空,请点击生成以生成UUID"},
            {22 , "[Warning]UUID {0} 已存在于白名单中,请确认此UUID是否是上一位玩家的UUID"},
            {23 , "[Warning]此玩家 {0} 已存在于白名单中"},

            {30 , "[Error]解析白名单JSON失败"},
            {31 , "[Warning]序列化白名单失败"},

            {40 , "[Error]服务器目录路径不能为空"},
            {41 , "[Warning]服务器根目录不存在"},
            {42 , "[Warning]无权访问服务器目录"},
            {43 , "[Error]目录遍历过程中发生错误"},

            {90 , "[Multiple values]发现多个错误，点击此信息打开错误列表"}
        };
        private List<int> _errorList = [];

        public Error_list() { }

        /// <summary>
        /// 添加错误
        /// </summary>
        /// <param name="error">错误代码</param>
        public void AddError(int error) => _errorList.Add(error);

        /// <summary>
        /// 设置错误列表（不建议使用）
        /// </summary>
        public List<int> List{set => _errorList = value; get => _errorList;}

        /// <summary>
        /// 获取错误信息
        /// </summary>
        /// <param name="subscript">下标</param>
        /// <returns>错误信息</returns>
        public string GetError(int subscript = 0) => Errors[_errorList[subscript % _errorList.Count]];

        /// <summary>
        /// 获取错误列表长度
        /// </summary>
        /// <returns>错误列表长度</returns>
        public int Length => _errorList.Count;

        /// <summary>
        /// 获取所有错误信息（按列表顺序）
        /// </summary>
        public List<string> AllErrors => [.. _errorList.Select(code => Errors.GetValueOrDefault(code, Errors[0]))];
    }
}
