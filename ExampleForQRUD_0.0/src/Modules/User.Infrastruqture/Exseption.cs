
using System.ComponentModel.Design;
using Microsoft.Extensions.DependencyInjection;
using User.Domain.Abstractions.PersistenceContracts;
using User.Infrastruqture.Persistence;

namespace User.Infrastruqture;

public static class Exseption
{

    public static IServiceCollection addInfrastructrureModule(this IServiceCollection selectionService)
    {
        if (selectionService == null)
        {
            throw new ArgumentNullException(nameof(selectionService));
        }

        selectionService.AddScoped<IUserRepository, UserDb>();

        return selectionService;
    }


}
