using BackEndAPI.Models;

namespace BackEndAPI.Services.Contract
{
    public interface IMemberService
    {
        Task<List<Member>> GetList();
        Task<Member> Get(int idMember);
        Task<Member> Add(Member model);
        Task<Member> Update(Member model);
        Task<bool> Delete(Member model);
    }
}
