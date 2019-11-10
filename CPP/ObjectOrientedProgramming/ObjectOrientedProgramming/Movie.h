#pragma once

#include <string>

class Movie
{
private:
	std::string name;
	std::string rating;
	int watched;
	
public:
	// Constructor
	Movie(std::string name, std::string rating, int watched);
	// Copy Constructor
	Movie(const Movie& source);
	// Destructor
	~Movie();

	void set_name(std::string name) { this->name = name; }
	std::string get_name() const { return name; }

	void set_rating(std::string rating) { this->rating = rating; }
	std::string get_rating() const { return rating; }

	void set_watched(int watched) { this->watched = watched; }
	int get_watched() const { return watched; }
	
	void increment_watched() { ++watched; }

	void display() const;
};

