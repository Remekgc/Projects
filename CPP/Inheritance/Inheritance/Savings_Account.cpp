#include <iostream>
#include "Savings_Account.h"

Savings_Account::Savings_Account() 
	: Savings_Account{ 0.0, 0.0 } {

}

Savings_Account::Savings_Account(double balance, double int_rate) 
	: Account(balance), int_rate{ int_rate }{

}

Savings_Account::~Savings_Account() {
	std::cout << "Destructor Called for Savings_Account" << std::endl;
}

void Savings_Account::deposit(double amount) {
	amount = amount + (amount * int_rate / 100);
	Account::deposit(amount);
}

/*void Savings_Account::withdraw(double amount) {
	std::cout << "Savings Account withdraw called with " << amount << std::endl;
}*/

std::ostream& operator<<(std::ostream& os, const Savings_Account& account) {
	os << "Savings account balance: " << account.balance << " Interest rate: " << account.int_rate;
	return os;
}