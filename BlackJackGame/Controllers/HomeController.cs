﻿using BlackJackGame.Models;
using Microsoft.AspNetCore.Mvc;
using SnakeEyesGame.Models.Extensions;

namespace BlackJackGame.Controllers
{
    public class HomeController : Controller
    {
        private BlackJack _blackJack;
        public IActionResult Index()
        {
            _blackJack = new BlackJack();
            HttpContext.Session.SetObject("BlackJack", _blackJack);
            return View(_blackJack);
        }

        public IActionResult NextCard()
        {
            _blackJack = HttpContext.Session.GetObject<BlackJack>("BlackJack");
            _blackJack.GivePlayerAnotherCard();
            HttpContext.Session.SetObject("BlackJack", _blackJack);
            return View(nameof(Index), _blackJack);
        }
        public IActionResult Pass()
        {
            _blackJack = HttpContext.Session.GetObject<BlackJack>("BlackJack");
            _blackJack.PassToDealer();
            HttpContext.Session.SetObject("BlackJack", _blackJack);
            return View(nameof(Index), _blackJack);
        }
    }
}