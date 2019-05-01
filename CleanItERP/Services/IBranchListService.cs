using System.Collections.Generic;
using CleanItERP.DataModel;

namespace CleanItERP.Services
{
    public interface IBranchListService
    {
        IEnumerable<Branch> GetBranches();
    }
}