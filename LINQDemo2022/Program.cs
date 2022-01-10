// See https://aka.ms/new-console-template for more information
using LINQDemo2022.Model;
using System;
using System.Collections.Generic;
using System.Linq;

// Alice Andělová P1
// Bořivoj Bohatý P1
// Ctirad Cudný P2
// Daniela Drozdová P2

// ALG, PRG, MAT, CJL

// https://docs.microsoft.com/cs-cz/dotnet/csharp/programming-guide/concepts/linq/
// https://www.tutorialsteacher.com/linq
// https://www.geeksforgeeks.org/linq-method-syntax/?ref=lbp

List<Mark> marks = new List<Mark> { 
    new Mark("Alice","Andělová", "P1", "ALG", 1, new DateTime(2020,1,1)),
    new Mark("Bořivoj","Bohatý", "P1", "ALG", 3, new DateTime(2020,1,1)),
    new Mark("Ctirad","Cudný", "P2", "PRG", 1, new DateTime(2020,2,2)),
    new Mark("Daniela","Drozdová", "P2", "PRG", 5, new DateTime(2020,2,2)),
    new Mark("Alice","Andělová", "P1", "MAT", 2, new DateTime(2020,3,1)),
    new Mark("Bořivoj","Bohatý", "P1", "MAT", 3, new DateTime(2020,4,7)),
    new Mark("Ctirad","Cudný", "P2", "MAT", 3, new DateTime(2020,2,2)),
    new Mark("Daniela","Drozdová", "P2", "MAT", 5, new DateTime(2020,1,2)),
    new Mark("Alice","Andělová", "P1", "MAT", 2, new DateTime(2020,1,1)),
    new Mark("Bořivoj","Bohatý", "P1", "MAT", 4, new DateTime(2020,1,1)),
    new Mark("Ctirad","Cudný", "P2", "PRG", 2, new DateTime(2020,2,2)),
    new Mark("Daniela","Drozdová", "P2", "PRG", 5, new DateTime(2020,2,2)),
    new Mark("Alice","Andělová", "P1", "ALG", 4, new DateTime(2020,1,1)),
    new Mark("Bořivoj","Bohatý", "P1", "ALG", 4, new DateTime(2020,1,1)),
    new Mark("Ctirad","Cudný", "P2", "CJL", 2, new DateTime(2020,2,2)),
    new Mark("Daniela","Drozdová", "P2", "CJL", 5, new DateTime(2020,2,2)),
    new Mark("Alice","Andělová", "P1", "CJL", 1, new DateTime(2020,3,1)),
    new Mark("Bořivoj","Bohatý", "P1", "CJL", 3, new DateTime(2020,4,4)),
    new Mark("Ctirad","Cudný", "P2", "MAT", 1, new DateTime(2020,3,2)),
    new Mark("Daniela","Drozdová", "P2", "MAT", 5, new DateTime(2020,2,3))
};

// Seřaďte záznamy podle jména studenta
// Seřaďte záznamy podle data
var res2 = marks.OrderBy(m => m.Created);
foreach (var x in res2)
{
    Console.WriteLine(x);
}
Console.WriteLine("---------------");
// Seřaďte záznamy podle třídy sestupně
var res3 = marks.OrderByDescending(m => m.ClassName);
foreach (var x in res3)
{
    Console.WriteLine(x);
}
Console.WriteLine("---------------");
// Získejte jen známky studentky Alice
var res4 = marks.Where(m => m.FirstName == "Alice");
foreach (var x in res4)
{
    Console.WriteLine(x);
}
Console.WriteLine("---------------");
// Získejte jen známky z P1, nezískávejte ale jiné informace kromě příjmení a známky
var res5 = marks
    .Where(m => m.ClassName == "P1")
    .Select(m => new Mark1VM { LastName = m.LastName, Value = m.Value});
  
foreach (var x in res5)
{
    Console.WriteLine(x);
}
Console.WriteLine("---------------");

// Získejte jen známky z P1 seřazené podle příjmení studenta
var res6 = marks.Where(m => m.ClassName == "P2").Count();
 Console.WriteLine(res6);

Console.WriteLine("---------------");

// Získejte průměr všech známek studentky Alice
var res7 = marks.Where(m => m.FirstName == "Alice").Average(m => m.Value);
Console.WriteLine(res7);

Console.WriteLine("---------------");
// Získejte známky z jednotlivých předmětů studentky Alice
var res8 = marks.Where(m => m.FirstName == "Alice").GroupBy(m => m.Subject);
foreach (var x in res8)
{
    Console.WriteLine(x.Key);
    foreach (var y in x.ToList())
    {
        Console.WriteLine(y.Value);
    }
}

Console.WriteLine("---------------");

// Získejte průměrné známky všech studentů
var res9 = marks
    .GroupBy(m => m.LastName)
    .Select(m => new Mark1VM { 
        LastName = m.Key,
        Value = (int)m.Average(n => n.Value)});
foreach (var x in res9)
{
    Console.WriteLine(x.LastName + " " + x.Value);
}
Console.WriteLine("---------------");

// znamky jaka trida
var res10 = marks.GroupBy(m => m.ClassName).Select(m => new Mark1VM { LastName = m.Key, Value = m.Count() });
foreach (var x in res10)
{
    Console.WriteLine(x.LastName + " " + x.Value);
}
Console.WriteLine("---------------");

//Nejvyssi znamky vsech studentu
var res11 = marks.GroupBy(m => m.LastName).Select(m => new Mark1VM { LastName = m.Key, Value = m.Max(x => x.Value) });
foreach (var x in res11)
{
    Console.WriteLine(x.LastName + " " + x.Value);
}
Console.WriteLine("---------------");

// Seřaďte studenty podle jejich průměrných známek
var res12 = marks.GroupBy(m => m.LastName).Select(m => new Mark1VM { LastName = m.Key, Value = (int)m.Average(x => x.Value) }).OrderBy(m => m.Value);
foreach (var x in res12)
{
    Console.WriteLine(x.LastName + " " + x.Value);
}
Console.WriteLine("---------------");
