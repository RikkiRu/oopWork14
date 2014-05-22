using System.ServiceModel;
using CommunicationInterface;
using System.IO;

namespace CommunicationInterface {
	[ServiceContract]
	public interface ICommandHandler {
		[OperationContract]
		object GetCommandString(object query, string data = null);
	}
}
