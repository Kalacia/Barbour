﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebuggingAndRefactoringTask1
{
    internal class AccountManager
    {
        private readonly IAccountRepository _accountRepository;

        public AccountManager() : this(Startup.BuildContainer())
        {
        }

        public AccountManager(IServiceProvider serviceProvider)
        {
            if (serviceProvider == null)
            {
                throw new ArgumentNullException(nameof(serviceProvider));
            }

            _accountRepository = serviceProvider.GetService<IAccountRepository>() ?? throw new ArgumentNullException(nameof(_accountRepository));
        }

        public void ShowAccountInterface() 
        {
            while (true)
            {
                Console.WriteLine("1. Add Account");
                Console.WriteLine("2. Deposit Money");
                Console.WriteLine("3. Withdraw Money");
                Console.WriteLine("4. Display Account Details");
                Console.WriteLine("5. Exit");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        //AddAccount();
                        break;
                    case "2":
                        //DepositMoney();
                        break;
                    case "3":
                        //WithdrawMoney();
                        break;
                    case "4":
                        //DisplayAccountDetails();
                        break;
                    case "5":
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

    }
}
