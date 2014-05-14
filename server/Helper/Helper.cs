using dbLib;

namespace HelpersLib {
	public delegate void StringDelegate(string text);

	public abstract class Logger {
		public event StringDelegate log;
		protected void Log(string text) {
			StringDelegate handler = log;
			if (handler != null) {
				handler(text);
			}
		}
	}
	public abstract class Helper : Logger {
		protected dbBind db;
	}
}
