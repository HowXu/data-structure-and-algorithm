namespace Test;

using Algorithm;
using Structure.LinearList;

class Program
{
    static void Main(String[] args){
        LinearListRun();
    }

    static void LinearListRun()
    {
        int[] arr = [123, 1, 23, 4, 5];
        Array.Sort(arr);
        Console.WriteLine("二分查找法结果: {0}", A1BinarySearch.binarySearch(arr, 0));

        Person[] persons = [new Person(10, "a"), new Person(12, "b"), new Person(13, "c")];

        ArrayList<Person> arrayList = new(3, persons); // 逆天写法
        arrayList.Insert(0, new Person(8, "as"));
        Console.WriteLine(arrayList.size);
        Console.WriteLine(arrayList.ToString());
        arrayList.Remove(0);
        Console.WriteLine(arrayList.size);
        Console.WriteLine(arrayList.ToString());
        Console.WriteLine(arrayList.Get(1).ToString());
        Console.WriteLine(arrayList.IndexOf(new Person(13, "c")));

        LinkedList<Person> linkedList = new(persons);
        Console.WriteLine(linkedList.ToString());
        linkedList.Insert(0, new Person(10, "0 insert"));
        // 0i a b c
        linkedList.Insert(3, new Person(10, "3 insert"));
        // 0i a b 3i c
        linkedList.Insert(2, new Person(10, "2 insert"));
        // 0i a 2i b 3i c
        Console.WriteLine(linkedList.ToString());

        linkedList.Add(new Person(10, "Add"));
        Console.WriteLine(linkedList.ToString());

        linkedList.Remove(0);
        // a 2i b 3i c add
        linkedList.Remove(5);
        // a 2i b 3i c
        linkedList.Remove(3);
        // a 2i b c
        Console.WriteLine(linkedList.ToString());
        Console.WriteLine(linkedList.Get(0)!.ToString());
        Console.WriteLine(linkedList.Get(3)!.ToString());
        Console.WriteLine(linkedList.Get(2)!.ToString());
        Console.WriteLine(linkedList.IndexOf(new Person(10, "2 insert")));
        Console.WriteLine(linkedList.IndexOf(new Person(10, "a")));
        Console.WriteLine(linkedList.IndexOf(new Person(13, "c")));

        Stack<Person> stack = new(persons);
        Console.WriteLine(stack.ToString());
        Console.WriteLine(stack.size);
        stack.Pop();
        stack.Pop();
        stack.Pop();
        Console.WriteLine(stack.size);
        Console.WriteLine(stack.ToString());
        stack.Push(new Person(10, "1"));
        stack.Push(new Person(10, "2"));
        stack.Push(new Person(10, "3"));
        stack.Push(new Person(10, "4"));
        Console.WriteLine(stack.ToString());
        Console.WriteLine(stack.size);
        Console.WriteLine("Queue");
        Queue<Person> queue = new(persons);
        Console.WriteLine(queue.ToString());
        Console.WriteLine(queue.size);
        queue.Pop();
        queue.Pop();
        queue.Pop();
        Console.WriteLine(queue.size);
        Console.WriteLine(queue.ToString());
        queue.Offer(new Person(10, "1"));
        queue.Offer(new Person(10, "2"));
        queue.Pop();
        queue.Offer(new Person(10, "3"));
        queue.Pop();
        queue.Offer(new Person(10, "4"));
        Console.WriteLine(queue.ToString());
        Console.WriteLine(queue.size);
    }

    class Person
    {
        private int age { get; set; }
        private String name { get; set; }

        public Person(int age, String name)
        {
            this.age = age;
            this.name = name;
        }

        public override String ToString()
        {
            return name;
        }
        public override bool Equals(object? obj)
        {
            if (obj is not null)
            {
                return ((Person)obj).name.Equals(name);
            }
            return false;

        }
    }
}