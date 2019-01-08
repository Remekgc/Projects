#include "pch.h"
#include <iostream>
#include <vector>

using namespace std;

//Prototypes
void swap(int &a, int &b);
void printVector(const vector<int> &v);
void TimesTenVector(vector<int> &v);

//Declarations
void swap(int &a, int &b) {// by using & you can change the value in main by using function
	int temp = a;
	a = b;
	b = temp;
}

void printVector(const vector<int> &v) {
	for (auto num : v) {
		cout << num << endl;
	}
}

void TimesTenVector(vector<int> &v) {
	for (int x{}; x < v.size(); x++) {
		v.at(x) *= 10;
	}
}

int main()
{
	int x{ 10 }, y{ 20 };
	cout << x << " " << y << endl; // 10 20
	swap(x, y);
	cout << x << " " << y << endl; // 20 10
	//Vecotr
	cout << "===================================" << endl;
	vector<int> data{ 1, 2, 3, 4, 5 };
	printVector(data);
	TimesTenVector(data);
	printVector(data);
}
