using LibraryApplication.BusinessLayer.Abstract;
using LibraryApplication.BusinessLayer.Concrete;
using LibraryApplication.Entities;
using LibraryApplication.Entities.Dtos;
using LibraryApplication.WebApp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApplication.WebApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserManager _userManager;

        public UserController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var list = _userManager.GetListCollection(nameof(Reservation) + "s");

            List<UserViewModel> userViewModels = new List<UserViewModel>();

            foreach (var item in list.Data)
            {
                userViewModels.Add(new UserViewModel()
                {
                    UserFullName = item.UserFullName,
                    Age = item.UserAge,
                    UserEMail = item.UserEMail
                });
            }
            return View(userViewModels);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(UserCrudViewModel userCrudViewModel)
        {
            if (DateTime.Now.Year - userCrudViewModel.UserBirthDate.Year < 12)
            {
                ModelState.AddModelError(string.Empty, "Sadece 13 Yaş Ve Üzeri Kullanıcı Oluşturulabilir.");
                return View(userCrudViewModel);
            }

            if (userCrudViewModel.UserIdentityNumber!=null)
            {
                var value = IdentityNumberValidation.IdentityNumberControl(userCrudViewModel.UserIdentityNumber);
                if (!value)
                {
                    ModelState.AddModelError(string.Empty, "Kayıt Edilmeye Çalışılan Türkiye Cumhuriyeti Kimlik Numarası Yanlış Formatta Girildi.");
                    return View(userCrudViewModel);
                }
            }
            if (ModelState.IsValid)
            {
                UserCrudDto userCrudDto = new UserCrudDto() { UserBirthDate = userCrudViewModel.UserBirthDate, UserIdentityNumber = userCrudViewModel.UserIdentityNumber, UserEMail = userCrudViewModel.UserEMail, UserTelephoneNumber = userCrudViewModel.UserTelephoneNumber, UserName = userCrudViewModel.UserName, UserSurname = userCrudViewModel.UserSurname };

                var serviceResult = _userManager.Insert(userCrudDto);

                if (!serviceResult.IsError)
                {
                    return RedirectToAction(nameof(Index));
                }

                foreach (string error in serviceResult.Errors)
                {
                    ModelState.AddModelError(string.Empty, error);
                }
            }
            return View(userCrudViewModel);
        }
    }
}
