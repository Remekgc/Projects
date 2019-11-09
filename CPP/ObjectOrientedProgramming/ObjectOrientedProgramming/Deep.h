#pragma once

#include <iostream>

class Deep
{
private:
	int* data;

public:
	Deep(int d);
	Deep(const Deep& source);
	~Deep();

	void set_data(int d);
	int get_data();
};

