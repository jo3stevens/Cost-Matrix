using CostMatrix.Core.Domain;

namespace CostMatrix.Core.Service
{
    public interface ISettingService
    {
        Setting Get();
        void Save(Setting setting);
    }
}