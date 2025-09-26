using static System.Net.Mime.MediaTypeNames;

namespace DagsBokApp
{
    internal class Program
    {

        static void Main(string[] args)
        {
            List<DiaryEntry> entries = new();
            Dictionary<DateTime, DiaryEntry> entriesByDate = new(); // VG-krav
            DiaryService service = new("diary.json");

            // Läs in existerande anteckningar
            entries = service.Load();
            foreach (var e in entries)
            {
                if (!entriesByDate.ContainsKey(e.Date))
                    entriesByDate[e.Date] = e;
            }

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\n--- MIN DAGBOK ---");
                Console.ResetColor();

                Console.WriteLine("1. Skriv ny anteckning");
                Console.WriteLine("2. Lista alla anteckningar");
                Console.WriteLine("3. Sök anteckning på datum");
                Console.WriteLine("4. Spara till fil");
                Console.WriteLine("5. Läs från fil");
                Console.WriteLine("6. Ta bort anteckning");
                Console.WriteLine("7. Uppdatera anteckning");
                Console.WriteLine("0. Avsluta");
                Console.Write("Välj: ");
                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Ange datum (åååå-mm-dd): ");
                        if (DateTime.TryParse(Console.ReadLine(), out DateTime date))
                        {
                            Console.Write("Skriv anteckning: ");
                            string text = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(text))
                            {
                                Console.WriteLine("Texten får inte vara tom.");
                                break;

                            }
                            DiaryEntry newEntry = new() { Date = date, Text = text };
                            entries.Add(newEntry);
                            entriesByDate[date] = newEntry;
                            Console.WriteLine("Anteckning sparad i minnet.");
                            break;
                        }
                        else
                            Console.WriteLine("Fel Datum ");
                        break;



                    case "2":
                        if (entries.Count == 0)
                            Console.WriteLine("Inga anteckningar.");
                        else
                            entries.ForEach(e => Console.WriteLine(e));
                        break;

                    case "3":
                        Console.Write("Ange datum att söka: ");
                        if (!DateTime.TryParse(Console.ReadLine(), out DateTime searchDate))
                        {
                            Console.WriteLine("Ogiltigt datum!");
                            break;
                        }

                        if (entriesByDate.TryGetValue(searchDate, out DiaryEntry? found))
                            Console.WriteLine(found);
                        else
                            Console.WriteLine("Ingen anteckning hittad för det datumet.");
                        break;

                    case "4":
                        service.Save(entries);
                        Console.WriteLine("Anteckningar sparade till fil.");
                        break;


                    case "5":
                        entries = service.Load();
                        entriesByDate.Clear();
                        foreach (var e in entries)
                            entriesByDate[e.Date] = e;
                        Console.WriteLine("Anteckningar inlästa från fil.");
                        break;

                    case "6": // Ta bort anteckning
                        Console.Write("Ange datum att ta bort: ");
                        if (DateTime.TryParse(Console.ReadLine(), out DateTime delDate) &&
                            entriesByDate.TryGetValue(delDate, out DiaryEntry? delEntry))
                        {
                            entries.Remove(delEntry);
                            entriesByDate.Remove(delDate);
                            Console.WriteLine("Anteckning borttagen.");
                        }
                        else
                        {
                            Console.WriteLine("Ingen anteckning hittad.");
                        }
                        break;

                    case "7": // Uppdatera anteckning
                        Console.Write("Ange datum att uppdatera: ");
                        if (DateTime.TryParse(Console.ReadLine(), out DateTime updDate) &&
                            entriesByDate.TryGetValue(updDate, out DiaryEntry? updEntry))
                        {
                            Console.Write("Ny text: ");
                            string? newText = Console.ReadLine();
                            if (!string.IsNullOrWhiteSpace(newText))
                            {
                                updEntry.Text = newText;
                                Console.WriteLine("Anteckning uppdaterad.");
                            }
                            else
                            {
                                Console.WriteLine("Texten får inte vara tom.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Ingen anteckning hittad.");
                        }
                        break;
                    case "8": // Sammanfatta dagbok
                        if (entries.Count == 0)
                        {
                            Console.WriteLine("Inga anteckningar att sammanfatta.");
                        }
                        else
                        {
                            var firstDate = entries.Min(e => e.Date);
                            var lastDate = entries.Max(e => e.Date);
                            Console.WriteLine($"Antal anteckningar: {entries.Count}");
                            Console.WriteLine($"Första anteckning: {firstDate:yyyy-MM-dd}");
                            Console.WriteLine($"Senaste anteckning: {lastDate:yyyy-MM-dd}");
                        }
                        break;

                    case "0":
                        Console.WriteLine(" Avslutar...");
                        return;

                    default:
                        Console.WriteLine(" Ogiltigt val.");
                        break;
                }

            }
            }
        }
    }
}

  
