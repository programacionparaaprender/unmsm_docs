Imports System
Imports System.Collections.Generic
Imports Microsoft.Spark.Sql


Public Class Programa
    Public Sub Main(ByVal args As String())
        leerCSV()
    End Sub

    Public Sub leerJSON()
        Dim spark As SparkSession = SparkSession.Builder().AppName("word_count_sample").GetOrCreate()
        Dim path As String = "data/sample_data.csv"
        Dim df As DataFrame = spark.Read().Csv(path)
        df.Show()
        Dim sqlDf As DataFrame = spark.Sql("SELECT * FROM sample_data")
        sqlDf.Show()
        spark.[Stop]()
    End Sub

    Public Sub leerCSV()
        Dim spark As SparkSession = SparkSession.Builder().AppName("word_count_sample").GetOrCreate()
        Dim path As String = "data/sample_data.csv"
        Dim df As DataFrame = spark.Read().Csv(path)
        df.Show()
        Dim df2 As DataFrame = spark.Read().[Option]("delimiter", ";").Csv(path)
        df2.Show()
        Dim df3 As DataFrame = spark.Read().[Option]("delimiter", ";").[Option]("header", "true").Csv(path)
        df3.Show()
        Dim optionsMap As Dictionary(Of String, String) = New Dictionary(Of String, String)()
        optionsMap.Add("delimiter", ";")
        optionsMap.Add("header", "true")
        Dim df4 = spark.Read().Options(optionsMap).Csv(path)
        df3.Write().Csv("output")
        Dim folderPath As String = "data/sample_data.csv"
        Dim df5 As DataFrame = spark.Read().Csv(folderPath)
        df5.Show()
        spark.[Stop]()
    End Sub

    Public Sub leerTxt()
        Console.WriteLine("Hello World!")
        Dim spark As SparkSession = SparkSession.Builder().AppName("word_count_sample").GetOrCreate()
        Dim dataFrame As DataFrame = spark.Read().Text("input.txt")
        Dim words As DataFrame = dataFrame.[Select](Functions.Split(Functions.Col("value"), " ").[Alias]("words")).[Select](Functions.Explode(Functions.Col("words")).[Alias]("word")).GroupBy("word").Count().OrderBy(Functions.Col("count").Desc())
        words.Show()
        spark.[Stop]()
    End Sub
End Class


Module Program
    Sub Main(args As String())
        Dim prueba As Programa = New Programa
        prueba.leerCSV()
        Console.WriteLine("Hello World!")
    End Sub
End Module
