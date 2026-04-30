namespace mod10.Models;

public class DbInitializer
{
    public static void Initialize(PetContext context)
    {
        context.Database.EnsureCreated();
        if (context.Pets.Any()) return;
        Pet[] petList = {
            new Pet
            {
                PetName = "小咪",Type="Cat",
                PictureUrl = "cat1.jpg", Owner="MiLord", AdopDate =new DateTime(2020,3,8),
            }, new Pet
            {
                PetName = "哈利",Type="Dog",
                PictureUrl = "dog2.jpg", Owner="HarryLord", AdopDate =new DateTime(2021,4,20),
            }, new Pet
            {
                PetName = "花花",Type="Dog",
                PictureUrl = "dog3.jpg", Owner="FLord", AdopDate =new DateTime(2019,7,1),
            }, new Pet
            {
                PetName = "路卡",Type="Dog",
                PictureUrl = "dog4.jpg", Owner="LuLord", AdopDate =new DateTime(2021,8,18),
            },new Pet
            {
                PetName = "湯圓",Type="Cat",
                PictureUrl = "cat2.jpg", Owner="TonyLord", AdopDate =new DateTime(2022,7,5),
            },new Pet
            {
                PetName = "路可",Type="Mouse",
                PictureUrl = "mouse1.jpg", Owner="RuLord", AdopDate =new DateTime(2020,3,8),
            },new Pet
            {
                PetName = "芝麻",Type="Mouse",
                PictureUrl = "mouse2.jpg", Owner="ZuLord", AdopDate =new DateTime(2020,3,8),
            }
        };

        context.Pets.AddRange(petList);
        context.SaveChanges();
    }

}
