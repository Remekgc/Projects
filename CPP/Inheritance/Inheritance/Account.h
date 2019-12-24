#pragma once
#include <iostream>

class Account
{
public:
	friend std::ostream& operator<<(std::ostream& os, const Account& account);

protected:
	double balance;
	std::string name;

public:
	Account();
	~Account();
	Account(double amount);

	void deposit(double amount);
	void withdraw(double amount);

};

