namespace PracticingCleanCode.Models;

using System;

public class CouplersExampleBetter
{
    public interface IDataStorage
    {
        string GetData();
    }

    public class DatabaseStorage : IDataStorage
    {
        public string GetData()
        {
            return "Some data from database";
        }
    }

    public class FileStorage : IDataStorage
    {
        public string GetData()
        {
            return "Some data from file";
        }
    }

    public class DataProcessor
    {
        private IDataStorage _dataStorage;

        public DataProcessor(IDataStorage dataStorage)
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
            IDataStorage storage = new DatabaseStorage(); // or FileStorage()
            DataProcessor processor = new DataProcessor(storage);
            processor.ProcessData();
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Client client = new Client();
            client.DoSomething();
        }
    }
}
