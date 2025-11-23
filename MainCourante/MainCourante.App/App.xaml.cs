using(var db = new MainCouranteDbContext())
{
    db.Database.Migrate();

    if (!db.Users.Any())
    {
        db.Users.Add(new User
        {
            Username = "PC SURETE",
            PasswordHash = AuthService.Hash("PCsurete")
        });

        db.SaveChanges();
    }
}
