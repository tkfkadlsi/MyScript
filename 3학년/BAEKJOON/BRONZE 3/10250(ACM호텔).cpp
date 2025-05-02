#include <iostream>
using namespace std;

int main()
{
	ios_base::sync_with_stdio(0);
	cin.tie(0);

	int t, h, w, n, wCount, answer;

	cin >> t;

	for (int i = 0; i < t; i++)
	{
		cin >> h >> w >> n;
		wCount = 1;
		answer = 0;

		while (n > h)
		{
			n -= h;
			wCount++;
		}

		cout << n * 100 + wCount << '\n';
	}

	return 0;
}