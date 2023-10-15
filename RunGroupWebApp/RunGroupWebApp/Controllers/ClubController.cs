﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RunGroupWebApp.Data;
using RunGroupWebApp.Interfaces;
using RunGroupWebApp.Models;

namespace RunGroupWebApp.Controllers
{
    public class ClubController : Controller
    {
        private readonly IClubRepository _clubRepository;

        public ClubController(
            ApplicationDBContext context,
            IClubRepository clubRepository)
        {
            this._clubRepository = clubRepository;
        }

        public async Task<IActionResult> Index()
        {
            var clubs = await _clubRepository.GetAll();
            return View(clubs);
        }

		//[HttpGet]
        public async Task<IActionResult> Detail(int id)
		{
            Club club = await _clubRepository.GetClubByIdAsync(id);
            return View(club);
		}
    }
}
