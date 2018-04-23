Imports System.Drawing
Imports System.Diagnostics
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraReports.UI
' ...


Public Class Form1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles Button1.Click
        ' A path to export a report.
        Dim reportPath As String = "c:\\Test.mht"

        ' Create a report instance.
        Dim report As New XtraReport1()

        ' Get its MHT export options.
        Dim mhtOptions As MhtExportOptions = report.ExportOptions.Mht

        ' Set MHT-specific export options.
        mhtOptions.CharacterSet = "UTF-8"
        mhtOptions.RemoveSecondarySymbols = False
        mhtOptions.Title = "Test Title"

        ' Set the pages to be exported, and page-by-page options.
        mhtOptions.ExportMode = HtmlExportMode.SingleFilePageByPage
        mhtOptions.PageRange = "1, 3-5"
        mhtOptions.PageBorderColor = Color.Blue
        mhtOptions.PageBorderWidth = 3

        ' Export the report to MHT.
        report.ExportToMht(reportPath)

        ' Show the result.
        StartProcess(reportPath)
    End Sub

    ' Use this method if you want to automaically open
    ' the created MHT file in the default program.
    Public Sub StartProcess(ByVal path As String)
        Dim process As New Process()
        Try
            process.StartInfo.FileName = path
            process.Start()
            process.WaitForInputIdle()
        Catch
        End Try
    End Sub
End Class
