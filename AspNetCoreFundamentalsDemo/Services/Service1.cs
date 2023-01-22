namespace AspNetCoreFundamentalsDemo.Services
{
    public sealed class Service1 : IDisposable
    {
        private bool _disposed;

        public void Write(string message)
        {
            Console.WriteLine($"Service1: {message}");
        }
        public void Dispose()
        {
            if (_disposed)
            {
                return;
            }
            Console.WriteLine("Service1.Dispose");
            _disposed = true;
        }
    }
}

