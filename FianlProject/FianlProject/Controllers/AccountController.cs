﻿using FianlProject.DAL;
using FianlProject.Models;
using FianlProject.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Net.Mail;
using System.Net;
using System.Threading.Tasks;
using FianlProject.Services;

namespace FianlProject.Controllers
{
    public class AccountController : Controller
    {
		private readonly UserManager<AppUser> _userManager;
		private readonly SignInManager<AppUser> _signInManager;
		private readonly RoleManager<IdentityRole> _roleManager;
		private readonly AppDbContext _context;
		private readonly IHttpContextAccessor _http;


		public AccountController
			(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager, AppDbContext context, IHttpContextAccessor http)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_roleManager = roleManager;
			_context = context;
			_http = http;
		}

		public IActionResult Register()
        {
            return View();
        }

		[HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Register(RegisterVM register)
        {
            if (!ModelState.IsValid) return View();
            if (!register.Terms)
            {
                ModelState.AddModelError(string.Empty, "Please check the terms");
                return View();
            }
			AppUser user = new AppUser
			{
				FirstName = register.FirstName,
				LastName = register.LastName,
				UserName = register.UserName,
				Email = register.Email,
				Admin = false
            };

            IdentityResult result = await _userManager.CreateAsync(user, register.Password);

            if (!result.Succeeded)
            {
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View();
            }
			//await _userManager.AddToRoleAsync(user, "Admin");
			await _userManager.AddToRoleAsync(user, "Member");
			string token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
			string link = Url.Action(nameof(VerifyEmail), "Account", new { email = user.Email, token }, Request.Scheme, Request.Host.ToString());
			MailMessage mail = new MailMessage();
			mail.From = new MailAddress("kamrangab@code.edu.az", "Furniture");
			mail.To.Add(new MailAddress(user.Email));

			mail.Subject = "Verify Email";
			string body = string.Empty;
			using (StreamReader reader = new StreamReader("wwwroot/Assets/Template/verifyemail.html"))
			{
				body = reader.ReadToEnd();
			}
			string about = $"Welcome <strong>{user.FirstName + " " + user.LastName}</strong> to our company, please click the link in below to verify your account";

			body = body.Replace("{{link}}", link);
			mail.Body = body.Replace("{{About}}", about);
			mail.IsBodyHtml = true;

			SmtpClient smtp = new SmtpClient();
			smtp.Host = "smtp.gmail.com";
			smtp.Port = 587;
			smtp.EnableSsl = true;

			smtp.Credentials = new NetworkCredential("kamrangab@code.edu.az", "Samsungg1");
			smtp.Send(mail);
			TempData["Verify"] = true;
			return RedirectToAction("Index", "Home");
        }

		public IActionResult Login()
		{
			return View();
		}

		[HttpPost]
		[AutoValidateAntiforgeryToken]
		public async Task<IActionResult> Login(LoginVM login)
		{
			if (login.UserName==null)
			{
				ModelState.AddModelError(string.Empty, "Please choose username");
				return View();
			}

			AppUser user = await _userManager.FindByNameAsync(login.UserName);
			if (user == null)
			{
				ModelState.AddModelError("UserName", "Please choose username");
				return View();
			}
			Microsoft.AspNetCore.Identity.SignInResult result =
				await _signInManager.PasswordSignInAsync(user, login.Password, login.Remember, true);
			if (!result.Succeeded)
			{
				ModelState.AddModelError(string.Empty, "Verify not confirmed or password incorrect");
				if (result.IsLockedOut)
				{
					ModelState.AddModelError("Lock", "5 minutes block");
					return View();
				}
				return View();
			}
			TempData["name"] = "Successfully entered";
			return RedirectToAction("Index", "Home");

		}

		public async Task<IActionResult> Logout()
		{
			await _signInManager.SignOutAsync();
			return RedirectToAction("Index", "Home");
		}
		public JsonResult ShowAuthentication()
		{
			return Json(User.Identity.IsAuthenticated);
		}
		//public async Task CreateRoles()
		//{
		//	await _roleManager.CreateAsync(new IdentityRole("Member"));
		//	await _roleManager.CreateAsync(new IdentityRole("Moderator"));
		//	await _roleManager.CreateAsync(new IdentityRole("Admin"));
		//}



		public async Task<IActionResult> VerifyEmail(string email, string token)
		{
			AppUser user = await _userManager.FindByEmailAsync(email);
			if (user == null) return BadRequest();
			await _userManager.ConfirmEmailAsync(user, token);

			await _signInManager.SignInAsync(user, true);
			TempData["Verified"] = true;
			return RedirectToAction("Index", "Home");
		}

		public IActionResult ForgotPassword()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> ForgotPassword(AccountVM account)
		{
			AppUser user = await _userManager.FindByEmailAsync(account.AppUser.Email);
			if (user == null) return BadRequest();

			string token = await _userManager.GeneratePasswordResetTokenAsync(user);
			string link = Url.Action(nameof(ResetPassword), "Account", new { email = user.Email, token }, Request.Scheme, Request.Host.ToString());
			MailMessage mail = new MailMessage();
			mail.From = new MailAddress("kamrangab@code.edu.az", "Furniture");
			mail.To.Add(new MailAddress(user.Email));

			mail.Subject = "Reset Password";
			mail.Body = $"<a href='{link}'>Please click here to reset your password</a>";
			mail.IsBodyHtml = true;

			SmtpClient smtp = new SmtpClient();
			smtp.Host = "smtp.gmail.com";
			smtp.Port = 587;
			smtp.EnableSsl = true;

			smtp.Credentials = new NetworkCredential("kamrangab@code.edu.az", "Samsungg1");
			smtp.Send(mail);
			return RedirectToAction("index", "home");
		}

		public async Task<IActionResult> ResetPassword(string email, string token)
		{
			AppUser user = await _userManager.FindByEmailAsync(email);
			if (user == null) return BadRequest();
			AccountVM model = new AccountVM
			{
				AppUser = user,
				Token = token
			};
			return View(model);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> ResetPassword(AccountVM account)
		{
			AppUser user = await _userManager.FindByEmailAsync(account.AppUser.Email);
			AccountVM model = new AccountVM
			{
				AppUser = user,
				Token = account.Token
			};
			if (!ModelState.IsValid) return View(model);
			IdentityResult result = await _userManager.ResetPasswordAsync(user, account.Token, account.Password);
			if (!result.Succeeded)
			{
				foreach (IdentityError error in result.Errors)
				{
					ModelState.AddModelError("", error.Description);
				}
				return View(model);

			}
			await _signInManager.SignInAsync(user, true);
			return RedirectToAction("Index", "Home");
		}

		//[HttpGet]
		//public async Task<IActionResult> ForgetPassword()
		//{
		//	return View();
		//}

		//[HttpPost]
		//public async Task<IActionResult> ForgetPassword(ForgetPasswordVM forgotPassword)
		//{
		//	if (!ModelState.IsValid) return View(forgotPassword);
		//	var user = await _userManager.FindByEmailAsync(forgotPassword.Email);
		//	if (user is null)
		//	{
		//		ModelState.AddModelError("", "User with this Email Doesn't Exist!");
		//		return View(forgotPassword);
		//	}
		//	var code = await _userManager.GeneratePasswordResetTokenAsync(user);
		//	var link = Url.Action(nameof(ResetPassword), "Account", new { email = user.Email, token = code }, Request.Scheme, Request.Host.ToString());
		//	string html = $"{link}";
		//	string content = "Reset Password";
		//	await _emailService.SendEmailAsync(user, html, content);
		//	return RedirectToAction(nameof(RecoverPasswordView));
		//}

		//[HttpGet]
		//public IActionResult ResetPassword(string email, string token)
		//{
		//	var resetPasswordModel = new ResetPasswordVM { Email = email, Token = token };
		//	return View(resetPasswordModel);
		//}

		//[HttpPost]
		//[ValidateAntiForgeryToken]
		//public async Task<IActionResult> ResetPassword(ResetPasswordVM resetPasswordVM)
		//{
		//	if (!ModelState.IsValid) return View(resetPasswordVM);
		//	var user = await _userManager.FindByEmailAsync(resetPasswordVM.Email);
		//	IdentityResult result = await _userManager.ResetPasswordAsync(user, resetPasswordVM.Token, resetPasswordVM.Password);
		//	if (!result.Succeeded)
		//	{
		//		foreach (var item in result.Errors)
		//		{
		//			ModelState.AddModelError("", item.Description);
		//		}
		//		return View(resetPasswordVM);
		//	}
		//	return RedirectToAction(nameof(BeenReseted));

		//}

	}
}
