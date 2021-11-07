### referencias
https://dotnet.microsoft.com/apps/data/spark
https://dotnet.microsoft.com/learn/data/spark-tutorial/create
http://spark.apache.org/docs/latest/sql-data-sources-csv.html
https://www.dotnetperls.com/hashmap
https://docs.microsoft.com/es-es/dotnet/spark/?WT.mc_id=dotnet-35129-website
https://github.com/dotnet/spark#get-started
https://docs.microsoft.com/es-es/dotnet/spark/?WT.mc_id=dotnet-35129-website
https://github.com/dotnet/spark#samples
https://sparktutorials.github.io/2015/11/08/spark-websocket-chat.html
https://sparktutorials.github.io/2015/04/02/setting-up-a-spark-project-with-maven.html

### crear proyecto
mkdir MySparkApp
cd MySparkApp
dotnet new console -f netcoreapp3.1 -o MySparkApp
dotnet sln add .\MySparkApp\MySparkApp.csproj
cd MySparkApp
dotnet add package Microsoft.Spark --version 1.0.0

### página de descarga de spark
https://archive.apache.org/dist/spark/spark-3.0.1/

### instalar en dotnet
spark-submit --version


setx /M HADOOP_HOME C:\bin\spark-3.0.1-bin-hadoop2.7\
setx /M SPARK_HOME C:\bin\spark-3.0.1-bin-hadoop2.7\
setx /M PATH "%PATH%;%HADOOP_HOME%;%SPARK_HOME%\bin" # Warning: Don't run this if your path is already long as it will truncate your path to 1024 characters and potentially remove entries!
setx /M DOTNET_WORKER_DIR "C:\bin\Microsoft.Spark.Worker-1.0.0"

### proyecto c#
dotnet build
spark-submit --class org.apache.spark.deploy.dotnet.DotnetRunner --master local bin\Debug\netcoreapp3.1\microsoft-spark-3-0_2.12-1.0.0.jar dotnet bin\Debug\netcoreapp3.1\MySparkApp.dll

### proyecto vb.net
dotnet build
spark-submit --class org.apache.spark.deploy.dotnet.DotnetRunner --master local bin\Debug\netcoreapp3.1\microsoft-spark-3-0_2.12-1.0.0.jar dotnet bin\Debug\netcoreapp3.1\MySparkBasic.dll

### error en spark
