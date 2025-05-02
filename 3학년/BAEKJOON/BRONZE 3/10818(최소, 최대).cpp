#include <iostream>
using namespace std;

int main()
{
	ios_base::sync_with_stdio(0);
	cin.tie(0);

	int n, input, min = 1000001, max = -1000001;

	cin >> n;

	for (int i = 0; i < n; i++)
	{
		cin >> input;
		if (input < min)
		{
			min = input;
		}
		if (input > max)
		{
			max = input;
		}
	}

	cout << min << " " << max;

	return 0;
}