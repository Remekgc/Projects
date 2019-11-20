#pragma once
class Mystring2
{
	friend bool operator==(const Mystring2& lhs, const Mystring2& rhs);
	friend Mystring2 operator-(const Mystring2& obj);
	friend Mystring2 operator+(const Mystring2& lhs, const Mystring2& rhs);
private:
	char* str;
public:
	Mystring2();
	Mystring2(const Mystring2& source);
	Mystring2(const char* s);
	Mystring2(Mystring2&& source);
	~Mystring2();

	Mystring2& operator=(const Mystring2& rhs);
	Mystring2& operator=(Mystring2&& rhs);

	/*Mystring2 operator-() const; //Make lowercase
	Mystring2 operator+(const Mystring2& rhs) const; //concatenate
	bool operator==(const Mystring2& rhs) const;*/



	void display() const;

	int get_length() const;
	const char* get_str() const;

};

