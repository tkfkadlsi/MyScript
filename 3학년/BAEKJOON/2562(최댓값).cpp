#include <iostream>
using namespace std;

int main()
{
	ios_base::sync_with_stdio(0);
	cin.tie(0);

	int input, max = 0, maxCount;

	for (int i = 1; i <= 9; i++)
	{
		cin >> input;

		if (input > max)
		{
			max = input;
			maxCount = i;
		}
	}

	cout << max << '\n' << maxCount;

	return 0;
}