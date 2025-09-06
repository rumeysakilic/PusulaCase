using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        var result1 = MaxIncreasingSubArrayAsJson.Find(new List<int> { 1, 3, 5, 4, 7, 8, 2 });
        Console.WriteLine(result1);

        var result2 = LongestVowelSubsequenceAsJson.FindVowel(new List<string> { "aeiou", "bcd", "aaa" });
        Console.WriteLine(result2);

        string xmlData = @"<People>
                                <Person>
                                    <Name>Ali</Name>
                                    <Age>35</Age>
                                    <Department>IT</Department>
                                    <Salary>6000</Salary>
                                    <HireDate>2018-06-01</HireDate>
                                </Person>
                                <Person>
                                    <Name>Ayşe</Name>
                                    <Age>28</Age>
                                    <Department>HR</Department>
                                    <Salary>4500</Salary>
                                    <HireDate>2020-04-15</HireDate>
                                </Person>
                            </People>";

        string result3 = FilterPeopleFromXml.FilterPeopleFromXmlFun(xmlData);
        Console.WriteLine(result3);
        
      var employees = new List<(string, int, string, decimal, DateTime)>
        {
            ("Ali", 30, "IT", 6000m, new DateTime(2018, 5, 1)),
            ("Ayşe", 35, "Finance", 8500m, new DateTime(2019, 3, 15)),
            ("Veli", 28, "IT", 7000m, new DateTime(2020, 1, 1))
        };

        string result4 = FilterEmployees.FilterEmployeesFind(employees);
        Console.WriteLine(result4);
    }
}
