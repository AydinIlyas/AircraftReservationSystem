﻿using AircraftReservationSystem.DataAccess.Data;
using AircraftReservationSystem.Models;
using AircraftReservationSystem.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AircraftReservationSystem.DataAccess.DbInitializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _db;

        public DbInitializer(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            ApplicationDbContext db)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _db = db;
        }


        public void Initialize()
        {
            //migrations if they are not applied
            try
            {
                if (_db.Database.GetPendingMigrations().Count() > 0)
                {
                    _db.Database.Migrate();
                }
            }
            catch (Exception ex)
            {

            }
            //create roles if they are not created
            if (!_db.Countries.Any())
            {
                // Execute the SQL script
                var sqlScriptCountry = File.ReadAllText("./Data/Countries.sql");
                _db.Database.ExecuteSqlRaw(sqlScriptCountry);
                var sqlScriptCity = File.ReadAllText("./Data/Cities.sql");
                _db.Database.ExecuteSqlRaw(sqlScriptCity);
                var sqlScriptDistrict = File.ReadAllText("./Data/Districts.sql");
                _db.Database.ExecuteSqlRaw(sqlScriptDistrict);

            }
            //create roles if they are not created
            if (!_roleManager.RoleExistsAsync(ROLES.Role_Admin).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(ROLES.Role_Admin)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(ROLES.Role_Airline_User)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(ROLES.Role_User)).GetAwaiter().GetResult();
            }
            var adminUser = _userManager.FindByEmailAsync("admin@gmail.com").GetAwaiter().GetResult();
            if (adminUser == null)
            {
                //if roles are not created, then we will create admin user as well

                _userManager.CreateAsync(new ApplicationUser
                {
                    UserName = "admin@gmail.com",
                    Email = "admin@gmail.com",
                    Firstname = "Admin",
                    Lastname = "Admin",
                    PassportNumber = "12345678910",
                    BirthDate = DateTime.Now,
                    SoldTickets = null
                }, "Admin123*").GetAwaiter().GetResult();
                _userManager.CreateAsync(new ApplicationUser
                {
                    UserName = "b211210101@sakarya.edu.tr",
                    Email = "b211210101@sakarya.edu.tr",
                    Firstname = "İlyas",
                    Lastname = "Aydın",
                    PassportNumber = "12345678910",
                    BirthDate = DateTime.ParseExact("31.03.2003", "dd.MM.yyyy", null),
                    SoldTickets = null
                }, "Ilyas123*").GetAwaiter().GetResult();
                _userManager.CreateAsync(new ApplicationUser
                {
                    UserName = "b211210047@sakarya.edu.tr",
                    Email = "b211210047@sakarya.edu.tr",
                    Firstname = "Emirhan",
                    Lastname = "Etli",
                    PassportNumber = "12345678910",
                    BirthDate = DateTime.ParseExact("15.06.2003", "dd.MM.yyyy", null),
                    SoldTickets = null
                }, "Emirhan123*").GetAwaiter().GetResult();
                _userManager.CreateAsync(new ApplicationUser
                {
                    UserName = "user@gmail.com",
                    Email = "user@gmail.com",
                    Firstname = "user",
                    Lastname = "user",
                    PassportNumber = "12345678910",
                    BirthDate = DateTime.Now,
                    SoldTickets = null
                }, "User123*").GetAwaiter().GetResult();
                _userManager.CreateAsync(new ApplicationUser
                {
                    UserName = "airlineuser@gmail.com",
                    Email = "airlineuser@gmail.com",
                    Firstname = "airlineUser",
                    Lastname = "airlineUser",
                    PassportNumber = "12345678910",
                    BirthDate = DateTime.Now,
                    SoldTickets = null
                }, "AirlineUser123*").GetAwaiter().GetResult();

                ApplicationUser admin = _db.Passengers.FirstOrDefault(u => u.Email == "admin@gmail.com");
                ApplicationUser ilyas = _db.Passengers.FirstOrDefault(u => u.Email == "b211210101@sakarya.edu.tr");
                ApplicationUser emirhan = _db.Passengers.FirstOrDefault(u => u.Email == "b211210047@sakarya.edu.tr");
                ApplicationUser user = _db.Passengers.FirstOrDefault(u => u.Email == "user@gmail.com");
                ApplicationUser airlineUser = _db.Passengers.FirstOrDefault(u => u.Email == "airlineuser@gmail.com");

                _userManager.AddToRoleAsync(admin, ROLES.Role_Admin).GetAwaiter().GetResult();
                _userManager.AddToRoleAsync(ilyas, ROLES.Role_Admin).GetAwaiter().GetResult();
                _userManager.AddToRoleAsync(emirhan, ROLES.Role_Admin).GetAwaiter().GetResult();
                _userManager.AddToRoleAsync(user, ROLES.Role_User).GetAwaiter().GetResult();
                _userManager.AddToRoleAsync(airlineUser, ROLES.Role_Airline_User).GetAwaiter().GetResult();
            }

            return;
        }
    }
}