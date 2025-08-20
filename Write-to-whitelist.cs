using System.Text.Json;
using System.Text.Json.Serialization;

namespace Minecraft离线UUID生成器
{
    internal class Write_to_whitelist
    {
        public class WhitelistEntry
        {
            [JsonPropertyName("uuid")]
            public required string Uuid { get; set; }

            [JsonPropertyName("name")]
            public required string Name { get; set; }
        }

        /// <summary>
        /// 将玩家信息添加到白名单文件
        /// </summary>
        /// <param name="whitelistPath">白名单文件路径</param>
        /// <param name="playerName">玩家名称</param>
        /// <param name="playerUuid">玩家UUID</param>
        /// <exception cref="Error_list">包含所有验证错误的异常</exception>
        public static void AddToWhitelist(string whitelistPath, string playerName, string playerUuid)
        {
            var errorList = new Error_list();

            // 第一阶段：参数验证
            if (string.IsNullOrWhiteSpace(whitelistPath))
                errorList.AddError(10); // 文件路径为空

            if (string.IsNullOrWhiteSpace(playerName))
                errorList.AddError(20); // 玩家名称为空

            if (string.IsNullOrWhiteSpace(playerUuid))
                errorList.AddError(21); // UUID为空

            // 如果有基本参数错误，直接抛出
            if (errorList.Length > 0)
                throw errorList;

            // 第二阶段：文件操作验证
            string absolutePath = Path.GetFullPath(whitelistPath);
            if (!File.Exists(absolutePath))
                errorList.AddError(11); // 文件不存在

            // 如果有文件错误，直接抛出
            if (errorList.Length > 0)
                throw errorList;

            // 第三阶段：数据处理
            List<WhitelistEntry> whitelist;
            try
            {
                string jsonContent = File.ReadAllText(absolutePath);
                whitelist = JsonSerializer.Deserialize<List<WhitelistEntry>>(jsonContent)
                    ?? [];
            }
            catch (Exception ex)
            {
                errorList.AddError(30); // JSON解析失败
                throw new Error_list
                {
                    List = [30],
                    Data = { ["0"] = ex.Message }
                };
            }

            // 检查重复项
            if (whitelist.Any(e => e.Uuid.Equals(playerUuid, StringComparison.OrdinalIgnoreCase)))
                errorList.AddError(22); // UUID已存在

            if (whitelist.Any(e => e.Name.Equals(playerName, StringComparison.OrdinalIgnoreCase)))
                errorList.AddError(23); // 玩家名称已存在

            if (errorList.Length > 0)
                throw errorList;

            // 第四阶段：写入操作
            whitelist.Add(new WhitelistEntry { Uuid = playerUuid, Name = playerName });

            try
            {
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
                };

                File.WriteAllText(absolutePath, JsonSerializer.Serialize(whitelist, options));
            }
            catch (Exception ex)
            {
                throw new Error_list
                {
                    List = [13],
                    Data = { ["0"] = ex.Message }
                };
            }
        }

        /// <summary>
        /// 示例使用方法
        /// </summary>
        public static void ExampleUsage()
        {
            try
            {
                AddToWhitelist(@".\1.20.1\whitelist.json", "NewPlayer", "new-uuid-123");
                Console.WriteLine("添加成功");
            }
            catch (Error_list ex) when (ex.Length == 1)
            {
                Console.WriteLine($"操作失败: {ex.GetError()}");
            }
            catch (Error_list ex)
            {
                Console.WriteLine("发生多个错误:");
                for (int i = 0; i < ex.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {ex.GetError(i)}");
                }
            }
        }
    }
}