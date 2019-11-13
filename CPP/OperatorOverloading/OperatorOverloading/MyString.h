#pragma once

#include <iostream>

class Mystring
{
private:
	char* str; // pointer to char[] that golds C-style string

public:
	Mystring();
	Mystring(const char* s);
	Mystring(const Mystring& source);
	~Mystring();

	Mystring& operator = (const Mystring& rhs);

	void display() const;

	int get_length() const;
	const char* get_str() const;
};

