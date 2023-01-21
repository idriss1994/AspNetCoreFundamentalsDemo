namespace AspNetCoreFundamentalsDemo
{
    public class MyDependency : IMyDependency
    {
        public void WriteMessage(string message)
        {
            Console.WriteLine($"MyDependency.WriteMessage called. Message: {message}");
        }
    }
}
