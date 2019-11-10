#pragma once

#include <vector>
#include <string>
#include "Movie.h"

class Movies
{
private:
	std::vector<Movie> movies;

public:
	// Constructor
	Movies();
	// Destructor
	~Movies();

	bool add_movie(std::string name, std::string rating, int watched);
	bool increment_watched(std::string name);
	void display() const;
};

