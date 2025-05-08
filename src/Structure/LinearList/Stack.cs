namespace Structure.LinearList;

// 栈是一种先入后出FILO的结构 从构造上讲 链表会更适合这种数据结构的内层
// 但是它又是FILO的 链表走了反方向 数组和链表的内部各有千秋 我个人觉得链表适用范围广一些
public class Stack<T> where T : class?
{
    // 指向栈顶的指针
    private Piece top;
    private class Piece
    {
        // 命名为层 存储元素
        internal T? element;
        internal Piece? prev;
        public Piece(T? element, Piece? prev)
        {
            this.element = element;
            this.prev = prev;
        }

        public Piece Copy()
        {
            return new Piece(element, prev);
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

    // 依旧是接受数组初始化
    public Stack(params T[]? array)
    {
        top = new Piece(null, null);
        bool has_top = false;
        // 有数组情况 这里只能说默认后索引的元素占顶部
        if (array is not null && array.Length != 0)
        {
            // 遍历
            foreach (var element in array)
            {
                var tmp_piece = new Piece(element, null);
                if (has_top)
                {
                    In(tmp_piece);
                    continue;
                }

                if (top.prev is null)
                {
                    has_top = true;
                    top = tmp_piece; // 这里没有head的说法 top直接指到这里来
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

    // 入栈操作 这里是底层封装函数
    private void In(Piece piece)
    {
        //Piece tmp = piece.Copy(); NOTE 我觉得这里可能需要Copy 但是考虑Cs的语言特性他这里应该不会GC
        piece.prev = top;
        top = piece;
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
    // 对外入栈操作
    public void Push(T? element)
    {
        // 考虑全部Pop后 这里的连接需要判断
        if (__size == -1)
        {
            // 说明此时top在栈顶
            top = new Piece(element, null); // 直接赋值而不是拉到下一块
            __size = 1;
        }
        else
        {
            In(new Piece(element, null));
        }
    }
    // 对外出栈操作 考虑入栈元素也可能为null
    public T? Pop()
    {
        T? to_re = top.element; // 这里拿一份指针应该没问题
        if (top.prev is null)
        {
            // 拿走了栈底元素
            __size = -1;
            capacity = 0;
        }
        else
        {
            top = top.prev;
            __size--;
            capacity--;
        }
        return to_re; // 这个返回它安全吗老铁
    }
    // 这个直接判断__size就行了
    public bool IsEmpty()
    {
        return __size == -1;
    }

    // 反向输出栈的元素
    public override string ToString()
    {
        Piece? tmp_node = top;
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

            if (tmp_node.prev is not null)
            {
                result.Append(", ");
                tmp_node = tmp_node.prev;
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