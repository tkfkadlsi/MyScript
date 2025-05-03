#include <iostream>
using namespace std;

int main()
{
	ios_base::sync_with_stdio(0);
	cin.tie(0);

	int array[100], n, m, dummy, answer = 0;


	cin >> n >> m;

	for (int i = 0; i < n; i++)
	{
		cin >> array[i];
	}

	for (int i = 0; i < n; i++)
	{
		for (int j = 1; j < n; j++)
		{
			if (i == j)
			{
				continue;
			}
			for (int k = 2; k < n; k++)
			{
				if (i == k || j == k)
				{
					continue;
				}

				dummy = array[i] + array[j] + array[k];
				if (dummy <= m && dummy > answer)
				{
					answer = dummy;
				}
			}
		}
	}

	cout << answer;

	return 0;
}