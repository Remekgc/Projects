// SmartPointers.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <memory>
#include <vector>
#include "Account.h"
#include "Trust_Account.h"
#include "Checking_Account.h"
#include "Savings_Account.h"
#include "SmartPointers.h"

class Test {
private:
	int data;
public:
	Test() : data{ 0 } { std::cout << "Test constructor (" << data << ")" << std::endl; }
	Test(int data) :data{ data } { std::cout << "Test constructor (" << data << ")" << std::endl; }
	int get_data() const { return data; }
	~Test() { std::cout << "Test destructor(" << data << ")" << std::endl; }
};

using namespace std;

void TestingSmartPointers()
{
	Test* t1 = new Test{ 1000 };
	delete t1;
	unique_ptr<Test> t2{ new Test{ 100 } };
	unique_ptr<Test> t3 = make_unique<Test>(1000);
	unique_ptr<Test> t4;
	t4 = move(t2);
	if (!t2)
	{
		cout << "t1 is nullptr" << endl;
	}
}

void UniquePointers()
{
	unique_ptr<Account> a1 = make_unique<Checking_Account>("Jack", 777);
	cout << *a1 << endl;
	a1->deposit(7000);
	cout << *a1 << endl;

	vector<unique_ptr<Account>> accounts;

	accounts.push_back(make_unique<Checking_Account>("Jace", 1000));
	accounts.push_back(make_unique<Savings_Account>("Victor", 5000, 6.2));
	accounts.push_back(make_unique<Trust_Account>("Jacob", 19000, 4.7));

	for (const auto& acc : accounts) {
		cout << *acc << endl;
	}
}

void SharedPointers() {
	shared_ptr<int> p1{ new int{100} };
	cout << "Use count: " << p1.use_count() << endl;

	shared_ptr<int> p2{ p1 }; // Shared ownership
	cout << "Use count: " << p1.use_count() << endl;

	p1.reset(); // decrement the use_count; p1 is nulled out
	cout << "Use count: " << p1.use_count() << endl;
	cout << "Use count: " << p2.use_count() << endl;
}

int main()
{
	//TestingSmartPointers();
	//UniquePointers();
	SharedPointers();
}

// Run program: Ctrl + F5 or Debug > Start Without Debugging menu
// Debug program: F5 or Debug > Start Debugging menu

// Tips for Getting Started: 
//   1. Use the Solution Explorer window to add/manage files
//   2. Use the Team Explorer window to connect to source control
//   3. Use the Output window to see build output and other messages
//   4. Use the Error List window to view errors
//   5. Go to Project > Add New Item to create new code files, or Project > Add Existing Item to add existing code files to the project
//   6. In the future, to open this project again, go to File > Open > Project and select the .sln file
