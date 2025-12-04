# 任務清單（Tasks）：SDD + TDD 執行步驟

此清單將 Spec 與 Plan 切分為原子化的 TDD 任務（Red → Green → Refactor），便於與 AI/團隊逐步執行。

Phase 0：基礎建設
- Task 0.1 (RED)：建立測試專案 `WinUI_Calculator.Tests`（若尚未存在），新增測試以驗證 `ICalculatorEngine` 被註冊於 DI 中。
- Task 0.2 (GREEN)：在 App 啟動註冊 `ICalculatorEngine` 與 `CalculatorViewModel`。
- Task 0.3 (REFACTOR)：確保 DI 註冊遵守憲法（以介面註冊、加上必要 XML 註解）。

Phase 1：核心引擎
- Task 1.1 (RED)：建立 `ICalculatorEngine` 介面，並在 `StandardCalculatorEngineTests` 撰寫失敗測試（加/減/乘/除）。
- Task 1.2 (GREEN)：實作 `StandardCalculatorEngine`，達到基礎算術測試通過。
- Task 1.3 (REFACTOR)：若方法過長或複雜，拆分並加入 XML 註解。

- Task 1.4 (RED)：針對除以零撰寫測試，預期 `CalculationResult.IsError == true` 且 Message 為 "Cannot divide by zero"。
- Task 1.5 (GREEN)：更新引擎實作以回傳錯誤結果而非拋例外。
- Task 1.6 (REFACTOR)：抽出常數（避免魔術字串），並更新文件。

Phase 2：科學函數
- Task 2.1 (RED)：為 `sin`/`cos`/`tan`/`sqrt`/`log`/`pow` 撰寫單元測試（代表性數值與容差驗證）。
- Task 2.2 (GREEN)：實作科學函數或擴充現有引擎以通過測試。
- Task 2.3 (REFACTOR)：統一誤差容忍常數與顯示格式設定。

Phase 3：ViewModel 與整合
- Task 3.1 (RED)：撰寫 `CalculatorViewModelTests`（輸入序列、操作鍵、等於、錯誤顯示）。
- Task 3.2 (GREEN)：實作 `CalculatorViewModel` 並透過 DI 注入 `ICalculatorEngine`。
- Task 3.3 (REFACTOR)：確認 `INotifyPropertyChanged` 正確觸發，並補上 XML 註解。

Phase 4：稽核與釋出
- Task 4.1：加入整合測試覆蓋常見使用流程。
- Task 4.2：執行靜態分析與代碼掃描，確認符合 `Constitution` 規範。
- Task 4.3：產出 Audit 報告並關閉任務清單。

注意：
- 每個 RED 任務先撰寫失敗的測試並執行 `dotnet test` 確認為失敗。
- 每個 GREEN 任務實作最小通過測試的程式碼。
- 每個 REFACTOR 任務在不改變行為的前提下提升程式碼品質並保持測試通過。
