專案名稱 : EquipmentAPI

專案簡介 : 基於ASP.NET Core Web API開發的輕量設備管理系統。專案中展示了如何實作完整的 CRUD 操作，並結合 DTO（Data Transfer Object） 模式進行資料封裝，適合用於學習或作為微服務的基礎腳手架。

專案技術 :

Language : C#

Framework : .NET 10

API Style : RESTful 架構

Data Query : LINQ

Database : Entity Framework Core (In-Memory Database)

API Documentation : Swagger (OpenAPI)

Design Pattern : DTO (Data Transfer Object) 模式



核心功能

Equipment CRUD: 完整的設備新增、查詢、修改與刪除功能。

In-Memory Storage: 無需安裝資料庫，執行即可啟動，適合快速測試與 Demo。

DTO 隔離: 確保資料庫模型 (Entity) 與 API 回傳模型 (DTO) 職責分離，提升安全性與彈性。

Swagger UI: 整合可視化文件，方便開發者直接進行接口測試。
