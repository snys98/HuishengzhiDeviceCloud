--��ѵģ��Ȩ�޴����
UPDATE dbo.Module SET InRight=REPLACE(InRight,'Trainig','Training')  WHERE MTCode='06'
GO

/*ȥ������ת�˶���ģ�� Start*/

DELETE FROM dbo.Module WHERE ModuleCode='2008' --���������
DELETE FROM dbo.Module WHERE ModuleCode='2009' --�걾���
DELETE FROM dbo.Module WHERE ModuleCode='2009' --�걾���
DELETE FROM dbo.Module WHERE ModuleCode='2001' --����ת��ת��
DELETE FROM dbo.Module WHERE ModuleCode='2002' --����ת�˽���
DELETE FROM dbo.Module WHERE ModuleCode='2003' --����ת�˲�ѯ
/*ȥ������ת�˶���ģ�� End*/
--��ת�������޸�Ϊ����(����)
UPDATE dbo.Module SET ModuelName='����(����)' WHERE ModuleCode='2007'
--ת���������� �޸�Ϊ 
UPDATE dbo.Module SET ModuelName='����ת��' WHERE ModuleCode='2004'
UPDATE dbo.Module SET ModuelName='�������' WHERE ModuleCode='2006'
--��������ת����ʾ˳��
UPDATE dbo.Module SET DispOrder=10 WHERE ModuleCode='2007' --����(����)
UPDATE dbo.Module SET DispOrder=20 WHERE ModuleCode='2004' --ת����������
UPDATE dbo.Module SET DispOrder=30 WHERE ModuleCode='2005' --����ת��
UPDATE dbo.Module SET DispOrder=40 WHERE ModuleCode='2010' --��������ѯ
UPDATE dbo.Module SET DispOrder=50 WHERE ModuleCode='2006' --��������ѯ
GO