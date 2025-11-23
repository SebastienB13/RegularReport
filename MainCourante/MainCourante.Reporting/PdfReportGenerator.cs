using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using MainCourante.Core.Models;

namespace MainCourante.Reporting;

public class PdfReportGenerator
{
    public static void GenerateDailyReport(List<EventEntry> events, string outputPath)
    {
        Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Margin(40);

                page.Header().Row(row =>
                {
                    row.RelativeItem().Column(col =>
                    {
                        col.Item().Text("MAIN COURANTE SÛRETÉ").FontSize(20).Bold();
                        col.Item().Text($"Rapport du {DateTime.Now:dd/MM/yyyy}").FontSize(12);
                    });
                });

                page.Content().Table(table =>
                {
                    table.ColumnsDefinition(cols =>
                    {
                        cols.ConstantColumn(80);   // Heure
                        cols.ConstantColumn(120);  // Catégorie
                        cols.RelativeColumn();     // Description
                        cols.ConstantColumn(120);  // Agent
                        cols.RelativeColumn();     // Pièce jointe
                    });

                    table.Header(header =>
                    {
                        header.Cell().Text("Heure").Bold();
                        header.Cell().Text("Catégorie").Bold();
                        header.Cell().Text("Description").Bold();
                        header.Cell().Text("Agent").Bold();
                        header.Cell().Text("Pièce jointe").Bold();
                    });

                    foreach (var e in events)
                    {
                        table.Cell().Text(e.Timestamp.ToString("HH:mm"));
                        table.Cell().Text(e.Category);
                        table.Cell().Text(e.Description);
                        table.Cell().Text(e.AgentName);
                        table.Cell().Text(System.IO.Path.GetFileName(e.AttachmentPath ?? ""));
                    }
                });

                page.Footer().AlignCenter().Text($"Généré le {DateTime.Now:dd/MM/yyyy HH:mm}");
            });
        })
        .GeneratePdf(outputPath);
    }
}
