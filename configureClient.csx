#r "MS.IT.Ops.ContractManagement.Agreements.BusinessObjects.dll"
#r "MS.IT.Ops.ContractManagement.Organizations.BusinessObjects.dll"
#r "MS.IT.Ops.Shared.Common.dll"
#r "MS.IT.Ops.ContractManagement.Agreements.Service.IAgreementService.dll"
#r "ContractManagement.Common.dll"

using System;
using System.Threading.Tasks;
using Microsoft.ServiceBus.Messaging;
using System.ServiceModel;
//using MS.IT.Ops.ContractManagement.Agreements.BusinessObjects.dll;
//using MS.IT.Ops.ContractManagement.Organizations.BusinessObjects.dll;
//using MS.IT.Ops.Shared.Common.dll;
//using MS.IT.Ops.ContractManagement.Agreements.Service.IAgreementService.dll;
//using ContractManagement.Common.dll;


public static MS.IT.Ops.ContractManagement.Agreements.Service.IBusinessWorkflowAgentService Configure()
{
    EndpointAddress endpointAdress = new EndpointAddress(new Uri("sb://bookmymealservicemsg-ns.servicebus.windows.net/contractmanagement/"));
    NetTcpRelayBinding tcpBinding = new NetTcpRelayBinding();
    tcpBinding.Name = "NetTcpRelayBinding_IBusinessWorkflowAgentService";    
    tcpBinding.TransactionFlow = false;
    tcpBinding.TransferMode = TransferMode.Buffered;
    tcpBinding.TransactionProtocol = TransactionProtocol.OleTransactions;
    tcpBinding.ListenBacklog = 10;
    tcpBinding.MaxBufferPoolSize = 524288;
    tcpBinding.MaxBufferSize = 2147483647;
    tcpBinding.MaxConnections = 10;
    tcpBinding.MaxReceivedMessageSize = 2147483647;
    tcpBinding.Security.Mode = SecurityMode.Transport;    

    var channel = new ChannelFactory<MS.IT.Ops.ContractManagement.Agreements.Service.IBusinessWorkflowAgentService>(tcpBinding, endpointAdress);
    var client = channel.CreateChannel();
    return client;
}