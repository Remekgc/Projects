#include <iostream>
#include "Account.h"

Account::Account() :
	balance{ 0.0 }, name{"Anonymous"} {	
}

Account::~Account() {
	std::cout << "Destructor Called for Account" << std::endl;
}

Account::Account(double balance)
	: balance(balance) {

}

void Account::deposit(double amount) {
	balance += amount;
	std::cout << "Account deposit called with " << amount << std::endl;
}

void Account::withdraw(double amount) {
	if (balance - amount >= 0)
	{
		balance -= amount;
		std::cout << "Account withdraw called with " << amount << std::endl;
	}
	else
	{
		std::cout << "Insufficient funds" << std::endl;
	}
}

std::ostream& operator<<(std::ostream& os, const Account& account) {
	os << "Account balance: " << account.balance;
	return os;
}