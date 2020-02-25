// SmartPointers.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <memory>
#include <vector>
#include "Account.h"
#include "Trust_Account.h"
#include "Checking_Account.h"
#include "Savings_Account.h"

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

int main()
{
	Test *t1 = new Test { 1000 };
	delete t1;
	unique_ptr<Test> t2{ new Test{100} };
	std::unique_ptr<Test> t3 = make_unique<Test>(1000);
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
