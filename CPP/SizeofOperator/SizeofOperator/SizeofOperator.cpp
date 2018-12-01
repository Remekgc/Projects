#include "pch.h"
#include <iostream>
#include <climits>

using namespace std;

int main() {
	cout << "Sizeof information:\n" << endl;

	cout << "char: " << sizeof(char) << " bytes" << endl;
	cout << "int: " << sizeof(int) << " bytes" << endl;
	cout << "unsigned int: " << sizeof(unsigned int) << " bytes" << endl;
	cout << "short: " << sizeof(short) << " bytes" << endl;
	cout << "long: " << sizeof(long) << " bytes" << endl;
	cout << "long long: " << sizeof(long long) << " bytes" << endl;
	cout << "============================================" << endl;

	//use climits
	cout << "Minimum values:" << endl;
	cout << "char: " << CHAR_MIN << endl;
	cout << "int: " << INT_MIN << endl;
	cout << "short: " << SHRT_MIN << endl;
	cout << "long: " << LONG_MIN << endl;
	cout << "long long: " << LLONG_MIN << endl;

	cout << "\nMaximum values:" << endl;
	cout << "char: " << CHAR_MAX << endl;
	cout << "int: " << INT_MAX << endl;
	cout << "short: " << SHRT_MAX << endl;
	cout << "long: " << LONG_MAX << endl;
	cout << "long long: " << LLONG_MAX << endl;
	cout << "============================================" << endl;

	cout << "Sizeof Variable" << endl;
	int number {67};
	cout << "number is " << sizeof(number) << " bytes." << endl;
	double dots {12.21};
	cout << "dots is " << sizeof(dots) << " bytes." << endl;
}
