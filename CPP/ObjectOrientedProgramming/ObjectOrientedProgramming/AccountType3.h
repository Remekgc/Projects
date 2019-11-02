#pragma once
#include <iostream>
#include <string>

class AccountType3 {
private:
	std::string Name;
	float Balance;

public:
	//Declaration override:
	AccountType3(std::string name = "None", float balance = 0.0f);

	//Copy constructor:
	AccountType3(const AccountType3& source);

	//AccountType3(const AccountType3& source) : Name{ source.Name }, Balance{ source.Balance } {
	//	std::cout << "Copy construcor" << std::endl;
	//}

	//Destructor:
	~AccountType3() { std::cout << "Destructor called for: " << Name << std::endl; }

	//Functions:
	void set_Name(std::string name);
	std::string get_Name();

	void set_Balance(float balance);
	float get_Balance();

};

