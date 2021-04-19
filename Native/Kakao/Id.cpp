#include <iostream>
#include <string>
#include <vector>

using namespace std;

inline bool IsChar(char c)
{
	return (int)c >= 65 && (int)c <= 92 
		|| (int)c >= 97 && (int)c <= 122;
}
inline bool IsNumber(char c) {
	return (int)c >= 48 && (int)c <= 57;
}
inline void Small2Big(char& c) 
{
	c += (int)c >= 65 && (int)c <= 92 ? (char)32 : (char)0;
}
void TrimString(string& s)
{
	for (size_t i = 0; i < s.size(); i++)
	{
		if (!IsChar(s[i]) && !IsNumber(s[i]))
		{
			if (s[i] != '.' && s[i] != '_' && s[i] != '-')
			{
				s.erase(i--, 1);
			}
		}
	}
	{
		int i = 0;
		while (s.size() > i + 1)
		{
			if (s[i] == '.' && s[i + 1] == '.')
			{
				s.erase(i, 1);
			}
			else
			{
				i++;
			}
		}
	}
	if (s[0] == '.')
	{
		s.erase(0, 1);
	}
	if (s.size() > 1) 
	{
		if (s[s.size() - 1] == '.')
		{
			s.erase(s.size() - 1, 1);
		}
	}
	if (s.size() == 0) 
	{
		s = "a";
	}
	if (s.size() >= 16) 
	{
		s.erase(s.begin() + 15, s.end());
	}
	if (s.size() > 1)
	{
		if (s[s.size() - 1] == '.')
		{
			s.erase(s.size() - 1, 1);
		}
	}
	if (s.size() < 3) 
	{
		char push = s.back();

		while (s.size() < 3) {
			s.push_back(push);
		}
	}
}

string Solution(string new_id)
{
	char idBuffer = ' ';
	string answer = "";

	for (size_t i = 0; i < new_id.size(); i++) 
	{
		Small2Big(new_id[i]);
		answer.push_back(new_id[i]);
	}
	TrimString(answer);
	return answer;
}

// int main()
// {
// 	string id;
// 	cin >> id;
// 
// 	cout << Solution(id) << endl;
// 
// 	return 0;
// }