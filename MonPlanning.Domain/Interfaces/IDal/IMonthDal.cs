﻿using MonPlanning.Domain.Dto;
using MonPlanning.Domain.Interfaces.IDao;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MonPlanning.Domain.Interfaces.IDal
{
    public interface IMonthDal
    {
        Task<IReadOnlyCollection<IMonthDao>> GetAllMonthsAsync();

        Task<IMonthDao> GetMonthByIdAsync(MonthDto monthId);
    }
}
