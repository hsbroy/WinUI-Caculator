# 專案憲法（Constitution） — SDD 基線

目的：此文件為專案最高開發規範，定義架構原則、品質閘門與 AI 協作限制。所有設計、實作與變更需遵守本憲法，若需例外必須在 `Plan.md` 提出並獲團隊核准。

## 1. 架構與責任分界
- 採用 MVVM：View 僅負責 UI 顯示與綁定；ViewModel 管理狀態和行為；Model 負責純演算法或資料處理。
- 嚴禁在 `*.xaml.cs`（Code-Behind）撰寫業務邏輯或演算法；僅允許最小的 UI 初始化程式碼。
- 外部相依需以介面注入（DI）；禁止在類別內直接 `new` 建立服務實例（例外需在 Plan 說明）。

## 2. 品質閘門（Quality Gates）
- 所有 public API 必須具備 XML 註解（summary、param、returns）。
- 單一方法行數上限 50 行；超過則需拆分或提出理由。
- 單元測試：關鍵模組（ViewModel、Model 演算法）目標覆蓋率 >= 80%（以模組重要性分級）。
- Cyclomatic Complexity 建議 < 10；違規時需重構或拆分。

## 3. 禁止清單（Negative Constraints）
- 禁止魔術數字/字串：請以 `const`、`readonly` 或 `enum` 命名常數。
- 禁止使用全域可變 `static` 狀態保存應用資料（以 DI 管理之 Singleton 例外）。
- 禁止未經審核新增第三方套件；新增相依須在 Plan 提案並取得批准。

## 4. 技術棧限定
- C# 10 / .NET 8
- WinUI 3（Windows App SDK）
- CommunityToolkit.Mvvm
- 測試框架：MSTest 或 xUnit（遵循專案既有慣例）

## 5. AI 與 SDD 使用規範
- 規格（Spec）、計畫（Plan）與憲法為開發基準，AI 產出程式碼前必須先檢查與這三份文件的一致性。
- 每次憲法變更需記錄 ChangeLog（版本、變更內容、理由），並在 AI 對話中重新載入最新版本以避免模型偏差。

## 6. 變更 / 豁免流程
- 若實作需要違反憲法，應在 `Plan.md` 提出豁免申請（含風險、替代方案與測試計畫），並取得團隊核可後方可執行。

---

ChangeLog:
- v1.0 - 建立 SDD-aligned 基線憲法。
