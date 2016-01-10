using System.Security.Policy;
using DeviceCloud.Models;

namespace DeviceCloud.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DeviceCloud.Models.SiteContentContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DeviceCloud.Models.SiteContentContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.News.AddOrUpdate(
              new News
              {
                  Content = @"���������һƪ����aklsdjflkasjd98������a�ʶ�A�������� a������as��a��ɭ �����忴as��������ad�ܾ���˹��������a�������߿�����������ɤ�",
                  CorverUrl = "http://images.cnitblog.com/blog/54161/201312/24173104-6234b1f78280498bb969b40c1c2dc48a.png",
                  CreateTime = DateTime.Now,
                  Introduction = @"��ʹ�� EF3 ֮ǰ�İ汾ʱ��ֻ����һ�� Code First Model ����������/�������ݿ�� Schema",
                  Title = "EF3"
              },
              new News {
                  Content = @"���ǵڶ�ƪ����:�������翵ŷ����ef����ɢ���������ﷴ����������ɣ����˭��ef�������˸���we����������A��ͺܿ�ɣ��aɳ���O�ô��޹�ˤ�������ǡ�",
                  CorverUrl = "http://images.cnitblog.com/blog/54161/201312/24173104-6234b1f78280498bb969b40c1c2dc48a.png",
                  CreateTime = DateTime.Now.AddDays(-1),
                  Introduction = @"��ʹ�� EF2 ֮ǰ�İ汾ʱ��ֻ����һ�� Code First Model ����������/�������ݿ�� Schema",
                  Title = "EF2"
              },
              new News {
                  Content = @"���ǵ�һƪ����:��A��ص�������˹���Ʒ���we�����ط�has��������a��������A���ܿ�we�Ǻ�ad�ܳ�a��������ɣ�O��as�ڵط�������a˫ɫ��ŷ������",
                  CorverUrl = "http://images.cnitblog.com/blog/54161/201312/24173104-6234b1f78280498bb969b40c1c2dc48a.png",
                  CreateTime = DateTime.Now.AddDays(-2),
                  Introduction = @"��ʹ�� EF1 ֮ǰ�İ汾ʱ��ֻ����һ�� Code First Model ����������/�������ݿ�� Schema",
                  Title = "EF1"
              }
            );

        }
    }
}
