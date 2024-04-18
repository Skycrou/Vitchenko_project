using System;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using Nethereum.Contracts;
using Nethereum.Hex.HexTypes;
using Nethereum.Util;

namespace ConsoleApp2
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
			string contractAbi = @"[
	{
		""inputs"": [],
		""name"": ""payForItem"",
		""outputs"": [],
		""stateMutability"": ""payable"",
		""type"": ""function""
	},
	{
		""inputs"": [],
		""stateMutability"": ""nonpayable"",
		""type"": ""constructor""
	},
	{
		""inputs"": [],
		""name"": ""withdrawAll"",
		""outputs"": [],
		""stateMutability"": ""nonpayable"",
		""type"": ""function""
	},
	{
		""inputs"": [],
		""name"": ""owner"",
		""outputs"": [
			{
				""internalType"": ""address"",
				""name"": """",
				""type"": ""address""
			}
		],
		""stateMutability"": ""view"",
		""type"": ""function""
	},
	{
		""inputs"": [
			{
				""internalType"": ""address"",
				""name"": """",
				""type"": ""address""
			}
		],
		""name"": ""payments"",
		""outputs"": [
			{
				""internalType"": ""uint256"",
				""name"": """",
				""type"": ""uint256""
			}
		],
		""stateMutability"": ""view"",
		""type"": ""function""
	}
]";
            var account = new Account("0xcd51db45a1d13a592687b1b1526a34ee0ef7be9bb839ebcf365ded95b8768c75"); //адрес покупателя
            var web3 = new Web3(account, "http://127.0.0.1:7545");

            var contract = web3.Eth.GetContract(contractAbi, "0x135593BfCFb68f93C3355eDB9D176A94F470df4F"); //адрес смарт-контракта
            var address_owner = "0xA7103bbdE0a71873423dA428b9C022Ca17bC60d7"; //адрес клиента. Списание с этого адр
            //var payForItemFunction = contract.GetFunction("payForItem");
            //var maxFeePerGas = Web3.Convert.ToWei(5, UnitConversion.EthUnit.Gwei); // Установите вашу максимальную комиссию
            //var maxPriorityFeePerGas = Web3.Convert.ToWei(1, UnitConversion.EthUnit.Gwei); // Установите вашу максимальную приоритетную комиссию
            //var transactionInput = payForItemFunction.CreateTransactionInput(address_owner,
            //   new Nethereum.Hex.HexTypes.HexBigInteger(90000), new Nethereum.Hex.HexTypes.HexBigInteger(9000000000000000000),
            //   new Nethereum.Hex.HexTypes.HexBigInteger(maxFeePerGas), new Nethereum.Hex.HexTypes.HexBigInteger(maxPriorityFeePerGas));
            //var transactionHash = await web3.Eth.Transactions.SendTransaction.SendRequestAsync(transactionInput);

            //Console.WriteLine($"Transaction Hash: {transactionHash}");
            // выводим баланс кошелька
            //try
            //{
            //    var walletAddress = "0x135593BfCFb68f93C3355eDB9D176A94F470df4F"; //адрес кошелька владельца
            //    var balance = await web3.Eth.GetBalance.SendRequestAsync(walletAddress);
            //    var balanceInEther = Web3.Convert.FromWei(balance);
            //    Console.WriteLine($"Баланс кошелька {walletAddress}: {balanceInEther} ETH");
            //    Console.ReadLine();
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"Ошибка: {ex.Message}");
            //    Console.ReadLine();
            //}
            //выводим баланс кошелька

            // Вызываем функцию withdrawAll
            var withdrawAllFunction = contract.GetFunction("withdrawAll");
            var withdrawAllTransactionInput = withdrawAllFunction.CreateTransactionInput("0x5D21d895685d49a66F386E0d91C0259D7ED9D6E5");
            var withdrawAllTransactionHash = await web3.Eth.Transactions.SendTransaction.SendRequestAsync(withdrawAllTransactionInput);
            Console.WriteLine($"WithdrawAll Transaction Hash: {withdrawAllTransactionHash}");

            Console.WriteLine($"Transaction Hash for withdrawAll: {withdrawAllTransactionHash}");
            Console.ReadLine();
        }
		static string GetContractAbi()
        {
            // Замените на ABI вашего смарт-контракта
            return @"[ABI_JSON_STRING]";
        }
    }
}
