#pragma once
#include "Account.h"

class Checking_Account : public Account
{
	friend std::ostream& operator<<(std::ostream& os, const Checking_Account& account);

private:
	static constexpr const char* def_name = "Unnamed Checking Account";
	static constexpr double def_balance = 0.0;
	static constexpr double def_int_rate = 0.0;

protected:
	double int_rate;
	double fee;

public:
	/*Savings_Account();
	Savings_Account(double balance, double int_rate);*/
	Checking_Account(std::string name = def_name, double balance = def_balance, double int_rate = def_int_rate);

	bool withdrawal(double amount);

	//Inherits the Account::withdraw methods
};

