#include <iostream>
using namespace std;

int main()
{
	ios_base::sync_with_stdio(0);
	cin.tie(0);

	int a, b, c, max;



	while (true)
	{
		cin >> a >> b >> c;

		if (a == 0 && b == 0 && c == 0)
		{
			break;
		}

		max = a > b ? a : b;
		max = max > c ? max : c;
		
		if (max == a)
		{
			if (b * b + c * c == a * a)
			{
				cout << "right";
			}
			else
			{
				cout << "wrong";
			}
			cout << '\n';
		}
		else if (max == b)
		{
			if (a * a + c * c == b * b)
			{
				cout << "right";
			}
			else
			{
				cout << "wrong";
			}
			cout << '\n';
		}
		else if (max == c)
		{
			if (a * a + b * b == c * c)
			{
				cout << "right";
			}
			else
			{
				cout << "wrong";
			}
			cout << '\n';
		}
	}



	return 0;
}