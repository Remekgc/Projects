// Pointers.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <vector>
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

void double_data(int* int_ptr) {
	*int_ptr *= 2;
}

void PonintersToConstans() {
	int value{ 10 };
	int* int_ptr{ nullptr };

	cout << "Value: " << value << endl;

	double_data(&value);

	cout << "Value: " << value << endl;
	cout << "--------------------------" << endl;

	int_ptr = &value;
	double_data(int_ptr);

	cout << "Value: " << value << endl;
	cout << endl;
}

void swap(int* a, int* b) {
	int temp = *a;
	*a = *b;
	*b = temp;
}

void SwapPointers() {
	int x{ 100 }, y{ 200 };

	cout << "\nx: " << x << endl;
	cout << "y: " << y << endl;

	swap(&x, &y);

	cout << "\nx: " << y << endl;
	cout << "y: " << y << endl;

	cout << endl;
}

void DisplayVector(const vector<string>* const v) {
	//(*v).at(0) = "Funny"; won't work because it's const
	for (auto str : *v) {
		cout << str << " ";
	}
	cout << endl;

	//v = nullptr; won't work because it's const
}

void PointerVector() {
	vector<string> stooges{ "Lary", "Moe", "Curly" };
	DisplayVector(&stooges);
}

int* create_array(size_t size, int init_value = 0) {
	int* new_storage{ nullptr };
	new_storage = new int[size];
	for (size_t i{ 0 }; i < size; ++i) {
		*(new_storage + i) = init_value;
	}
	return new_storage;
}

void display(const int* const array, size_t size) {
	for (size_t i{ 0 }; i < size; ++i) {
		cout << array[i] << " ";
	}
	cout << endl;
}

void PointerFunction() {
	int* my_array{ nullptr };
	size_t size;
	int int_value{};

	cout << "\nHow many integers would you like to allocate?";
	cin >> size;
	cout << "What value would you like them initialized to?";
	cin >> int_value;

	my_array = create_array(size, int_value);
	cout << "\n-------------------------------\n" << endl;
	display(my_array, size);
	delete[] my_array;

}

int main()
{
	cout << "Hello sunshine!\n";
	//PointerTest();
	//pointerArrays();
	//PointerArthmetic();
	//PonintersToConstans();
	//SwapPointers();
	//PointerVector();
	PointerFunction();
}


// Run program: Ctrl + F5 or Debug > Start Without Debuggaing menu
// Debug program: F5 or Debug > Start Debugging menu

// Tips for Getting Started: 
//   1. Use the Solution Explorer window to add/manage files
//   2. Use the Team Explorer window to connect to source control
//   3. Use the Output window to see build output and other messages
//   4. Use the Error List window to view errors
//   5. Go to Project > Add New Item to create new code files, or Project > Add Existing Item to add existing code files to the project
//   6. In the future, to open this project again, go to File > Open > Project and select the .sln file
