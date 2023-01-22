using AspNetCoreFundamentalsDemo.Services.Interfaces;

namespace AspNetCoreFundamentalsDemo.Services
{
    public sealed class Service3 : IService3, IDisposable
    {
        private bool _disposed;

        public string MyKey { get; }

        public Service3(string myKey)
        {
            MyKey = myKey;
        }

        public void Write(string message)
        {
            Console.WriteLine($"Service3: {message}, MyKey: {MyKey}");
        }

        public void Dispose()
        {
            if (_disposed) return;

            Console.WriteLine("Service2.Dispose");
            _disposed= true;
        }
    }
}
