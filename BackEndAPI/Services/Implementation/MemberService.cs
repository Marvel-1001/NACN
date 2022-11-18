using BackEndAPI.Models;
using BackEndAPI.Services.Contract;
using Microsoft.EntityFrameworkCore;

namespace BackEndAPI.Services.Implementation
{
    public class MemberService : IMemberService
    {
        private readonly NACNContext _dbcontext;

        public MemberService(NACNContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        async Task<List<Member>> IMemberService.GetList()
        {
            try
            {
                List<Member> memberList = new List<Member>();
                memberList = await _dbcontext.Members.Include(dpt => dpt.IdMembertypeNavigation).ToListAsync();
            
                return memberList;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public async Task<Member> Get(int idMember)
        {
            
            try
            {
                Member? memberFound = new Member();
                memberFound = await _dbcontext.Members.Include(dpt => dpt.IdMembertypeNavigation)
                    .Where(e => e.IdMember == idMember)
                    .FirstOrDefaultAsync();


                return memberFound;
            }
             catch (Exception ex)
            {
                throw ex;
            }
        }
        async Task<Member> IMemberService.Add(Member model)
        {
            try
            {
                _dbcontext.Members.Add(model);
                await _dbcontext.SaveChangesAsync();
                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        async Task<Member> IMemberService.Update(Member model)
        {
            try
            {
                _dbcontext.Members.Update(model);
                await _dbcontext.SaveChangesAsync();
                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        async Task<bool> IMemberService.Delete(Member model)
        {
            try
            {
                _dbcontext.Members.Remove(model);
                await _dbcontext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
