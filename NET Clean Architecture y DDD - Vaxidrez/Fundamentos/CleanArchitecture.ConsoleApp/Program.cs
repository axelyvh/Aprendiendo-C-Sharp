using CleanArchitecture.Data;
using CleanArchitecture.Domain;
using Microsoft.EntityFrameworkCore;

StreamerDbContext dbContext = new();
//await MultipleEntitiesQuery();
//await AddNewActorWithVideo();
//await AddNewStreamerWithVideoId();
//await AddNewStreamerWitchVideo();
//await TrakingAndNotTraking();
//await QueryLinq();
//await QueryMethods();
//await QueryFilter();
//await AddNewRecords();

Console.WriteLine("Presione cualquier tecla para terminar el programa");
Console.ReadKey();

async Task AddNewRecords() {

    Streamer streamer = new()
    {
        Nombre = "Amazon Prime",
        Url = "url2"
    };

    dbContext!.Streamers!.Add(streamer);

    await dbContext!.SaveChangesAsync();

    var movies = new List<Video>
    {
        new Video { Nombre = "Mad Max", StreamerId = streamer.Id },
        new Video { Nombre = "Batman", StreamerId = streamer.Id },
        new Video { Nombre = "Crepusculo", StreamerId = streamer.Id },
        new Video { Nombre = "Citizen kane", StreamerId = streamer.Id },
    };

    await dbContext!.AddRangeAsync(movies);
    await dbContext!.SaveChangesAsync();

}

async Task QueryFilter() {

    Console.WriteLine("Ingrese una compañia de streaming");
    var streamingNombre = Console.ReadLine();

    //var streamers = await dbContext!.Streamers!.Where(x => x.Nombre!.Contains(streamingNombre!)).ToListAsync();
    var streamers = await dbContext!.Streamers!.Where(x => EF.Functions.Like(x.Nombre, $"%{streamingNombre}%")).ToListAsync();

    foreach (var streamer in streamers)
    {
        Console.WriteLine($"{streamer.Id} - {streamer.Nombre}");
    }

}

async Task QueryMethods() 
{

    var streamer = dbContext!.Streamers!;

    var firstAsync = await streamer.Where(y => y.Nombre.Contains("a")).FirstAsync();

    var firstOrDefaultAsync = await streamer.Where(y => y.Nombre.Contains("a")).FirstOrDefaultAsync();

    var firstOrDefault_v2 = await streamer.FirstOrDefaultAsync(y => y.Nombre.Contains("a"));

    var singleAsync = await streamer.Where(y => y.Id == 1).SingleAsync();
    var singleOrDefaultAsync = await streamer.Where(y => y.Id == 1).SingleOrDefaultAsync();

    var resultado = await streamer.FindAsync(1);

    var count = await streamer.CountAsync();
    var longAccount = await streamer.LongCountAsync(); 
    var min = await streamer.MinAsync();
    var max = await streamer.MaxAsync();

}

async Task QueryLinq() {

    Console.WriteLine($"Ingrese el servicio de streaming");
    var streamerNombre = Console.ReadLine();

    var streamers = await (from i in dbContext.Streamers
                           where EF.Functions.Like(i.Nombre, $"%{streamerNombre}%")
                       select i).ToListAsync();

    foreach (var streamer in streamers)
    {
        Console.WriteLine($"{streamer.Id}-{streamer.Nombre}");
    }

}

async Task TrakingAndNotTraking() {

    /**
     * AsNoTracking:
     * No se puede usar => FindAsync
     * No se puede actualizar el registro en BD
     * Es recomendable para realizar consultas a gran demanda
    **/

    var streamerWithTracking = await dbContext!.Streamers!.FirstOrDefaultAsync(x => x.Id == 1);
    var streamerWithNoTracking = await dbContext!.Streamers!.AsNoTracking().FirstOrDefaultAsync(x => x.Id == 2);

    streamerWithTracking.Nombre = "Netflix Super";
    streamerWithNoTracking.Nombre = "Amazon Plus";

    await dbContext!.SaveChangesAsync();

}

async Task AddNewStreamerWitchVideo() {

    var pantaya = new Streamer
    {
        Nombre = "Pantaya"
    };
    
    var hungerGames = new Video
    {
        Nombre = "Hunger Games",
        Streamer = pantaya
    };

    await dbContext.AddAsync(hungerGames);
    await dbContext.SaveChangesAsync();

}

async Task AddNewStreamerWithVideoId()
{
    var batmanForever = new Video
    {
        Nombre = "batman forever",
        StreamerId = 3
    };
    await dbContext.AddAsync(batmanForever);
    await dbContext.SaveChangesAsync();
}

async Task AddNewActorWithVideo()
{
    var actor = new Actor
    {
        Nombre="Brad",
        Apellido="Pitt"
    };
    await dbContext.AddAsync(actor);
    await dbContext.SaveChangesAsync();

    var videoActor = new VideoActor
    {
        ActorId = actor.Id,
        VideoId = 6
    };
    await dbContext.AddAsync(videoActor);
    await dbContext.SaveChangesAsync();
}

async Task MultipleEntitiesQuery() {

    //var videoWithActores = await dbContext!.Videos!.Include(q => q.Actores).FirstOrDefaultAsync(q => q.Id == 1);

    //var actor = await dbContext!.Actores!.Select(q => q.Nombre).ToListAsync();

    var videoWithDirector = await dbContext!.Videos!
                            .Where(q => q.Director != null)
                            .Include(q => q.Director)
                            .Select(q =>
                               new
                               {
                                   Director_Nombre_Completo = $"{q.Director.Nombre}{q.Director.Apellido}",
                                   Movie = q.Nombre
                               }
                             )
                            .ToListAsync();

    foreach (var pelicula in videoWithDirector)
    {
        Console.WriteLine($"{pelicula.Movie}-{pelicula.Director_Nombre_Completo}");
    }

}