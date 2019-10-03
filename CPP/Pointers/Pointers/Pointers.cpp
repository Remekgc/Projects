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

	for (size_t i{0}; i < size; ++i) {
		*(new_storage + i) = init_value;
	}
	return new_storage;
}

void display(const int* const array, size_t size) {
	for (size_t i{0}; i < size; ++i) {
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

void PlayingWithReferences() {
	vector<string> names{ "Remy", "Agata", "Jeff" };
	
	for (auto str : names) {
		str = "Jack"; //str here is a copy of each vector element in names
	}

	for (auto str : names)
	{
		cout << str << endl;
	}

	for (auto& str : names) {
		str = "Sparrow"; //Here we change the reference point so names got edited
	}

	for (auto str : names)
	{
		cout << str << endl; //here we make a copy so it's not as efficient as using the reference
	}
	//More efficent way to display it would be:
	for (auto const& str : names) { //used constant to pervent the value form changing
		cout << str << endl;
	}

}

void print(int arr[], int size) {
	cout << "Array:" << endl;

	for (int i{0}; i < size; i++)
	{
		cout << "Element " << i + 1 << ": " << arr[i] << endl;
	}
}

int* apply_all(int arr1[], int size1, int arr2[], int size2) {
	int* result{ nullptr };
	result = new int[size1*size2];
	int allocator = 0;

	for (int i{0}; i < size1; i++)
	{
		for (int x{0}; x < size2; x++)
		{
			*(result + allocator) = arr1[i] * arr2[x];
			cout << *(result + allocator) << endl;
			allocator++;
		}
	}
	
	return result;
}

void SectionChallange() {
	int array1[]{ 1,2,3,4,5 };
	int array2[]{ 10,20,30 };

	cout << "Array 1: ";
	print(array1, 5);

	cout << "Array 1: ";
	print(array1, 3);

	int* results = apply_all(array1, 5, array2, 3);
	
	cout << "Result";
	print(results, 15);
	delete[] results;

}

int main()
{
	cout << "Examples of pointer usage\n";
	PointerTest();
	pointerArrays();
	PointerArthmetic();
	PonintersToConstans();
	SwapPointers();
	PointerVector();
	PointerFunction();
	PlayingWithReferences();
	SectionChallange();

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
