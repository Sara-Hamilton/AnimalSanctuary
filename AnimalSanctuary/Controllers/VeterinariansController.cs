using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using AnimalSanctuary.Models;
using Microsoft.EntityFrameworkCore;
using AnimalSanctuary.Models.Repositories;

namespace AnimalSanctuary.Controllers
{
    public class VeterinariansController : Controller
    {
        private IVeterinarianRepository veterinarianRepo;

        public VeterinariansController(IVeterinarianRepository repo = null)
        {
            if (repo == null)
            {
                this.veterinarianRepo = new EFVeterinarianRepository();
            }
            else
            {
                this.veterinarianRepo = repo;
            }
        }
        public ViewResult Index()
        {
            List<Veterinarian> model = veterinarianRepo.Veterinarians.ToList();
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Veterinarian veterinarian)
        {
            veterinarianRepo.Save(veterinarian);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var thisVeterinarian = veterinarianRepo.Veterinarians.FirstOrDefault(veterinarians => veterinarians.VeterinarianId == id);
            return View(thisVeterinarian);
        }

        public IActionResult Edit(int id)
        {
            var thisVeterinarian = veterinarianRepo.Veterinarians.FirstOrDefault(veterinarians => veterinarians.VeterinarianId == id);
            return View(thisVeterinarian);
        }

        [HttpPost]
        public IActionResult Edit(Veterinarian veterinarian)
        {
            veterinarianRepo.Edit(veterinarian);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var thisVeterinarian = veterinarianRepo.Veterinarians.FirstOrDefault(veterinarians => veterinarians.VeterinarianId == id);
            return View(thisVeterinarian);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisVeterinarian = veterinarianRepo.Veterinarians.FirstOrDefault(veterinarians => veterinarians.VeterinarianId == id);
            veterinarianRepo.Remove(thisVeterinarian);
            return RedirectToAction("Index");
        }
    }
}
