# Minecraft离线UUID生成器

一个用于生成Minecraft离线模式玩家UUID并管理服务器白名单的Windows专用工具。

> **平台声明**: 本项目(boyuan5629/Minecraft离线UUID生成器) **永远不会** 支持除Windows以外的任何操作系统。对于跨平台需求，请关注 BMST(boyuan5629's Minecraft Server-side Toolset)项目（尚未公开，目前处于早期开发阶段）。

## 功能特性

- 🎮 生成符合Minecraft离线模式标准的UUID
- 📁 自动扫描服务器目录中的白名单文件
- ✏️ 一键将玩家添加到多个服务器的白名单
- 🖥️ 支持GUI和命令行两种操作模式
- 📊 详细的错误日志记录和导出功能
- 📦 完全独立可执行，无需额外依赖
- 🪟 **Windows专属** - 针对Windows系统优化

## 系统要求

- **Windows 7** 或更高版本以及对应的Server版本
- 无需安装.NET运行时
- **不支持** macOS、Linux或其他操作系统

## 安装方法

1. 从[发布页面](https://github.com/boyuan5629/boyuan5629-s-Minecraft-offline-UUID-generator/releases/tag/minecraft-server)找到你需要的版本的ZIP文件
2. 解压到任意目录即可使用
3. 无需安装任何依赖，直接运行 `Minecraft离线UUID生成器.exe`
4. 如需快捷方式，请右键程序文件选择"创建快捷方式"

## 使用方法

### GUI模式（默认）

1. 运行程序
2. 在"Player name"输入框中输入玩家名称
3. 点击"生成"按钮生成UUID
4. 从服务器列表中选择要添加玩家的服务器
5. 点击"导出"按钮将玩家添加到选中的服务器白名单中

### 命令行模式

```bash
# 基本用法
Minecraft离线UUID生成器.exe -nogui -playername "Steve"

# 指定搜索路径
Minecraft离线UUID生成器.exe -seekfolder "C:\Servers" -nogui -playername "Alex"

# 显示帮助信息
Minecraft离线UUID生成器.exe -help
```

### 命令行参数

| 参数 | 说明 | 示例 |
|------|------|------|
| `-seek` 或 `-seekfolder` | 设置服务器目录搜索路径 | `-seek "C:\Servers"` |
| `-nogui` | 启用命令行模式 | `-nogui` |
| `-name` 或 `-playername` | 指定玩家名称 | `-name "Steve"` |
| `-help`, `/?`, `/help` | 显示帮助信息 | `-help` |

## 项目结构

```
Minecraft离线UUID生成器/
├── Minecraft离线UUID生成器.exe    # 主程序（独立可执行文件）
├── Log/                          # 日志目录（自动创建）
└── 配置文件、依赖项...
```

## 技术特点

- 使用MD5哈希算法生成符合标准的UUID（已使用Paper服务端生成的whitelist进行校对）
- 支持递归搜索服务器目录结构
- 完整的JSON序列化/反序列化处理
- 多线程安全的UI更新机制
- 详细的错误代码和描述系统
- 完全独立打包，无需外部依赖
- **专为Windows系统优化**

## 平台政策

本项目明确声明：

1. **仅支持Windows操作系统**
2. **永远不会** 支持macOS、Linux或其他平台
3. 所有功能开发和优化都**仅针对Windows环境**
4. 跨平台用户请使用 BMST（暂未公开）

## 错误代码说明

程序使用数字错误代码系统，主要错误类别：

- `0-9`: 系统级错误
- `10-19`: 文件操作错误
- `20-29`: 玩家数据错误
- `30-39`: JSON处理错误
- `40-49`: 目录操作错误
- `90`: 多重错误标识

## 常见问题

**Q: 为什么生成的UUID与在线工具不同？**
A: 本工具使用Minecraft官方离线模式算法，确保与游戏服务器兼容。

**Q: 如何添加自定义服务器路径？**
A: 使用`-seekfolder`参数。

**Q: 需要安装.NET吗？**
A: 不需要，本程序已打包为独立可执行文件，包含所有必要运行组件。

**Q: 支持Linux或macOS吗？**
A: **不支持**。本项目仅支持Windows系统。

**Q: 为什么选择仅支持Windows？**
A: 这是项目作者的明确技术决策，旨在为Windows用户提供最优化的体验。

**Q: 为什么会做这个项目？**
A: 作者发现Forge服务端将`online-mode`设为`false`时，使用`whitelist add 玩家名`的方式添加玩家到whitelist，如果此玩家是正版玩家仍会使用其正版uuid，导致正版玩家无法进入离线模式服务器。

## 许可证

本项目采用MIT许可证。

## 支持

如有问题请提交GitHub Issue或联系开发者。请注意，所有功能请求和问题报告都**仅针对Windows平台**。

---

*由boyuan5629开发 - 专注于Windows平台的Minecraft工具开发*