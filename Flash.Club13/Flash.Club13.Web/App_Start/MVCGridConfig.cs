[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Flash.Club13.Web.MVCGridConfig), "RegisterGrids")]

namespace Flash.Club13.Web
{
    using System;
    using System.Web;
    using System.Web.Mvc;
    using System.Linq;
    using System.Collections.Generic;

    using MVCGrid.Models;
    using MVCGrid.Web;
    using Flash.Club13.Models;
    using Flash.Club13.Data;

    public static class MVCGridConfig
    {
        public static void RegisterGrids()
        {
            MVCGridDefinitionTable.Add("PagingGrid", new MVCGridBuilder<Member>(new ColumnDefaults() { EnableSorting = true})
    .WithAuthorizationType(AuthorizationType.AllowAnonymous)
    .AddColumns(cols =>
    {
        cols.Add("Id").WithSorting(false)
            .WithValueExpression(p => p.Id.ToString());
        cols.Add("FirstName").WithHeaderText("First Name")
            .WithValueExpression(p => p.FirstName);
        cols.Add("LastName").WithHeaderText("Last Name")
            .WithValueExpression(p => p.LastName);
    })
    .WithSorting(true, "LastName")
    .WithPaging(true, 10)
    .WithRetrieveDataMethod((context) =>
    {
        var options = context.QueryOptions;
        var result = new QueryResult<Member>();
        using (var db = new MainDbContext())
        {
            var query = db.Members.AsQueryable();
            result.TotalRecords = query.Count();
            if (!String.IsNullOrWhiteSpace(options.SortColumnName))
            {
                switch (options.SortColumnName.ToLower())
                {
                    case "firstname":
                        if (options.SortDirection == SortDirection.Asc)
                        {
                            query = query.OrderBy(p => p.FirstName);
                        }
                        else if (options.SortDirection == SortDirection.Dsc)
                        {
                            query = query.OrderByDescending(p => p.FirstName);
                        }
                        break;
                    case "lastname":
                        if (options.SortDirection == SortDirection.Asc)
                        {
                            query = query.OrderBy(p => p.LastName);
                        }
                        else if (options.SortDirection == SortDirection.Dsc)
                        {
                            query = query.OrderByDescending(p => p.LastName);
                        }
                        break;
                }
            }
            //if (options.GetLimitOffset().HasValue)
            //{
            //    query = query.Skip(options.GetLimitOffset().Value).Take(options.GetLimitRowcount().Value);
            //}
            result.Items = query.ToList();
        }
        return result;
    })
);
        }
    }
}