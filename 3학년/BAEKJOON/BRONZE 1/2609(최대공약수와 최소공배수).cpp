#include <iostream>
using namespace std;

int GCD(int a, int b)
{
	int swap, dummy1, dummy2;
	if (a < b)
	{
		swap = b;
		b = a;
		a = swap;
	}

	dummy1 = a;
	dummy2 = b;

	while (dummy2 != 0)
	{
		swap = dummy1 % dummy2;
		dummy1 = dummy2;
		dummy2 = swap;
	}

	return dummy1;
}

int main()
{
	ios_base::sync_with_stdio(0);
	cin.tie(0);

	int a, b, gcd, lcm;
	cin >> a >> b;

	gcd = GCD(a, b);
	lcm = a * b / gcd;

	cout << gcd << '\n' << lcm;

	return 0;
}