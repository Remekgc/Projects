#pragma once

#include <iostream>

class MyString
{
private:
	char* str;

public:
	MyString();
	MyString(const char* s);
	MyString(const MyString& source);
	~MyString();
	void display() const;
	int get_length() const;
	const char* get_str() const;
};

