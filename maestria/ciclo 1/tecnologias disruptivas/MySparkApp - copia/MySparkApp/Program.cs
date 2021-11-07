using System;
using System.Collections.Generic;
using Microsoft.Spark.Sql;


namespace MySparkApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //leerCSV();
            leerJSON();
        }

        public static void leerJSON()
        {
            SparkSession spark = SparkSession
                .Builder()
                .AppName("word_count_sample")
                .GetOrCreate();
            // A CSV dataset is pointed to by path.
            // The path can be either a single CSV file or a directory of CSV files
            string path = "data/sample_data.csv";

            //Dataset<Row> df = spark.Read().Csv(path);//.csv(path);
            DataFrame df = spark.Read().Csv(path);
            df.Show();
            // +------------------+
            // |               _c0|
            // +------------------+
            // |      name;age;job|
            // |Jorge;30;Developer|
            // |  Bob;32;Developer|
            // +------------------+

            //realizar conteo de nombres con sql
            DataFrame sqlDf = spark.Sql("SELECT * FROM sample_data");
            // Show results
            sqlDf.Show();

            // Stop Spark session
            spark.Stop();
        }

        public static void leerCSV()
        {
            SparkSession spark = SparkSession
                .Builder()
                .AppName("word_count_sample")
                .GetOrCreate();
            // A CSV dataset is pointed to by path.
            // The path can be either a single CSV file or a directory of CSV files
            string path = "data/sample_data.csv";

            //Dataset<Row> df = spark.Read().Csv(path);//.csv(path);
            DataFrame df = spark.Read().Csv(path);
            df.Show();
            // +------------------+
            // |               _c0|
            // +------------------+
            // |      name;age;job|
            // |Jorge;30;Developer|
            // |  Bob;32;Developer|
            // +------------------+

            

            // Read a csv with delimiter, the default delimiter is ","
            //Dataset<Row> df2 = spark.read().option("delimiter", ";").csv(path);
            DataFrame df2 = spark.Read().Option("delimiter", ";").Csv(path);
            df2.Show();
            // +-----+---+---------+
            // |  _c0|_c1|      _c2|
            // +-----+---+---------+
            // | name|age|      job|
            // |Jorge| 30|Developer|
            // |  Bob| 32|Developer|
            // +-----+---+---------+

            // Read a csv with delimiter and a header
            //Dataset<Row> df3 = spark.read().option("delimiter", ";").option("header", "true").csv(path);
            DataFrame df3 = spark.Read().Option("delimiter", ";").Option("header", "true").Csv(path);
            df3.Show();
            // +-----+---+---------+
            // | name|age|      job|
            // +-----+---+---------+
            // |Jorge| 30|Developer|
            // |  Bob| 32|Developer|
            // +-----+---+---------+

            // You can also use options() to use multiple options
            Dictionary<string, string> optionsMap = new Dictionary<string, string>();
            optionsMap.Add("delimiter",";");
            optionsMap.Add("header","true");
            var df4 = spark.Read().Options(optionsMap).Csv(path);

            // "output" is a folder which contains multiple csv files and a _SUCCESS file.
            df3.Write().Csv("output");

            // Read all files in a folder, please make sure only CSV files should present in the folder.
            string folderPath = "data/sample_data.csv";
            DataFrame df5 = spark.Read().Csv(folderPath);
            df5.Show();
            // Wrong schema because non-CSV files are read
            // +-----------+
            // |        _c0|
            // +-----------+
            // |238val_238|
            // |  86val_86|
            // |311val_311|
            // |  27val_27|
            // |165val_165|
            // +-----------+
            // Stop Spark session
            spark.Stop();
        }

        public static void leerTxt()
        {
            Console.WriteLine("Hello World!");
            // Create a Spark session
            SparkSession spark = SparkSession
                .Builder()
                .AppName("word_count_sample")
                .GetOrCreate();

            // Create initial DataFrame
            DataFrame dataFrame = spark.Read().Text("input.txt");

            // Count words
            DataFrame words = dataFrame
                .Select(Functions.Split(Functions.Col("value"), " ").Alias("words"))
                .Select(Functions.Explode(Functions.Col("words"))
                .Alias("word"))
                .GroupBy("word")
                .Count()
                .OrderBy(Functions.Col("count").Desc());

            // Show results
            words.Show();

            // Stop Spark session
            spark.Stop();
        }
    }
}
