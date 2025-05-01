#include <iostream>
using namespace std;

int main()
{
    ios_base::sync_with_stdio(0);
    cin.tie(0);

    string s;
    int i;
    cin >> s;
    cin >> i;

    cout << s[i-1];

    return 0;
}