using System.Security.Cryptography;
using System.Text;

namespace Minecraft离线UUID生成器
{
    internal static class GenerateUUID
    {
        /// <summary>
        /// 生成玩家的离线uuid
        /// </summary>
        /// <param name="username">玩家名称</param>
        /// <returns>此玩家的uuid</returns>
        public static string GenerateOfflineUUID(string username)
        {
            const string prefix = "OfflinePlayer:";
            string input = prefix + username;
            byte[] hash = MD5.HashData(Encoding.UTF8.GetBytes(input));

            // 调整字节顺序为大端序（特别注意第6-7字节需要交换位置）
            byte[] reordered =
            [
            hash[3],  // 第4字节 -> 第1字节
            hash[2],
            hash[1],
            hash[0],
            hash[5],  // 第6字节 -> 第5字节
            hash[4],
            hash[7],  // 注意：原始的第7字节放在第6位
            (byte)((hash[6] & 0x0F) | 0x30), // 原始的第6字节处理为版本号后放在第7位
            (byte)((hash[8] & 0x3F) | 0x80), // Variant RFC 4122
            hash[9],
            hash[10],
            hash[11],
            hash[12],
            hash[13],
            hash[14],
            hash[15],
        ];
            return new Guid(reordered).ToString();
        }
    }
}