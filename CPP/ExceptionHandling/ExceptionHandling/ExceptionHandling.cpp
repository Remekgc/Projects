// ExceptionHandling.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <memory>
#include <vector>
#include "Account.h"
#include "Trust_Account.h"
#include "Checking_Account.h"
#include "Savings_Account.h"
#include "IllegalBalanceException.h"
#include "InsufficientFundsException.h"

using namespace std;

int main()
{
    unique_ptr<Account> Remi_Account;
    unique_ptr<Account> Agatha_Account;

    try {
        Agatha_Account = make_unique<Savings_Account>("Agatha", -2000);
        cout << *Agatha_Account << endl;
    }
    catch (const IllegalBalanceException & ex) {
        cerr << ex.what() << endl;
    }

    try {
        Remi_Account = make_unique<Savings_Account>("Remi", 1000);
        cout << *Remi_Account << endl;
        Remi_Account->withdraw(500);
        cout << *Remi_Account << endl;
        Remi_Account->withdraw(1000);
        cout << *Remi_Account << endl;

    }
    catch (const IllegalBalanceException & ex) {
        cerr << ex.what() << endl;
    }
    catch (const InsufficientFundsException & ex) {
        cerr << ex.what() << endl;
    }
    cout << "Program completed succesfully" << endl;
 
}

