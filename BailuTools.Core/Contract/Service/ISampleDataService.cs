using BailuTools.Core.Model;

namespace BailuTools.Core.Contract.Service;

// Remove this class once your pages/features are using your data.
public interface ISampleDataService
{
    Task<IEnumerable<SampleOrder>> GetListDetailsDataAsync();
}
