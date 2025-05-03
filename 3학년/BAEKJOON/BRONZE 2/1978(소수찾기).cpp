#include <iostream>
using namespace std;

int main()
{
	ios_base::sync_with_stdio(0);
	cin.tie(0);

	int n, input, counter, primeCount = 0;
	cin >> n;

	for (int i = 0; i < n; i++)
	{
		cin >> input;

		if (input == 1)
		{
			continue;
		}
		if (input == 2)
		{
			primeCount++;
			continue;
		}

		counter = 0;
		for (int i = 2; i < input; i++)
		{
			if (input % i == 0)
			{
				counter++;
				break;
			}
		}
		if (counter == 0)
		{
			primeCount++;
		}
	}

	cout << primeCount;

	return 0;
}