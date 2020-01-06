#pragma once
#include "Account.h"

/*
Savings Account is type of Account
Withdraw - same as regular account
Deposit - Amount to deposit will be incremented by (amount * int_rate / 100)
and then the updated amount will be disposited
*/
class Savings_Account : public Account
{
	friend std::ostream& operator<<(std::ostream& os, const Savings_Account& account);

private:
	static constexpr const char* def_name = "Unnamed Savings Account";
	static constexpr double def_balance = 0.0;
	static constexpr double def_int_rate = 0.0;

protected:
	double int_rate;

public:
	/*Savings_Account();
	Savings_Account(double balance, double int_rate);*/
	Savings_Account(std::string name = def_name, double balance = def_balance, double int_rate = def_int_rate);
	~Savings_Account();

	bool deposit(double amount);
	/*void withdrawal(double amount);*/

	//Inherits the Account::withdrawl methods
};

