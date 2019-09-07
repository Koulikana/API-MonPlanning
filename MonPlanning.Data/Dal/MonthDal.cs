using Dapper;
using MonPlanning.Domain.Dto;
using MonPlanning.Domain.Interfaces.IDal;
using MonPlanning.Domain.Interfaces.IDao;
using MonPlanning.Infrastructure.Dao;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MonPlanning.Infrastructure.Dal
{
    public class MonthDal : IMonthDal
    {
        private readonly Func<IDbConnection> _connectionProvider;

        public MonthDal(Func<IDbConnection> connectionProvider)
        {
            _connectionProvider = connectionProvider;
        }

        /// <summary>
        /// Gets a list of all months
        /// </summary>
        /// <returns>A new instance of <see cref="IEnumerable{IMonthDao}"/></returns>
        public async Task<IReadOnlyCollection<IMonthDao>> GetAllMonthsAsync()
        {
            IEnumerable<IMonthDao> months = null;

            using (var connection = _connectionProvider())
            {
                months = await connection.QueryAsync<MonthDao>(
                    MonthsQueries.GetAllMonths,
                    commandType: CommandType.StoredProcedure
                    ).ConfigureAwait(false);

            }

            return months.ToList();
        }

        /// <summary>
        /// Gets a months by its identifiyer
        /// </summary>
        /// <returns>A new instance of <see cref="IMonthDao"/></returns>
        public async Task<IMonthDao> GetMonthByIdAsync(MonthDto monthDto)
        {
            IMonthDao month = null;

            using(var connection = _connectionProvider())
            {
                month = await connection.QueryFirstAsync<MonthDao>(
                    MonthsQueries.GetMonthById,
                    new { monthID = monthDto.MonthId },
                    commandType: CommandType.StoredProcedure
                    ).ConfigureAwait(false);
            }

            return month;
        }

        public static class MonthsQueries
        {
            internal const string GetAllMonths = "ps_month_select_all";
            internal const string GetMonthById = "ps_month_select_by_monthid";
        }
    }
}
