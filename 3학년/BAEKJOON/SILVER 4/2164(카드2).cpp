#include <iostream>
#include <queue>
using namespace std;

int main()
{
	ios_base::sync_with_stdio(0);
	cin.tie(0);

	int n;
	queue<int> qint;
	cin >> n;

	for (int i = 1; i <= n; i++)
	{
		qint.push(i);
	}

	while (qint.size() > 1)
	{
		qint.pop();

		int i = qint.front();
		qint.pop();
		qint.push(i);
	}

	cout << qint.front();

	return 0;
}