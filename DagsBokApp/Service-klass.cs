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

        }

        {
           
    }
}
