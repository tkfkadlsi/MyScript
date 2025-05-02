#include <iostream>
using namespace std;

int main()
{
	ios_base::sync_with_stdio(0);
	cin.tie(0);

	string s;
	int count = 0;

	while (cin >> s)
	{
		count++;
	}

	cout << count;

	return 0;
}