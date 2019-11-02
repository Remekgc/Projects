#include "AccountType2.h"

AccountType2::AccountType2() : AccountType2{ "None", 0.0f } {
	std::cout << "no-arg declaration" << std::endl;
}

AccountType2::AccountType2(std::string name) : AccountType2{ name, 0.0f } {
	std::cout << "1-arg declaration" << std::endl;
}

AccountType2::AccountType2(std::string name, float balance) : Name{ name }, Balance{ balance } {
	std::cout << "2-arg declaration" << std::endl;
}