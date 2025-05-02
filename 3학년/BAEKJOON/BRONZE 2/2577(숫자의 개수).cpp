#include <iostream>
#include <string>
using namespace std;

int main()
{
	ios_base::sync_with_stdio(0);
	cin.tie(0);

	string s;
	int a, b, c;
	int array[10] = { 0 };

	cin >> a >> b >> c;

	s = to_string(a * b * c);

	for (int i = 0; i < s.size(); i++)
	{
		array[(int)s[i] - 48]++;
	}

	for (int i = 0; i < 10; i++)
	{
		cout << array[i] << '\n';
	}

	return 0;
}