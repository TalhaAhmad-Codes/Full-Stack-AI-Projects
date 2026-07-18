
---

# CSV operations

---

## 1. Reading

```cs
using System.Globalization;
using System.IO;
using CsvHelper;

public class Person
{
    public int Id { get; set; }
    public string Name { get; set; }
}

// Read data safely
using var reader = new StreamReader("path/to/file.csv");
using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

// Yields records one by one to save memory
var records = csv.GetRecords<Person>(); 

foreach (var person in records)
{
    Console.WriteLine($"{person.Id}: {person.Name}");
}
```

## 2. Writing

```cs
using System.Globalization;
using System.IO;
using CsvHelper;

var records = new List<Person>
{
    new Person { Id = 1, Name = "Alice" },
    new Person { Id = 2, Name = "Bob" }
};

using var writer = new StreamWriter("path/to/newfile.csv");
using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);

csv.WriteRecords(records);
```

> **Alternatives:** `TinyCsvParser` and `FastCsv`

---
