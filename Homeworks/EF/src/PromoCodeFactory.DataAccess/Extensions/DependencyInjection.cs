using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PromoCodeFactory.Core.Common.Interfaces;
using PromoCodeFactory.DataAccess.Persistence;
using System;
using System.IO;

namespace PromoCodeFactory.DataAccess.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            var dbPath = GetDatabasePath("EfUrok.db3");
            EnsureDirectoryExists(dbPath);

            _ = services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlite($"Filename={dbPath}");
            });

            _ = services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

            return services;
        }

        private static string GetDatabasePath(string dbFileName)
        {
            var folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            return Path.Combine(folderPath, dbFileName);
        }

        private static void EnsureDirectoryExists(string dbFilePath)
        {
            var directory = Path.GetDirectoryName(dbFilePath);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }
    }
}
