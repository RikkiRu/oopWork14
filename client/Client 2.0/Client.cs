using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using CommunicationInterface;

namespace Client_2._0 {
	class Client {

		private ICommandHandler service;

		public ICommandHandler Service {
			get {return service;}
		}

		public Client() {
			Uri tcpUri = new Uri("http://localhost:8081/TestService");
			EndpointAddress address = new EndpointAddress(tcpUri);
			BasicHttpBinding binding = new BasicHttpBinding();
			ChannelFactory<ICommandHandler> factory = new ChannelFactory<ICommandHandler>(binding, address);
			service = factory.CreateChannel();
		}
	}
}
