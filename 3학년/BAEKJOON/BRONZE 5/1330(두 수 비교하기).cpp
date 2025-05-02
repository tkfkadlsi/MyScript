#include <iostream>
using namespace std;

int main()
{
    ios_base::sync_with_stdio(0);
    cin.tie(0);

    int a, b;
    cin >> a >> b;

    if (a > b)
    {
        cout << ">";
    }
    else if (a < b)
    {
        cout << "<";
    }
    else
    {
        cout << "==";
    }

    return 0;
}