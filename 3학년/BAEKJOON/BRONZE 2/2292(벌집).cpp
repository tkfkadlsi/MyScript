#include <iostream>
#include <string>
using namespace std;

int main()
{
	ios_base::sync_with_stdio(0);
	cin.tie(0);

	int n, count = 0, six = 6;

	cin >> n;

	if (n == 1)
	{
		cout << 1;
		return 0;
	}

	while (n > 1)
	{
		n -= count * six;
		count++;
	}

	cout << count;

	return 0;
}