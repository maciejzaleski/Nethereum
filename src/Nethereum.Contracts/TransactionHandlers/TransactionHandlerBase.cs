﻿using Nethereum.Contracts.ContractHandlers;
using Nethereum.Contracts.MessageEncodingServices;
using Nethereum.JsonRpc.Client;
using Nethereum.RPC.Accounts;
using Nethereum.RPC.TransactionManagers;

namespace Nethereum.Contracts.CQS
{
#if !DOTNET35
    public abstract class TransactionHandlerBase<TFunctionMessage> : ContractTransactionHandlerBase
       where TFunctionMessage : FunctionMessage, new()
    {
        protected FunctionMessageEncodingService<TFunctionMessage> FunctionMessageEncodingService { get; set; }

        protected TransactionHandlerBase(IClient client, IAccount account) : base(client, account)
        {
            InitialiseEncodingService();
        }

        private void InitialiseEncodingService()
        {
            FunctionMessageEncodingService = new FunctionMessageEncodingService<TFunctionMessage>();
            FunctionMessageEncodingService.DefaultAddressFrom = GetAccountAddressFrom();
        }

        protected TransactionHandlerBase(ITransactionManager transactionManager) : base(transactionManager)
        {
            InitialiseEncodingService();
        }

        protected void SetEncoderContractAddress(string contractAddress)
        {
            FunctionMessageEncodingService.SetContractAddress(contractAddress);
        }

    }
#endif
}