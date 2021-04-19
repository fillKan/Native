#include <iostream>
#include <string>
#include <vector>
#include <map>

using namespace std;

vector<string> Combine(vector<int> course, int front, vector<char> menu)
{
    vector<string> answer;
    
    // 모든 코스에 대응하는 조합을 만든다
    for (auto iter : course)
    {
        for (int i = front; i < menu.size(); i++)
        {
            string combine;
            combine.push_back(menu[front]);

            for (int j = 1; j < iter; j++)
            {
                if (menu.size() > j + i)
                {
                    combine.push_back(menu[j + i]);
                }
            }
            if (combine.size() >= 2)
            {
                answer.push_back(combine);
            }
        }
    }
    return answer;
}
vector<string> solution(vector<string> orders, vector<int> course)
{
    // 1. order에서 언급된 메뉴들을 각각 언급된 횟수와 함께 저장한다 
    map<char, int> orderMap;

    for (auto iter : orders)
    {
        for (int i = 0; i < iter.size(); ++i) 
        {
            if (orderMap.find(iter[i]) == orderMap.end()) 
            {
                orderMap.insert(make_pair(iter[i], 1));
            }
            else
            {
                orderMap[iter[i]]++;
            }
        }
    }
    // 2. 두 번 이상 언급된 메뉴들로 이루어진 배열을 만든다
    vector<char> menu;

    for (auto iter : orderMap)
    {
        if (iter.second >= 2)
        {
            menu.push_back(iter.first);
        }
    }
    // 2.1. menu에 해당되는 배열의 각 요소와 함께 언급된 문자열을 저장한다
    map<char, vector<string>> togeter;

    for (auto iter : menu)
    {
        for (auto index : orders)
        {
            size_t find = index.find(iter);
            if (find != string::npos)
            {
                if (togeter.find(iter) == togeter.end())
                {
                    togeter.insert(make_pair(iter, vector<string>()));
                }
                string indexBackup = index;

                togeter[iter].push_back(index.erase(find, 1));

                index = indexBackup;
            }
        }
    }
    // 3. 만든 배열의 가장 앞에서부터 요구된 코스에 따라 조합을 시작한다. 이 과정에서 구한 배열들은 answer에 저장된다.
    vector<string> answer;

    for (int i = 0; i < menu.size(); ++i)
    {
        vector<string> combines = Combine(course, i, menu);

        for (auto iter : combines)
        {
            answer.push_back(iter);
        }
    }
    return answer;
}
int mmmain()
{
    vector<string> orders;
    vector<int> course;

    orders.push_back("XYZ");
    orders.push_back("XWY");
    orders.push_back("WXA");

    course.push_back(2);
    course.push_back(3);
    course.push_back(4);

    vector<string> result = solution(orders, course);
    
    //for (auto iter : result)
    //{
    //    cout << iter << endl;
    //}
    return 0;
}