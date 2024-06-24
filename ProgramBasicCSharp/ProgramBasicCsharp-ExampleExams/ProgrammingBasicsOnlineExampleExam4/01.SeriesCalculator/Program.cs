//input
string seriesName = Console.ReadLine();
int countSeasons = int.Parse(Console.ReadLine());
int countEpisodePerSeason = int.Parse(Console.ReadLine());
double minutesPerEpisode  = double.Parse(Console.ReadLine());

//calculations
double seriesInMinutes = countSeasons * countEpisodePerSeason * minutesPerEpisode + countSeasons * 10;
double comersials = countSeasons * countEpisodePerSeason * minutesPerEpisode * 0.2;
double totalTimeNeeded =seriesInMinutes + comersials;

//output
Console.WriteLine($"Total time needed to watch the {seriesName} series is {Math.Floor(totalTimeNeeded)} minutes.");