namespace Practice._1539;

public class Solution
{
    // 最简单的还是直接暴力循环求解
    public int FindKthPositive(int[] arr, int k)
    {
        int j = 1, i = 0, len = arr.Length;
        while (i < len)
        {
            if (arr[i] != j)
            { // 循环找到一个不对等的数 k就自减一下 表示经过一个缺少的数
                k--;
            }
            else
            {
                i++;
            }
            // 这里来判断找的怎么样
            if (k == 0)
            {
                // 说明找到了
                return j;
            }
            j++;
        }
        // 遍历完了都没有那直接就可以算出来了
        return j + k - 1;
    }
    // 这里用二分搜索的说法 i位置不匹配的数一定满足被跳过索引值k = arr[i] - i - 1 通过这个关系可以找到k的大概范围
    public int FindKthPositive2(int[] arr, int k)
    {
        if (arr[0] > k) return k;
        int left = 0, right = arr.Length;

        while (left < right)
        {
            var mid = (left + right) / 2; // 二分取到中间的索引位置
            if (arr[mid] - mid - 1 >= k)
            {
                // 说明mid这个位置已经是k之后了
                right = mid;
            }
            else
            {
                left = mid + 1;
            }
        }
        // 得到的应该是刚好比k大一点的值，我们取left - 1 的位置的值再次使用这个公式
        // 下面这个东西 k 与 计算得到的left-1这个位置的k 的差值 加上left - 1的值
        return k - (arr[left - 1] - (left - 1) - 1) + arr[left - 1];
    }
}