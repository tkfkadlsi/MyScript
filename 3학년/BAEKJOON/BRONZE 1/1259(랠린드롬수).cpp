#include <iostream>
#include <stack>
#include <queue>
using namespace std;

bool isEqual(stack<char> sc, queue<char> qc)
{
	while (!sc.empty())
	{
		if (sc.top() != qc.front())
		{
			return false;
		}
		sc.pop();
		qc.pop();
	}

	return true;
}

int main()
{
	ios_base::sync_with_stdio(0);
	cin.tie(0);

	string s;
	stack<char> sc;
	queue<char> qc;

	while (cin >> s)
	{
		if (s == "0")
		{
			break;
		}

		while (!sc.empty())
		{
			sc.pop();
		}
		while (!qc.empty())
		{
			qc.pop();
		}

		for (int i = 0; i < s.size(); i++)
		{
			sc.push(s[i]);
			qc.push(s[i]);
		}

		if (isEqual(sc, qc))
		{
			cout << "yes" << '\n';
		}
		else
		{
			cout << "no" << '\n';
		}
	}

	return 0;
}