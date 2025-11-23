private void AddEvent_Click(object sender, RoutedEventArgs e)
{
    var win = new AddEventWindow(currentUser: LoggedUserName);
    win.ShowDialog();
}

private void OpenJournal_Click(object sender, RoutedEventArgs e)
{
    var win = new EventListView();
    win.ShowDialog();
}

private void GenerateReport_Click(object sender, RoutedEventArgs e)
{
    using var db = new MainCouranteDbContext();

    // Récupérer les événements du jour
    var today = DateTime.Now.Date;
    var events = db.Events
                   .Where(ev => ev.Timestamp.Date == today)
                   .OrderBy(e => e.Timestamp)
                   .ToList();

    if (!events.Any())
    {
        MessageBox.Show("Aucun événement pour aujourd'hui.");
        return;
    }

    // Choix du dossier d’export
    var folder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
    var pdfPath = Path.Combine(folder, $"Rapport_MC_{today:ddMMyyyy}.pdf");
    var excelPath = Path.Combine(folder, $"Rapport_MC_{today:ddMMyyyy}.xlsx");

    // Génération PDF
    PdfReportGenerator.GenerateDailyReport(events, pdfPath);

    // Génération Excel
    ExcelReportGenerator.Generate(events, excelPath);

    MessageBox.Show($"Rapport généré :\nPDF : {pdfPath}\nExcel : {excelPath}");
}
