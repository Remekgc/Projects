#include <iostream>
#include <iomanip>
#include <vector>
#include <string>
#include <fstream>
#include <Windows.h>
//#include <sstream> // use this to get number out of a string: "10 heyy" would give out 10
//#include <limits>

#include "IOandStreams.h"

using namespace std;

struct City {
    string name;
    long population;
    double cost;
};

struct Country {
    string name;
    vector<City> cities;
};

struct Tours {
    string title;
    vector<Country> countries;
};

void ruler() {
    cout << "\n 123456789012345678901234567890123456789012345678901234567890\n" << endl;
}

void ToursExample()
{
    Tours tours
    { "Tour Ticket Prices from Miami",
    {
        {
            "Colombia",{
                { "Bogota", 8778000, 400.98 },
    { "Cali", 2401000, 424.12 },
    { "Medellin", 2464000, 350.98 },
    { "Cartagena", 972000, 345.34 }
    },
        },
            {
                "Brazil",{
                    { "Rio De Janiero", 13500000, 567.45 },
    { "Sao Paulo", 11310000, 975.45 },
    { "Salvador", 18234000, 855.99 }
    },
            },
            {
                "Chile",{
                    { "Valdivia", 260000, 569.12 },
    { "Santiago", 7040000, 520.00 }
    },
            },
    { "Argentina",{
        { "Buenos Aires", 3010000, 723.77 }
    }
    },
    }
    };

    const int total_width{ 70 };
    const int field1_width{ 20 };    // Country name
    const int field2_width{ 20 };    // City name
    const int field3_width{ 15 };    // Population
    const int field4_width{ 15 };    // Cost

                                     // Display the Report title header centered in width of total_width
                                     // You could make this a function for practice

    ruler();
    int title_length = tours.title.length();
    cout << setw((total_width - title_length) / 2) << "" << tours.title << endl;
    cout << endl;
    cout << setw(field1_width) << left << "Country"
        << setw(field2_width) << left << "City"
        << setw(field3_width) << right << "Population"
        << setw(field4_width) << right << "Price"
        << endl;

    cout << setw(total_width)
        << setfill('-')
        << ""
        << endl;   // display total_width dashes

    cout << setfill(' '); // reset setfill to blank spaces
    cout << setprecision(2) << fixed;                // for displaying the cost with 2 decimal digits

                                                     // Note the use of the conditional operator to display the country name or "" for the first country

    for (Country country : tours.countries) {
        for (size_t i = 0; i < country.cities.size(); ++i) {
            cout << setw(field1_width) << left << ((i == 0) ? country.name : "") // conditional operator
                << setw(field2_width) << left << country.cities.at(i).name
                << setw(field3_width) << right << country.cities.at(i).population
                << setw(field4_width) << right << country.cities.at(i).cost
                << endl;
        }
    }

    cout << endl << endl;
}

void CreateFile(string directory, string filename, string extension, string text) {
    ofstream myFile(directory + "/" + filename + extension);
    myFile << text;
    myFile.close();
}

void CreateWindowsDirectory() {
    LPCWSTR Folder = L"text_files";
    CreateDirectory(Folder, NULL);
}

void print_header() {
    cout << setw(15) << left << "Student"
        << setw(5) << "Score" << endl;
    cout << setw(20) << setfill('-') << "" << endl;
    cout << setfill(' ');
}

void print_footer(double average) {
    cout << setw(20) << setfill('-') << "" << endl;
    cout << setfill(' ');
    cout << setw(15) << left << "Average score"
        << setw(5) << right << average;
}

void print_student(const string& student, int score) {
    cout << setprecision(1) << fixed;
    cout << setw(15) << left << student
        << setw(5) << right << score << endl;
}

// return the number of correct responses
int process_response(const string& response, const string& answer_key) {
    int score{ 0 };
    for (size_t i = 0; i < answer_key.size(); ++i) {
        if (response.at(i) == answer_key.at(i))
            score++;
    }
    return score;
}

void ReadFromTextFile() {
    ifstream in_file;
    string answer_key{}, name{}, response{};
    int running_sum{ 0 }, total_students{ 0 };
    double average_score{ 0.0 };

    in_file.open("text_files/responses.txt");
    if (!in_file) {
        cerr << "Problem opening file" << std::endl;
    }

    in_file >> answer_key;

    print_header();

    while (in_file >> name >> response) {
        ++total_students;
        int score = process_response(response, answer_key);
        running_sum += score;
        print_student(name, score);
    }

    if (total_students != 0) {
        average_score = static_cast<double>(running_sum) / total_students;
    }

    print_footer(average_score);

    in_file.close();
    cout << endl << endl;

}

bool find_substring(const string& word_to_find, const string& target) {
    size_t found = target.find(word_to_find);
    if (found == string::npos)
        return false;
    else
        return true;
}

void SearchingTextInFile() {
    ifstream in_file{};
    string word_to_find{};
    string word_read{};
    int word_count{ 0 };
    int match_count{ 0 };

    in_file.open("text_files/romeoandjuliet.txt");
    if (!in_file) {
        cerr << "Problem opening file" << endl;
    }
    
    cout << "Enter the substring to search for: ";
    cin >> word_to_find;
    while (in_file >> word_read) {
        ++word_count;
        if (find_substring(word_to_find, word_read)) {
            ++match_count;
            cout << word_read << " ";
        }
    }

    cout << word_count << " words were searched..." << endl;
    cout << "The substring " << word_to_find << " was found " << match_count << " times " << endl;

    in_file.close();
    cout << endl;
}

void CreatingFileBasedOnAnother() {
    ifstream in_file{ "text_files/romeoandjuliet2.txt" };
    ofstream out_file{ "text_files/romeoandjuliet2_out.txt" };

    if (!in_file.is_open()) {
        cerr << "Error opening input file" << endl;
    }
    if (!out_file.is_open()) {
        cerr << "Error opening output file" << endl;
    }
     
    string line{};
    int line_number{ 0 };

    while (getline(in_file, line)) {
        if (line == "") {
            out_file << endl;
        }
        else {
            ++line_number;
            out_file << setw(7) << left << line_number
                << line << endl;
        }
    }
    cout << "\nCopy complete" << endl;

    in_file.close();
    out_file.close();
}

int main()
{
    ToursExample();
    //CreateWindowsDirectory();
    //CreateFile("text_files", "responses", ".txt", "ABCDE\nFrank\nABCDE\nLarry\nABCAC\nMoe\nBBCDE\nCurly\nBBAAE\nMichael\nBBCDE");
    ReadFromTextFile();
    SearchingTextInFile();
    CreatingFileBasedOnAnother();
}
