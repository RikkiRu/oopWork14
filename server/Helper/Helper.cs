using dbLib;

namespace HelpersLib {
	public delegate void StringHandler(string text);

	public abstract class Logger {
		public StringHandler log;
		protected Logger(StringHandler log = null) {
			this.log = log;
		}
		protected void Log(string text) {
			if (log != null) {
				log(text);
			}
		}
	}
	public abstract class Helper : Logger {
		protected dbBind db;
		protected Helper(dbBind db, StringHandler log = null) : base(log) {
			this.db = db;
		}
	}
}
