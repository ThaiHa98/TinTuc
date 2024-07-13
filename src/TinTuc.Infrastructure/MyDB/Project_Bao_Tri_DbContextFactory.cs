﻿using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;




namespace TinTuc.Infrastructure.MyDB
{
    public class Project_Bao_Tri_DbContextFactory : IDesignTimeDbContextFactory<MyDBContext>
    {
        public MyDBContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.jon")
                .Build();
            var connectionString = configuration.GetConnectionString("DB");

            var optionsBuilder = new DbContextOptionsBuilder<MyDBContext>();
            optionsBuilder.UseSqlServer(connectionString);
            return new MyDBContext(optionsBuilder.Options);
        }
    }
}