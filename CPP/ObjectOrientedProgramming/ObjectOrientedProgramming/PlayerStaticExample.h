#pragma once

#include <iostream>
#include <string>

class PlayerStaticExample
{
private:
	static int num_players;
	std::string name;
	int health;
	int xp;

public:
	std::string get_name() { return name; }
	int get_health() { return health; }
	int get_xp() { return xp; }

	PlayerStaticExample(std::string name_val = "None", int health_val = 0, int xp_val = 0);
	// Copy Constructor
	PlayerStaticExample(const PlayerStaticExample& source);
	// Destructor
	~PlayerStaticExample();

	static int get_num_players();
};

