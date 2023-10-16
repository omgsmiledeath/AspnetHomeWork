using Microsoft.EntityFrameworkCore;

public static class SeedData
{
    public static void AddData(IApplicationBuilder app){
        SiteDbContext cont = app.ApplicationServices.CreateScope()
                                                    .ServiceProvider
                                                    .GetRequiredService<SiteDbContext>();
        if (cont.Database.GetPendingMigrations().Any()){
            cont.Database.Migrate();
        }
        if(!cont.Entries.Any()){
            cont.Entries.AddRange(
                new Entry{
                    Owner = "Test1",
                    Description = "Надо бла бла бла",
                    Date = new DateTime(2023,10,15,10,0,0),
                    Phone = "88005553535"
                },
                new Entry{
                    Owner = "Test2",
                    Description = "Надо бла бла бла",
                    Date = new DateTime(2023,10,15,11,0,0),
                    Phone = "88005553535"
                                    },
                new Entry{
                    Owner = "Test3",
                    Description = "Надо бла бла бла",
                    Date = new DateTime(2023,10,15,18,0,0),
                    Phone = "88005553535"
                                    },
                new Entry{
                    Owner = "Test4",
                    Description = "Надо бла бла бла",
                    Date = new DateTime(2023,10,19,10,0,0),
                    Phone = "88005553535"                },
                new Entry{
                    Owner = "Test5",
                    Description = "Надо бла бла бла",
                    Date = new DateTime(2023,10,15,22,0,0),
                    Phone = "88005553535"
                }
            );
            cont.SaveChanges();
        }
    }
}