using System;
using System.Linq;
using System.Xml.Linq;
using System.Text.Json;
using System.Collections.Generic;

public class FilterPeopleFromXml
{
    public static string FilterPeopleFromXmlFun(string xmlData)
    {
        if (string.IsNullOrWhiteSpace(xmlData))
        {
            return JsonSerializer.Serialize(new
            {
                Names = new List<string>(),
                TotalSalary = 0,
                AverageSalary = 0,
                MaxSalary = 0,
                Count = 0
            });
        }

        var doc = XDocument.Parse(xmlData);

        var people = doc.Descendants("Person")
            .Select(p => new
            {
                Name = (string)p.Element("Name"),
                Age = (int)p.Element("Age"),
                Department = (string)p.Element("Department"),
                Salary = (int)p.Element("Salary"),
                HireDate = DateTime.Parse((string)p.Element("HireDate"))
            })
            .Where(p => p.Age > 30 &&
                        p.Department == "IT" &&
                        p.Salary > 5000 &&
                        p.HireDate < new DateTime(2019, 1, 1))
            .ToList();

        var names = people.Select(p => p.Name).OrderBy(n => n).ToList();
        int totalSalary = people.Sum(p => p.Salary);
        int count = people.Count;
        int averageSalary = count > 0 ? (int)people.Average(p => p.Salary) : 0;
        int maxSalary = count > 0 ? people.Max(p => p.Salary) : 0;

        var result = new
        {
            Names = names,
            TotalSalary = totalSalary,
            AverageSalary = averageSalary,
            MaxSalary = maxSalary,
            Count = count
        };

        return JsonSerializer.Serialize(result);
        //JSON Formatına döndürüldü
    }
}
