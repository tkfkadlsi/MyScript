#include <iostream>
#include <vector>
using namespace std;

int main()
{
	ios_base::sync_with_stdio(0);
	cin.tie(0);

	float n, input, dummy = 0, max = 0;
	vector<int> vint;

	cin >> n;

	for (int i = 0; i < n; i++)
	{
		cin >> input;
		vint.push_back(input);
		if (max < input)
		{
			max = input;
		}
	}

	for (int i = 0; i < vint.size(); i++)
	{
		dummy += (vint[i] / max) * 100;
	}

	cout << dummy / n;

	return 0;
}