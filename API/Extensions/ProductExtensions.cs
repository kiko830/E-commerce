using System;
using API.Entities;

namespace API.Extensions;

public static class ProductExtensions
{
    public static IQueryable<Product> Sort(this IQueryable<Product> query, string? orderBy)
    {
        return orderBy switch
        {
            "priceDesc" => query.OrderByDescending(p => p.Price),
            "price" => query.OrderBy(p => p.Price),
            _ => query.OrderBy(p => p.Name)
        };
    }

    public static IQueryable<Product> Search(this IQueryable<Product> query, string? searchTerm)
    {
        if (string.IsNullOrEmpty(searchTerm)) return query;

        var lowerSearchTerm = searchTerm.Trim().ToLower();

        return query.Where(p => p.Name.ToLower().Contains(lowerSearchTerm));
    }

    public static IQueryable<Product> Filter(this IQueryable<Product> query, string? brands, string? types)
    {
        var brandList = new List<string>();
        var typeList = new List<string>();

        if (!string.IsNullOrEmpty(brands))
        {
            brandList.AddRange(brands.ToLower().Split(",").ToList());
        }

        if (!string.IsNullOrEmpty(types))
        {
            typeList = types.ToLower().Split(",").ToList();
        }

        return query.Where(p =>
            (brandList.Count == 0 || brandList.Contains(p.Brand.ToLower())) &&
            (typeList.Count == 0 || typeList.Contains(p.Type.ToLower()))
        );
    }
}
