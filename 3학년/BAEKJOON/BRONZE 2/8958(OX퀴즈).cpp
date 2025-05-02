#include <iostream>
using namespace std;

int main()
{
    ios_base::sync_with_stdio(0);
    cin.tie(0);

    int n, count, sum;
    string input;

    cin >> n;

    for (int i = 0; i < n; i++)
    {
        count = 0;
        sum = 0;
        cin >> input;
        for (int j = 0; j < input.size(); j++)
        {
            if (input[j] == 'O')
            {
                count++;
                sum += count;
            }
            else
            {
                count = 0;
            }
        }
        cout << sum << '\n';
    }

    return 0;
}