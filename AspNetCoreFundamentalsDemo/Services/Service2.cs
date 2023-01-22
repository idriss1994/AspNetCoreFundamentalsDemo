namespace AspNetCoreFundamentalsDemo.Services
{
    public sealed class Service2 : IDisposable
    {
        private bool _disposed;

        public void Write(string message)
        {
            Console.WriteLine($"Service2: {message}");
        }
        public void Dispose()
        {
            if (_disposed) return;

            Console.WriteLine("Service2.Dispose");
            _disposed= true;
        }
    }
}
