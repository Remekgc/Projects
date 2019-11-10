#pragma once

#include <iostream>

class Move
{
private:
	int* data;

public:
	void set_data(int d);
	int get_data() const;

	Move(int d);
	Move(const Move& source);
	Move(Move&& source) noexcept;
	~Move();
};

