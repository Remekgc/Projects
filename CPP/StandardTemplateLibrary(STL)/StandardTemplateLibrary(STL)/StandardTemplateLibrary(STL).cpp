#include <cctype>
#include <deque>
#include <iostream>
#include <string>
#include <vector>
#include <iomanip>
#include <limits>
#include <list>
#include <fstream>
#include <sstream>
#include <map>
#include <set>
#include <stack>
#include <queue>

#include "StandardTemplateLibrary(STL).h"


using namespace std;

bool is_palindrome(const string& word)
{
    deque<char> d;

    for (char c : word) {
        if (isalpha(c)) {
            d.push_back(toupper(c));
        }     
    }

    char c1{};
    char c2{};

    while (d.size() > 1) {
        c1 = d.front();
        c2 = d.back();

        d.pop_front();
        d.pop_back();

        if (c1 != c2) {
            //if first and last char are not the same then it's not a palindrome and return false.
            return false;
        }
    }
    return true;
}

void Palindrome()
{
    vector<string> test_strings{ "a", "aa", "aba", "abba", "abbcbba", "ab", "abc", "radar", "bob", "ana",
        "avid diva", "Amore, Roma", "A Toyota's a toyota", "A Santa at NASA", "C++",
        "A man, a plan, a cat, a ham, a yak, a yam, a hat, a canal-Panama!", "This is a palindrome", "palindrome" };

    cout << boolalpha;
    cout << setw(15) << left << "Result" << "String" << endl;

    for (const auto& word : test_strings) {
        cout << setw(15) << left << is_palindrome(word) << word << endl;
    }

    cout << endl;
}

class Song {
    friend ostream& operator<<(ostream& os, const Song& s);

    string name;
    string artist;
    int rating;
public:
    Song() = default;
    Song(string name, string artist, int rating)
        : name{ name }, artist{ artist }, rating{ rating } {}

    string get_name() const {
        return name;
    }

    string get_artist() const {
        return artist;
    }

    int get_rating() const {
        return rating;
    }

    bool operator<(const Song& rhs) const {
        return this->name < rhs.name;
    }

    bool operator==(const Song& rhs) const {
        return this->name == rhs.name;
    }
};

ostream& operator<<(ostream& os, const Song& s) {
    os << setw(20) << left << s.name
        << setw(30) << left << s.artist
        << setw(2) << left << s.rating;
    return os;
}

void display_menu() {
    cout << "\nF - Play First Song" << endl;
    cout << "N - Play Next song" << endl;
    cout << "P - Play Previous song" << endl;
    cout << "A - Add and play a new Song at current location" << endl;
    cout << "L - List the current playlist" << endl;
    cout << "===============================================" << endl;
    cout << "Enter a selection (Q to quit): ";
}

void play_current_song(const Song& song) {
    cout << "Playing: " << endl;
    cout << song << endl;
}

void display_playlist(const list<Song>& playlist, const Song& current_song) {
    for (const Song& song : playlist) {
        cout << song << endl;
    }
    cout << "Current song: " << endl;
    cout << current_song << endl;
}

void SongListExample() {

    list<Song> playlist{
            {"God's Plan",        "Drake",                     5},
            {"Never Be The Same", "Camila Cabello",            5},
            {"Pray For Me",       "The Weekend and K. Lamar",  4},
            {"The Middle",        "Zedd, Maren Morris & Grey", 5},
            {"Wait",              "Maroone 5",                 4},
            {"Whatever It Takes", "Imagine Dragons",           3}
    };

    list<Song>::iterator current_song = playlist.begin();
    display_playlist(playlist, *current_song);

    char selection{};
    do {
        display_menu();
        cin >> selection;
        selection = toupper(selection);
        if (selection == 'F') {
            cout << "Playing first song" << endl;
            current_song = playlist.begin();
            play_current_song(*current_song);
        }
        else if (selection == 'N') {
            cout << "Playing next song" << endl;
            current_song++;
            if (current_song == playlist.end()) {
                cout << "Wrapping to start of playlist" << endl;
                current_song = playlist.begin();
            }
            play_current_song(*current_song);
        }
        else if (selection == 'P') {
            cout << "Playing previous song" << endl;
            if (current_song == playlist.begin()) {
                cout << "Wrapping to end of playlist" << endl;
                current_song = playlist.end();
            }
            current_song--;
            play_current_song(*current_song);
        }
        else if (selection == 'A') {
            string name, artist;
            int rating;
            cin.clear();
            cin.ignore(numeric_limits<streamsize>::max(), '\n');
            cout << "Adding and playing new song" << endl;
            cout << "Enter song name:";
            getline(cin, name);
            cout << "Enter song artist: ";
            getline(cin, artist);
            cout << "Enter your rating (1-5): ";
            cin >> rating;
            playlist.insert(current_song, Song{ name, artist, rating });
            current_song--;
            play_current_song(*current_song);
        }
        else if (selection == 'L') {
            cout << endl;
            display_playlist(playlist, *current_song);
        }
        else if (selection == 'Q')
            cout << "Quitting" << endl;
        else
            cout << "Illegal choice, try again...";
    } while (selection != 'Q');

    cout << "Thanks for listening!" << endl;
}

// Display the word and count from the 
// map<string, int>

void display_words(const map<string, int>& words) {
    cout << setw(12) << left << "\nWord"
        << setw(7) << right << "Count" << endl;
    cout << "===================" << endl;
    for (auto pair : words)
        cout << setw(12) << left << pair.first
        << setw(7) << right << pair.second << endl;
}

// Display the word and occurences from the 
// map<string, set<int>>

void display_words(const map<string, set<int>>& words)
{
    cout << setw(12) << left << "\nWord"
        << "Occurrences" << endl;
    cout << "=====================================================================" << endl;
    for (auto pair : words) {
        cout << setw(12) << left << pair.first
            << left << "[ ";
        for (auto i : pair.second)
            cout << i << " ";
        cout << "]" << endl;
    }
}

// This function removes periods, commas, semicolons and colon in 
// a string and returns the clean version
string clean_string(const string& s) {
    string result;
    for (char c : s) {
        if (c == '.' || c == ',' || c == ';' || c == ':') {
            continue;
        }
        else {
            result += c;
        } 
    }
    return result;
}

void NumberOfTimesWordOccuresInFile() {
    map<string, int> words;
    string line;
    string word;
    ifstream in_file{ "text_files/words.txt" };
    if (in_file) {
        while (getline(in_file, line)) {
            //cout << line;
            stringstream ss(line);
            while (ss >> word) {
                word = clean_string(word);
                words[word]++; // increment the count for the word in the map
            }
        }
        in_file.close();
        display_words(words);
    }
    else {
        cerr << "Error opening input file" << endl;
    }
}

void LineNumbersInWhichWordAppearsInFile() {
    map<string, set<int>> words;
    string line;
    string word;
    ifstream in_file{ "text_files/words.txt" };
    if (in_file) {
        int line_number = 0;
        while (getline(in_file, line)) {
            //std::cout << line;
            line_number++; // incrementing line number for each line
            stringstream ss(line);
            while (ss >> word) {
                word = clean_string(word);
                words[word].insert(line_number);
            }
        }
        in_file.close();
        display_words(words);
    }
    else {
        cerr << "Error opening input file" << endl;
    }
}

bool is_palindrome_WithQueueAndStack(const string& word) {
    stack<char> stk;
    queue<char> q;

    for (char c : word)
    {
        if (isalpha(c))
        {
            c = toupper(c);
            q.push(c);
            stk.push(c);
        }
    }

    char c1{};
    char c2{};

    while (!q.empty())
    {
        c1 = q.front();
        q.pop();
        c2 = stk.top();
        stk.pop();
        if (c1 != c2)
        {
            return false;
        }
    }
    return true;
}

void PalindromeWithStackAndQueue()
{
    vector<string> test_strings{ "a", "aa", "aba", "abba", "abbcbba", "ab", "abc", "radar", "bob", "ana",
        "avid diva", "Amore, Roma", "A Toyota's a toyota", "A Santa at NASA", "C++",
        "A man, a plan, a cat, a ham, a yak, a yam, a hat, a canal-Panama!", "This is a palindrome", "palindrome" };

    cout << boolalpha; // to display bool values(true and false)
    cout << setw(15) << left << "Result" << "String" << endl;

    for (const auto& word : test_strings) {
        cout << setw(15) << left << is_palindrome_WithQueueAndStack(word) << word << endl;
    }

    cout << endl;
}

void main()
{
    //Palindrome();
    PalindromeWithStackAndQueue();
    //SongListExample();
    NumberOfTimesWordOccuresInFile();
    LineNumbersInWhichWordAppearsInFile();
}