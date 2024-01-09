using System.Linq;

const string FilePath = @"C:\TextFiles\Marks.txt";
double[] marks = new double[25];
int markCount;

markCount = LoadData(FilePath, marks);
PrintSummary(marks, markCount);


static int LoadData(string filePath, double[] marks)
{
    int numberOfMarks = 0;
    try
    {
        var lines = File.ReadAllLines(filePath);
        for (int i = 0; i < lines.Length; i++)
        {
            marks[i] = double.Parse(lines[i]);
            numberOfMarks++;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error reading from {filePath} with exception {ex.Message}");
    }

    return numberOfMarks - 1;
}

static void PrintSummary(double[] marks, int markCount)
{
    double percentage,
           totalPercentage = 0;
    int numberOfPass = 0,
        numberOfFail = 0;
    Console.WriteLine($"\nQuiz marks: Quiz Total = {marks[0]}");
    Console.WriteLine($"Mark\tPercentage");
    
    for (int i = 1; i <= markCount; i++)
    {
        percentage = marks[i] / marks[0];
        totalPercentage += percentage;
        if ((percentage * 100) >= 50)
        {
            numberOfPass++;
        }
        else
        {
            numberOfFail++;
        }
        Console.WriteLine($"{marks[i],5:F1}\t{percentage,8:P2}");
    }
    Console.WriteLine($"The class average is {(totalPercentage / markCount):P2}");
    Console.WriteLine($"There were {numberOfPass} passes and {numberOfFail} fails.");
}