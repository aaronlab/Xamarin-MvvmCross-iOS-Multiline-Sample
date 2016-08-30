using MvvmCross.MultiLine.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmCross.MultiLine.Core.Service
{
    public interface IDataService
    {
       Task<List<SampleData>> GetSampleData();
    }
}
