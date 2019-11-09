#pragma once

#include <iostream> 

class Shallow
{
private:
	int * data;
	
public:
	Shallow(int d);
	Shallow(const Shallow& source);

	void set_data(int d);
	int get_data();
	
	~Shallow();
};

