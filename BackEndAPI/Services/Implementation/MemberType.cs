using BackEndAPI.Models;
using BackEndAPI.Services.Contract;
using Microsoft.AspNetCore.Server.Kestrel.Transport.Quic;
using Microsoft.EntityFrameworkCore;

namespace BackEndAPI.Services.Implementation
{
    public class MemberTypeService : IMemberTypeService
    {

        private readonly NACNContext _dbContext;

        public  MemberTypeService(NACNContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<MemberType>> GetList()
        {
            try {
                List<MemberType> membertypeList = new List<MemberType>();
                membertypeList = await _dbContext.MemberTypes.ToListAsync();

                return membertypeList;

            } catch (Exception ex) {
                throw ex;
            }
        }   
    }
}
