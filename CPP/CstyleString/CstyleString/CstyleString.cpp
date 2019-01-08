#include "pch.h"
#include <iostream>
#include <cstring>
#include <cctype>

using namespace std;

int main()
{
	char first_name[20]{};
	char last_name[20]{};
	char full_name[50]{};
	char temp[50]{};

	cout << "First name: ";
	cin.getline(first_name, 50);

	cout << "Last name: ";
	cin >> last_name;

	cout << "Hello, " << first_name << " " << last_name << " your name has " << strlen(first_name) + strlen(last_name) << " characters" << endl;
	//strlen() is size_t 

	strcpy_s(full_name, first_name);//copy first_name to full_name
	strcat_s(full_name, " ");//add space to full name
	strcat_s(full_name, last_name); //copy last name to full_name

	cout << "Your name is: " << full_name << endl;

	strcpy_s(temp, full_name);
	
	if (strcmp(temp, full_name) == 0) { // compare if the strings are the same
		cout << temp << " and " << full_name << " are the same " << endl;
	}
	else {
		cout << temp << " and " << full_name << " are not the same " << " are different" << endl;
	}

	for (size_t i{ 0 }; i < strlen(full_name); i++) {//set string to toUpper
		if (isalpha(full_name[i])) {
			full_name[i] = toupper(full_name[i]);
		}
	}

	cout << "Your full name is " << full_name << endl;

	if (strcmp(temp, full_name) == 0) {
		cout << temp << " and " << full_name << " are the same " << endl;
	}
	else {
		cout << temp << " and " << full_name << " are different" << endl;
	}

}
