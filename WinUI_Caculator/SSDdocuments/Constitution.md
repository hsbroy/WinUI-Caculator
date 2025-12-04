# WinUI Calculator – Project Constitution
SDD Project Constitution v1.0  
Author: Roy  
Last Updated: 2025-01-XX  
Status: Active

---

# 1. 專案使命（Mission）
建立一套 WinUI 3 計算器應用，提供：
- 四則運算
- 進制轉換
- 溫度轉換

並以 SDD（Specification-Driven Development）進行開發，確保：
- 高可維護性
- 良好模組化
- 可測試的 Domain Logic
- UI 與邏輯分離
- 一致性高品質

---

# 2. 架構總原則（Architecture Principles）

## 2.1 分層架構
專案必須遵循下列分層：

UI (Views)
→ ViewModel (Thin)
→ Domain / Engines (Pure Logic)
→ Services / Utilities


## 2.2 MVVM 原則
- View 不得包含商業邏輯。
- ViewModel 不得包含計算實作（不得寫 Calculate、ConvertBase 等邏輯）。
- 所有邏輯必須放在 Engine / Domain 層。

---

# 3. Code-Behind 原則（非常重要）
- Code-behind 僅允許：
  - UI 初始化
  - NavigationService 呼叫
  - Minimal glue code（不得含商業邏輯）
- Code-behind 禁止：
  - new ViewModel
  - 操作核心邏輯
  - 資料轉換
  - 控制狀態流程

---

# 4. 品質標準（Quality Standards）

## 4.1 命名規範
- 類別：PascalCase
- 方法：PascalCase
- 變數：camelCase
- 常數：UPPER_CASE
-禁止英文錯字（例如 WinUI_Caculator 必須修正為 WinUI_Calculator）

## 4.2 函式長度原則
- 一個方法不得超過 25 行。
- 循環複雜度不得超過 8。

## 4.3 禁止 Magic Number
- 所有數字常數必須抽出為 const 或 static readonly。
- UI 尺寸除外。

## 4.4 Null Safety
- 所有 public 方法需要明確異常處理或回傳 safe value。

---

# 5. 測試規範（Testing Rules）

## 5.1 必須採 TDD
每個功能必須遵循  
**RED → GREEN → REFACTOR**

## 5.2 ViewModel 不得寫不可測試的邏輯  
所有 Domain Engine 必須 100% 可測試。

## 5.3 測試覆蓋率目標
- Domain Layer：90%+
- ViewModel Layer：70%+
- UI Layer：人工驗證

---

# 6. DI（Dependency Injection）原則
- App 啟動時必須使用 HostBuilder 建立 DI Container。
- 所有 ViewModel、Engine、Service 必須透過 DI 注入。
- 禁止 new Engine() 出現在 ViewModel 中。

---

# 7. 專案最終目標（Final State Goal）
- 三種功能（Arithmetic / BaseConversion / Temperature）均獨立分層。
- UI 不依賴邏輯。
- Domain Engine 完全獨立、可測試。
- MainWindow 不含業務邏輯、無 ViewModel new。
- 開發流程全部遵循 SDD。
