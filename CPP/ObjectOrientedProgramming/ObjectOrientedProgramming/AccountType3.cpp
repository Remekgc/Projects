#include "AccountType3.h"

AccountType3::AccountType3(std::string name, float balance) : Name{ name }, Balance{ balance }{
	std::cout << "\n 2-args constructor" << std::endl;
}

AccountType3::AccountType3(const AccountType3& source) 
	//: Name{ source.Name }, Balance{ source.Balance }
	: AccountType3{source.Name, source.Balance} {
	std::cout << "\nCopy constructor - made copy of: " << source.Name << std::endl;
}

void AccountType3::set_Name(std::string name) {
	Name = name;
}

std::string AccountType3::get_Name() {
	return Name;
}

void AccountType3::set_Balance(float bal) {
	Balance = bal;
}

float AccountType3::get_Balance() {
	return Balance;
}