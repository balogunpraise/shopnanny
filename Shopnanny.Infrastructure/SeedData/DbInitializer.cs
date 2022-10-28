using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Shopnanny.Core.Application.Constants;
using Shopnanny.Core.Entities;
using Shopnanny.Infrastructure.Data;

namespace Shopnanny.Infrastructure.SeedData
{
    public static class DbInitializer
    {
        public static async Task SeedRoleAsync(ApplicationDbContext context, RoleManager<IdentityRole> roleManager)
        {
            await context.Database.EnsureCreatedAsync();

            string[] roles = { RoleConstants.GlobalAdmin, RoleConstants.Admin, RoleConstants.Customer };

            try
            {

                foreach (var role in roles)
                {
                    if (!roleManager.RoleExistsAsync(role).Result)
                    {
                        var role1 = new IdentityRole
                        {
                            Name = role
                        };
                        roleManager.CreateAsync(role1).Wait();
                    }
                }
                await context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public static async Task SeedUserAsync(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            try
            {
                var user = new ApplicationUser
                {
                    FirstName = "Praise",
                    LastName = "Balogun",
                    Email = "globaladmin@gmail.com",
                    UserName = "globaladmin",
                    PhoneNumber = "08034879878",
                    Addresses = new List<Address>
                    {
                        new Address
                        {
                            State = "Edo",
                            City = "Benin",
                            StreetName = "Adolo",
                            Country = "Nigeria",
                        }
                    }
                };
                var foundUser = await userManager.FindByEmailAsync(user.Email);
                if (foundUser == null)
                {
                    await userManager.CreateAsync(user, "Pa$$w0rd");
                    await userManager.AddToRoleAsync(user, RoleConstants.GlobalAdmin);
                }

                var adminUser = new ApplicationUser
                {
                    FirstName = "Fortune",
                    LastName = "Balogun",
                    Email = "admin@gmail.com",
                    UserName = "admin", 
                    PhoneNumber = "08034879228",
                    Addresses = new List<Address>
                    {
                        new Address
                        {
                            State = "Edo",
                            City = "Benin",
                            StreetName = "Ekosodin",
                            Country = "Nigeria",
                        }
                    }
                };

                var secondFoundUser = await userManager.FindByEmailAsync(adminUser.Email);
                if (secondFoundUser == null)
                {
                    await userManager.CreateAsync(adminUser, "Pa$$w0rd");
                    userManager.AddToRoleAsync(adminUser, RoleConstants.Admin).Wait();
                }


                var customer = new ApplicationUser
                {
                    FirstName = "Onimsi",
                    LastName = "Balogun",
                    Email = "customer@gmail.com",
                    UserName = "customer",
                    PhoneNumber = "08034879228",
                    Addresses = new List<Address>
                    {
                        new Address
                        {
                            State = "Edo",
                            City = "Benin",
                            StreetName = "Ekosodin",
                            Country = "Nigeria",
                        }
                    }
                };

                var customerUser = await userManager.FindByEmailAsync(adminUser.Email);
                if (customerUser == null)
                {
                    await userManager.CreateAsync(adminUser, "Pa$$w0rd");
                    userManager.AddToRoleAsync(adminUser, RoleConstants.Customer).Wait();

                }
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
