#include <iostream>
#include <vector>
#include "Account.h"
#include "Savings_Account.h"
#include "Inheritance.h"
#include "Account_Util.h"


using namespace std;

void Exampe1()
{
    // Use the Account class
    cout << "\n=== Account ==================================" << endl;
    Account acc{};
    acc.deposit(2000.0);
    acc.withdrawal(500.0);

    cout << endl;

    Account* p_acc{ nullptr };
    p_acc = new Account();
    p_acc->deposit(1000.0);
    p_acc->withdrawal(500.0);
    delete p_acc;

    // Use the Savings Account class

    cout << "\n=== Savings Account ==========================" << endl;
    Savings_Account sav_acc{};
    sav_acc.deposit(2000.0);
    sav_acc.withdrawal(500.0);

    cout << endl;

    Savings_Account* p_sav_acc{ nullptr };
    p_sav_acc = new Savings_Account();
    p_sav_acc->deposit(1000.0);
    p_sav_acc->withdrawal(500.0);
    delete p_sav_acc;

    cout << "\n==============================================" << endl;
}

void Example2() {
    // Account class, example of usage
    cout << "\n===== Account class ==========================" << endl;

    Account a1{ 1000.0 };
    cout << a1 << endl;

    a1.deposit(500.0);
    cout << a1 << endl;

    a1.withdrawal(1000.0);
    cout << a1 << endl;

    a1.withdrawal(5000.0);
    cout << a1 << endl;

    // Savings Account class, example of usage
    cout << "\n===== Savings Account Class ===================" << endl;

    Savings_Account s1{ "Batman", 1000.0 , 0.5 };
    cout << s1 << endl;

    s1.deposit(1000);
    cout << s1 << endl;

    s1.withdrawal(2000);
    cout << s1 << endl;

    s1.withdrawal(1000);
    cout << s1 << endl;

}

void Example3() {
    cout.precision(2);
    cout << fixed;

    // Accounts
    vector<Account> accounts;
    accounts.push_back(Account{});
    accounts.push_back(Account{ "Agatha" });
    accounts.push_back(Account{ "Remy", 2000 });
    accounts.push_back(Account{ "Simon", 5000 });

    display(accounts);
    deposit(accounts, 1000);
    withdrawal(accounts, 2000);

    // Savings

    vector<Savings_Account> sav_accounts;
    sav_accounts.push_back(Savings_Account{});
    sav_accounts.push_back(Savings_Account{ "Geralt" });
    sav_accounts.push_back(Savings_Account{ "Yenefer", 2000 });
    sav_accounts.push_back(Savings_Account{ "Triss", 5000, 5.0 });

    display(sav_accounts);
    deposit(sav_accounts, 1000);
    withdrawal(sav_accounts, 2000);
}

void Example4() {
    cout.precision(2);
    cout << fixed;

    // Checking Account

    vector<Checking_Account> check_accunts;
    check_accunts.push_back(Checking_Account{});
    check_accunts.push_back(Checking_Account{ "Jenn" });
    check_accunts.push_back(Checking_Account{ "Ciri", 2000 });
    check_accunts.push_back(Checking_Account{ "Athena", 5000, 5.0 });

    display(check_accunts);
    deposit(check_accunts, 1000);
    withdrawal(check_accunts, 2000);

    // Trust Account

    vector<Trust_Account> trust_accounts;
    trust_accounts.push_back(Trust_Account{});
    trust_accounts.push_back(Trust_Account{ "Poseidon" });
    trust_accounts.push_back(Trust_Account{ "Zeus", 2000 });
    trust_accounts.push_back(Trust_Account{ "Hades", 5000, 5.0 });

    display(trust_accounts);
    deposit(trust_accounts, 1000);
    withdrawal(trust_accounts, 200);
    withdrawal(trust_accounts, 200);
    withdrawal(trust_accounts, 200);
    withdrawal(trust_accounts, 200);
}

int main()
{
    // Uncoment to check the functionality
    //Exampe1();
    //Example2();
    //Example3();
    Example4();
}