namespace Test;

using Algorithm;
using Structure.LinearList;

class Program
{
    static void Main(String[] args)
    {
        int[] arr = [123, 1, 23, 4, 5];
        Array.Sort(arr);
        Console.WriteLine("二分查找法结果: {0}", A1BinarySearch.binarySearch(arr, 0));

        Person[] persons = [new Person(10, "a"), new Person(12, "b"), new Person(13, "c")];
        
        ArrayList<Person> arrayList = new(3, persons); // 逆天写法
        arrayList.Insert(0, new Person(8, "as"));
        Console.WriteLine(arrayList.size);
        Console.WriteLine(arrayList.ToString());
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

        public override String ToString(){
            return name;
        }
    }
}