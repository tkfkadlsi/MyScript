#include <iostream>
#include <set>
using namespace std;

int main()
{
    ios_base::sync_with_stdio(0);
    cin.tie(0);

    set<int> sint;
    int input;

    for (int i = 0; i < 10; i++)
    {
        cin >> input;
        sint.insert(input % 42);
    }

    cout << sint.size();

    return 0;
}