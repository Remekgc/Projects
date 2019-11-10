#include "Move.h"

void Move::set_data(int d) {
	*data = d;
}

int Move::get_data() const {
	return *data;
}

//Deep copy constructor
Move::Move(const Move& source) : Move {*source.data} {
	std::cout << "Copy constructor called for Move class - deep copy for: " << *data << std::endl;
}

//Move constructor
Move::Move(Move&& source) noexcept : data{source.data} {
	source.data = nullptr; //'Steal' the data and then null out the source pointer
	std::cout << "Move constructor beeing called for Move class - Moving resource: " << *data << std::endl;
}

Move::Move(int d) {
	data = new int;
	*data = d;
}

Move::~Move() {
	if (data != nullptr)
	{
		std::cout << "Destructor freeing data for: " << *data << std::endl;
	}
	else
	{
		std::cout << "Destructor freeing data for nullptr" << std::endl;
	}
	delete data;
}