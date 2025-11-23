namespace MusicHub
{
    using System;
    using System.Text;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;

    public class StartUp
    {
        public static void Main()
        {
            MusicHubDbContext context =
                new MusicHubDbContext();

            //DbInitializer.ResetDatabase(context);

            //Test your solutions here

            Console.WriteLine(ExportSongsAboveDuration(context, 4));
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            StringBuilder sb = new StringBuilder();

            var albums = context.Albums
                .Where(p => p.ProducerId == producerId)
                .Select(a => new
                {
                    a.Name,
                    a.ReleaseDate,
                    ProducerName = a.Producer!.Name,
                    Songs = a.Songs.Select(s => new
                    {
                        SongName = s.Name,
                        s.Price,
                        SongWriterName = s.Writer.Name
                    })
                    .OrderByDescending(s => s.SongName)
                    .ThenBy(arg => arg.SongWriterName)
                    .ToArray(),
                    TotalPrice = a.Price
                })
                .ToArray()
                .OrderByDescending(a => a.TotalPrice)
                .ToArray();


            foreach (var album in albums)
            {
                sb
                    .AppendLine($"-AlbumName: {album.Name}")
                    .AppendLine($"-ReleaseDate: {album.ReleaseDate:MM/dd/yyyy}")
                    .AppendLine($"-ProducerName: {album.ProducerName}")
                    .AppendLine("-Songs:");

                int songNumber = 1;

                foreach (var song in album.Songs)
                {
                    sb
                        .AppendLine($"---#{songNumber}")
                        .AppendLine($"---SongName: {song.SongName}")
                        .AppendLine($"---Price: {song.Price:f2}")
                        .AppendLine($"---Writer: {song.SongWriterName}");

                    songNumber++;
                }

                sb.AppendLine($"-AlbumPrice: {album.TotalPrice:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            StringBuilder sb = new StringBuilder();

            var songs = context
                .Songs
                .AsNoTracking()
                .Where(s => (s.Duration.Seconds + s.Duration.Minutes*60) > duration)
                .Select(s => new
                {
                    SongName = s.Name,
                    PerformerFullName = s
                                        .SongPerformers
                                        .Select(sp => sp.Performer.FirstName + " " + sp.Performer.LastName)
                                        .OrderBy(n => n)
                                        .ToArray(),
                    WriterName = s.Writer.Name,
                    AlbumProducer = s.Album.Producer.Name,
                    Duration = s.Duration
                })
                .OrderBy(s => s.SongName)
                .ThenBy(s => s.WriterName)
                //.Take(4)
                .ToArray();

            int songNumber = 1;
            foreach (var song in songs)
            {
                sb
                    .AppendLine($"-Song #{songNumber}")
                    .AppendLine($"---SongName: {song.SongName}")
                    .AppendLine($"---Writer: {song.WriterName}");

                if (song.PerformerFullName.Any())
                {
                    foreach (var performer in song.PerformerFullName)
                    {
                        sb.AppendLine($"---Performer: {performer}");
                    }
                }
                sb
                    .AppendLine($"---AlbumProducer: {song.AlbumProducer}")
                    .AppendLine($"---Duration: {song.Duration.ToString("c")}");

                songNumber++;
            }

            return sb.ToString().TrimEnd();
        }
    }
}
