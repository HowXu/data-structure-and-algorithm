namespace Practice._61;
// Definition for singly-linked list.
public class ListNode {
    public int val;
    public ListNode next;
    public ListNode(int val=0, ListNode next=null) {
        this.val = val;
        this.next = next;
    }
}

public class Solution
{
    //  比较优的解是 变成循环链表 然后遍历(注意k的周期问题)找到最终位置 修改head指针
    public ListNode RotateRight(ListNode head, int k)
    {
        if(head is null || head.next is null || k == 0){
            return head;
        }
        ListNode cur = head;
        int len = 1; // 注意到这里天生有一个head了 所以len应该从1开始计算
        while(cur.next is not null){
            cur = cur.next;
            len++;
        }
        // 这样就拿到了长度和末尾节点
        cur.next = head; // 回环
        var t = len - k % len; // 每个len为一个周期 超出len的应该用len减才符合需求的旋转方法
        if(t == len){ // 注意到这个结果是可能为len的 所以可以提前return
            cur.next = null;
            return head;
        }
        for (int i = 0; i < t; i++)
        {
            // 循环拿到应该变成头节点的节点的前一节点
            cur = cur.next;
        }
        head = cur.next;
        cur.next = null;
        return head;
    }
}