#pragma once
#include <iostream>

class InsufficientFundsException : public std::exception
{
public:
	InsufficientFundsException() noexcept = default;
	~InsufficientFundsException() = default;
	virtual const char* what() const noexcept {
		return "Insufficent funds exception";
	}
};

