﻿using Newtonsoft.Json;
using SonarrSharp.Helpers;
using System.Threading.Tasks;

namespace SonarrSharp.Endpoints.Queue
{
    public class Queue : IQueue
    {
        private SonarrClient _sonarrClient;

        public Queue(SonarrClient sonarrClient)
        {
            _sonarrClient = sonarrClient;
        }

        /// <summary>
        /// Gets currently downloading info
        /// </summary>
        /// <returns>Data.Queue[]</returns>
        public async Task<Data.Queue[]> GetQueue()
        {
            var json = await _sonarrClient.GetJson($"/queue");

            if (!string.IsNullOrEmpty(json))
                return JsonConvert.DeserializeObject<Data.Queue[]>(json, JsonHelpers.SerializerSettings);

            return null;
        }
    }
}