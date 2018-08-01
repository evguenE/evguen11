using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls; //For SortBy method

namespace MvcApp_Megapolis_test
{
    public class ResultSet
    {
        public List<Transport> GetResult(string search, string sortOrder, int start, int length, List<Transport> dtResult, List<string> columnFilters)
        {
            return FilterResult(search, dtResult, columnFilters).SortBy(sortOrder).Skip(start).Take(length).ToList();
        }

        public int Count(string search, List<Transport> dtResult, List<string> columnFilters)
        {
            return FilterResult(search, dtResult, columnFilters).Count();
        }

        private IQueryable<Transport> FilterResult(string search, List<Transport> dtResult, List<string> columnFilters)
        {
            IQueryable<Transport> results = dtResult.AsQueryable();

            results = results.Where(p => (search == null || (p.rout != null && p.rout.ToLower().Contains(search.ToLower()) || p.timeDep != null && p.timeDep.ToLower().Contains(search.ToLower())
                || p.timeArr != null && p.timeArr.ToLower().Contains(search.ToLower()) || p.stop != null && p.stop.ToLower().Contains(search.ToLower())
                ))
                && (columnFilters[0] == null || (p.rout != null && p.rout.ToLower().Contains(columnFilters[0].ToLower())))
                && (columnFilters[1] == null || (p.timeDep != null && p.timeDep.ToLower().Contains(columnFilters[1].ToLower())))
                && (columnFilters[2] == null || (p.timeArr != null && p.timeArr.ToLower().Contains(columnFilters[2].ToLower())))
                && (columnFilters[3] == null || (p.stop != null && p.stop.ToLower().Contains(columnFilters[3].ToLower())))                
                );

            return results;
        }


    }
}