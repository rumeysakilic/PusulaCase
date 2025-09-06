using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text.Json;


public class FilterEmployees
{
     public static string FilterEmployeesFind(IEnumerable<(string Name, int Age, string Department, decimal Salary, DateTime HireDate)> employees)
    {
        var filtered = employees
            .Where(e =>
                e.Age >= 25 && e.Age <= 40 &&
                (e.Department == "IT" || e.Department == "Finance") &&
                e.Salary >= 5000 && e.Salary <= 9000 &&
                e.HireDate > new DateTime(2017, 1, 1))
            .ToList();

        var names = filtered
            .Select(e => e.Name)
            .OrderByDescending(n => n.Length)
            .ThenBy(n => n)
            .ToList();

        decimal totalSalary = filtered.Sum(e => e.Salary);
        int count = filtered.Count;
        decimal averageSalary = count > 0 ? Math.Round(filtered.Average(e => e.Salary), 2) : 0;
        decimal minSalary = count > 0 ? filtered.Min(e => e.Salary) : 0;
        decimal maxSalary = count > 0 ? filtered.Max(e => e.Salary) : 0;

        var result = new
        {
            Names = names,
            TotalSalary = totalSalary,
            AverageSalary = averageSalary,
            MinSalary = minSalary,
            MaxSalary = maxSalary,
            Count = count
        };

        return JsonSerializer.Serialize(result);
    }
}