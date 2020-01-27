// Polymorphism.cpp : This file contains the 'main' function. Program execution begins and ends there.
//
#include <vector>
#include <iostream>
#include "Polymorphism.h"

using namespace std;

class I_Printable {
	friend ostream& operator<<(ostream& os, const I_Printable& obj);

public:
	virtual void print(ostream& os) const = 0;
	virtual ~I_Printable() = default;
};

ostream& operator<<(ostream& os, const I_Printable& obj) {
	obj.print(os);
	return os;
}

class Account : public I_Printable {
	friend ostream& operator<<(ostream& os, const Account& account) {
	};

private:
	static constexpr const char* def_name = "Unnamed Account";
	static constexpr double def_balance = 0.0;

protected:
	string name;
	double balance;

public:
	// Constructors
	Account(string name = def_name, double balance = def_balance)
		: name{ name }, balance{ balance } {
	}

	// Functions
	virtual bool deposit(double amount) {
		if (amount < 0)
		{
			return false;
		}
		else
		{
			balance += amount;
			std::cout << "[Account deposit called with " << amount << " for " << name << "]" << std::endl;
			return true;
		}
	}

	virtual bool withdraw(double amount) {
		if (balance - amount >= 0)
		{
			balance -= amount;
			std::cout << "[Account withdraw called with " << amount << " for " << name << "]" << std::endl;
			return true;
		}
		else
		{
			std::cout << "~Insufficient funds" << std::endl;
			return false;
		}
	}

	virtual double get_balance() const {
		return balance;
	}

	virtual void print(ostream& os) const override {
		os << "Account display [ " << name << " balance: " << balance << " ]";
	}

	virtual ~Account() = default;
};

class Checking : public Account {
private:
	static constexpr const char* def_name = "Unnamed Checking Account";
	static constexpr double def_balance = 0.0;
	static constexpr double def_int_rate = 0.0;

protected:
	double int_rate;

public:
	// Constructors
	Checking(string name = def_name, double balance = def_balance, double int_rate = def_int_rate)
		: Account{ name, balance }, int_rate{ int_rate }{
	}

	// Functions
	virtual bool withdraw(double amount) override {
		if (balance - amount >= 0)
		{
			balance -= amount;
			std::cout << "[Checking Account withdraw called with " << amount << " for " << name << "]" << std::endl;
			return true;
		}
		else
		{
			std::cout << "~Insufficient funds" << std::endl;
			return false;
		}
	}

	virtual void print(ostream& os) const override {
		os << "Checking Account display [ " << name << " balance: " << balance << " ]";
	}
	virtual ~Checking() = default;
};

class Savings : public Account {

private:
	static constexpr const char* def_name = "Unnamed Savings Account";
	static constexpr double def_balance = 0.0;
	static constexpr double def_int_rate = 0.0;

protected:
	double int_rate;

public:
	// Constructors
	Savings(string name = def_name, double balance = def_balance, double int_rate = def_int_rate)
		: Account{ name, balance }, int_rate{ int_rate } {
	}

	// Functions
	virtual bool deposit(double amount) override {
		if (amount < 0)
		{
			return false;
		}
		else
		{
			balance += amount;
			std::cout << "[Savings Account deposit called with " << amount << " for " << name << "]" << std::endl;
			return true;
		}
	}

	virtual bool withdraw(double amount) override {
		if (balance - amount >= 0)
		{
			balance -= amount;
			std::cout << "[Savings Account withdraw called with " << amount << " for " << name << "]" << std::endl;
			return true;
		}
		else
		{
			std::cout << "~Insufficient funds" << std::endl;
			return false;
		}
	}

	virtual void print(ostream& os) const override {
		os << "Savings Account display [ " << name << " balance: " << balance << " ]";
	}
	virtual ~Savings() = default;
};

class Trust : public Savings {

private:
	static constexpr const char* def_name = "Unnamed Trust Account";
	static constexpr double def_balance = 0.0;
	static constexpr double def_int_rate = 0.0;

protected:
	double int_rate;
	int withdrawlsThisYear;

public:
	Trust(string name = def_name, double balance = def_balance, double int_rate = def_int_rate)
		: Savings{ name, balance }, int_rate{ int_rate } {
		withdrawlsThisYear = 0;
	}

	// Functions
	virtual bool deposit(double amount) override {
		if (amount >= 5000.0)
		{
			amount += 50.0;
			std::cout << "Bonus 50.00$ has been added due to deposit larger than $5000.00" << std::endl;
		}
		return Account::deposit(amount);
	}

	virtual bool withdraw(double amount) override {
		if (withdrawlsThisYear < 3)
		{
			if (amount < (balance * 0.2))
			{
				std::cout << "[Trust Account withdrawl called with " << amount << " From " << name << " Account]" << std::endl;
				withdrawlsThisYear++;
				return Account::withdraw(amount);
			}
			else
			{
				std::cout << "Withdrawl amount can't be larger than 20% of the current amount (20% of " << amount << " = " << (balance * 0.2) << ")" << std::endl;
				return false;
			}
		}
		else
		{
			std::cout << "Withdrawl limit for this account has been reached" << std::endl;
			return false;
		}
	}

	virtual void print(ostream& os) const override {
		os << "Trust Account display [ " << name << " balance: " << balance << " ]";
	}
	virtual ~Trust() = default;
};

class Shape {
private:
	//atributes common to all shapes
public:
	virtual void draw() = 0;
	virtual void rotate() = 0;
	virtual ~Shape() = default;
};

class Open_Shape : public Shape { // Abstract class
public:
	virtual ~Open_Shape() = default;
};

class Closed_Shape : public Shape { // Abstract class
public:
	virtual ~Closed_Shape() = default;
};

class Line : public Open_Shape { // Concrete class
public:
	virtual void draw() override {
		cout << "Drawing a line" << endl;
	}
	virtual void rotate() override {
		cout << "Rotating a line" << endl;
	}
	virtual ~Line() = default;
};

class Circle : public Closed_Shape { // Concrete class
public:
	virtual void draw() override {
		cout << "Drawing a circle" << endl;
	}
	virtual void rotate() override {
		cout << "Rotating a circle" << endl;
	}
	virtual ~Circle() = default;;
};

class Square: public Closed_Shape{ // Concrete class
public:
	virtual void draw() override {
		cout << "Drwaing a square" << endl;
	}
	virtual void rotate() override {
		cout << "Rotating a square" << endl;
	}
	virtual ~Square() = default;;
};

void screen_refresh(const vector<Shape*>& shapes) { // reference to a pointer so the program won't copy the vector
	cout << "Refreshing" << endl;
	for (const auto p : shapes) {
		p->draw();
	}
}

void display(const vector<Account*>& accounts) {
	for (const auto& acc : accounts)
	{
		cout << acc << endl;
	}
};

void deposit(vector<Account*>& accounts, double amount) {
	for (auto& acc : accounts)
	{
		if (acc->withdraw(amount))
		{
			std::cout << "~Deposited" << amount << " to " << acc << "\n" << std::endl;
		}
		else
		{
			std::cout << "~Failed Deposit of " << amount << " to " << acc << "\n" << std::endl;
		}
	}
};

void withdrawal(vector<Account*>& accounts, double amount) {
	for (auto& acc : accounts)
	{
		if (acc->withdraw(amount))
		{
			std::cout << "~Withdrew " << amount << " from " << acc << std::endl;
		}
		else
		{
			std::cout << "~Failed Withdrawal of " << amount << " from [" << acc << "]" << std::endl;
		}
	}
};

void Example1()
{
	cout << "Polymorphism Examples" << endl;
	cout << "Pointers" << endl;

	Account* p1 = new Account();
	Account* p2 = new Savings();
	Account* p3 = new Checking();
	Account* p4 = new Trust();

	Account joe;
	Savings S_acc{ "Remi", 3000. };

	cout << "\n ==== Depoist ====" << endl;
	p1->deposit(5000);
	S_acc.deposit(5000);

	cout << "\n ==== Withdraw ====" << endl;

	p1->withdraw(1000);
	p2->withdraw(1000);
	p3->withdraw(1000);
	p4->withdraw(1000);
	S_acc.withdraw(1000);

	cout << "\n ==== Printing classes ====" << endl;

	cout << *p1 << endl;
	cout << *p2 << endl;
	cout << *p3 << endl;
	cout << *p4 << endl;
	cout << S_acc << endl;

	cout << "\n ==== Clean up ====" << endl;
	delete p1;
	delete p2;
	delete p3;
	delete p4;
}

void Example2()
{
	// dynamically call methods from Circle class
	Shape* ptr = new Circle();

	ptr->draw();
	ptr->rotate();

	Shape* s1 = new Circle();
	Shape* s2 = new Line();
	Shape* s3 = new Square();

	vector<Shape*> shapes{ s1, s2, s3 };

	screen_refresh(shapes);

	delete s1;
	delete s2;
	delete s3;
}

int main()
{
	Example1();
	//Example2();
}

// Run program: Ctrl + F5 or Debug > Start Without Debugging menu
// Debug program: F5 or Debug > Start Debugging menu
