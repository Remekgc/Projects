#include "Account_Util.h"
#include <iostream>

void display(const std::vector<Account>& accounts) {
	std::cout << "\n==== Accounts =======================================================\n" << std::endl;
	for (const auto &acc: accounts)
	{
		std::cout << acc << std::endl;
	}
}

void deposit(std::vector<Account>& accounts, double amount) {
	std::cout << "\n=== Dpositing to Accounts ===========================================\n" << std::endl;
	for (auto &acc:accounts)
	{
		if (acc.deposit(amount))
		{
			std::cout << "~Deposited" << amount << " to " << acc << "\n" << std::endl;
		}
		else
		{
			std::cout << "~Failed Deposit of " << amount << " to " << acc << "\n" << std::endl;
		}
	}
}

void withdrawal(std::vector<Account>& accounts, double amount) {
	std::cout << "\n=== Withdrawing from Accounts ================================\n" << std::endl;
	for (auto &acc:accounts)
	{
		if (acc.withdrawal(amount))
		{
			std::cout << "~Withdrew " << amount << " from " << acc << std::endl;
		}
		else
		{
			std::cout << "~Failed Withdrawal of " << amount << " from [" << acc << "]" << std::endl;
		}
	}
}

// Savings_Account

void display(const std::vector<Savings_Account>& accounts) {
	std::cout << "\n==== Saving Accounts =======================================================\n" << std::endl;
	for (const auto& acc : accounts)
	{
		std::cout << acc << std::endl;
	}
}

void deposit(std::vector<Savings_Account>& accounts, double amount) {
	std::cout << "\n=== Dpositing to Saving Accounts ===========================================\n" << std::endl;
	for (auto& acc : accounts)
	{
		if (acc.deposit(amount))
		{
			std::cout << "~Deposited " << amount << " to " << acc << "\n" << std::endl;
		}
		else
		{
			std::cout << "~Failed Deposit of " << amount << " to " << acc << "\n" << std::endl;
		}
	}
}

void withdrawal(std::vector<Savings_Account>& accounts, double amount) {
	std::cout << "\n=== Withdrawing from Saving Accounts ================================\n" << std::endl;
	for (auto& acc : accounts)
	{
		if (acc.withdrawal(amount))
		{
			std::cout << "~Withdrew " << amount << " from " << acc  << "\n" << std::endl;
		}
		else
		{
			std::cout << "~Failed Withdrawal of " << amount << " from " << acc << "\n" << std::endl;
		}
	}
}

// Checking Account

void display(const std::vector<Checking_Account>& accounts) {
	std::cout << "\n==== Checking Account =======================================================\n" << std::endl;
	for (const auto& acc : accounts)
	{
		std::cout << acc << std::endl;
	}
}

void deposit(std::vector<Checking_Account>& accounts, double amount) {
	std::cout << "\n=== Dpositing to Checking Account ===========================================\n" << std::endl;
	for (auto& acc : accounts)
	{
		if (acc.deposit(amount))
		{
			std::cout << "~Deposited " << amount << " to " << acc << "\n" << std::endl;
		}
		else
		{
			std::cout << "~Failed Deposit of " << amount << " to " << acc << "\n" << std::endl;
		}
	}
}

void withdrawal(std::vector<Checking_Account>& accounts, double amount) {
	std::cout << "\n=== Withdrawing from Checking Account ================================\n" << std::endl;
	for (auto& acc : accounts)
	{
		if (acc.withdrawal(amount))
		{
			std::cout << "~Withdrew " << amount << " from " << acc << "\n" << std::endl;
		}
		else
		{
			std::cout << "~Failed Withdrawal of " << amount << " from " << acc << "\n" << std::endl;
		}
	}
}

// Trust Account

void display(const std::vector<Trust_Account>& accounts) {
	std::cout << "\n==== Trust Account =======================================================\n" << std::endl;
	for (const auto& acc : accounts)
	{
		std::cout << acc << std::endl;
	}
}

void deposit(std::vector<Trust_Account>& accounts, double amount) {
	std::cout << "\n=== Dpositing to Trust Account ===========================================\n" << std::endl;
	for (auto& acc : accounts)
	{
		if (acc.deposit(amount))
		{
			std::cout << "~Deposited " << amount << " to " << acc << "\n" << std::endl;
		}
		else
		{
			std::cout << "~Failed Deposit of " << amount << " to " << acc << "\n" << std::endl;
		}
	}
}

void withdrawal(std::vector<Trust_Account>& accounts, double amount) {
	std::cout << "\n=== Withdrawing from Trust Accounts ================================\n" << std::endl;
	for (auto& acc : accounts)
	{
		if (acc.withdrawal(amount))
		{
			std::cout << "~Withdrew " << amount << " from " << acc << "\n" << std::endl;
		}
		else
		{
			std::cout << "~Failed Withdrawal of " << amount << " from " << acc << "\n" << std::endl;
		}
	}
}
