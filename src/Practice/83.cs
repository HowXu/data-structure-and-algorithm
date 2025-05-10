namespace Practice._83;
// LeetCode 83 删除链表中重复元素
// 给定链表已经排序 112233这个样子
// ListNode函数声明
public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}

// 运行框架 返回值为已排序的链表
// 因为已经排序 所以相同元素一定是靠近的 只需要不断判断next就可以了

// 其实这里还有一个叫做双指针的玩法 让前后指针一直保持1位的差距
public class Solution
{
    public ListNode DeleteDuplicates(ListNode head)
    {
        if(head is null || head.next is null){
            return head;
        }
        ListNode ptr = head;
        while (ptr.next is not null)
        {
            if(ptr.val == ptr.next.val){
                ptr.next = ptr.next.next;
                // 这里不进行移动，这样就可以实现一个按序比较而不是每次都跨一位的比较
            }else{
                ptr = ptr.next;
            }
        }
        return head;
    }
}
