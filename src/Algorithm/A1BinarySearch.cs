namespace Algorithm;

public class A1BinarySearch{
    public static int binarySearch(int[] arr,int target)
    {
        // 相对索引的入参 这个 - 1很重要 IndexOut的关键原因
        return binarySearch_index(arr,target,0,arr.Length - 1);
    }

    private static int binarySearch_index(int[] arr, int target,int start,int end){
        int middle = (start + end) / 2; //这个是向下取整吧 这样是最低为0 最高超不过Length的

        if(middle >= arr.Length || start > end) return -1;

        if(target == arr[middle]){
            return middle;
        }
        else
        {
            // 大小于对应下面的middle要抽一下 加一减一排除它自己，不然在寻找不存在元素时会无限迭代
            if (target > arr[middle])
            {
                return binarySearch_index(arr, target, middle + 1, end);
            }
            else
            {
                return binarySearch_index(arr, target, start, middle - 1);
            }
        }
    }
}