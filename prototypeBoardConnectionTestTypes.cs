using System;
using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.Ccr.Core;
using Microsoft.Dss.Core.Attributes;
using Microsoft.Dss.ServiceModel.Dssp;
using Microsoft.Dss.ServiceModel.DsspServiceBase;

using W3C.Soap;

namespace prototypeBoardConnectionTest
{
	public sealed class Contract
	{
		[DataMember]
		public const string Identifier = "http://schemas.tempuri.org/2012/10/prototypeboardconnectiontest.html";
	}
	
	[DataContract]
	public class prototypeBoardConnectionTestState
	{
	}
	
	[ServicePort]
	public class prototypeBoardConnectionTestOperations : PortSet<DsspDefaultLookup, DsspDefaultDrop, Get>
	{
	}
	
	public class Get : Get<GetRequestType, PortSet<prototypeBoardConnectionTestState, Fault>>
	{
		public Get()
		{
		}
		
		public Get(GetRequestType body)
			: base(body)
		{
		}
		
		public Get(GetRequestType body, PortSet<prototypeBoardConnectionTestState, Fault> responsePort)
			: base(body, responsePort)
		{
		}
	}
}


