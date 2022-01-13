﻿using FiorelloDataFromDb.DAL;
using FiorelloDataFromDb.Extensions;
using FiorelloDataFromDb.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FiorelloDataFromDb.Areas.FiorelloManager.Controllers
{
    [Area("FiorelloManager")]
    public class SliderController : Controller
    {
        private readonly AppDbContext _context;
        private  IWebHostEnvironment _env;
        public SliderController(AppDbContext context,IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            List<Slider> model = _context.Sliders.ToList();
            return View(model);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Slider slider)
        {
            if (!ModelState.IsValid)
                return View();

            if (slider.ImageFile == null)
            {
                ModelState.AddModelError("ImageFile", "You can input only image");
                return View();
            }
            //extensiondan evvelki variant
            //if (slider.ImageFile.Length / Math.Pow(2,20)>=2)
                if (slider.ImageFile.CheckSize(2))
                {
                ModelState.AddModelError("ImageFile", "Image size max can be 2 mb");
                return View();
              }
            //if (!slider.ImageFile.ContentType.Contains("image/"))
            if (!slider.ImageFile.IsImage())
            {
                ModelState.AddModelError("ImageFile", "Please choose image file");
                return View();
            }

            //extensiondan evvelki variant

            //string rootPath = @"C:\Users\RufetPC\source\repos\FiorelloDataFromDb\FiorelloDataFromDb\wwwroot\assets\images\";
            ////file name i tekrarlana biler,buna gore yaziriq Guidi
            //string filename = Guid.NewGuid().ToString() + slider.ImageFile.FileName;
            //string fullpath = Path.Combine(rootPath, filename);
            //using(FileStream fileStream=new FileStream(fullpath, FileMode.Create))
            //{
            //    slider.ImageFile.CopyTo(fileStream);
            //}
            //slider.Image = filename;
            slider.Image = slider.ImageFile.SaveImg(_env.WebRootPath,"assets/images");
            _context.Sliders.Add(slider);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
