# 計畫（Plan）：實作技術藍圖

目的：將 Spec 中的需求轉換為技術契約、介面與實作里程碑，作為開發與 AI 產出的藍圖。

## 架構概觀
- 採 MVVM 與 DI。專案新增 `Features/Calculator/` 目錄，包含 `Models`、`ViewModels`、`Views`。
- 計算邏輯封裝在 `ICalculatorEngine` 與其實作中（`StandardCalculatorEngine`、`ScientificCalculatorEngine`）。
- 計算回傳一統一型別 `CalculationResult`（Value, IsError, Message）以標準化錯誤處理。

## 介面契約（範例）
```
public interface ICalculatorEngine
{
    CalculationResult Calculate(double? operand1, double? operand2, string operation);
}

public record CalculationResult(double? Value, bool IsError, string? Message);
```

註：`operand2` 對於單元運算（如 sin）可為 null；`operation` 使用穩定標記（例如 "+", "sin"）。

## DI 與啟動
- 在 App 啟動時註冊 DI：
  - `builder.Services.AddSingleton<ICalculatorEngine, StandardCalculatorEngine>();`
  - 註冊 `CalculatorViewModel`（scope 或 singleton 視需求而定）。
- ViewModel 透過建構子注入 `ICalculatorEngine`。

## 錯誤策略
- 計算引擎對於預期的領域性錯誤（除零、定義域外）**不得拋例外**，應回傳 `CalculationResult(IsError=true, Message=...)`。
- ViewModel 根據 `CalculationResult` 設定 `DisplayText` 以供 UI 綁定。

## 測試策略
- 為 `StandardCalculatorEngine` 撰寫單元測試（加減乘除、除零）。
- 為 `ScientificCalculatorEngine` 撰寫代表性輸入的單元測試（sin/cos/log 等），使用容差驗證。
- 撰寫 ViewModel 測試（輸入序列、運算邏輯、錯誤映射）。
- 整合測試覆蓋常見流程（例如 12 + 34 = 46，10 / 0 -> 錯誤顯示）。

## 里程碑
- M1：定義 `ICalculatorEngine` 與失敗的單元測試（RED）。
- M2：實作 `StandardCalculatorEngine` 以通過基礎測試（GREEN）。
- M3：實作 `CalculatorViewModel` 並完成 DI 配置；通過 ViewModel 測試。
- M4：加入科學函數並補測試。
- M5：整合測試與 Audit，確認符合憲法要求。

## 開放問題（需在 Plan 鎖定前決定）
- 顯示格式採固定 8 位小數或動態格式？
- 決定 engine 回傳例外還是統一回傳 Result（建議使用 Result）。

## DoD（每個里程碑）
- 對應的單元測試通過（`dotnet test`）。
- 程式碼符合憲法（無 Code-Behind 邏輯、public API 有 XML 註解）。
- PR 包含測試、實作與若有的憲法豁免說明。
