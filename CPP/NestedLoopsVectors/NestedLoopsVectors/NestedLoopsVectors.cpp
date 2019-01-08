#include "pch.h"
#include <iostream>
#include <vector>

using namespace std;

int main()
{
	vector<int> vec{1, 2, 3};
	int result {};
	for (size_t i = 0; i < vec.size(); ++i) {
		for (size_t j = i + 1; j < vec.size(); ++j) {
			result = result + vec.at(i) * vec.at(j);
		}
	}
	cout << result;
}