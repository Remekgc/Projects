// ObjectOrientedProgramming.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <string>
#include <vector>
#include "ObjectOrientedProgramming.h"
#include "Account.h"
#include "AccountType2.h"
#include "AccountType3.h"
#include "Shallow.h"
#include "Deep.h"
#include "Move.h"
#include "PlayerStaticExample.h"
#include "Movies.h"

using namespace std;


//Player class:
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

	Player player1{"Remy", 100, 9323};
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

void CopyConstructor(AccountType3 Stormtrooper) {
	cout << "Name: " << Stormtrooper.get_Name() << "\nBalance: " << Stormtrooper.get_Balance() << endl;
}

void ExampleOfAccountClass()
{
	Account Remy;
	Remy.set_Name("Remy");
	Remy.set_Balance(690000.0f);

	Account Anon, Fred{"Fred"}, Eddie{ "Eddie", 579.5f };

	string AccName{ Remy.get_Name() };
	float AccBal{ Remy.get_Balance() }; 

	cout << "Account owner: " << AccName << "\n Balance: " << AccBal << endl;
	Anon.ShowAccountInfo();
	Fred.ShowAccountInfo();
	Eddie.ShowAccountInfo();

	cout << endl;

	AccountType2 JayZ, Harry{ "Harry" }, Voldemort{ "Tom Riddle", 9000.0f};
	AccountType3 Grizzly, Cat{ "Late" }, Dog{ "Dragon", 7000.0f };

	CopyConstructor(Grizzly);
	CopyConstructor(Dog);

	//Note: in the program you can see that The copy was destryed at the end of a function as it supposed to be
	cout << endl;
}
void display_shallow(Shallow s) {
	cout << s.get_data() << endl;
}

void ShallowClass() {
	Shallow shallowObj1{ 100 };
	display_shallow(shallowObj1);

	Shallow shallowObj2{ shallowObj1 };
	shallowObj2.set_data(500);

	//shallowCop.set_data(500);
	//int shallowObjData = shallowObj.get_data();
	
	//Will end up with Crash
}

void display_deep(Deep s) {
	cout << s.get_data() << endl;
}

void DeepClass() {
	Deep deep1{ 100 };
	display_deep(deep1);

	Deep deep2{ deep1 };
	deep1.set_data(9999);
	display_deep(deep2);
}

void MoveClass() {
	vector<Move> vec;

	vec.push_back(Move{ 10 });
	vec.push_back(Move{ 20 });
}

void DisplayActivePlayers()
{
	cout << "Active Players: " << PlayerStaticExample::get_num_players() << endl;
}

void PlayerStatic() {
	DisplayActivePlayers();
	PlayerStaticExample hero{ "Hero" };
	DisplayActivePlayers();
	{
		PlayerStaticExample Tom{ "Tom" };
		DisplayActivePlayers();
	}
	DisplayActivePlayers();

	PlayerStaticExample* Jerry = new PlayerStaticExample{ "Jerry", 100, 100 };
	DisplayActivePlayers();
	delete Jerry;
	DisplayActivePlayers();
}

void increment_watched(Movies& movies,string name) {
	if (movies.increment_watched(name)) {
		cout << name << " watch incremented" << endl;
	}
	else {
		cout << name << " not found" << endl;
	}
}

void add_movie(Movies& movies, string name, string rating, int watched) {
	if (movies.add_movie(name, rating, watched)) {
		cout << name << " added" << endl;
	}
	else {
		cout << name << " already exists" << endl;
	}
}

void MoviesExample() {
	Movies my_movies;

	my_movies.display();

	add_movie(my_movies, "Big", "PG-13", 2);                 // OK
	add_movie(my_movies, "Star Wars", "PG", 5);             // OK
	add_movie(my_movies, "Cinderella", "PG", 7);           // OK

	my_movies.display();   // Big, Star Wars, Cinderella

	add_movie(my_movies, "Cinderella", "PG", 7);            // Already exists
	add_movie(my_movies, "Ice Age", "PG", 12);              // OK

	my_movies.display();    // Big, Star Wars, Cinderella, Ice Age

	increment_watched(my_movies, "Big");                    // OK
	increment_watched(my_movies, "Ice Age");              // OK

	my_movies.display();    // Big and Ice Age watched count incremented by 1

	increment_watched(my_movies, "XXX");         // XXX not found
}

int main()
{
	//Note (Difference on Struct and Class): Struct is used for apssive objects with public access and usally have no methods

	//UNCOMENT TO USE CLASSES:

	//BasicClasses();
	//ExampleOfAccountClass();
	//ShallowClass();
	//DeepClass();
	//MoveClass();
	//PlayerStatic();
	MoviesExample();

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
