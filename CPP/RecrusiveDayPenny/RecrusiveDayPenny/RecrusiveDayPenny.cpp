#include "pch.h"
#include <iostream>
#include <iomanip>

using namespace std;

//Prototypes
double pennyEveryDay(int day, long double penny = 0.01);

//Declarations
double pennyEveryDay(int day, long double penny) {
	if (day == 1) {
		return penny; //at the end when day = 1 return value of penny
	}
	return pennyEveryDay(--day, penny * 2); // do penny * 2 as long as day != 1
}

int main()
{
	long double total_penny{};
	int days{};

	cout << "How many days?: " << endl;
	cin >> days;

	total_penny = pennyEveryDay(days);

	cout << "Total amount: " << setprecision(10) << total_penny;
}

