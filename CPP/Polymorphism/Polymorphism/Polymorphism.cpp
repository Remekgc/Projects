// Polymorphism.cpp : This file contains the 'main' function. Program execution begins and ends there.
//
#include <vector>
#include <iostream>
#include "Polymorphism.h"
#include "I_Printable.h"
#include "Account.h"
#include "Savings_Account.h"
#include "Trust_Account.h"
#include "Checking_Account.h"
#include "Account_Util.h"

using namespace std;
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

void Example1()
{
	cout << "Polymorphism Examples" << endl;
	cout << "Pointers" << endl;

	// Account* p1 = new Account(); // not allowed since it is an abstract class
	Account* p2 = new Savings_Account();
	Account* p3 = new Checking_Account();
	Account* p4 = new Trust_Account();

	// Account joe; // not allowed 
	Savings_Account S_acc{ "Remi", 3000. };

	cout << "\n ==== Depoist ====" << endl;
	p2->deposit(5000);
	S_acc.deposit(5000);

	cout << "\n ==== Withdraw ====" << endl;
	// p1->withdraw(1000);
	p2->withdraw(1000);
	p3->withdraw(1000);
	p4->withdraw(1000);
	S_acc.withdraw(1000);

	cout << "\n ==== Printing classes ====" << endl;
	// cout << *p1 << endl;
	cout << *p2 << endl;
	cout << *p3 << endl;
	cout << *p4 << endl;
	cout << S_acc << endl;

	cout << "\n ==== Clean up ====" << endl;
	// delete p1;
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

void Example3()
{
	//Account joe; //This won't work
	/*Checking_Account c;
	cout << c << endl;

	Savings_Account s{ "Sara", 5000, 2.6 };
	cout << s << endl;
	s.deposit(10000);
	cout << s << endl;
	s.withdraw(10000);
	cout << s << endl;*/

	Account* ptr = new Trust_Account("Leo", 10000, 2.6);

	//cout << ptr << endl; // this will show to where the pointer is pointing(memory address)
	cout << *ptr << endl; // this displays the data at the memory address*/

	Checking_Account Remi{ "Remi", 5000 };
	cout << Remi << endl;

	Account* trust = new Trust_Account("Adrian");
	cout << *trust << endl;

	Account* p1 = new Checking_Account("Agatha", 10000);
	Account* p2 = new Savings_Account("Vignir", 1000);
	Account* p3 = new Trust_Account("James");

	std::vector<Account*> accounts{ p1,p2,p3 };

	display(accounts);
	deposit(accounts, 1000);
	withdraw(accounts, 2000);

	display(accounts);

	delete p1;
	delete p2;
	delete p3;
	delete ptr;
}

int main()
{
	Example1();
	Example2();
	Example3();
}

// Run program: Ctrl + F5 or Debug > Start Without Debugging menu
// Debug program: F5 or Debug > Start Debugging menu
