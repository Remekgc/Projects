#include "Trust_Account.h"

Trust_Account::Trust_Account(std::string name, double balance, double int_rate)
	: Savings_Account{ name, balance }, int_rate{ int_rate } {
	withdrawlsThisYear = 0;
}

bool Trust_Account::deposit(double amount) {
	if (amount >= 5000.0)
	{
		amount += 50.0;
		std::cout << "Bonus 50.00$ has been added due to deposit larger than $5000.00" << std::endl;
	}
	return Account::deposit(amount);
}

bool Trust_Account::withdrawal(double amount) {
	if (withdrawlsThisYear < 3)
	{
		if (amount < (balance * 0.2))
		{
			std::cout << "[Trust Account withdrawl called with " << amount << " From " << name << " Account]" << std::endl;
			withdrawlsThisYear++;
			return Account::withdrawal(amount);
		}
		else
		{
			std::cout << "Withdrawl amount can't be larger than 20% of the current amount (20% of " << amount << " = " << (balance * 0.2) << ")" << std::endl;
			return false;
		}
	}
	else
	{
		std::cout << "Withdrawl limit for this account has been reached" << std::endl;
		return false;
	}
}

std::ostream& operator<<(std::ostream& os, const Trust_Account& account) {
	os << "Trust Account balance: " << account.balance << " Interest rate: " << account.int_rate;
	return os;
}