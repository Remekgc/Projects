#pragma once
#include <iostream>

class Account
{
friend std::ostream& operator<<(std::ostream& os, const Account& account);

private:
	static constexpr const char* def_name = "Unnamed Account";
	static constexpr double def_balance = 0.0;

protected:
	std::string name;
	double balance;
	
public:
	//Account();
	~Account();
	Account(double amount);
	Account(std::string name = def_name, double balance = def_balance);
	//Account(std::string anme = "Unamed Account", double balance = 0.0);

	bool deposit(double amount);
	bool withdrawal(double amount);
	double get_balance() const;
};

