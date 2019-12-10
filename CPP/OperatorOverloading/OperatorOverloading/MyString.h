#pragma once

#include <iostream>

class MyString
{
    friend std::ostream& operator<<(std::ostream& os, const MyString& rhs);
    friend std::istream& operator>>(std::istream& in, MyString& rhs);

private:
    char* str;      // pointer to a char[] that holds a C-style string
public:
    MyString();                                                         // No-args constructor
    MyString(const char* s);                                     // Overloaded constructor
    MyString(const MyString& source);                    // Copy constructor
    MyString(MyString&& source);                         // Move constructor
    ~MyString();                                                     // Destructor

    MyString& operator=(const MyString& rhs);     // Copy assignment
    MyString& operator=(MyString&& rhs);            // Move assignment

    void display() const;

    int get_length() const;                                                // getters
    const char* get_str() const;

    // Overloaded operator member methods 
    MyString operator-() const;                                         // make lowercase
    MyString operator+(const MyString& rhs) const;         // concatenate
    bool operator==(const MyString& rhs) const;             // equals
    bool operator!=(const MyString& rhs) const;              //not equals
    bool operator<(const MyString& rhs) const;               //less than
    bool operator>(const MyString& rhs) const;               //greater than
    MyString& operator+=(const MyString& rhs);            // s1 += s2;  concat and assign
    MyString operator*(int n) const;                                // s1 = s2 * 3;  repeat s2 n times
    MyString& operator*=(int n);                                    // s1 *= 3;   s1 = s1 * 3;    
    MyString& operator++();                                          // pre-increment    ++s1;
    MyString operator++(int);                                         // post-increment   s1++;
};

