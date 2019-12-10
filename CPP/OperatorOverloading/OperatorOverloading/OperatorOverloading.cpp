// OperatorOverloading.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <string>
#include <vector>
#include "MyString.h"
#include "Mystring2.h"
#include "MyStringV3.h"
#include "OperatorOverloading.h"

using namespace std;

void mystring()
{
	MyString empty;
	MyString Tom("Tom");
	MyString Jerry(Tom);

	empty.display();
	Tom.display();
	Jerry.display();
}

void Example2()
{
	MyString a{ "Hello" };                // overloaded constructor
	MyString b;                             // no-args contructor
	b = a;                                      // copy assignment 
												// b.operator=(a)
	b = "This is a test";                 // b.operator=("This is a test");

	MyString empty;                      // no-args constructor
	MyString larry("Larry");             // overloaded constructor
	MyString stooge{ larry };            // copy constructor 
	MyString stooges;                   // no-args constructor

	empty = stooge;                     // copy assignment operator

	empty.display();                      // Larry : 5
	larry.display();                         // Larry : 5
	stooge.display();                     // Larry : 5
	empty.display();                      // Larry : 5

	stooges = "Larry, Moe, and Curly";
	stooges.display();                              // Larry, Moe, and Curly : 21

	vector<MyString> stooges_vec;
	stooges_vec.push_back("Larry");
	stooges_vec.push_back("Moe");
	stooges_vec.push_back("Curly");

	cout << "=== Loop 1 ==================" << endl;
	for (const MyString& s : stooges_vec)
		s.display();                                        // Larry
															// Moe
															//Curly
	cout << "=== Loop 2 ==================" << endl;
	for (MyString& s : stooges_vec)
		s = "Changed";                              // copy assignment

	cout << "=== Loop 3 ================" << endl;
	for (const MyString& s : stooges_vec)
		s.display();                                     // Changed
														 // Changed
														 // Changed
}

void MystringMoveAssignment()
{
	Mystring2 empty;                      // no-args constructor
	Mystring2 larry("Larry");             // overloaded constructor
	Mystring2 stooge{ larry };            // copy constructor 
	Mystring2 stooges;                   // no-args constructor

	empty = stooge;                     // copy assignment operator
												  // stooge is an l-value

	empty = "Funny";                    // move assignment operator
												  // "Funny" is an r-value

	empty.display();
	larry.display();
	stooge.display();
	empty.display();

	stooges = "Larry, Moe, and Curly";
	stooges.display();

	vector<Mystring2> stooges_vec;
	stooges_vec.push_back("Larry");                // Move constructor
	stooges_vec.push_back("Moe");                // Move constructor
	stooges_vec.push_back("Curly");              // Move constructor    

	cout << "=== Loop 1 ==================" << endl;
	for (const Mystring2& s : stooges_vec)
		s.display();

	cout << "=== Loop 2 ==================" << endl;
	for (Mystring2& s : stooges_vec)
		s = "Changed";                                      // move assignment

	cout << "=== Loop 3 ==================" << endl;
	for (const Mystring2& s : stooges_vec)
		s.display();
}

void OverloadingOperatorsAsMemberFunction() {
	cout << boolalpha << endl;

	Mystring2 larry{ "Larry" };
	Mystring2 moe{ "Moe" };

	Mystring2 stooge = larry;
	larry.display();
	moe.display();

	cout << (larry == moe) << endl;
	cout << (larry == stooge) << endl;

	larry.display();
	Mystring2 larry2 = -larry;
	larry2.display();

	Mystring2 stooges = larry + "Moe";

	Mystring2 two_stooges = moe + " " + "Larry";
	two_stooges.display();

	Mystring2 three_stooges = moe + " " + larry + "Curly";
	three_stooges.display();
}

void OverloadingInsertionAndExtraction()
{
	MyStringV3 larry{ "Larry" };
	MyStringV3 moe{ "Moe" };
	MyStringV3 curly;

	cout << "Enter the third stooge's first name: ";
	cin >> curly;

	cout << "The three stooges are " << larry << ", " << moe << ", and " << curly << endl;

	cout << "\nEnter the three stooges names separated by a space: ";
	cin >> larry >> moe >> curly;

	cout << "The three stooges are " << larry << ", " << moe << ", and " << curly << endl;
}

void FullUsageOfOverloads() {
	cout << boolalpha << endl;
	MyString a{ "frank" };
	MyString b{ "frank" };
	cout << (a == b) << endl;         // true
	cout << (a != b) << endl;           // false

	b = "george";
	cout << (a == b) << endl;         // false
	cout << (a != b) << endl;          // true
	cout << (a < b) << endl;         // true
	cout << (a > b) << endl;          // false

	MyString s1{ "REMI" };
	s1 = -s1;
	cout << s1 << endl;             // remi              

	s1 = s1 + "*****";
	cout << s1 << endl;             // remi*****       

	s1 += "-----";                      // remi*****-----
	cout << s1 << endl;

	MyString s2{ "12345" };
	s1 = s2 * 3;
	cout << s1 << endl;           // 123451234512345

	MyString s3{ "abcdef" };
	s3 *= 5;
	cout << s3 << endl;             // abcdefabcdefabcdefabcdefabcdef

	MyString repeat_string;
	int repeat_times;
	cout << "Enter a string to repeat: " << endl;
	cin >> repeat_string;
	cout << "How many times would you like it repeated? " << endl;
	cin >> repeat_times;
	repeat_string *= repeat_times;
	cout << "The resulting string is: " << repeat_string << endl;

	cout << (repeat_string * 12) << endl;

	repeat_string = "RepeatMe";
	cout << (repeat_string + repeat_string + repeat_string) << endl;

	repeat_string += (repeat_string * 3);
	cout << repeat_string << endl;

	repeat_string = "RepeatMe";
	repeat_string += (repeat_string + repeat_string + repeat_string);


	MyString s = "Remi";
	++s;
	cout << s << endl;                  // Remi

	s = -s;
	cout << s << endl;                  // remi
	MyString result;
	result = ++s;
	cout << s << endl;                  // Remi
	cout << result << endl;           // Remi

	s = "Frank";
	s++;
	cout << s << endl;                  // Remi

	s = -s;
	cout << s << endl;                  // remi
	result = s++;
	cout << s << endl;                  // Remi
	cout << result << endl;           // remi
}

int main()
{
	//mystring();
	//Example2();
	//MystringMoveAssignment();
	//OverloadingOperatorsAsMemberFunction();
	//OverloadingInsertionAndExtraction();
	FullUsageOfOverloads();

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
