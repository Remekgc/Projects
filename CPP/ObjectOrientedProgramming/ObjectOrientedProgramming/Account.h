#pragma once
#include <iostream>
#include <string>

class Account
{
private:
	std::string Name;
	float Balance;

public:
	void set_Name(std::string name);
	std::string get_Name();

	void set_Balance(float balance);
	float get_Balance();

	std::string ShowAccountInfo() {
		std::cout << "Account owner: " << Name << "\n Balance: " << Balance << std::endl;
	}
};

