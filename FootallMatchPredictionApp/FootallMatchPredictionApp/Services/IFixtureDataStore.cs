using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FootallMatchPredictionApp.Services
{
    public interface IFixtureDataStore<Fixture>
    {
        Task<int> AddFixtureAsync(Fixture fixture);
        Task<int> DeleteFixtureAsync(Fixture fixture);
        Task<Fixture> GetFixtureAsync(int id);
        Task<List<Fixture>> GetFixturesAsync(bool forceRefresh = false);
        void RefreshFixturesAsync();
    }
}
