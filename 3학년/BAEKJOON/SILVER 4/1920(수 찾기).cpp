#include <iostream>
#include <set>
using namespace std;

int main()
{
	ios_base::sync_with_stdio(0);
	cin.tie(0);

	int n, input;
	set<int> sint;

	cin >> n;
	for (int i = 0; i < n; i++)
	{
		cin >> input;
		sint.insert(input);
	}

	cin >> n;
	for (int i = 0; i < n; i++)
	{
		cin >> input;
		if (sint.find(input) != sint.end())
		{
			cout << 1 << '\n';
		}
		else
		{
			cout << 0 << '\n';
		}
	}

	return 0;
}