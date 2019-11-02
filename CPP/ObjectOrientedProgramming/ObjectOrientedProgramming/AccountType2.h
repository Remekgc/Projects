#pragma once
#include <iostream>
#include <string>

class AccountType2 {
private:
	std::string Name;
	float Balance;
public:
	AccountType2();
	AccountType2(std::string name);
	AccountType2(std::string name, float balance);
};

