//•	"The architect {името на архитекта} will need {необходими часове} hours to complete {брой на проектите} project/s."

string name = Console.ReadLine();
int numberOfProjects = int.Parse(Console.ReadLine());
int hoursPerProject = 3;
int hoursForAllProjects = numberOfProjects * hoursPerProject;

Console.WriteLine($"The architect {name} will need {hoursForAllProjects} hours to complete {numberOfProjects} project/s.");