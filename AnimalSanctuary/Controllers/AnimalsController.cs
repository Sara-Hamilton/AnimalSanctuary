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
    public class AnimalsController : Controller
    {

        private IAnimalRepository animalRepo;

        public AnimalsController(IAnimalRepository repo = null)
        {
            if(repo == null)
            {
                this.animalRepo = new EFAnimalRepository();
            }
            else
            {
                this.animalRepo = repo;
            }
        }

        public ViewResult Index()
        {
            return View(animalRepo.Animals.ToList());
        }

        public IActionResult Details(int id)
        {
            Animal thisAnimal = animalRepo.Animals.FirstOrDefault(x => x.AnimalId == id);
            return View(thisAnimal);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Animal animal)
        {
            animalRepo.Save(animal);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            Animal thisAnimal = animalRepo.Animals.FirstOrDefault(x => x.AnimalId == id);
            return View(thisAnimal);
        }

        [HttpPost]
        public IActionResult Edit(Animal animal)
        {
            animalRepo.Edit(animal);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            Animal thisAnimal = animalRepo.Animals.FirstOrDefault(x => x.AnimalId == id);
            animalRepo.Remove(thisAnimal);
            return RedirectToAction("Index");
        }
    }
}
