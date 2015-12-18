--培训模块权限错别字
UPDATE dbo.Module SET InRight=REPLACE(InRight,'Trainig','Training')  WHERE MTCode='06'
GO

/*去掉样本转运多余模块 Start*/

DELETE FROM dbo.Module WHERE ModuleCode='2008' --检验号生成
DELETE FROM dbo.Module WHERE ModuleCode='2009' --标本审核
DELETE FROM dbo.Module WHERE ModuleCode='2009' --标本审核
DELETE FROM dbo.Module WHERE ModuleCode='2001' --样本转运转出
DELETE FROM dbo.Module WHERE ModuleCode='2002' --样本转运接收
DELETE FROM dbo.Module WHERE ModuleCode='2003' --样本转运查询
/*去掉样本转运多余模块 End*/
--将转运申请修改为开单(外送)
UPDATE dbo.Module SET ModuelName='开单(外送)' WHERE ModuleCode='2007'
--转运条码生成 修改为 
UPDATE dbo.Module SET ModuelName='样本转出' WHERE ModuleCode='2004'
UPDATE dbo.Module SET ModuelName='样本监控' WHERE ModuleCode='2006'
--调整样本转运显示顺序
UPDATE dbo.Module SET DispOrder=10 WHERE ModuleCode='2007' --开单(外送)
UPDATE dbo.Module SET DispOrder=20 WHERE ModuleCode='2004' --转运条码生成
UPDATE dbo.Module SET DispOrder=30 WHERE ModuleCode='2005' --样本转入
UPDATE dbo.Module SET DispOrder=40 WHERE ModuleCode='2010' --检验结果查询
UPDATE dbo.Module SET DispOrder=50 WHERE ModuleCode='2006' --检验结果查询
GO