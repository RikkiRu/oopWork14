using System.ServiceModel;
using CommunicationInterface;

namespace CommunicationInterface {
	public enum Commands { LOGIN, ADD_CONSULTER, SHOW_CONSULTER, ADD_FAQ, SHOW_FAQ, ADD_THEME, SHOW_THEME, ADD_TARIF, SHOW_TARIF, GET_QUESTION, SET_ANSWER, GET_SOME_QUESTIONS }
	[ServiceContract]
	public interface ICommandHandler {
		[OperationContract]
		object GetCommandString(Commands command, string data = null);
	}
}
