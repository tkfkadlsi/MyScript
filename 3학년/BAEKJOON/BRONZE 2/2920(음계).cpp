#include <iostream>
#include <string>
using namespace std;

int main()
{
	ios_base::sync_with_stdio(0);
	cin.tie(0);

	bool ascend = true, descend = true;
	int input, before;

	cin >> input;

	if (input != 1 && input != 8)
	{
		cout << "mixed";
		return 0;
	}

	for (int i = 0; i < 8; i++)
	{
		before = input;
		cin >> input;
		
		if (input > before)
		{
			descend = false;
		}
		if (input < before)
		{
			ascend = false;
		}

		if (ascend == false && descend == false)
		{
			cout << "mixed";
			return 0;
		}
	}

	cout << (ascend == true ? "ascending" : "descending");

	return 0;
}