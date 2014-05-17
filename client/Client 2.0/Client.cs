using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using CommunicationInterface;

namespace Client_2._0 {
	public class Client {

		public ICommandHandler service;

		public ICommandHandler Service {
			get {return service;}
		}

		public Client(string remoteAddress) {
			ChannelFactory<ICommandHandler> factory = new ChannelFactory<ICommandHandler>(new BasicHttpBinding(), new EndpointAddress(remoteAddress));
			service = factory.CreateChannel();
		}
	}
}
