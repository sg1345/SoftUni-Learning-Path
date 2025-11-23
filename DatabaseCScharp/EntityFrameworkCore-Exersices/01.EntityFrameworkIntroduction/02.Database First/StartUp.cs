using Microsoft.EntityFrameworkCore;
using SoftUni.Data;
using SoftUni.Models;
using System.Globalization;
using System.Linq;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Console.WriteLine(RemoveTown(new SoftUniContext()));
        }

        //Problem 3
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {

            StringBuilder sb = new StringBuilder();

            foreach (Employee employee in context.Employees.OrderBy(e => e.EmployeeId))
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary:f2}");
            }

            return sb.ToString();
        }

        //Problem 4
        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context
                .Employees
                .Select(e => new
                {
                    e.FirstName,
                    e.Salary
                })
                .Where(e => e.Salary > 50000)
                .OrderBy(e => e.FirstName)
                .ToArray();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} - {employee.Salary:f2}");
            }

            return sb.ToString();
        }

        //Problem 5
        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context
                .Employees
                .Where(e => e.Department.Name == "Research and Development")
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    DepartmentName = e.Department.Name,
                    e.Salary,

                })
                .ToArray();


            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} from {employee.DepartmentName} - ${employee.Salary:f2}");
            }

            return sb.ToString();
        }

        //Problem 6
        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            var newAddress = new Address
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            context.Addresses.Add(newAddress);

            var employee = context.Employees.First(e => e.LastName == "Nakov");

            employee.Address = newAddress;

            context.SaveChanges();

            StringBuilder stringBuilder = new StringBuilder();

            var addresses = context
                .Employees
                .OrderByDescending(e => e.AddressId)
                .Select(e => e.Address.AddressText)
                .Take(10)
                .ToList();

            foreach (var e in addresses)
            {
                stringBuilder.AppendLine(e);
            }

            return stringBuilder.ToString();
            //return "";
        }

        //Problem 7
        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context.Employees
                .OrderBy(e => e.EmployeeId) // get first 10 employees
                .Take(10)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    ManagerFirstName = e.Manager.FirstName,
                    ManagerLastName = e.Manager.LastName,
                    Projects = e.EmployeesProjects
                                .Where(ep => ep.Project.StartDate.Year >= 2001 && ep.Project.StartDate.Year <= 2003)
                                .Select(ep => new
                                {
                                    ep.Project.Name,
                                    ep.Project.StartDate,
                                    ep.Project.EndDate
                                })
                                .ToList()
                })
                .ToList();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} - Manager: {employee.ManagerFirstName} {employee.ManagerLastName}");

                foreach (var project in employee.Projects)
                {
                    string endDateText = project.EndDate.HasValue
                        ? project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)
                        : "not finished";

                    sb.AppendLine($"--{project.Name} - {project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)} - {endDateText}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 8
        public static string GetAddressesByTown(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var addresses = context
                .Addresses
                .Select(a => new
                {
                    a.AddressText,
                    townName = a.Town.Name,
                    EmployeeCount = a.Employees.Count
                })
                .OrderByDescending(a => a.EmployeeCount)
                .ThenBy(a => a.townName)
                .ThenBy(a => a.AddressText)
                .Take(10)
                .ToArray();

            foreach (var a in addresses)
            {
                string addressName = a.AddressText;
                string townName = a.townName;
                int EmployeeCount = a.EmployeeCount;

                sb.AppendLine($"{addressName}, {townName} - {EmployeeCount} employees");
            }

            return sb.ToString();
        }

        public static string TestMethodForProblem6(SoftUniContext context)
        {
            StringBuilder stringBuilder = new StringBuilder();

            var addresses = context
                .Employees
                .OrderByDescending(a => a.AddressId)
                .Select(e => e.Address.AddressText)
                .Take(10)
                .ToList();

            foreach (var address in addresses)
            {
                stringBuilder.AppendLine(address);
            }

            return stringBuilder.ToString();
        }

        //Problem 9
        public static string GetEmployee147(SoftUniContext context)
        {
            StringBuilder stringBuilder = new StringBuilder();

            var employee = context
                .Employees
                .Where(e => e.EmployeeId == 147)
                .Select(e => new
                {
                    firstName = e.FirstName,
                    lastName = e.LastName,
                    jobTitle = e.JobTitle,

                    projects = e.EmployeesProjects
                    .Select(ep => ep.Project.Name)
                    .OrderBy(ep => ep)
                    .ToArray()
                })
                .FirstOrDefault();

            stringBuilder.AppendLine($"{employee.firstName} {employee.lastName} - {employee.jobTitle}");

            foreach (var project in employee.projects)
            {
                stringBuilder.AppendLine(project);
            }

            return stringBuilder.ToString().TrimEnd();
        }

        //Problem 10
        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            StringBuilder stringBuilder = new StringBuilder();

            var departmentsWithMoreThan5Emloyees = context
                .Departments
                .Where(d => d.Employees.Count > 5)
                .Select(d => new
                {
                    DepartmentName = d.Name,
                    ManagerFirstName = d.Manager.FirstName,
                    ManagerLastName = d.Manager.LastName,
                    Employees = d.Employees
                        .Select(e => new
                        {
                            EmployeeFirstName = e.FirstName,
                            EmployeeLastName = e.LastName,
                            EmployeeJobTitle = e.JobTitle
                        })
                        .OrderBy(e => e.EmployeeFirstName)
                        .ThenBy(e => e.EmployeeLastName)
                        .ToArray()
                })
                .OrderBy(d => d.Employees.Length)
                .ThenBy(d => d.DepartmentName)
                .ToArray();

            foreach (var department in departmentsWithMoreThan5Emloyees)
            {
                stringBuilder.AppendLine($"{department.DepartmentName} - {department.ManagerFirstName} {department.ManagerLastName}");

                foreach (var employee in department.Employees)
                {
                    stringBuilder.AppendLine($"{employee.EmployeeFirstName} {employee.EmployeeLastName} - {employee.EmployeeJobTitle}");
                }
            }

            return stringBuilder.ToString().TrimEnd();
        }

        //Problem 11
        public static string GetLatestProjects(SoftUniContext context)
        {
            StringBuilder stringBuilder = new StringBuilder();

            var latestProjects = context
                .Projects
                .OrderByDescending(p => p.StartDate)
                .Take(10)
                .Select(p => new
                {
                    ProjectName = p.Name,
                    p.Description,
                    p.StartDate
                })
                .OrderBy(p => p.ProjectName)
                .ToArray();

            foreach (var project in latestProjects)
            {
                stringBuilder.AppendLine($"{project.ProjectName}");
                stringBuilder.AppendLine($"{project.Description}");
                stringBuilder.AppendLine($"{project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)}");
            }

            return stringBuilder.ToString().TrimEnd();
        }

        //Problem 12
        public static string IncreaseSalaries(SoftUniContext context)
        {
            StringBuilder stringBuilder = new StringBuilder();

            var employeesToIncreaseSalaries = context
                .Employees
                .Where(e => e.Department.Name == "Engineering" ||
                            e.Department.Name == "Tool Design" ||
                            e.Department.Name == "Marketing" ||
                            e.Department.Name == "Information Services")
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToArray();

            foreach (var employee in employeesToIncreaseSalaries)
            {
                employee.Salary *= 1.12m;

                stringBuilder.AppendLine($"{employee.FirstName} {employee.LastName} (${employee.Salary:f2})");
            }

            context.SaveChanges();
            return stringBuilder.ToString().TrimEnd();
        }

        //Problem 13
        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            StringBuilder stringBuilder = new StringBuilder();

            var employees = context
                .Employees
                .Where(e => e.FirstName.StartsWith("Sa"))
                .Select(e => new
                {
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    JobTitle = e.JobTitle,
                    Salary = e.Salary
                })
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToArray();

            foreach (var employee in employees)
            {
                stringBuilder.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle} - (${employee.Salary:f2})");
            }

            return stringBuilder.ToString().TrimEnd();
        }

        //Problem 14
        public static string DeleteProjectById(SoftUniContext context)
        {
            StringBuilder stringBuilder = new StringBuilder();

            var projectToDelete = context
                .Projects
                .Find(2);

            var employeeProjectsToDelete = context
                .EmployeesProjects
                .Where(ep => ep.ProjectId == 2)
                .ToArray();

            foreach (var ep in employeeProjectsToDelete)
            {
                if (ep.ProjectId == 2)
                {
                    context.EmployeesProjects.Remove(ep);
                }
            }

            context.Projects.Remove(projectToDelete);

            context.SaveChanges();

            var remainingProjects = context
                .Projects
                .AsNoTracking()
                .Take(10)
                .Select(p => p.Name)
                .ToArray();

            foreach (var project in remainingProjects)
            {
                stringBuilder.AppendLine(project);
            }

            return stringBuilder.ToString().TrimEnd();
        }

        //Problem 15
        public static string RemoveTown(SoftUniContext context)
        {
            string townNameToRemove = "Seattle";
            int count = 0;

            var townToDelete = context
                .Towns
                .FirstOrDefault(t => t.Name == townNameToRemove);

            var addressesToDelete = context
                .Addresses
                .Where(a => a.TownId == townToDelete!.TownId)
                .ToArray();

            var addressesIdsToDelete = addressesToDelete
                .Select(a => a.AddressId)
                .ToList(); 

            var employeesWithAddressesToDelete = context
                .Employees
                .Where(e => e.AddressId.HasValue && addressesIdsToDelete.Contains(e.AddressId.Value))
                .ToArray();

            foreach (var item in employeesWithAddressesToDelete)
            {
                item.AddressId = null;
                count++;
            }

            context.RemoveRange(addressesToDelete);
            context.Towns.Remove(townToDelete!);
            context.SaveChanges();

            return $"{addressesToDelete.Length} addresses in Seattle were deleted";
        }
    }
}
