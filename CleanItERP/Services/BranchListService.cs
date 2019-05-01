using System.Collections.Generic;
using CleanItERP.DataModel;

namespace CleanItERP.Services
{
    public class BranchListService : IBranchListService
    {
        private CleanItERPContext Context { get; }
        public BranchListService(CleanItERPContext context)
        {
            this.Context = context;
        }

        public IEnumerable<Branch> GetBranches() => Context.Branches;
    }
}