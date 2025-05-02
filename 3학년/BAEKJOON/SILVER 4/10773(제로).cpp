#include <iostream>
#include <stack>
using namespace std;

int main()
{
	ios_base::sync_with_stdio(0);
	cin.tie(0);

	stack<int> sint;
	int k, sum = 0, input;

	cin >> k;

	for (int i = 0; i < k; i++)
	{
		cin >> input;

		if (input == 0)
		{
			sint.pop();
		}
		else
		{
			sint.push(input);
		}
	}

	while (!sint.empty())
	{
		sum += sint.top();
		sint.pop();
	}

	cout << sum;

	return 0;
}