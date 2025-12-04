# WinUI-Calculator專案導覽20251204

# 📘 WinUI Calculator

一個使用 **WinUI 3**（Windows App SDK）開發的現代化計算器應用程式。此專案主要用於練習 WinUI、MVVM 架構與 C# UI 開發技巧。

---

## 🚀 功能特色

- 基本四則運算：加、減、乘、除
- 乾淨直覺的 WinUI 介面
- 採用 MVVM 架構：
    - **View**：XAML UI
    - **ViewModel**：處理按鈕事件、管理運算邏輯
    - 更容易維護與擴充功能

---

## 📂 專案結構

```
WinUI_Calculator/
├─ Views/                 # XAML UI 介面
├─ ViewModels/            # 處理按鈕操作與資料邏輯
├─ Assets/                # 圖片、圖示資源
├─ App.xaml               # 應用程式設定
└─ MainWindow.xaml        # 主視窗

```

---

## 🛠️ 開發環境

- **Visual Studio 2022**（17.x 以上）
- **.NET 8 或 .NET 7**（依你的專案設定）
- **Windows App SDK / WinUI 3**
- 支援建置平台：x86 / x64 / ARM64（見 .sln 設定）

---

## ▶️ 如何執行

1. Clone 專案：

```bash
git clone https://github.com/hsbroy/WinUI_Calculator.git

```

1. 使用 Visual Studio 開啟：
    
    `WinUI_Calculator.sln`
    
2. 選擇建置模式：
    - Debug / Release
    - x64 / x86 / ARM64
3. 執行（Ctrl + F5）

---

## 📦 未來可加入功能

（可以依你的學習目標調整）

- 加入「歷史紀錄」功能
- 支援科學計算模式
- UI 深色模式
- 按鈕動畫或 Fluent Design 風格
- 單元測試（Unit Test）

---

## 🧑‍💻 作者

R oy — C# / WinUI 學習與練習專案