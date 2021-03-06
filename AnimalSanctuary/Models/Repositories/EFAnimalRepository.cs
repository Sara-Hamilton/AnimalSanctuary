﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnimalSanctuary.Models.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AnimalSanctuary.Models
{
    public class EFAnimalRepository : IAnimalRepository
    {
        AnimalSanctuaryContext db;

        public EFAnimalRepository()
        {
            db = new AnimalSanctuaryContext();
        }

        public EFAnimalRepository(AnimalSanctuaryContext thisDb)
        {
            db = thisDb;
        }

        public IQueryable<Veterinarian> Veterinarians
        { get { return db.Veterinarians; } }

        public IQueryable<Animal> Animals
        { get { return db.Animals; } }

        public Animal Save(Animal animal)
        {
            db.Animals.Add(animal);
            db.SaveChanges();
            return animal;
        }

        public Animal Edit(Animal animal)
        {
            db.Entry(animal).State = EntityState.Modified;
            db.SaveChanges();
            return animal;
        }

        public void Remove(Animal animal)
        {
            db.Animals.Remove(animal);
            db.SaveChanges();
        }

        public void DeleteAll()
        {
            db.Animals.RemoveRange(db.Animals);
            db.SaveChanges();
        }

    }
}
