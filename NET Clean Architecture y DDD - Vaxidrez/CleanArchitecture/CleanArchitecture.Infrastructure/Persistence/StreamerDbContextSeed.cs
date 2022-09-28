using CleanArchitecture.Domain;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Infrastructure.Persistence
{
    public class StreamerDbContextSeed
    {

        public static async Task SeedAsync(StreamerDbContext context, ILoggerFactory loggerFactory) {

            if (!context.Streamers!.Any()) {
                var logger = loggerFactory.CreateLogger<StreamerDbContextSeed>();
                context.Streamers!.AddRange(GetPreconfiguredStreamer());
                await context.SaveChangesAsync();
                logger.LogInformation("Estamos insertando nuevos records al db {context}", typeof(StreamerDbContext).Name);
            }

        }

        private static IEnumerable<Streamer> GetPreconfiguredStreamer() {

            return new List<Streamer>
            {
                new Streamer { CreatedBy = "axel", Nombre = "Maxi HBP", Url = "url1" },
                new Streamer { CreatedBy = "axel", Nombre = "Amazon VIP", Url = "url2" }
            };

        }

    }
}
