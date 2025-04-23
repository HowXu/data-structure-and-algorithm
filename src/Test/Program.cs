namespace Test;

using Algorithm;
using Helper;

class Program{
    static void Main(String[] args){
        int[] arr = new int[] { 123, 1, 23, 4, 5 };
        Array.Sort(arr);
        Console.WriteLine("二分查找法结果: {0}",A1BinarySearch.binarySearch(arr,0));
    }
}