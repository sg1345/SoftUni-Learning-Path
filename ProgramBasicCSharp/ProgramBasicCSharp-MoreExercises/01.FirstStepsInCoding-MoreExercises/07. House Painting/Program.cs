double x = double.Parse(Console.ReadLine());
double y = double.Parse(Console.ReadLine());
double h = double.Parse(Console.ReadLine());

double door = 1.2 * 2;
double window = 1.5 * 1.5;

double frontWall = x * x - door;
double backWall = x * x;
double leftWall = x * y - window;
double rightWall = x * y - window;   

double totalWall = frontWall + backWall + leftWall + rightWall;
double greenPaint = totalWall / 3.4;

double leftRoof = x * y;
double rightRoof = x * y;
double frontRoof = x * h / 2;
double backRoof = x * h / 2;

double totalRoof = leftRoof + rightRoof + frontRoof + backRoof;
double redPaint = totalRoof / 4.3;

Console.WriteLine(greenPaint.ToString("0.00"));
Console.WriteLine(redPaint.ToString("0.00"));