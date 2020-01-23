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
};

ostream& operator<<(ostream& os, const I_Printable& obj) {
	obj.print(os);
	return os;
}

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

class Shape {
private:
	//atributes common to all shapes
public:
	virtual void draw() = 0;
	virtual void rotate() = 0;
	virtual ~Shape() {}
};

class Open_Shape : public Shape { // Abstract class
public:
	virtual ~Open_Shape() {}
};

class Closed_Shape : public Shape { // Abstract class
public:
	virtual ~Closed_Shape() {};
};

class Line : public Open_Shape { // Concrete class
public:
	virtual void draw() override {
		cout << "Drawing a line" << endl;
	}
	virtual void rotate() override {
		cout << "Rotating a line" << endl;
	}
	virtual ~Line() {}
};

class Circle : public Closed_Shape { // Concrete class
public:
	virtual void draw() override {
		cout << "Drawing a circle" << endl;
	}
	virtual void rotate() override {
		cout << "Rotating a circle" << endl;
	}
	virtual ~Circle() {};
};

class Square: public Closed_Shape{ // Concrete class
public:
	virtual void draw() override {
		cout << "Drwaing a square" << endl;
	}
	virtual void rotate() override {
		cout << "Rotating a square" << endl;
	}
	virtual ~Square() {};
};

void Example1()
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

void screen_refresh(const vector<Shape*>& shapes) { // reference to a pointer so the program won't copy the vector
	cout << "Refreshing" << endl;
	for (const auto p : shapes) {
		p->draw();
	}
}

int main()
{
	//Example1();

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

// Run program: Ctrl + F5 or Debug > Start Without Debugging menu
// Debug program: F5 or Debug > Start Debugging menu
