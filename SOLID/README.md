# SOLID 與最小知識原則

以下內容整理自使用者提供的筆記，搭配範例程式碼說明 SOLID 五大原則以及 1 條額外的最小知識原則（Law of Demeter）。各範例皆以 C# 撰寫並附上繁體中文註解，便於閱讀理解。

SOLID 五大原則共 6 條，就像四大天王都會有五位一樣，分別是：

1. **S - 單一職責原則** (Single Responsibility Principle, SRP)
2. **O - 開放封閉原則** (Open-Closed Principle, OCP)
3. **L - 里氏替換原則** (Liskov Substitution Principle, LSP)
4. **I - 介面隔離原則** (Interface Segregation Principle, ISP)
5. **D - 依賴反轉原則** (Dependency Inversion Principle, DIP)
6. **迪米特法則/最小知識原則** (Law of Demeter / Least Knowledge Principle, LKP)

---

## S－單一職責原則 (SRP)

「單一職責」指的是一個類別只負責一件事，也就是只有一個引起它變化的原因。遵守此原則能使程式碼更容易維護及擴充。

簡單範例如 `SRPExample.cs`：將處理訂單、資料庫存取與通知客戶各自拆成不同類別，彼此不互相干擾。

- 不遵守時會導致重複、邊界不清、修改困難。
- 遵守後能提升重複使用、降低耦合，修改目標也更清楚。

## O－開放封閉原則 (OCP)

軟體實體應對擴展開放、對修改封閉。也就是透過新增程式碼來擴充功能，而非修改既有程式碼。

在 `OCPExample.cs` 中定義 `IShape` 介面，任何新形狀只要實作此介面即可被面積計算器支援，而不需修改既有邏輯。

## L－里氏替換原則 (LSP)

子類別必須能夠完全替換父類別，不會造成錯誤或異常。好的擴展方式不應要求比父類別更多，回饋也不應少於父類別。

`LSPExample.cs` 將鳥類抽象成 `Bird`，若需要飛行能力則透過 `IFlyable` 介面實現，避免「企鵝繼承鳥類卻不能飛」的問題。

## I－介面隔離原則 (ISP)

介面不應強迫實作方依賴未使用的方法，應保持精簡並符合單一職責。

在 `ISPExample.cs` 中將跑步、飛行、游泳拆成獨立介面，企鵝只實作自己需要的跑步與游泳能力，避免出現空實作。

## D－依賴反轉原則 (DIP)

高階模組與低階模組都應依賴抽象，不直接相互依賴。建議使用依賴注入讓高階模組不需關心具體實作。

`DIPExample.cs` 透過建構式注入 `IPrinter`，高階的 `ReportService` 僅依賴介面，具體列印行為由外部決定。

## 迪米特法則 / 最小知識原則 (LKP)

物件應盡可能只與直接的朋友物件溝通，減少對其他物件的了解，降低耦合度。

`LKPExample.cs` 的 `MessageController` 僅與 `MessageService` 互動，不會直接操作 `MessageProvider`，符合只與熟識物件溝通的作法。

---

每個範例程式都放在本資料夾中，歡迎參考檔案以了解實際實作方式：

- [`SRPExample.cs`](SRPExample.cs)
- [`OCPExample.cs`](OCPExample.cs)
- [`LSPExample.cs`](LSPExample.cs)
- [`ISPExample.cs`](ISPExample.cs)
- [`DIPExample.cs`](DIPExample.cs)
- [`LKPExample.cs`](LKPExample.cs)

