
import findspark
from pyspark.sql import SparkSession

def busqueda():
    findspark.init()

def test1():
    #Lets initialize our sparksession now.

    spark = SparkSession.builder.appName("how to read csv file").getOrCreate()
    #Lets first check the spark version using spark.version.
    spark.version
    df = spark.read.csv('data/sample_data.csv')
    type(df)
    #pyspark.sql.dataframe.DataFrame
    df.show(5)
    df.show(2)
    return
test1()