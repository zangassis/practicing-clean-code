namespace PracticingCleanCode.Models;

using System;

public class CouplersExample
{
    public class DataStorage
    {
        public string GetData()
        {
            return "Some data from database";
        }
    }

    public class DataProcessor
    {
        private DataStorage _dataStorage;

        public DataProcessor(DataStorage dataStorage)
        {
            _dataStorage = dataStorage;
        }

        public void ProcessData()
        {
            string data = _dataStorage.GetData();

            Console.WriteLine("Processing data: " + data);
        }
    }

    public class Client
    {
        public void DoSomething()
        {
            DataStorage storage = new DataStorage();
            DataProcessor processor = new DataProcessor(storage);
            processor.ProcessData();
        }
    }

    public static void Main(string[] args)
    {
        Client client = new Client();
        client.DoSomething();
    }
}
