using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVReaderConsole {
	class CSVReaderClass {
		string [] Arguments;
		public CSVReaderClass( string [] args ) {
			Arguments = args;
			if ( checkIfArgumentsAreEntered() ) Console.WriteLine( "Są argumenty" );
			else Console.WriteLine( "Brak argumentów" );
		}

		private bool checkIfArgumentsAreEntered() {
			return ( Arguments.Length > 0 ) ? true : false;
		}
		private void appExit() {
			Console.WriteLine( "Application shutdown." );
			
		}
	}
}
