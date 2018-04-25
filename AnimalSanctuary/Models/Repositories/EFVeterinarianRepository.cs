using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnimalSanctuary.Models.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AnimalSanctuary.Models
{
    public class EFVeterinarianRepository : IVeterinarianRepository
    {
        AnimalSanctuaryContext db = new AnimalSanctuaryContext();

        public IQueryable<Veterinarian> Veterinarians
        { get { return db.Veterinarians; } }

        public Veterinarian Save(Veterinarian veterinarian)
        {
            db.Veterinarians.Add(veterinarian);
            db.SaveChanges();
            return veterinarian;
        }

        public Veterinarian Edit(Veterinarian veterinarian)
        {
            db.Entry(veterinarian).State = EntityState.Modified;
            db.SaveChanges();
            return veterinarian;
        }

        public void Remove(Veterinarian veterinarian)
        {
            db.Veterinarians.Remove(veterinarian);
            db.SaveChanges();
        }
    }
}
