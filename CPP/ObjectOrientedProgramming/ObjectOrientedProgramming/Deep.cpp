#include "Deep.h"

void Deep::set_data(int d) {
	*data = d;
}

int Deep::get_data() {
	return *data;
}

Deep::Deep(int d) {
	data = new int;
	*data = d;
}

Deep::Deep(const Deep& source) {
	data = new int; //allocate storage
	*data = *source.data;
	std::cout << "Copy construcotr - deep"
		<< std::endl;
}

Deep::~Deep() {
	std::cout << "Destructor called for Deep class object" << std::endl;
}