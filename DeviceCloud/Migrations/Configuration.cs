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
                  Content = @"这是最晚的一篇文章aklsdjflkasjd98场外孙a肥东A卡塞进很 a竞赛很as还a发森 撒海峰看as还看房看ad很精拉斯铃铛翻看a网诶上诉堪当翻看昂完成の",
                  CorverUrl = "http://images.cnitblog.com/blog/54161/201312/24173104-6234b1f78280498bb969b40c1c2dc48a.png",
                  CreateTime = DateTime.Now,
                  Introduction = @"当使用 EF3 之前的版本时，只会有一个 Code First Model 被用来生成/管理数据库的 Schema",
                  Title = "EF3"
              },
              new News {
                  Content = @"这是第二篇文章:发窘党风康欧茶王ef产哈散开房卡金宏达反哈抗跌反哈桑开放谁昂ef兰卡赛浪复仇we很兰卡塞很A类就很看桑达a沙三扥好戳无哈摔三党风是∞",
                  CorverUrl = "http://images.cnitblog.com/blog/54161/201312/24173104-6234b1f78280498bb969b40c1c2dc48a.png",
                  CreateTime = DateTime.Now.AddDays(-1),
                  Introduction = @"当使用 EF2 之前的版本时，只会有一个 Code First Model 被用来生成/管理数据库的 Schema",
                  Title = "EF2"
              },
              new News {
                  Content = @"这是第一篇文章:甲A风控当付出哈斯多云飞羽传we哈工地反has将订房看a龙当饭匡A栋很抗we是红ad很出a网诶神红茶桑扥是as岗地烦死掉就a双色很欧茶隼撒",
                  CorverUrl = "http://images.cnitblog.com/blog/54161/201312/24173104-6234b1f78280498bb969b40c1c2dc48a.png",
                  CreateTime = DateTime.Now.AddDays(-2),
                  Introduction = @"当使用 EF1 之前的版本时，只会有一个 Code First Model 被用来生成/管理数据库的 Schema",
                  Title = "EF1"
              }
            );

        }
    }
}
