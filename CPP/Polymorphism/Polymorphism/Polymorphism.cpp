// Polymorphism.cpp : This file contains the 'main' function. Program execution begins and ends there.
//
#include <vector>
#include <iostream>

using namespace std;

class Account {
public:
	virtual void withdraw(double amount) const {
		cout << "In Account::withdraw" << endl;
	}
	virtual ~Account() { cout << "Account::destructor" << endl; }
};

class Checking : public Account {
public:
	virtual void withdraw(double amount) const override {
		cout << "In Checking::withdraw" << endl;
	}
	virtual ~Checking() { cout << "Checking::destructor" << endl; }
};

class Savings : public Account {
public:
	virtual void withdraw(double amount) const override {
		cout << "In Savings::withdraw" << endl;
	}
	virtual ~Savings() { cout << "Savings::destructor" << endl; }
};

class Trust : public Account {
public:
	virtual void withdraw(double amount) const override {
		cout << "In Trust::withdraw" << endl;
	}
	virtual ~Trust() { cout << "Trust::destructor" << endl; }
};

int main()
{
	cout << "Polymorphism Examples" << endl;
	cout << "Pointers" << endl;

	Account* p1 = new Account();
	Account* p2 = new Savings();
	Account* p3 = new Checking();
	Account* p4 = new Trust();

	p1->withdraw(1000);
	p2->withdraw(1000);
	p3->withdraw(1000);
	p4->withdraw(1000);

	cout << "\n ==== Clean up ====" << endl;
	delete p1;
	delete p2;
	delete p3;
	delete p4;

}

// Run program: Ctrl + F5 or Debug > Start Without Debugging menu
// Debug program: F5 or Debug > Start Debugging menu
