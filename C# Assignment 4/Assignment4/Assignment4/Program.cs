
using Assignment4;


//MyStack
/*
MyStack<string> stack = new MyStack<string>();

stack.Push("one");
stack.Push("two");
stack.Push("three");
Console.WriteLine(stack.Count());
Console.WriteLine(stack.Pop());
Console.WriteLine(stack.Pop());
Console.WriteLine(stack.Pop());
*/

//MyList
/*
MyList<int> list = new MyList<int>();

list.Add(1);
list.Add(2);
list.Add(3);

Console.WriteLine(list.Find(0));
Console.WriteLine(list.Find(1));
Console.WriteLine(list.Find(2));

Console.WriteLine(list.Contains(4));
Console.WriteLine(list.Contains(1));

list.InsertAt(0, 1);

Console.WriteLine(list.Find(0));
Console.WriteLine(list.Find(1));
Console.WriteLine(list.Find(2));
Console.WriteLine(list.Find(3));

list.DeleteAt(2);

Console.WriteLine(list.Find(0));
Console.WriteLine(list.Find(1));
Console.WriteLine(list.Find(2));

list.Clear();
*/

// Generic Repository

GenericRepository<Entity> repo = new GenericRepository<Entity>();
Entity i0 = new Entity(0);
Entity i1 = new Entity(1);
Entity i2 = new Entity(2);
repo.Add(i0);
repo.Add(i1);
repo.Add(i2);

foreach (var item in repo.GetAll()) Console.WriteLine(item.Id);

repo.Remove(i1);

Console.WriteLine(repo.GetById(2).Id);

repo.Save();