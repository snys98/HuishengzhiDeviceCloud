using DeviceCloud.Models.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DeviceCloud.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /Admin/User/
        public ActionResult Login([System.Web.Http.FromBody]SysUserModel user)
        {
            ViewBag.ErrorMessage = "";
            if (user != null && !string.IsNullOrEmpty(user.UserName))
            {
                Dapper.DynamicParameters p = new Dapper.DynamicParameters();
                p.Add("@UserName", user.UserName);
                p.Add("@Password", user.Password);
                var result = Db.Query<SysUserModel>("select * from SysAdmin where UserName=@UserName AND Password=@Password", p);
                if (result != null && result.Count() == 1)
                {
                    Session["sysadmin"] = result.First();
                    return RedirectToAction("Index", "Home", new { Area = "Admin" });
                }
                else
                {
                    ViewBag.ErrorMessage = "用户名或密码错误！";
                    return View(user);
                }
            }
            else
            {
                user = new SysUserModel();
                return View();
            }
        }
    }
}