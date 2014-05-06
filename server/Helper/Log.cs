
namespace Helpers {
	public delegate void StringDelegate(string text);

	public class Logger {
		public event StringDelegate log;
		protected void Log(string text) {
			StringDelegate handler = log;
			if (handler != null) {
				handler(text);
			}
		}
	}
}
