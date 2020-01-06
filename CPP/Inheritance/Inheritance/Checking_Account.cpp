#include "Checking_Account.h"

Checking_Account::Checking_Account(std::string name, double balance, double int_rate)
	: Account{ name, balance }, int_rate{ int_rate } {
	fee = 1.5;
}

bool Checking_Account::withdrawal(double amount) {
	std::cout << "[Checking Account withdraw called with " << amount << " - fee(" << fee << ") from " << name << "]" << std::endl;
	amount -= fee;
	return Account::withdrawal(amount);
}

std::ostream& operator<<(std::ostream& os, const Checking_Account& account) {
	os << "Checking Account " << account.balance << " Interest rate: " << account.int_rate;
	return os;
}