#include <iostream>
#include <string>
using namespace std;

int main()
{
	ios_base::sync_with_stdio(0);
	cin.tie(0);

	int a, b, c;
	string s = "";

	cin >> a >> b >> c;

	cout << a + b - c << '\n';

	s += to_string(a);
	s += to_string(b);

	cout << stoi(s) - c;


	return 0;
}