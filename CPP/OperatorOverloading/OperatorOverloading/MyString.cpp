#include <iostream>
#include <cstring>
#include "MyString.h"

// No-args constructor
MyString::MyString()
    : str{ nullptr } {
    str = new char[1];
    *str = '\0';
}

// Overloaded constructor
MyString::MyString(const char* s)
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
MyString::MyString(const MyString& source)
    : str{ nullptr } {
    str = new char[strlen(source.str) + 1];
    strcpy(str, source.str);
    //       std::cout << "Copy constructor used" << std::endl;

}

// Move constructor
MyString::MyString(MyString&& source)
    :str(source.str) {
    source.str = nullptr;
    //        std::cout << "Move constructor used" << std::endl;
}

// Destructor
MyString::~MyString() {
    delete[] str;
}

// Copy assignment
MyString& MyString::operator=(const MyString& rhs) {
    //    std::cout << "Using copy assignment" << std::endl;

    if (this == &rhs)
        return *this;
    delete[] str;
    str = new char[strlen(rhs.str) + 1];
    strcpy(str, rhs.str);
    return *this;
}

// Move assignment
MyString& MyString::operator=(MyString&& rhs) {
    //   std::cout << "Using move assignment" << std::endl;
    if (this == &rhs)
        return *this;
    delete[] str;
    str = rhs.str;
    rhs.str = nullptr;
    return *this;
}


// Display method
void MyString::display() const {
    std::cout << str << " : " << get_length() << std::endl;
}

// getters
int MyString::get_length() const { return strlen(str); }
const char* MyString::get_str() const { return str; }

// overloaded insertion operator
std::ostream& operator<<(std::ostream& os, const MyString& rhs) {
    os << rhs.str;
    return os;
}

// overloaded extraction operator
std::istream& operator>>(std::istream& in, MyString& rhs) {
    char* buff = new char[1000];
    in >> buff;
    rhs = MyString{ buff };
    delete[] buff;
    return in;
}


// Equality
bool MyString::operator==(const MyString& rhs) const {
    return (std::strcmp(str, rhs.str) == 0);
}

// Not equals
bool MyString::operator!=(const MyString& rhs) const {
    return !(std::strcmp(str, rhs.str) == 0);
}

// Less than
bool MyString::operator<(const MyString& rhs) const {
    return (std::strcmp(str, rhs.str) < 0);
}

// Greater than
bool MyString::operator>(const MyString& rhs) const {
    return (std::strcmp(str, rhs.str) > 0);
}

// Make lowercase
MyString MyString::operator-() const {
    char* buff = new char[std::strlen(str) + 1];
    std::strcpy(buff, str);
    for (size_t i = 0; i < std::strlen(buff); i++)
        buff[i] = tolower(buff[i]);
    MyString temp{ buff };
    delete[] buff;
    return temp;
}

// Concatentate
MyString MyString::operator+(const MyString& rhs) const {
    char* buff = new char[strlen(str) + strlen(rhs.str) + 1];
    strcpy(buff, str);
    strcat(buff, rhs.str);
    MyString temp{ buff };
    delete[] buff;
    return temp;
}

// Concat and assign
MyString& MyString::operator+=(const MyString& rhs) {
    *this = *this + rhs;
    return *this;
}

// repeat
MyString MyString::operator*(int n) const {
    MyString temp;
    for (int i = 1; i <= n; i++)
        temp = temp + *this;
    return temp;
    /*
    size_t buff_size = std::strlen(str) * n + 1;
    char *buff = new char[buff_size];
    strcpy(buff, "");
    for (int i =1; i <=n; i++)
        strcat(buff, str);
    Mystring temp{buff};
    delete [] buff;
    return temp;
    */
}

// repeat and assign
MyString& MyString::operator*=(int n) {
    *this = *this * n;
    return *this;
}

// Pre-increment - make the string upper-case
MyString& MyString::operator++() {  // pre-increment
    for (size_t i = 0; i < strlen(str); i++)
        str[i] = toupper(str[i]);
    return *this;
}

//Post-increment - make the string upper-case
MyString MyString::operator++(int) { // post-increment
    MyString temp(*this);       // make a copy
    operator++();                    // call pre-increment - make sure you call preincrement!
    return temp;                     // return the old value
}