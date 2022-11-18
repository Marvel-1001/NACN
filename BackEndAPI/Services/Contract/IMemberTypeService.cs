using BackEndAPI.Models;

namespace BackEndAPI.Services.Contract
{
    public interface IMemberTypeService
    {
        Task<List<MemberType>> GetList();
    }
}
