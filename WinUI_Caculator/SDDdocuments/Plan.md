# WinUI Calculator — Technical Plan (Plan.md)

Version: 1.0  
Author: Roy  
Last Updated: 2025-12-XX  
Status: Draft → Awaiting Alignment

---

# 1. 架構總攬（Architecture Overview）

WinUI_Calculator (UI)
├── Views
├── ViewModels
│ ├── CalculatorViewModel (將逐步瘦身)
│ ├── BaseConversionViewModel (新)
│ └── TemperatureViewModel (新)
├── Domain
│ ├── ICalculatorEngine
│ ├── IBaseConversionEngine
│ ├── ITemperatureEngine
│ ├── StandardCalculatorEngine
│ ├── BaseConversionEngine
│ └── TemperatureEngine
└── Services
└── NavigationService (選用)

---

# 2. 模組設計（Module Design）

## 2.1 四則運算引擎

public interface ICalculatorEngine
{
float Add(float a, float b);
float Sub(float a, float b);
float Mul(float a, float b);
float Div(float a, float b);
}


## 2.2 進制轉換引擎

public interface IBaseConversionEngine
{
string ToBinary(double value);
string ToOctal(double value);
string ToDecimal(double value);
string ToHex(double value);
}

## 2.3 溫度轉換引擎

public interface ITemperatureEngine
{
double CelsiusToF(double c);
double FahrenheitToC(double f);
double CelsiusToK(double c);
double KelvinToC(double k);
}

---

# 3. UI Flow（View 與 ViewModel）

## 3.1 MainWindow
- 不再 new View 和 ViewModel。
- 改為「ViewModel 來決定模式」+ DataTemplate 或 NavigationService。

## 3.2 每個功能一個 ViewModel
- CalculatorViewModel：四則運算
- BaseConversionViewModel：進制轉換
- TemperatureViewModel：溫度轉換

ViewModel 只做：
- 接收 UI 指令
- 驅動 Domain Engine
- 更新 DisplayText與 MessageText

---

# 4. DI 設定

在 `App.xaml.cs`：

var builder = Host.CreateApplicationBuilder();
builder.Services.AddSingleton<ICalculatorEngine, StandardCalculatorEngine>();
builder.Services.AddSingleton<IBaseConversionEngine, BaseConversionEngine>();
builder.Services.AddSingleton<ITemperatureEngine, TemperatureEngine>();

builder.Services.AddTransient<CalculatorViewModel>();
builder.Services.AddTransient<BaseConversionViewModel>();
builder.Services.AddTransient<TemperatureViewModel>();

_services = builder.Build();


---

# 5. 遷移計畫（Migration Plan）

## Phase 1
- 新增 Domain Engines + Tests
- 修改 ViewModel 改呼叫 Engine

## Phase 2
- 拆分 ViewModel（三個 VM）

## Phase 3
- 引入 NavigationService 並移除 code-behind routing

---

# 6. 一致性審查（Consistency Checklist）

| 條目 | 狀態 |
|------|------|
| Spec 與 Plan 模型一致 | ☐ |
| ViewModel 不含業務邏輯 | ☐ |
| Engine 100% 可測試 | ☐ |
| DI 全部導入 | ☐ |
| Code-behind 無邏輯 | ☐ |