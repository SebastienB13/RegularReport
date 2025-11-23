private void Login_Click(object sender, RoutedEventArgs e)
{
    using var db = new MainCouranteDbContext();
    var auth = new AuthService(db);

    if (auth.Login(UsernameField.Text, PasswordField.Password))
    {
        MainWindow main = new MainWindow();
        main.Show();
        this.Close();
    }
    else
    {
        MessageBox.Show("Identifiants incorrects");
    }
}
