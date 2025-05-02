#include <iostream>
using namespace std;

int main()
{
    ios_base::sync_with_stdio(0);
    cin.tie(0);

    string s, answer = "";
    int array[26];

    for (int i = 0; i < 26; i++)
    {
        array[i] = -1;
    }

    cin >> s;

    for (int i = 0; i < s.size(); i++)
    {
        if (array[(int)s[i] - 97] == -1)
        {
            array[(int)s[i] - 97] = i;
        }
    }

    for (int i = 0; i < 26; i++)
    {
        cout << array[i];
        if (i != 25)
        {
            cout << " ";
        }
    }

    return 0;
}