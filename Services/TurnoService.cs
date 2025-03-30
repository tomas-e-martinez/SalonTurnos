using Newtonsoft.Json;
using SalonTurnos.Models;

namespace SalonTurnos.Services
{
    public class TurnoService
    {
        private readonly HttpClient _httpClient;

        public TurnoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("http://localhost:5016/api/");
        }

        public async Task<List<Turno>> GetTurnosAsync(bool? disponible, int? salonId)
        {
            var url = "turnos";

            bool firstParameter = true;

            if (disponible.HasValue)
            {
                url += $"?disponible={disponible.Value}";
                firstParameter = false;
            }

            if (salonId.HasValue)
            {
                if (firstParameter)
                {
                    url += $"?salonId={salonId.Value}";
                    firstParameter = false;
                }
                else
                {
                    url += $"&salonId={salonId.Value}";
                }
            }

            var response = await _httpClient.GetStringAsync(url);
            var turnos = JsonConvert.DeserializeObject<List<Turno>>(response);
            return turnos;
        }
    }
}
