namespace Structure.LinearList;
// 队列 一种FIFO的数据结构
// 实现和Stack差不多 可以用链表也可以是数组 数组就循环数组(下标复用环形使用) 出队之后元素前压 依旧更喜欢链表作为内部

public class Queue<T> where T : class
{
    // 指向栈顶的指针
    private Piece front;
    private Piece rear;
    private class Piece
    {
        internal T? element;
        internal Piece? next; // 这个只需要next就可以
        public Piece(T? element, Piece? next)
        {
            this.element = element;
            this.next = next;
        }

        public Piece Copy()
        {
            return new Piece(element, next);
        }
    }

    private int capacity;
    private int __size;
    public int size
    {
        get
        {
            return __size;
        }
    }

    public Queue(params T[]? array)
    {
        // 根据它的内部构造思想 应该这样写
        var empty = new Piece(null, null);
        front = rear = empty;

        bool has_rear = false;

        // 这里应该优先把rear作为判别
        if (array is not null && array.Length != 0)
        {
            // 遍历
            foreach (var element in array)
            {
                var tmp_piece = new Piece(element, null);
                if (has_rear)
                {
                    // 这里应该不需要管front
                    Append(tmp_piece);
                    continue;
                }

                if (rear.next is null)
                {
                    has_rear = true;
                    rear = tmp_piece;
                    front = tmp_piece; // 都指到这里来
                    __size = 1;
                }
            }

        }
        else // 无数组情况
        {
            capacity = 0;
            __size = -1; //这里的-1是为了遵循统一规范 这个东西应该不叫size
        }
    }

    private void Append(Piece piece)
    {
        rear.next = piece;
        rear = piece;
        // 这里做一下 全部Pop的Size判断
        if (__size == -1)
        {
            __size = 1;
        }
        else
        {
            __size++;
        }
        capacity++; // 这个东西其实有点多余
    }

    // 入队offer 这里也要考虑很经典的全部Pop之后
    public void Offer(T? element)
    {
        // 考虑全部Pop后 rear和front指向同一个空引用
        if (__size == -1)
        {
            var tp = new Piece(element, null);
            rear = tp; // 直接赋值
            front = tp;
            __size = 1;
        }
        else
        {
            Append(new Piece(element, null));
        }
    }
    public T? Pop()
    {
        T? to_re = front.element;
        if (front.Equals(rear) || (front.next is null && rear.next is null))
        {
            // 说明拿走了栈底元素 前对后充分 这里要直接进行清空
            Piece etp = new Piece(null,null);
            front = rear = etp;
            __size = -1;
            capacity = 0;
        }
        else
        {
            front = front.next!;
            __size--;
            capacity--;
        }
        return to_re; // 这个返回它安全吗老铁
    }

    public override string ToString()
    {
        Piece? tmp_node = front;
        if (__size == -1)
        {
            return "[]";
        }
        var result = new System.Text.StringBuilder("[");
        for (; tmp_node is not null;)
        {
            if (tmp_node.element is null)
            {
                result.Append("null");
            }
            else
            {
                result.Append(tmp_node.element.ToString());
            }

            if (tmp_node.next is not null)
            {
                result.Append(", ");
                tmp_node = tmp_node.next;
            }
            else
            {
                result.Append(']');
                break;
            }
        }
        return result.ToString();
    }
}