using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;

namespace SearchInCSV
{
    internal class MyCSV
    {
        public string? FilePath { get; set; }

        public MyCSV(string filePath)
        {
            this.FilePath = filePath;
        }

        public MyCSV()
        {
        }

        public void FindInFileAndShow(int columnIndex, string searchKey)
        {
            try
            {
                if (!String.IsNullOrEmpty(FilePath))
                {
                    bool notFound = true;

                    CsvConfiguration csvConfig = new(CultureInfo.CurrentCulture)
                    {
                        HasHeaderRecord = false
                    };

                    using StreamReader? streamReader = File.OpenText(FilePath);
                    using CsvReader? csvReader = new CsvReader(streamReader, csvConfig);
                    while (csvReader.Read())
                    {
                        bool gotField = csvReader.TryGetField<string>(columnIndex, out string searchColumnValue);

                        if (gotField && searchColumnValue == searchKey)
                        {
                            notFound = false;
                            for (int i = 0; csvReader.TryGetField<string>(i, out string value); i++)
                                Console.Write($"{value} ");
                            Console.WriteLine();
                        }
                    }

                    if (notFound)
                        Console.WriteLine("No data found");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Something Went Wrong 1");
            }
        }
    }
}
