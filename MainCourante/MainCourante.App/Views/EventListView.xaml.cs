using MainCourante.Data;

namespace MainCourante.App.Views;

public partial class EventListView : Window
{
    public EventListView()
    {
        InitializeComponent();
        LoadEvents();
        CategoryFilter.SelectedIndex = 0;
    }

    private void LoadEvents()
    {
        using var db = new MainCouranteDbContext();
        var data = db.Events.OrderByDescending(e => e.Timestamp).ToList();
        EventsGrid.ItemsSource = data;
    }

    private void FilterChanged(object sender, EventArgs e)
    {
        using var db = new MainCouranteDbContext();
        var query = db.Events.AsQueryable();

        // Filtre date
        if (DateFilter.SelectedDate != null)
        {
            var d = DateFilter.SelectedDate.Value.Date;
            query = query.Where(e => e.Timestamp.Date == d);
        }

        // Filtre catégorie
        var cat = (CategoryFilter.SelectedItem as ComboBoxItem)?.Content?.ToString();
        if (cat != "Toutes")
        {
            query = query.Where(e => e.Category == cat);
        }

        EventsGrid.ItemsSource = query.OrderByDescending(e => e.Timestamp).ToList();
    }
}
