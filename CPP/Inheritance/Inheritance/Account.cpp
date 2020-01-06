#include <iostream>
#include "Account.h"

/*Account::Account() :
	balance{ 0.0 }, name{"Anonymous"} {	
}*/

Account::~Account() {
	//std::cout << "Destructor Called for Account of " + name << std::endl;
}

Account::Account(double balance)
	: balance(balance) {

}

Account::Account(std::string name, double balance)
	: name{ name }, balance{ balance } {

}

bool Account::deposit(double amount) {
	if (amount < 0)
	{
		return false;
	}
	else
	{
		balance += amount;
		std::cout << "[Account deposit called with " << amount << " for " << name << "]" << std::endl;
		return true;
	}
	
}

bool Account::withdrawal(double amount) {
	if (balance - amount >= 0)
	{
		balance -= amount;
		std::cout << "[Account withdraw called with " << amount << " for " << name << "]" << std::endl;
		return true;
	}
	else
	{
		std::cout << "~Insufficient funds" << std::endl;
		return false;
	}
}

double Account::get_balance() const {
	return balance;
}

std::ostream& operator<<(std::ostream& os, const Account& account) {
	os << " Account balance: " << account.balance;
	return os;
}