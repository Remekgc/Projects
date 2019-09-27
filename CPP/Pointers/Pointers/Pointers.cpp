// Pointers.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
//#include <string>

using namespace std;


void PointerTest() {
	int* int_ptr{};
	double* double_ptr{ nullptr }; //no difference to *name
	char* char_ptr{ nullptr }; //use nullptr to make it point to 0
	string* string_ptr{ nullptr };
	string s1{ "Remy" };
	string* p1{ &s1 }; //&addres of s1

	cout << *p1 << " " << p1 << endl; // *p1 will print Remy while p1 the pointer(memmory adres)
}

void pointerArrays() {
	int scores[]{ 100,95,89 }; //Array is a stack of memmory in c++
	int* score_ptr{ scores }; //So by pointing to the first item/adress in array we can then add to the pointer value and get next number

	cout << "Value of scores: " << scores << endl;
	cout << "Value of score_ptr: " << score_ptr << endl;

	cout << "\nArray subscript notation----------------------------" << endl;
	cout << scores[0] << endl;
	cout << scores[1] << endl;
	cout << scores[2] << endl;

	cout << "\nPointer subscript notation---------------------------" << endl;
	cout << score_ptr[0] << endl;
	cout << score_ptr[1] << endl;
	cout << score_ptr[2] << endl;

	cout << "\nPointer offset notation------------------------------" << endl;
	cout << *score_ptr << endl;
	cout << *(score_ptr + 1) << endl; // = (score_ptr + 1(1 here is equal to size of int, so it's like + 4 to the memmory adres that pointer is pointing to))
	cout << *(score_ptr + 2) << endl;

	cout << "\nArray offest notation--------------------------------" << endl;
	cout << *scores << endl;
	cout << *(scores + 1) << endl;
	cout << *(scores + 2) << endl;

	cout << endl;
}

void PointerArthmetic() {
	int scores[]{ 100, 95, 89, 68, -1 };
	int* score_ptr{ scores };

	while (*score_ptr != -1)
	{
		cout << *score_ptr++ << endl;
		//score_ptr++;
	}
}

void PonintersToConstans() {

}

int main()
{
    cout << "Hello sunshine!\n";
	PointerTest();
	//pointerArrays();
	//PointerArthmetic();
}


// Run program: Ctrl + F5 or Debug > Start Without Debugging menu
// Debug program: F5 or Debug > Start Debugging menu

// Tips for Getting Started: 
//   1. Use the Solution Explorer window to add/manage files
//   2. Use the Team Explorer window to connect to source control
//   3. Use the Output window to see build output and other messages
//   4. Use the Error List window to view errors
//   5. Go to Project > Add New Item to create new code files, or Project > Add Existing Item to add existing code files to the project
//   6. In the future, to open this project again, go to File > Open > Project and select the .sln file
