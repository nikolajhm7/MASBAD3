using Handin3.Data;
using Handin3.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Handin3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeedController : ControllerBase
    {
        private readonly myDbContext _context;

        public SeedController(myDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult SeedData()
        {
            try
            {
                // Inserting data into Supermarket table
                _context.Supermarkets.AddRange(
                    new Supermarket { Name = "Føtex", Location = "Finlandsgade 17, 8200 Aarhus N", Latitude = 56.171089, Longitude = 10.190290 },
                    new Supermarket { Name = "REMA 1000", Location = "Randersvej 142, 8200 Aarhus N", Latitude = 56.178930, Longitude = 10.200730 }
                );

                _context.SaveChanges();

                // Inserting data into Schedule table
                _context.Schedules.Add(new Schedule { Name = "BakerySchedule" });

                _context.SaveChanges();

                // Inserting data into SOrder table
                _context.Orders.AddRange(
                    new SOrder { SupermarketId = 1, ScheduleId = 1, Date = "05-03-2024", Location = "Finlandsgade 17, 8200 Aarhus N" },
                    new SOrder { SupermarketId = 2, ScheduleId = 1, Date = "03-02-2023", Location = "Randersvej 142, 8200 Aarhus N" },
                    new SOrder { SupermarketId = 1, ScheduleId = 1, Date = "12-10-2021", Location = "Finlandsgade 17, 8200 Aarhus N" }
                );

                _context.SaveChanges();

                // Inserting data into Batch table
                _context.Batches.AddRange(
                    new Batch { ScheduleId = 1, OrderId = 1, Quantity = 400, StartTime = "12-10-2021 10:00", TargetFinishTime = "12-10-2021 16:00", ActualFinishTime = "12-10-2021 16:30", RecipeId = 3 },
                    new Batch { ScheduleId = 1, OrderId = 1, Quantity = 300, StartTime = "12-10-2021 10:00", TargetFinishTime = "12-10-2021 16:00", ActualFinishTime = "12-10-2021 15:50", RecipeId = 1 },
                    new Batch { ScheduleId = 1, OrderId = 1, Quantity = 300, StartTime = "12-10-2021 10:00", TargetFinishTime = "12-10-2021 16:00", ActualFinishTime = "12-10-2021 17:00", RecipeId = 2 },
                    new Batch { ScheduleId = 1, OrderId = 2, Quantity = 700, StartTime = "03-02-2023 10:00", TargetFinishTime = "03-02-2023 16:00", ActualFinishTime = "03-02-2023 15:45", RecipeId = 3 },
                    new Batch { ScheduleId = 1, OrderId = 2, Quantity = 100, StartTime = "03-02-2023 10:00", TargetFinishTime = "03-02-2023 16:00", ActualFinishTime = "03-02-2023 16:00", RecipeId = 2 },
                    new Batch { ScheduleId = 1, OrderId = 3, Quantity = 300, StartTime = "05-03-2024 10:00", TargetFinishTime = "05-03-2024 16:00", ActualFinishTime = "05-03-2024 18:00", RecipeId = 2 },
                    new Batch { ScheduleId = 1, OrderId = 3, Quantity = 200, StartTime = "05-03-2024 10:00", TargetFinishTime = "05-03-2024 16:00", ActualFinishTime = "05-03-2024 15:30", RecipeId = 1 }
                );

                _context.SaveChanges();

                // Inserting data into Recipe table
                _context.Recipes.AddRange(
                    new Recipe { Name = "Alexandertorte" },
                    new Recipe { Name = "Butter cookies" },
                    new Recipe { Name = "Studenterbrød" },
                    new Recipe { Name = "Romkugler" }
                );

                _context.SaveChanges();

                // Inserting data into Ingredient table
                _context.Ingredients.AddRange(
                    new Ingredient { Name = "Sugar", Quantity = 100000 },
                    new Ingredient { Name = "Flour", Quantity = 242000 },
                    new Ingredient { Name = "Salt", Quantity = 10000 },
                    new Ingredient { Name = "Rum", Quantity = 2000 },
                    new Ingredient { Name = "Cocoa", Quantity = 3000 },
                    new Ingredient { Name = "Raspberry jam", Quantity = 5000 },
                    new Ingredient { Name = "Leftover cake", Quantity = 31415 }
                );

                _context.SaveChanges();

                // Inserting data into RecipeIngredient table
                _context.RecipeIngredients.AddRange(
                    new RecipeIngredient { RecipeId = 1, IngredientName = "Sugar", Quantity = 300 },
                    new RecipeIngredient { RecipeId = 1, IngredientName = "Cocoa", Quantity = 20 },
                    new RecipeIngredient { RecipeId = 1, IngredientName = "Raspberry jam", Quantity = 50 },
                    new RecipeIngredient { RecipeId = 1, IngredientName = "Leftover Cake", Quantity = 30 },
                    new RecipeIngredient { RecipeId = 2, IngredientName = "Sugar", Quantity = 100 },
                    new RecipeIngredient { RecipeId = 2, IngredientName = "Flour", Quantity = 200 },
                    new RecipeIngredient { RecipeId = 2, IngredientName = "Salt", Quantity = 20 },
                    new RecipeIngredient { RecipeId = 2, IngredientName = "Leftover Cake", Quantity = 305 },
                    new RecipeIngredient { RecipeId = 3, IngredientName = "Sugar", Quantity = 320 },
                    new RecipeIngredient { RecipeId = 3, IngredientName = "Cocoa", Quantity = 20 },
                    new RecipeIngredient { RecipeId = 3, IngredientName = "Rum", Quantity = 50 },
                    new RecipeIngredient { RecipeId = 3, IngredientName = "Leftover Cake", Quantity = 30 }
                );

                _context.SaveChanges();

                // Inserting data into Driver table
                _context.Drivers.Add(new Driver { Name = "Star" });

                _context.SaveChanges();

                // Inserting data into Packet table
                _context.Packets.AddRange(
                    new Packet { OrderId = 1, DriverId = 1 },
                    new Packet { OrderId = 2, DriverId = 1 }
                );

                _context.SaveChanges();

                return Ok("Data seeded successfully");
            }
            catch (Exception ex)
            {
                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                }

                return StatusCode(500, $"Error while seeding data: {ex.Message}");
            }
        }

        [HttpPost("SeedAllergens")]
        public IActionResult SeedAllergens()
        {
            try
            {
                // Inserting data into Allergen table
                _context.Allergens.AddRange(
                    new Allergen { Name = "Gluten" },
                    new Allergen { Name = "Lactose" },
                    new Allergen { Name = "Nuts" }
                );

                _context.SaveChanges();

                // Inserting data into IngredientAllergen table
                if (!_context.IngredientAllergens.Any(ia => ia.IngredientName == "Leftover Cake"))
                {
                    _context.IngredientAllergens.AddRange(
                        new IngredientAllergen { IngredientName = "Leftover Cake", AllergenName = "Gluten" },
                        new IngredientAllergen { IngredientName = "Leftover Cake", AllergenName = "Lactose" },
                        new IngredientAllergen { IngredientName = "Leftover Cake", AllergenName = "Nuts" }
                    );

                    _context.SaveChanges();
                }

                return Ok("Allergens seeded successfully");
            }
            catch (Exception ex)
            {
                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                }

                return StatusCode(500, $"Error while seeding allergens: {ex.Message}");
            }
        }
    }
}
