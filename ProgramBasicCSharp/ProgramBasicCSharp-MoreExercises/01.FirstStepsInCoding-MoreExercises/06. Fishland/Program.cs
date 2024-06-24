double skumriqPerKilogram = double.Parse(Console.ReadLine());
double cacaPerKilogram = double.Parse(Console.ReadLine());
double palamudKilograms = double.Parse(Console.ReadLine());
double safridKilograms = double.Parse(Console.ReadLine());
double midiKilograms = double.Parse(Console.ReadLine());

double palamudPerKilogram = (skumriqPerKilogram * 0.6) + skumriqPerKilogram;
double safridPerKilogram = (cacaPerKilogram *0.8) + cacaPerKilogram;

double palamud = palamudKilograms * palamudPerKilogram;
double safrid = safridKilograms * safridPerKilogram;
double midi = midiKilograms * 7.5;

double total = palamud + safrid + midi;

Console.WriteLine(total.ToString("0.00"));
