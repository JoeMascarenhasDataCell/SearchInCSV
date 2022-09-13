namespace SearchInCSV
{
    class Program
    {
        static int Main(string[] args)
        {
            try
            {
                if (args.Length != 3)
                {
                    Console.WriteLine("Invalid number of arguements");
                    return 1;
                }

                if (!Int32.TryParse(args[1], out int columnIndex))
                {
                    Console.WriteLine("Column index must be a positive integer");
                    return 1;
                }

                string fileName = args[0];
                string searchKey = args[2];

                if (fileName.Split('.').Last() != "csv")
                {
                    Console.WriteLine("Invalid file type");
                    return 1;
                }

                if (!File.Exists(fileName))
                {
                    Console.WriteLine("File not found");
                    return 1;
                }

                if (columnIndex < 0)
                {
                    Console.WriteLine("Column index must be a positive integer");
                    return 1;
                }

                MyCSV myCSV = new(fileName);
                myCSV.FindInFileAndShow(columnIndex, searchKey);
            }
            catch (Exception)
            {
                Console.WriteLine("Something Went Wrong");
            }
            return 0;
        }
    }
}