#include <iostream>
using namespace std;

int main()
{
    ios_base::sync_with_stdio(0);
    cin.tie(0);

    int a = -1, b = -1;

    while (true)
    {
        cin >> a >> b;
        if (a == 0 && b == 0) break;
        cout << a + b << '\n';
    }

    return 0;
}