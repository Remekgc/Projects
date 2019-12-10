#pragma once
class MyStringV3
{
    friend std::ostream& operator<<(std::ostream& os, const MyStringV3& rhs);
    friend std::istream& operator>>(std::istream& in, MyStringV3& rhs);

private:
    char* str;      // pointer to a char[] that holds a C-style string
public:
    MyStringV3();                                                         // No-args constructor
    MyStringV3(const char* s);                                     // Overloaded constructor
    MyStringV3(const MyStringV3& source);                    // Copy constructor
    MyStringV3(MyStringV3&& source);                         // Move constructor
    ~MyStringV3();                                                     // Destructor

    MyStringV3& operator=(const MyStringV3& rhs); // Copy assignment
    MyStringV3& operator=(MyStringV3&& rhs);       // Move assignment

    void display() const;

    int get_length() const;                                       // getters
    const char* get_str() const;
};

