# metrics
There are two files consumed as input to the command line tool. The TotalTemp file contains the data that will be calculated; the

Configuration file contains the calculations that will need to be performed.

The TotalTemp file is output that is created by a different tool. It represents values of variables within scenarios across periods. The

TotalTemp file is in the following format:

 Tab-delimited text file.

 .TXT file extension.

 The first line of the file is the header.

 Each subsequent line contains the values for the scenario/variable combination for the periods.

 The scenario is identified by the ScenId column. This column may appear in different locations. The sample data in the

example shows this as the ScenId column. The column will ALWAYS appear before the Value### columns.

 The variable is identified by the VarName column. This column may appear in different locations. The sample data in the

example shows VarName as the second column. The column will ALWAYS appear before the Value### columns.

 The periods are identified by the Value### columns. Once you have found Value000, you can safely assume that

subsequent columns are labeled Value001, Value002, and so on, increasing in order with no gaps between numbers.

The number of scenarios, and the variables within the scenarios, differ from file to file. Also, although a single file will contain the

same number of periods for each row, the number of periods differ from one file to the next.


The Configuration file will instruct your tool about what calculations to perform on which variables and values. The Configuration file is in the following format:
Tab delimited text file.
.TXT file extension.
No header.
Each line contains the variable name, statistic calculation, and period choice, as follows:
Statistic Calculation
MinValue
MaxValue
Average
Period Choice
FirstValue (the value in the first Period - i.e. Value000)
LastValue (the value in the last Period - i.e. ValueNNN)
MinValue (the minimum value in any Period for the scenario/variable combination)
MaxValue (the maximum value in any Period for the scenario/variable combination)
