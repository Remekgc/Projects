#include "Shallow.h"
#include <iostream>

Shallow::Shallow(int d) {
	data = new int; //allocate storage dynamically
	*data = d;
}

Shallow::~Shallow() {
	delete data; //free the storage
	std::cout << "Destructor freeing data" << std::endl;
}

Shallow::Shallow(const Shallow& source)
	: data(source.data) {
	std::cout << "Copy constrictor - shallow copy called" << std::endl;
}

void Shallow::set_data(int d) {
	*data = d;
}

int Shallow::get_data() {
	return *data;
}