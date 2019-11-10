#include "PlayerStaticExample.h"

int PlayerStaticExample::num_players{ 0 };

PlayerStaticExample::PlayerStaticExample(std::string name_val, int health_val, int xp_val) : name{ name_val }, health{ health_val }, xp{ xp_val }{
	++num_players;
}

PlayerStaticExample::PlayerStaticExample(const PlayerStaticExample& source) : PlayerStaticExample{ source.name, source.health, source.xp } {

}

PlayerStaticExample::~PlayerStaticExample() {
	--num_players;
}

int PlayerStaticExample::get_num_players() {
	return num_players;
}