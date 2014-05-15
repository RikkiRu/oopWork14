using System.ServiceModel;
using CommunicationInterface;

namespace CommunicationInterface {
	public enum Commands { LOGIN, ADD_CONSULTER, ADD_FAQ, ADD_THEME, ADD_TARIF, GET_QUESTION, SET_ANSWER, GET_SOME_QUESTIONS }
	[ServiceContract]
	public interface ICommandHandler {
		[OperationContract]
		object GetCommandString(Commands command, object data = null);
	}
}
