using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Context;
using Infrastructure.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Model;
using Repositories.Faculties;

namespace Services
{
    public class DatabasePopulationService
    {
        public static void Populate(AppDbContext context)
        {
            PopulateFaculties(context);
            PopulateRooms(context);

            context.SaveChanges();
        }

        private static void PopulateFaculties(AppDbContext context)
        {
            var faculties = context.Faculties;

            if (faculties.Any()) return;

            CheckAndCreateFaculty("ftn", faculties);
            CheckAndCreateFaculty("pmf", faculties);
            CheckAndCreateFaculty("etf", faculties);
        }

        private static void CheckAndCreateFaculty(string name, DbSet<Faculty> faculties)
        {
            var faculty = faculties.FirstOrDefault(x => x.Name == name);
            if (faculty == null)
            {
                faculty = new Faculty()
                {
                    Name = name,
                };
                faculties.Add(faculty);
            }
        }

        private static void PopulateRooms(AppDbContext context)
        {
            var faculties = context.Faculties.Include(x => x.Rooms);

            foreach (var faculty in faculties)
            {
                if (!faculty.Rooms.Any())
                {
                    var newRoom = new Room()
                    {
                        Name = $"{faculty.Name} - room 1"
                    };
                    faculty.Rooms.Add(newRoom);
                }
            }
        }
    }
}
