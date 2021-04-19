#include <stdio.h>
#include <iostream>

using namespace std;

struct Node
{
    Node* Next = nullptr;
    int Data;
};
// a->b->c->d
// b->a->c->d
// c->b->a->d
// d->c->b->a

void InversePrint(Node* head)
{
    Node* p, * q, * r;

    p = head;
    q = nullptr;
    
    while (p->Next != nullptr)
    {
        r = p->Next->Next;
        p->Next->Next = p;
        p->Next = r;
    }
}
int main()
{
    Node a;
    Node b;
    Node c;
    Node d;

    a.Data = 1;
    a.Next = &b;

    b.Data = 2;
    b.Next = &c;

    c.Data = 3;
    c.Next = &d;

    d.Data = 4;

    InversePrint(&a);

    cout << a.Data << endl;
    cout << b.Data << endl;
    cout << c.Data << endl;
    cout << d.Data << endl;
}