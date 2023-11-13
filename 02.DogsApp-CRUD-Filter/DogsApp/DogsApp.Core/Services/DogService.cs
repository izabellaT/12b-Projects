using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using DogsApp.Core.Contracts;
using DogsApp.Infrastructure.Data;
using DogsApp.Infrastructure.Data.Domain;

namespace DogsApp.Core.Services
{
    public class DogService : IDogService
    {
        private readonly ApplicationDbContext _context;

        public DogService(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Create(string name, int age, string breed, string? picture)
        {
            Dog item = new Dog
            {
                Name = name,
                Age = age,
                Breed = breed,
                Picture = picture
            };
            _context.Dogs.Add(item);
            return _context.SaveChanges() != 0;
        }

        public Dog GetDogBtId(int dogId)
        {
            return _context.Dogs.Find(dogId);
        }

        public List<Dog> GetDogs()
        {
            List<Dog> dogs = _context.Dogs.ToList();
            return dogs;
        }

        public List<Dog> GetDogs(string searchStringBreed, string seatchStringName)
        {
            List<Dog> dogs = _context.Dogs.ToList();
            if (!String.IsNullOrEmpty(searchStringBreed) && !String.IsNullOrEmpty(seatchStringName))
            {
                dogs = dogs.Where(d => d.Breed.Contains(searchStringBreed) && d.Name.Contains(seatchStringName)).ToList();
            }
            else if (!String.IsNullOrEmpty(searchStringBreed))
            {
                dogs = dogs.Where(d => d.Breed.Contains(searchStringBreed)).ToList();
            }
            else if (!String.IsNullOrEmpty(seatchStringName))
            {
                dogs = dogs.Where(d => d.Name.Contains(seatchStringName)).ToList();
            }
            return dogs;
        }

        public bool RemoveById(int dogId)
        {
            var dog = GetDogBtId(dogId);
            if (dog == default(Dog))
            {
                return false;
            }
            _context.Remove(dog);
            return _context.SaveChanges() != 0;
        }

        public bool UpdateDog(int dogId, string name, int age, string breed, string picture)
        {
            var dog = GetDogBtId(dogId);
            if (dog == default(Dog))
            {
                return false;
            }

            dog.Name = name;
            dog.Age = age;
            dog.Breed = breed;
            dog.Picture = picture;

            _context.Update(dog);
            return _context.SaveChanges() != 0;
        }
    }
}
