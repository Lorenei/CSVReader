using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CSVReaderConsole {

	class CSVReaderClass {

		string [] Arguments;
		string FilePath;
		char CSVChar = ';';
		List<int> FormatList = new List<int>();

		public CSVReaderClass( string [] args ) {
			Arguments = args;

			FilePath = "C:/Users/LoreneiYOGA/Desktop/github/CSVReader/CSVReaderConsole/CSVReaderConsole/Steam.csv";
			if ( !CheckIfArgumentsAreEntered() ) AppExit(1);
			else Console.WriteLine("Arguments specified");

			//FilePath = Arguments [0];
			if ( Arguments.Length > 1 ) CSVChar = Convert.ToChar(Arguments [1]);

			//if(!File.Exists(Arguments[0])) {
			if(!File.Exists(FilePath)) { 
				AppExit( 2 );
			}
			Console.WriteLine("Trying to read file...");

			ReadCSV();
		}

		private bool CheckIfArgumentsAreEntered() {
			return ( Arguments.Length > 0 ) ? true : false;
		}
		private void AppExit(int exitCode = 0) {
			switch(exitCode) {
				case 1:
					Console.WriteLine("No arguments specified.");
					UsageInstructions();
					break;
				case 2:
					Console.WriteLine("Specified file path is incorrect.");
					break;
			}
			Console.WriteLine( "Application shutdown." );		
		}
		private void ReadCSV() {
			using(var fileReader = new StreamReader(FilePath)) {

				List<List<string>> linesList = new List<List<string>>();
				int columnsCount = 0;
				while(!fileReader.EndOfStream) {
					var tempLineValues = fileReader.ReadLine().Split( CSVChar );
					List<string> tempLineValuesList = new List<string>();
					foreach(var singleValue in tempLineValues) {
						tempLineValuesList.Add( singleValue );
						int tempLength = singleValue.Length;
						if ( FormatList.Count() > columnsCount ) {
							if ( FormatList [columnsCount] < tempLength ) {
								FormatList [columnsCount] = tempLength;
							}
						}
						else {
							FormatList.Add( tempLength );
						}
						columnsCount++;
					}
					columnsCount = 0;
					linesList.Add( tempLineValuesList );
				}

				foreach(var line in linesList) {
					//foreach(var column in line) {
					for(int i=0; i<line.Count; i++) {
						
						Console.Write("{0, -" + (FormatList[i]+2) + "}", line[i]);
					}
					Console.WriteLine();
				}
			}
		}
		private void UsageInstructions() {
			Console.WriteLine("\nApplication usage instruction.");
			Console.WriteLine("Please start application like this:");
			Console.WriteLine( "CSVReaderConsole.exe pathToFile [characterToSplit]");
			Console.WriteLine("Where [characterToSplit] is optional and the default value is ';'.\n");
		}
	}
}
