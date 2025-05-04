#include <iostream>
#include <string>
using namespace std;

int main()
{
	ios_base::sync_with_stdio(0);
	cin.tie(0);

	int n, m = 0, dummy;
	string s;

	cin >> n;

	for (int i = 1; i < n; i++)
	{
		dummy = i;
		s = to_string(i);
		for (int j = 0; j < s.size(); j++)
		{
			dummy += s[j] - 48;
		}

		if (dummy == n)
		{
			m = i;
			break;
		}
	}

	cout << m;

	return 0;
}