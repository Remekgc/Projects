// OperatorOverloading.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <string>
#include <vector>
#include "MyString.h"
#include "OperatorOverloading.h"

using namespace std;

void mystring()
{
	Mystring empty;
	Mystring Tom("Tom");
	Mystring Jerry(Tom);

	empty.display();
	Tom.display();
	Jerry.display();
}

int main()
{
	Mystring a{ "Hello" };                // overloaded constructor
	Mystring b;                             // no-args contructor
	b = a;                                      // copy assignment 
												  // b.operator=(a)
	b = "This is a test";                 // b.operator=("This is a test");

	Mystring empty;                      // no-args constructor
	Mystring larry("Larry");             // overloaded constructor
	Mystring stooge{ larry };            // copy constructor 
	Mystring stooges;                   // no-args constructor

	empty = stooge;                     // copy assignment operator

	empty.display();                      // Larry : 5
	larry.display();                         // Larry : 5
	stooge.display();                     // Larry : 5
	empty.display();                      // Larry : 5

	stooges = "Larry, Moe, and Curly";
	stooges.display();                              // Larry, Moe, and Curly : 21

	vector<Mystring> stooges_vec;
	stooges_vec.push_back("Larry");
	stooges_vec.push_back("Moe");
	stooges_vec.push_back("Curly");

	cout << "=== Loop 1 ==================" << endl;
	for (const Mystring& s : stooges_vec)
		s.display();                                        // Larry
																// Moe
																//Curly
	cout << "=== Loop 2 ==================" << endl;
	for (Mystring& s : stooges_vec)
		s = "Changed";                              // copy assignment

	cout << "=== Loop 3 ================" << endl;
	for (const Mystring& s : stooges_vec)
		s.display();                                     // Changed
															// Changed
															// Changed


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
