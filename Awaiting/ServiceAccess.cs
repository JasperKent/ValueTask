namespace Awaiting
{
    public class ServiceAccess : IServiceAccess
    {
        private string? _cache;

        public async ValueTask<string> GetDataAsync()
        {
            if (_cache == null)
            {
                var client = new HttpClient();

                var response = await client.GetAsync(new Uri("https://jasperkent.com"));

                _cache = await response.Content.ReadAsStringAsync();
            }

            return _cache;
        }
    }
}
