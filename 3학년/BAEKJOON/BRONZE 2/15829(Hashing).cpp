#include <iostream>
using namespace std;

long long myPow(int base, int exponent)
{
	long long n = 1;

	if (exponent == 0)
	{
		return 1;
	}

	for (int i = 0; i < exponent; i++)
	{
		n *= base;
		n %= 1234567891;
	}

	return n;
}

int main()
{
	ios_base::sync_with_stdio(0);
	cin.tie(0);

	int l;
	long long hash = 0;
	string s;
	cin >> l >> s;

	for (int i = 0; i < l; i++)
	{
		hash += (s[i] - 96) * myPow(31, i);
		hash %= 1234567891;
	}
	
	cout << hash;

	return 0;
}