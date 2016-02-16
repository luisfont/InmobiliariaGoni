﻿using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace InmobiliariaGoni.Services
{
    public class CoordService
    {
        private ILogger<CoordService> _logger;

        public CoordService(ILogger<CoordService> logger)
        {
            _logger = logger;
        }

        public async Task<CoordServiceResult> LookupAsync(string location)
        {
            var result = new CoordServiceResult()
            {
                Success = false,
                Message = "Undetermined failure while looking up coordinates"
            };

            var bingKey = Startup.Configuration["AppSettings:BingMapsKey"];
            var encodedName = WebUtility.UrlEncode(location);
            var url = $"http://dev.virtualearth.net/REST/v1/Locations?q={encodedName}&key={bingKey}";

            using (var client = new HttpClient())
            {
                var jsonResult = await client.GetStringAsync(url);

                var results = JObject.Parse(jsonResult);
                var resources = results["resourceSets"][0]["resources"];
                if (!resources.HasValues)
                {
                    result.Message = $"Could not find '{location}' as a location";
                }
                else
                {
                    var confidence = (string)resources[0]["confidence"];
                    if (confidence != "High")
                    {
                        result.Message = $"Could not find a confident match for '{location}' as a location";
                    }
                    else
                    {
                        var coords = resources[0]["geocodePoints"][0]["coordinates"];
                        result.Latitude = (double)coords[0];
                        result.Longitude = (double)coords[1];
                        result.Success = true;
                        result.Message = "Success";
                    }
                }

                return result;
            }
        }
    }
}
