using System.Text.Json;

namespace DagsBokApp
{

    public class DiaryService
    {
        private readonly string filePath;
        private readonly string errorLogPath = "errorlog.txt";

        public DiaryService(string filePath)
        {
            this.filePath = filePath;
        }

        public void Save(List<DiaryEntry> entries)
        {
            try
            {
                string json = JsonSerializer.Serialize(entries, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(filePath, json);
            }
        catch (Exception ex)
        {
                LogError(ex);
                Console.WriteLine("Kunde inte spara filen.");
            }
        }

        public List<DiaryEntry> Load()
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    Console.WriteLine("Ingen fil hittades – en ny dagbok skapas.");
                    return new List<DiaryEntry>();
                }

                string json = File.ReadAllText(filePath);
                return JsonSerializer.Deserialize<List<DiaryEntry>>(json) ?? new List<DiaryEntry>();
            }
            catch (Exception ex)
            {
                LogError(ex);
                Console.WriteLine(" Kunde inte läsa in filen (felaktigt format?).");
                return new List<DiaryEntry>();
            }
        }

        private void LogError(Exception ex)
        {
            File.AppendAllText(errorLogPath, $"{DateTime.Now}: {ex.Message}{Environment.NewLine}");
        }
    }
}


