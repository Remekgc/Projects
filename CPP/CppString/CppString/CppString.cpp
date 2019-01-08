#include "pch.h"
#include <iostream>
#include <string>

using namespace std;

int main()
{
	string s1;
	string s2{ "Frank" };
	string s3{ s2 };
	string s4{ "Frank", 3 }; // Fra
	string s5{ s3, 0, 2 }; // Fr
	string s6(3, 'X'); // XXX
	string s7{ "This is a test" };

	cout << s7.find("This") << "\n" << s7.find("is") << "\n" << s7.find("test") << endl;
	cout << s7.find("is", 4) << endl;
	cout << s7.substr(0, 4); //display from a to b
	cout << s7.erase(0, 5) << endl;
	cout << s2.length() << endl;
	s2 += " Cena";
	cout << s2 << endl;

	string testgetline{}, testcin{};
	cout << "Enter 'John Cena': ";
	getline(cin, testgetline); //getline gets all input with empty spaces until user press enter
	cout << testgetline << endl;
	cout << "Enter 'John Cena': ";
	cin >> testcin;
	cout << testcin << "\n================================"<< endl;

	string word{};
	cin >> word;
	
	string findword{ "My name is John Cena!" };
	size_t position = findword.find(word);
	if (position != string::npos) {
		cout << "Found " << word << " at position: " << position << endl;
	}
	else {
		cout << "Sorry, " << word << " not found" << endl;
	}
	// string.swap(test1, test2); = swap test1 with test2
}
