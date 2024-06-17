namespace AdventureWorksDSL.Services;
public class ProductService(IDbContextFactory<AdventureWorksDbContext> dbContextFactory, ILogger<ProductService> logger)
{
    [KernelFunction]
    public async Task<IEnumerable<ProductDTO>> SearchProductsByNameAsync(string name)
    {
        logger.LogInformation("Searching for products with name containing '{name}'", name);
        using var dbContext = await dbContextFactory.CreateDbContextAsync();
        return (await dbContext.Products
            .Include(_ => _.ProductModel)
                .ThenInclude(_ => _!.ProductModelProductDescriptionCultures)
                    .ThenInclude(_ => _.ProductDescription)
            .Where(p => EF.Functions.Like(p.Name, $"%{name}%")).ToListAsync())
            .Select(_ => new ProductDTO(_.ProductId, _.Name, _.ProductNumber, 
            _.ProductModel?.ProductModelProductDescriptionCultures.FirstOrDefault()?.ProductDescription.Description ?? ""));
    }
}

public record ProductDTO(int ProductId, string Name, string ProductNumber, string Description);
