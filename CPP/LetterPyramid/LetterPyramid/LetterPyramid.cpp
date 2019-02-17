#include "pch.h"
#include <iostream>
#include <string>

using namespace std;

int main()
{
	string pyramid{};

	cout << "Write some letters: ";
	cin >> pyramid;

	for (int i{}; i < pyramid.length(); i++) {//from 0 to length of pytamid.
		for (int x{ i }; x < pyramid.length(); x++) {//from place where i ended to length of pyramid(as far as i is the shorter this loop will be)
			cout << " "; //create empty space
		}
		for (int x{}; x < i + 1; x++) { //from 0 to i + 1
			cout << pyramid.at(x); //display items fro m0 to i + 1
		}
		for (int z{ i - 1 }; z < pyramid.length(); z--) { //from i - 1 to length of pyramid(backward loop to display the letters in reverse order starting from second item so it wont repeat in the console.) 
			cout << pyramid.at(z); //displayting the characters in reverse way
		}
		cout << "\n";//create new line
	}
}