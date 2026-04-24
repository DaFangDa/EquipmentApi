# *EquipmentAPI*

## 專案簡介 :
基於ASP.NET Core Web API開發的輕量設備資料管理系統。專案以RESTful架構實作完整的CRUD操作，使用LINQ語法進行高效的資料查詢，並結合DTO物件以及例外處理機制來提升資料庫的安全性。

## 專案技術 :
- Language : C#
- Framework : .NET 10
- Database : Entity Framework Core (In-Memory Database)
- API Style : RESTful
- Design Pattern : DTO
- API Documentation : Swagger (OpenAPI)

## 專案核心 :
- 設備資料管理 : 透過LINQ方法語法進行資料的篩選與投影，實作完整的資料新增、查詢、更新以及刪除功能。
- DTO封裝分離 : 為了提升安全、效能以及維護性，針對資料的回傳、新增以及更新，區分成三種用途的DTO物件。
- 雙層例外處理 : 除了針對業務邏輯捕捉預期錯誤之外，也針對非預期異常實作全域例外處理。
- 記憶體資料庫 : 無需安裝實體資料庫，執行即可快速測試(已先寫入一筆種子資料)。
- Swagger介面 :
<img width="1451" height="703" alt="螢幕擷取畫面 2026-04-24 223202" src="https://github.com/user-attachments/assets/65eeae76-c28f-4c0e-907d-828f24f4b191" />

## 快速開始 :
1.
