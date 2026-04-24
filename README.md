# *EquipmentAPI*

## 專案簡介 :
基於ASP.NET Core Web API開發的輕量設備管理系統。專案以RESTful架構實作完整的CRUD操作，使用LINQ方法語法進行高效的資料查詢，以及DTO模式來分離資料模型與傳輸格式。

## 專案技術 :
- Language : C#
- Framework : .NET 10
- Database : Entity Framework Core (In-Memory Database)
- API Style : RESTful
- Design Pattern : DTO
- API Documentation : Swagger (OpenAPI)

## 核心功能 :
- Equipment CRUD : 完整的設備新增、查詢、修改與刪除功能。
- In-Memory Storage: 無需安裝資料庫，執行即可啟動，適合快速測試。
- DTO 隔離: 確保資料庫模型 (Entity) 與 API 回傳模型 (DTO) 職責分離，提升安全性與彈性。
- Swagger UI: 整合可視化文件，方便開發者直接進行接口測試。
