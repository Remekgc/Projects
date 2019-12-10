#include <iostream>
#include <cstring>
#include "MyStringV3.h"

// No-args constructor
MyStringV3::MyStringV3()
    : str{ nullptr } {
    str = new char[1];
    *str = '\0';
}

// Overloaded constructor
MyStringV3::MyStringV3(const char* s)
    : str{ nullptr } {
    if (s == nullptr) {
        str = new char[1];
        *str = '\0';
    }
    else {
        str = new char[strlen(s) + 1];
        strcpy(str, s);
    }
}

// Copy constructor
MyStringV3::MyStringV3(const MyStringV3& source)
    : str{ nullptr } {
    str = new char[strlen(source.str) + 1];
    strcpy(str, source.str);
    std::cout << "Copy constructor used" << std::endl;

}

// Move constructor
MyStringV3::MyStringV3(MyStringV3&& source)
    :str(source.str) {
    source.str = nullptr;
    std::cout << "Move constructor used" << std::endl;
}

// Destructor
MyStringV3::~MyStringV3() {
    delete[] str;
}

// Copy assignment
MyStringV3& MyStringV3::operator=(const MyStringV3& rhs) {
    std::cout << "Using copy assignment" << std::endl;

    if (this == &rhs)
        return *this;
    delete[] str;
    str = new char[strlen(rhs.str) + 1];
    strcpy(str, rhs.str);
    return *this;
}

// Move assignment
MyStringV3& MyStringV3::operator=(MyStringV3&& rhs) {
    std::cout << "Using move assignment" << std::endl;
    if (this == &rhs)
        return *this;
    delete[] str;
    str = rhs.str;
    rhs.str = nullptr;
    return *this;
}


// Display method
void MyStringV3::display() const {
    std::cout << str << " : " << get_length() << std::endl;
}

// getters
int MyStringV3::get_length() const { return strlen(str); }
const char* MyStringV3::get_str() const { return str; }

// overloaded insertion operator
std::ostream& operator<<(std::ostream& os, const MyStringV3& rhs) {
    os << rhs.str;
    return os;
}

// overloaded extraction operator
std::istream& operator>>(std::istream& in, MyStringV3& rhs) {
    char* buff = new char[1000];
    in >> buff;
    rhs = MyStringV3{ buff };
    delete[] buff;
    return in;
}

