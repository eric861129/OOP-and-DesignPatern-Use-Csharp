# SOLID 與最小知識原則

以下內容整理自使用者提供的筆記並搭配範例程式碼，說明 SOLID 五大原則以及額外一條最小知識原則（Law of Demeter）。
範例皆以 C# 撰寫並附上繁體中文註解，便於閱讀理解。

SOLID 五大原則共六條，就像四大天王其實有五位一樣，分別是：

1. **S - 單一職責原則** (Single Responsibility Principle, SRP)
2. **O - 開放封閉原則** (Open-Closed Principle, OCP)
3. **L - 里氏替換原則** (Liskov Substitution Principle, LSP)
4. **I - 介面隔離原則** (Interface Segregation Principle, ISP)
5. **D - 依賴反轉原則** (Dependency Inversion Principle, DIP)
6. **迪米特法則 / 最小知識原則** (Law of Demeter / Least Knowledge Principle, LKP)

---

## S－單一職責原則 (SRP)

一個類別應只有一個引起它變化的原因，也就是只負責一件事。遵守 SRP 可以讓程式碼更容易維護與測試。

簡單範例如 `SRPExample.cs`：新增訂單時將「處理訂單邏輯」、「寫入資料庫」與「通知客戶」拆成三個類別，各自負責自己的職責，呼叫端只需關心流程本身。

當未遵守 SRP 時容易造成程式碼重複、邊界不清、維護困難；遵守後能提高重複使用度並降低耦合，修改目標也更明確。撰寫程式時應清楚地展示意圖，保持類別職責單一。

## O－開放封閉原則 (OCP)

軟體實體應對擴展開放、對修改封閉。也就是說，面對新需求應以增加程式碼（擴展）而非修改既有程式碼來完成。

在 `OCPExample.cs` 中，我們以 `IShape` 介面抽象形狀，`AreaService` 只依賴此介面。未來新增形狀只需實作 `IShape` 即可，計算邏輯毋須改動。

撰寫程式時可先區分主要與附加邏輯，並預留擴充點。配合介面與依賴注入，便能在外部自由擴展功能而不必改動既有模組。設計擴充點時也要注意避免過度設計，等確定需求會變化時再進行重構即可。

## L－里氏替換原則 (LSP)

子類別必須能完全替換父類別且不造成錯誤。好的擴展方式應遵守三項準則：

1. **先驗條件不可強化**：子類別接受的輸入不應比父類別要求更多。
2. **後驗條件不可弱化**：子類別回傳的結果不得少於父類別的保證。
3. **不變條件必須維持**：子類別的行為需符合父類別預期。

`LSPExample.cs` 先定義 `Bird` 基底類別，再以 `IFlyable` 介面提供飛行能力，避免出現「企鵝繼承鳥類卻不能飛」的矛盾情況。

## I－介面隔離原則 (ISP)

介面應精簡、專注於單一職責，不該強迫使用者實作不需要的方法。透過多個小介面搭配組合的方式，類別只實作自身需要的功能。

`ISPExample.cs` 中將跑步、飛行、游泳分成三個介面，企鵝僅實作跑步與游泳，避免出現空實作。設計資料庫存取介面時也能依據 CRUD 需求拆分介面，只繼承實際會用到的部分。

## D－依賴反轉原則 (DIP)

高階模組與低階模組皆應依賴抽象，不直接依賴彼此。常配合依賴注入實作，以降低耦合並提升彈性。

`DIPExample.cs` 展示利用建構式注入 `IPrinter`，`ReportService` 只依賴列印介面，不需知道實際列印細節。依賴注入常見形式有建構式注入、方法注入與屬性注入，其中建構式注入最常用且符合封裝精神。

## 迪米特法則 / 最小知識原則 (LKP)

物件應盡量只與直接的朋友物件溝通，不與陌生物件對話，以降低耦合度並維持封裝。方法內應只操作自身、參數、內部建立或直接依賴的物件。

`LKPExample.cs` 的 `MessageController` 僅與 `MessageService` 互動，不會直接操作 `MessageProvider`，透過中介服務來減少耦合。

---

每個範例程式皆位於本資料夾，可搭配閱讀以了解實際實作方式：

- [`SRPExample.cs`](SRPExample.cs)
- [`OCPExample.cs`](OCPExample.cs)
- [`LSPExample.cs`](LSPExample.cs)
- [`ISPExample.cs`](ISPExample.cs)
- [`DIPExample.cs`](DIPExample.cs)
- [`LKPExample.cs`](LKPExample.cs)

