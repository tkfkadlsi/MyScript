#include <iostream>
using namespace std;

int main()
{
	ios_base::sync_with_stdio(0);
	cin.tie(0);

	int h, m;
	cin >> h >> m;

	if (m < 45)
	{
		if (h == 0)
		{
			h = 23;
		}
		else
		{
			h--;
		}
		m += 15;
	}
	else
	{
		m -= 45;
	}

	cout << h << " " << m;

	return 0;
}