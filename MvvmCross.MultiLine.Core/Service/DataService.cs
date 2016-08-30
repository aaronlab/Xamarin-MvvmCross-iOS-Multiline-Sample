using MvvmCross.MultiLine.Core.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MvvmCross.MultiLine.Core.Service
{
    public class DataService : IDataService
    {
        public async Task<List<SampleData>> GetSampleData()
        {
            List<SampleData> data = null;
            try
            {
                string resourcePath = "MvvmCross.MultiLine.Core.Mock.sample_data_one.json";
                var assembly = typeof(DataService).GetTypeInfo().Assembly;
                string json = string.Empty;
                using (var stream = assembly.GetManifestResourceStream(resourcePath))
                {
                    using (var sr = new StreamReader(stream))
                    {
                        json = await sr.ReadToEndAsync();
                    }
                }
                if (json != string.Empty)
                {
                    data = JsonConvert.DeserializeObject<List<SampleData>>(json);
                    return data;
                }

            }
            catch (Exception ex)
            {
            }
            return new List<SampleData>();
        }
    }
}
