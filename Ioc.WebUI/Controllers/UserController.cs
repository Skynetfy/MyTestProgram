using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ioc.Serivce;
using Ioc.WebUI.Models;
using User = Ioc.Core.Data.User;
using UserProfile = Ioc.Core.Data.UserProfile;

namespace Ioc.WebUI.Controllers
{
    public class UserController : Controller
    {
        private IUserService userService;
        public UserController(IUserService service)
        {
            this.userService = service;
        }

        // GET: User 
        [HttpGet]
        public ActionResult Index()
        {
            using (var entity = new TestDBEntities1())
            {

                entity.User.Add(new Ioc.WebUI.Models.User { UserName = "ds", Email = "122@qq.com", Password = "ddd" });
                entity.SaveChanges();
                var q = entity.User;
                var f = entity.User.FirstOrDefault();
                var list = entity.User.ToList();

                var u = entity.User.Where(x => x.UserName == "ds").FirstOrDefault();
                u.ModifiedDate = DateTime.Now;
                entity.SaveChanges();

                var c = q.ToList();
            }
            try
            {
                IEnumerable<UserModel> users = userService.GetUsers().Select(u => new UserModel
                           {
                               FirstName = u.UserProfile.FirstName,
                               LastName = u.UserProfile.LastName,
                               Email = u.Email,
                               Address = u.UserProfile.Address,
                               ID = u.ID
                           });
            }
            catch (Exception ex)
            {
                throw;
            }

            return View();
        }
        [HttpGet]
        public ActionResult CreateEditUser(int? id)
        {
            UserModel model = new UserModel();
            if (id.HasValue && id != 0)
            {
                User userEntity = userService.GetUser(id.Value);
                model.FirstName = userEntity.UserProfile.FirstName;
                model.LastName = userEntity.UserProfile.LastName;
                model.Address = userEntity.UserProfile.Address;
                model.Email = userEntity.Email;
                model.UserName = userEntity.UserName;
                model.Password = userEntity.Password;
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult CreateEditUser(UserModel model)
        {
            if (model.ID == 0)
            {
                User userEntity = new User
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    Password = model.Password,
                    AddedDate = DateTime.UtcNow,
                    ModifiedDate = DateTime.UtcNow,
                    IP = Request.UserHostAddress,
                    UserProfile = new UserProfile
                    {
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Address = model.Address,
                        AddedDate = DateTime.UtcNow,
                        ModifiedDate = DateTime.UtcNow,
                        IP = Request.UserHostAddress
                    }
                };
                userService.InsertUser(userEntity);
                if (userEntity.ID > 0)
                {
                    return RedirectToAction("index");
                }
            }
            else
            {
                User userEntity = userService.GetUser(model.ID);
                userEntity.UserName = model.UserName;
                userEntity.Email = model.Email;
                userEntity.Password = model.Password;
                userEntity.ModifiedDate = DateTime.UtcNow;
                userEntity.IP = Request.UserHostAddress;
                userEntity.UserProfile.FirstName = model.FirstName;
                userEntity.UserProfile.LastName = model.LastName;
                userEntity.UserProfile.Address = model.Address;
                userEntity.UserProfile.ModifiedDate = DateTime.UtcNow;
                userEntity.UserProfile.IP = Request.UserHostAddress;
                userService.UpdateUser(userEntity);
                if (userEntity.ID > 0)
                {
                    return RedirectToAction("index");
                }

            }
            return View(model);
        }

        public ActionResult DetailUser(int? id)
        {
            UserModel model = new UserModel();
            if (id.HasValue && id != 0)
            {
                User userEntity = userService.GetUser(id.Value);
                // model.ID = userEntity.ID;
                model.FirstName = userEntity.UserProfile.FirstName;
                model.LastName = userEntity.UserProfile.LastName;
                model.Address = userEntity.UserProfile.Address;
                model.Email = userEntity.Email;
                model.AddedDate = userEntity.AddedDate;
                model.UserName = userEntity.UserName;
            }
            return View(model);
        }

        public ActionResult DeleteUser(int id)
        {
            UserModel model = new UserModel();
            if (id != 0)
            {
                User userEntity = userService.GetUser(id);
                model.FirstName = userEntity.UserProfile.FirstName;
                model.LastName = userEntity.UserProfile.LastName;
                model.Address = userEntity.UserProfile.Address;
                model.Email = userEntity.Email;
                model.AddedDate = userEntity.AddedDate;
                model.UserName = userEntity.UserName;
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult DeleteUser(int id, FormCollection collection)
        {
            try
            {
                if (id != 0)
                {
                    User userEntity = userService.GetUser(id);
                    userService.DeleteUser(userEntity);
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }
    }
}