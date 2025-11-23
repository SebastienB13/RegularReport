using Microsoft.Win32;
using MainCourante.Core.Models;
using MainCourante.Data;

namespace MainCourante.App.Views;

public partial class AddEventWindow : Window
{
    private string? _attachmentFile;
    private string _currentUser;

    public AddEventWindow(string currentUser)
    {
        InitializeComponent();
        _currentUser = currentUser;
    }

    private void AddAttachment_Click(object sender, RoutedEventArgs e)
    {
        var dialog = new OpenFileDialog();
        if (dialog.ShowDialog() == true)
        {
            _attachmentFile = dialog.FileName;
            AttachmentPath.Text = System.IO.Path.GetFileName(_attachmentFile);
        }
    }

    private void Cancel_Click(object sender, RoutedEventArgs e)
    {
        this.Close();
    }

    private void Validate_Click(object sender, RoutedEventArgs e)
    {
        var selectedCategory = (CategoryField.SelectedItem as ComboBoxItem)?.Content?.ToString();

        if (string.IsNullOrWhiteSpace(selectedCategory) ||
            string.IsNullOrWhiteSpace(DescriptionField.Text))
        {
            MessageBox.Show("Veuillez remplir tous les champs.");
            return;
        }

        using var db = new MainCouranteDbContext();

        var entry = new EventEntry
        {
            Category = selectedCategory,
            Description = DescriptionField.Text,
            AgentName = _currentUser,
            Timestamp = DateTime.Now,
            AttachmentPath = _attachmentFile,
            IsLocked = true   // sécurité : l’événement n’est plus modifiable après saisie
        };

        db.Events.Add(entry);
        db.SaveChanges();

        MessageBox.Show("Entrée enregistrée !");
        this.Close();
    }
}
