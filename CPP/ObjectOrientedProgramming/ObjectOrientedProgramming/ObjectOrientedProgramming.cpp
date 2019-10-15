// ObjectOrientedProgramming.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <string>
#include <vector>
#include "ObjectOrientedProgramming.h"
#include "Account.h"

using namespace std;

class Player {
public:
	string Name;
	int health;
	int xp;

	void talk(string textToSay) {
		cout << Name << " Said: " << textToSay << endl;
	}
};

void BasicClasses()
{
	cout << "Basic classes:\n";

	Player player1;
	player1.Name = "Remy";
	player1.health = 100;
	player1.xp = 9323;
	player1.talk("Hello there");

	Player player2;
	player2.Name = "Agata";
	player2.health = 120;
	player2.xp = 10343;
	player2.talk("General Kenobi!?");

	//Player* enemy{ nullptr };
	//enemy = new Player();
	Player* enemy = new Player();
	(*enemy).Name = "Kolos";
	(*enemy).health = 90;
	enemy->xp = 1234;
	enemy->talk("evil line 1");
	(*enemy).talk("evil line 2");

	vector<Player> Player_Vec{ player1 };
	Player_Vec.push_back(player2);

	delete enemy; //dynamic creation, has to be deleted
}

int main()
{
	//BasicClasses();
	Account Remy;
	Remy.set_Name("Remy");
	Remy.set_Balance(690000);

	string AccName{ Remy.get_Name() };
	float AccBal{ Remy.get_Balance() };

	cout << "Account owner: " << AccName << "\nBalance: " << AccBal << endl;
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
