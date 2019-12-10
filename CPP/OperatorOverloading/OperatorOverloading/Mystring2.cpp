#include "Mystring2.h"
#include <cstring>
#include <string>
#include <iostream>

Mystring2::Mystring2() : str{nullptr} {
	str = new char[1];
	*str = '\0';
}

Mystring2::Mystring2(const char* s) : str{ nullptr } {
	if (s == nullptr)
	{
		str = new char[1];
		*str = '\0';
	}
	else
	{
		str = new char[strlen(s) + 1];
		strcpy(str, s);
	}
}

// Copy constructor
Mystring2::Mystring2(const Mystring2& source) : str{ nullptr } {
	str = new char[strlen(source.str) + 1];
	strcpy(str, source.str);
	std::cout << "Copy constructor used" << std::endl;
}

// Move constructor
Mystring2::Mystring2(Mystring2&& source) :str(source.str) {
	source.str = nullptr;
	std::cout << "Move constructor used" << std::endl;
}

// Destructor
Mystring2::~Mystring2() {
	if (str == nullptr) {
		std::cout << "Calling destructor for Mystring : nullptr" << std::endl;
	}
	else {
		std::cout << "Calling destructor for Mystring : " << str << std::endl;
	}
	delete[] str;
}

// Copy assignment
Mystring2& Mystring2::operator=(const Mystring2& rhs) {
	std::cout << "Using copy assignment" << std::endl;

	if (this == &rhs) {
		return *this;
	}

	delete[] str;
	str = new char[strlen(rhs.str) + 1];
	strcpy(str, rhs.str);
	return *this;
}

// Move assignment opterator
Mystring2& Mystring2::operator=(Mystring2&& rhs) {
	std::cout << "Using move assignment" << std::endl;

	if (this == &rhs) {
		return *this;
	}

	delete[] str;
	str = rhs.str;
	rhs.str = nullptr;
	return *this;

}

// Equality
/*bool Mystring2::operator==(const Mystring2& rhs) const {
	return (std::strcmp(str, rhs.str) == 0);
}

// Make lowercase
Mystring2 Mystring2::operator-() const {
	char* buff = new char[std::strlen(str) + 1];
	std::strcpy(buff, str);
	
	for (size_t i = 0; i < std::strlen(buff); i++)
	{
		buff[i] = std::tolower(buff[i]);
	}

	Mystring2 temp{ buff };
	delete[] buff;

	return temp;
}

Mystring2 Mystring2::operator+(const Mystring2& rhs) const {
	char* buff = new char[std::strlen(str) + std::strlen(rhs.str) + 1];
	std::strcpy(buff, str);
	std::strcat(buff, rhs.str);
	Mystring2 temp{ buff };
	delete[] buff;
	return temp;
}*/

void Mystring2::display() const {
	std::cout << str << " : " << get_length() << std::endl;
}

int Mystring2::get_length() const { 
	return strlen(str); 
}

const char* Mystring2::get_str() const {
	return str;
}

//Equality
bool operator==(const Mystring2& lhs, const Mystring2& rhs) {
	return (std::strcmp(lhs.str, rhs.str) == 0);
}

//Make lowercase
Mystring2 operator-(const Mystring2& obj) {
	char* buff = new char[std::strlen(obj.str) + 1];
	std::strcpy(buff, obj.str);
	for (size_t i = 0; i < std::strlen(buff); i++)
	{
		buff[i] = std::tolower(buff[i]);
	}
	Mystring2 temp{ buff };
	delete[] buff;

	return temp;
}

//Concatination
Mystring2 operator+(const Mystring2& lhs, const Mystring2& rhs) {
	char* buff = new char[std::strlen(lhs.str) + std::strlen(rhs.str) + 1];
	std::strcpy(buff, lhs.str);
	std::strcat(buff, rhs.str);

	Mystring2 temp{ buff };
	delete[] buff;

	return temp;
}

