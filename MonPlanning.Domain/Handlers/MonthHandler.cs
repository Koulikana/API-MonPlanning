using MonPlanning.Domain.Commands;
using MonPlanning.Domain.Dto;
using MonPlanning.Domain.Interfaces.IDal;
using MonPlanning.Domain.Interfaces.IDao;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MonPlanning.Domain.Handlers
{
    public class MonthHandler
    {
        private IMonthDal _monthDal;

        public MonthHandler(IMonthDal monthDal)
        {
            _monthDal = monthDal;
        }

        public async Task<IMonthDao> HandleAsync(GetMonthByIdCommand command)
        {
            var monthDto = MonthDto.SetMonthId(command.monthId);
            var month = await _monthDal.GetMonthByIdAsync(monthDto);

            return month;
        }
    }
}
