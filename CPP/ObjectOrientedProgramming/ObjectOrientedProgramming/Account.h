#pragma once
#include <iostream>
#include <string>

class Account
{
private:
	std::string Name;
	float Balance;

public:
	//Different ways of initialization
	Account() {
		Name = "None";
		Balance = 0.0;
	}

	Account(std::string n) {
		Name = n;
		Balance = 0.0;
	}
	
	Account(std::string n, float b) :Name{ n }, Balance{b} {
	}

	void set_Name(std::string name);
	std::string get_Name();

	void set_Balance(float balance);
	float get_Balance();

	void ShowAccountInfo() {
		std::cout << "Account owner: " << Name << "\n Balance: " << Balance << std::endl;
	}
};

