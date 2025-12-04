# WinUI Calculator – Tasks (SDD)

Version: 1.0  
Author: Roy  
Status: Active

---

# Phase 1 — 建立 Domain 與測試（必須先完成）

## Task 1.1 — 建立測試專案（RED）
- 建立 `WinUI_Calculator.Core.Tests`
- 新增 `CalculatorEngineTests.cs`
- 撰寫 Add/Sub/Mul/Div 測試（先失敗）

**DoD：測試執行並全部 → 失敗（紅燈）**

---

## Task 1.2 — 實作 StandardCalculatorEngine（GREEN）
- 實作 ICalculatorEngine
- 通過所有 Task 1.1 的測試

**DoD：所有四則測試綠燈**

---

## Task 1.3 — 重構並導入 ViewModel（REFACTOR）
- CalculatorViewModel 的四則邏輯移除，改呼叫 engine.Div/Add/etc.
- UI 不變，行為一致

**DoD：行為一致、測試仍綠燈**

---

# Phase 2 — 進制轉換

## Task 2.1 — 建立 BaseConversionEngine（RED）
- 撰寫測試：十進 → 二進、十進 → Hex、小數轉換等

## Task 2.2 — 實作 BaseConversionEngine（GREEN）

## Task 2.3 — 重構 BaseConversion 相關邏輯（REFACTOR）

---

# Phase 3 — 溫度轉換

## Task 3.1 — 建立 TemperatureEngine 測試（RED）
## Task 3.2 — 實作 TemperatureEngine（GREEN）
## Task 3.3 — 重構 Temperature VM（REFACTOR）

---

# Phase 4 — 移除 code-behind UI routing

## Task 4.1 — 加入 NavigationService
## Task 4.2 — MainWindow 移除 new View/VM
## Task 4.3 — 使用 DataTemplate 或 NavigationService 完成 routing

---

# Phase 5 — 稽核（Audit）

## Task 5.1 — 檢查憲法一致性
## Task 5.2 — 檢查 Spec 與 Plan 一致性
## Task 5.3 — 靜態分析（Cyclomatic Complexity ≤ 8）
## Task 5.4 — 文件回寫（Spec/Plan 更新）

---

