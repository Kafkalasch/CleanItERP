using System.Collections.Generic;
using CleanItERP.DataModel;
using CleanItERP.DTOs;

namespace CleanItERP.Services
{
    public interface IListBranchesService
    {
        IEnumerable<BranchDto> GetBranches();
    }
}