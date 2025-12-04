# WinUI Calculator — Specification (Spec.md)

Version: 1.0  
Author: Roy  
Last Updated: 2025-12-XX  
Status: Approved

---

# 1. 使用者故事（User Stories）

## US-001 四則運算
As a 使用者，  
I want to 進行加減乘除計算，  
So that 我可以快速處理基本計算。

## US-002 進制轉換
As a 使用者，  
I want to 在十進位、二進位、八進位、十六進位之間互轉，  
So that 我可以處理不同進位系統的數字。

## US-003 溫度轉換
As a 使用者，  
I want to 在 C、F、K 之間轉換，  
So that 我可以快速計算不同溫標。

---

# 2. 驗收標準（AC）

## AC-001 基本四則運算
- 使用者輸入 1 + 2 = 時，必須顯示 3。
- 支援小數，如 1.5 + 1.2 = 2.7。
- 支援負數顯示。
- 除以零時必須顯示錯誤訊息「除數不可為 0」。

## AC-002 進制轉換
- 輸入 10（十進位）→ BIN = 1010。
- 輸入 255（十進位）→ HEX = FF。
- 支援小數轉換（小數部分最多 8 位）。
- 支援負數。

## AC-003 溫度轉換（正確公式）
- C → F = C × 9/5 + 32
- F → C = (F – 32) × 5/9
- C → K = C + 273.15
- K → C = K – 273.15
- 結果需格式化為小數點後 2 位。

---

# 3. 互動規格

## 3.1 數字鍵
- 點擊數字鍵時應在 DisplayText 加上相應字元。
- DisplayText 初值為 "0"，若輸入數字則覆蓋。

## 3.2 MessageText
- 在任何錯誤狀況下（格式錯誤、非法輸入），需顯示完整錯誤訊息。
- 當正常計算後，清除 MessageText。

## 3.3 清除鍵
- 清除 DisplayText、MessageText、狀態（firstNumber、secondNumber、operator）。

---

# 4. 非功能性需求（NFR）

## NFR-001 可測試性
- 所有計算邏輯必須可在無 UI 的情況下測試。

## NFR-002 可讀性
- ViewModel 必須保持纖細（Thin ViewModel 原則）。

## NFR-003 模組化
- 三類功能不得混在同一 Engine 內。

