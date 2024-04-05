using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using Deedle;
using Microsoft.Data.Analysis;
using static Deedle.FrameBuilder;
using static Microsoft.FSharp.Core.ByRefKinds;

//update 20240405

public class Program
{
    private static void Main(string[] args)
    {
        // Define data path
        var dataPath = Path.GetFullPath(@"C:\temp_files\20231110_T29_cpu1_trimmed.csv");

        // Load the data into the data frame
        var df = DataFrame.LoadCsv(dataPath, separator: ',', header: false);

        string input = df[0,2].ToString(); // Replace with your actual input string

        // Create a new DataFrame
        var splitData = new DataFrame();

        // Split the input string into 16 columns
        for (int i = 0; i < 16; i++)
        {
            var column = new StringDataFrameColumn($"Column{i + 1}");
            string[] rows = input.Split('\n');
            foreach (string row in rows)
            {
                string value = row.Substring(i * 2, 2);
                column.Append(value);
            }
            splitData.Columns.Add(column);
        }

        // Now 'splitData' contains the split values in 16 columns
        // You can further process or save this dataframe as needed
        Console.WriteLine(splitData.ToString());
    }
}