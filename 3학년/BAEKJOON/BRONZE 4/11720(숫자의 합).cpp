#include <iostream>
using namespace std;

int main()
{
	ios_base::sync_with_stdio(0);
	cin.tie(0);

	int n, sum = 0;
	string s = "";
	cin >> n >> s;

	for (int i = 0; i < n; i++)
	{
		sum += s[i] - '0';
	}

	cout << sum;

	return 0;
}