#include <iostream>
#include <string>
using namespace std;

int main()
{
	ios_base::sync_with_stdio(0);
	cin.tie(0);

	int n, count;
	string s;

	cin >> n;

	for (int i = 0; i < n; i++)
	{
		cin >> count >> s;
		for (int j = 0; j < s.size(); j++)
		{
			for (int k = 0; k < count; k++)
			{
				cout << s[j];
			}
		}
		cout << '\n';
	}

	return 0;
}