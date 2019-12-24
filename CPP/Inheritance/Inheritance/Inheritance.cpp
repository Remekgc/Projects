#include <iostream>
#include "Account.h"
#include "Savings_Account.h"
#include "Inheritance.h"

using namespace std;

void Exampe1()
{
    // Use the Account class
    cout << "\n=== Account ==================================" << endl;
    Account acc{};
    acc.deposit(2000.0);
    acc.withdraw(500.0);

    cout << endl;

    Account* p_acc{ nullptr };
    p_acc = new Account();
    p_acc->deposit(1000.0);
    p_acc->withdraw(500.0);
    delete p_acc;

    // Use the Savings Account class

    cout << "\n=== Savings Account ==========================" << endl;
    Savings_Account sav_acc{};
    sav_acc.deposit(2000.0);
    sav_acc.withdraw(500.0);

    cout << endl;

    Savings_Account* p_sav_acc{ nullptr };
    p_sav_acc = new Savings_Account();
    p_sav_acc->deposit(1000.0);
    p_sav_acc->withdraw(500.0);
    delete p_sav_acc;

    cout << "\n==============================================" << endl;
}

void Example2() {
    //Account class, example of usage
    cout << "\n===== Account class ==========================" << endl;

    Account a1{ 1000.0 };
    cout << a1 << endl;

    a1.deposit(500.0);
    cout << a1 << endl;

    a1.withdraw(1000.0);
    cout << a1 << endl;

    a1.withdraw(5000.0);
    cout << a1 << endl;

    //Savings Account class, example of usage
    cout << "\n===== Savings Account Class ===================" << endl;

    Savings_Account s1{ 1000, 5.0 };
    cout << s1 << endl;

    s1.deposit(1000);
    cout << s1 << endl;

    s1.withdraw(2000);
    cout << s1 << endl;

    s1.withdraw(1000);
    cout << s1 << endl;

}

int main()
{
    Exampe1();
    Example2();
}