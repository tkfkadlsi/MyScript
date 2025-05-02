#include <iostream>
#include <queue>
using namespace std;

int main()
{
	ios_base::sync_with_stdio(0);
	cin.tie(0);

	bool isPass;
	int n, openCount, closeCount;
	string input;

	cin >> n;

	for (int i = 0; i < n; i++)
	{
		cin >> input;

		if (input[0] == ')' || input[input.size()] == '(')
		{
			isPass = false;
		}

		openCount = 0;
		closeCount = 0;
		isPass = true;

		for (int j = 0; j < input.size(); j++)
		{
			input[j] == '(' ? openCount++ : closeCount++;

			if (openCount < closeCount)
			{
				isPass = false;
				break;
			}
		}

		if (openCount != closeCount)
		{
			isPass = false;
		}

		if (isPass)
		{
			cout << "YES" << '\n';
		}
		else
		{
			cout << "NO" << '\n';
		}
	}

	return 0;
}