using System.Collections.Generic;
using System.Linq;
using CleanItERP.DataModel;
using CleanItERP.DTOs;

namespace CleanItERP.Services
{
    public class ListBranchesService : IListBranchesService
    {
        private CleanItERPContext Context { get; }
        public ListBranchesService(CleanItERPContext context)
        {
            this.Context = context;
        }

        public IEnumerable<BranchDto> GetBranches(){
            var dtos = Context.Branches.Select(
                branch => BranchDto.CreateFromBranch(branch)
            );
            return dtos;
        } 
    }
}