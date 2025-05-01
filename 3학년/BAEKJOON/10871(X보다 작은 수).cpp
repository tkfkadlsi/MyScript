#include <iostream>
#include <string>
using namespace std;

int main()
{
    ios_base::sync_with_stdio(0);
    cin.tie(0);

    int n, x, input;
    cin >> n >> x;
    string s = "";

    for (int i = 0; i < n; i++)
    {
        cin >> input;

        if (input < x)
        {
            s += to_string(input);
            s += " ";
        }
    }

    s.pop_back();
    cout << s;

    return 0;
}