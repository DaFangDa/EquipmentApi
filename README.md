# *EquipmentAPI*

## 專案簡介 :
基於ASP.NET Core Web API開發的輕量設備資料管理系統。專案以RESTful架構實作完整的CRUD操作，使用LINQ方法語法進行高效的資料查詢，以及DTO物件來分離資料模型與傳輸格式。

## 專案技術 :
- Language : C#
- Framework : .NET 10
- Database : Entity Framework Core (In-Memory Database)
- API Style : RESTful
- Design Pattern : DTO
- API Documentation : Swagger (OpenAPI)

## 專案核心 :
- 設備資料管理 : 完整的資料新增、查詢、修改以及刪除功能。
- 記憶體資料庫 : 無需安裝實體資料庫，執行即可快速測試(已先寫入一筆範例種子資料)。
- DTO封裝分離 : 為了提升安全、效能以及維護性，針對資料的回傳、新增以及修改分成了三種DTO物件。
- 全域例外處理 :
- Swagger介面 : 整合可視化文件，方便開發者直接進行接口測試。
