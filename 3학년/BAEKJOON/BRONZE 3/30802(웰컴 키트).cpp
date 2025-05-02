#include <iostream>
using namespace std;

int main()
{
	ios_base::sync_with_stdio(0);
	cin.tie(0);

	int n, tshirt[6], t, p, answerT = 0, answerP1 = 0, answerP2;

	cin >> n;

	for (int i = 0; i < 6; i++)
	{
		cin >> tshirt[i];
	}
	
	cin >> t >> p;

	for (int i = 0; i < 6; i++)
	{
		answerT += tshirt[i] / t;
		if (tshirt[i] % t != 0)
		{
			answerT++;
		}
	}
	
	answerP1 = n / p;
	answerP2 = n % p;

	cout << answerT << '\n' << answerP1 << " " << answerP2;

	return 0;
}