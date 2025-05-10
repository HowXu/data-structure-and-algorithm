// 反转链表

// Definition for singly-linked list.
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

// 返回反转后的链表
public class Solution
{
    public ListNode ReverseList(ListNode head)
    {
        if (head is null || head.next is null)
        {
            return head;
        }
        // 最简单的办法是拉个可变数组把值存储出来，然后for反向循环创建新链表
        // 这里我觉得双指针应该是一种比较靠谱的办法 然后加一个中间变量存变化值next
        var front = head;
        var rear = head.next;
        ListNode tmp = null;
        front.next = null;
        while (rear is not null)
        {
            // 始终先让rear拿到next
            tmp = rear.next;
            rear.next = front;
            front = rear;
            rear = tmp;
        }

        return front;
    }
}