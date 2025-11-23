using OfficeOpenXml;
using OfficeOpenXml.Style;
using MainCourante.Core.Models;

namespace MainCourante.Reporting;

public class ExcelReportGenerator
{
    public static void Generate(List<EventEntry> events, string outputPath)
    {
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

        using var package = new ExcelPackage();
        var sheet = package.Workbook.Worksheets.Add("Rapport");

        // En-têtes
        string[] headers = { "Heure", "Catégorie", "Description", "Agent", "Pièce jointe" };
        for (int i = 0; i < headers.Length; i++)
        {
            sheet.Cells[1, i + 1].Value = headers[i];
            sheet.Cells[1, i + 1].Style.Font.Bold = true;
        }

        // Données
        int row = 2;
        foreach (var e in events)
        {
            sheet.Cells[row, 1].Value = e.Timestamp.ToString("HH:mm");
            sheet.Cells[row, 2].Value = e.Category;
            sheet.Cells[row, 3].Value = e.Description;
            sheet.Cells[row, 4].Value = e.AgentName;
            sheet.Cells[row, 5].Value = System.IO.Path.GetFileName(e.AttachmentPath ?? "");
            row++;
        }

        sheet.Cells.AutoFitColumns();

        package.SaveAs(new FileInfo(outputPath));
    }
}
