#include "pch.h"
#include <iostream>
#include <vector>
#include <string>

using namespace std;

void ArrayOfPointers() {
	int *array_ptr{ nullptr }; //create empty array pointer
	int size{0}; //value for size of array


	cout << "How big do you want the array?(more than 3): ";
	cin >> size;

	array_ptr = new int[size]; // Create space for array_ptr

	for (int i{ 0 }; i < size; i++) {
		cout << "item " << i << ": ";
		cin >> array_ptr[i];
	}

	// Can use while like this:
	
	int score[] {100, 122, 223, 43, -1};
	int *score_ptr {score};
	do{
		cout << *score_ptr << endl;
		score_ptr++;
	} while (*score_ptr != -1);
	

	//change value of second item by other way than array_ptr[i]
	*(array_ptr + 1) = 9;

	for (int i{ 0 }; i < size; i++) {
		cout << "Item number " << i << " in array: " << *(array_ptr + i) << endl; // other way using acctual pointer 
	}

	delete [] array_ptr;
}

int main()
{
	// Variables
	int num{ 10 };
	int temp{ 37 };
	vector<string> list{ "Mario", "Salami", "Pizza" };
	int scores[]{ 100, 122, 34 };

	// Pointers
	int *int_ptr{}; // empty pointer pointing to a garbage data
	double *double_ptr{ nullptr }; // emty pointer pointing to no data
	int *temp_ptr{ &temp }; // Create pointer with ready int
	vector<string> *vector_ptr{ &list }; // vector pointer pointing to list vector
	int *score_ptr{ scores }; // pointer to array scores (don't sue &, array is already an address)

    cout << "POINTERS:" << endl; 

	cout << endl;
	// Testing
	cout << "Value of num is: " << num << endl; //10
	cout << "sizeof num is: " << sizeof num << endl; //4
	cout << "Address of num is: " << &num << endl; // memory stuff
	
	cout << endl;
	// Connect pointer to variables
	int_ptr = &num;
	cout << "I'm int_ptr poniter and I point to: " << int_ptr << " And have value of num which is: " << *int_ptr << endl;
	
	// change value of num with it's pointer
	*int_ptr = 200;
	cout << "Pointer changed value of num to:" << num << endl;
	// change value of num and pointer changes too
	num = 100;
	cout << "Num changed so int_ptr points to: " << *int_ptr << endl;
	
	cout << endl;
	// show something out of vector pointer:
	cout << "Vector first item: " << (*vector_ptr).at(0) << endl;

	cout << endl;
	// Pointer with allocation on the heap
	int *mesa{ nullptr };

	mesa = new int; // allocate an interger to the heap

	cout << mesa << endl; // allocated memmory
	cout << *mesa << endl; // garbage
	*mesa = 100;
	cout << *mesa << endl; // 100

	delete mesa; // release memmory that was used for mesa

	cout << endl;
	//pointer to array
	cout << "address of array: " << scores << endl; //& is not needed in creation of pointer ot array
	for (int i{ 0 }; i < 3; i++) {
		cout << "Item number " << i << " in array: " << score_ptr[i] << endl; // point to memmory of item in pointer starting from 0(first one)
	}
	cout << endl;
	for (int i{ 0 }; i < 3; i++) {
		cout << "Item number " << i << " in array: " << *(score_ptr + i) << endl; // other way using acctual pointer 
	}
	ArrayOfPointers();
}
