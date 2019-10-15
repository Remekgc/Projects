#include "Account.h"

void Account::set_Name(std::string name) {
	Name = name;
}

std::string Account::get_Name() {
	return Name;
}

void Account::set_Balance(float bal) {
	Balance = bal;
}

float Account::get_Balance() {
	return Balance;
}
