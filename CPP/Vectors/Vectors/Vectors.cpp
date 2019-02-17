#include "pch.h"
#include <iostream>
#include <vector>

using namespace std;

int main()
{
	//vector <char> vowels; is empty
	vector <char> vowels{'a', 'e', 'i', 'o', 'u'};

	cout << vowels[0] << endl;
	cout << vowels[4] << endl;

	cout << "\nTest scores: " << endl;
	vector <int> test_scores {100, 98, 89};
	cout << test_scores[0] << "\n" << test_scores[1] << "\n" << test_scores[2] << endl;
	cout << "\n There are " << test_scores.size() << " scores in the vector" << endl;
	// cam use:
	// cout << test_scores.at(0);

	int score_to_add {0};

	cout << "\nEnter a test score to add to the vector: ";
	cin >> score_to_add;
	test_scores.push_back(score_to_add);

	cout << "\nEnter one more test score to add to the vector: ";
	cin >> score_to_add;
	test_scores.push_back(score_to_add);

	cout << "\nVectors:\n";
	for (int i = 0; i < test_scores.size(); i++) {
		cout << "\n" << test_scores.at(i);
	}

	vector <vector<int>> movie_ratings { 
		{1, 2, 3, 4}, /*Reviewer 1*/
		{1, 3, 4, 4}, /*Reviewer 2*/
		{1, 5, 3, 4}  /*Reviewer 3*/
		 /*Score*/
	};

	for (int z = 0; z < 3; z++) {
		cout << "\nHere are the movie rating for reviewer #" << (z + 1) << " using array syntax: " << endl;
		cout << movie_ratings.at(z).at(0) << endl;
		cout << movie_ratings.at(z).at(1) << endl;
		cout << movie_ratings.at(z).at(2) << endl;
		cout << movie_ratings.at(z).at(3) << endl;
	}
}
