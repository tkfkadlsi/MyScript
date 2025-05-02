	#include <iostream>
	#include <queue>
	using namespace std;

	int main()
	{
		ios_base::sync_with_stdio(0);
		cin.tie(0);

		int n, k;
		queue<int> qint;

		cin >> n >> k;

		for (int i = 1; i <= n; i++)
		{
			qint.push(i);
		}

		cout << "<";

		while (!qint.empty())
		{
			if (qint.size() == 1)
			{
				cout << qint.front();
				qint.pop();
			}
			else
			{
				for (int i = 0; i < k - 1; i++)
				{
					qint.push(qint.front());
					qint.pop();
				}

				cout << qint.front() << ", ";
				qint.pop();
			}
		}

		cout << ">";

		return 0;
	}