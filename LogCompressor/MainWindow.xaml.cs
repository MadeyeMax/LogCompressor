using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace LogCompressor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string outputPath;
        public string rootDirectory;
        List<string> errorKeywordsList = new List<string>();

        public MainWindow()
        {
            InitializeComponent();


        }

        private void SrcBtn_Click(object sender, RoutedEventArgs e)
        {
            CommonOpenFileDialog fileDialog = new CommonOpenFileDialog();

            fileDialog.InitialDirectory = "C:\\";
            fileDialog.IsFolderPicker = true;



            if (fileDialog.ShowDialog() == CommonFileDialogResult.Ok)
                ScrsTxt.Text = fileDialog.FileName;

        }

        private void DestinationBtn_Click(object sender, RoutedEventArgs e)
        {
            CommonOpenFileDialog fileDialog = new CommonOpenFileDialog();

            fileDialog.InitialDirectory = "C:\\";
            fileDialog.IsFolderPicker = true;



            if (fileDialog.ShowDialog() == CommonFileDialogResult.Ok)
                DstnTxt.Text = fileDialog.FileName;


        }

        private void ComBtn_Click(object sender, RoutedEventArgs e)
        {
            rootDirectory = ScrsTxt.Text;
            outputPath = DstnTxt.Text + "\\" + "CompressedOutput.txt";

            //search all files in picked rootdirectory independent from file extension 
            string[] files = Directory.GetFiles(rootDirectory, "*.*", SearchOption.AllDirectories);

            using (StreamWriter outputFile = new StreamWriter(outputPath))
            {
                foreach (string file in files)
                {
                    // Search each fiel for keywords
                    string[] lines = File.ReadAllLines(file);
                    List<string> errorsInFile = new List<string>();

                    foreach (string line in lines)
                    {
                        // search each Line in Files for keyword
                        if (errorKeywordsList.Any(keyword => line.Contains(keyword)))
                        {
                            // adds found line with keyword to new line
                            errorsInFile.Add($"Fehler: {line}");
                        }
                    }

                    // writes each found line in outputfile
                    if (errorsInFile.Count > 0)
                    {
                        //write filename where keyword appear
                        outputFile.WriteLine($"Datei: {file}");
                        //write all found lines with keyword in spesific file
                        outputFile.WriteLine(string.Join(Environment.NewLine, errorsInFile));
                        outputFile.WriteLine(new string('-', 50)); // separator for better reading between files
                    }
                }

                //Console.WriteLine("Durchsuchung abgeschlossen. Ergebnisse wurden in die Ausgabedatei geschrieben.");
            }
        }

        private void kwor_Btn_Click(object sender, RoutedEventArgs e)
        {
            // adds Keywords dfrom textbox to listbox 
            string newKword = kword.Text.Trim();
            if (!string.IsNullOrEmpty(newKword))
            {
                errorKeywordsList.Add(newKword);
                keywordList.Items.Add(newKword);
                kword.Clear();
            }
            // adds the keywords to the list to use it
            foreach (string keyword in keywordList.Items)
            {
                errorKeywordsList.Add(keyword);
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // delte selected keyword
            if (keywordList.SelectedIndex != -1)
            {
                int selectedIndex = keywordList.SelectedIndex;
                errorKeywordsList.RemoveAt(selectedIndex);
                keywordList.Items.RemoveAt(selectedIndex);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
