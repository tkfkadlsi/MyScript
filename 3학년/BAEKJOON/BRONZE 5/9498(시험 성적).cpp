#include <iostream>
using namespace std;

int main()
{
    ios_base::sync_with_stdio(0);
    cin.tie(0);

    int n;
    cin >> n;

    n /= 10;
    switch (n)
    {
    case 10:
    case 9:
        cout << "A";
        break;
    case 8:
        cout << "B";
        break;
    case 7:
        cout << "C";
        break;
    case 6:
        cout << "D";
        break;
    default:
        cout << "F";
        break;
    }

    return 0;
}