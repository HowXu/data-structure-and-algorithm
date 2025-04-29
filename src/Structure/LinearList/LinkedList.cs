namespace Structure.LinearList;

// 带头节点的单向链表 因为这类高级语言是直接引用传递 省了指针操作
/**
    where T : class
    这是泛型类型约束，它指定：
    T 必须是引用类型（类、接口、委托或数组类型）
    T 不能是值类型（如 int, double, struct 等）
    T 可以是可为 null 的引用类型（因为有 ? 后缀）
*/
public class LinkedList<T> where T : class?
{

    private class Node
    {
        // 存储元素
        public T? element;
        // 下一个节点 因为带头 所以可空
        public Node? next;
        // 考虑需不需要index呢 C#应该是可以实现的
        public Node(T? element, Node? next)
        {
            this.element = element;
            this.next = next;
        }
    }

    // 头节点
    /**
        只能在声明时或构造函数中赋值
        在其他地方不能修改
    */
    private readonly Node head;
    // 这里多加一个尾部节点 可以极大的减少Append的开销 经典的空间换时间
    private Node? final;
    private int _size;
    public int size
    {
        get
        {
            return _size;
        }
        set
        {
            _size = value;
        }
    }



    // 初始化函数就比较阴间了 首先是不需要size这个参数(这个字段应该用属性的get获取)
    // 其次就是 直接要根据数组直接建立长链表
    public LinkedList(params T[]? array)
    {
        head = new Node(null, null);
        bool has_head = false;
        // 有数组情况
        if (array is not null && array.Length != 0)
        {
            // 遍历
            foreach (var element in array)
            {
                var tmp_node = new Node(element, null);
                if (has_head)
                {
                    Append(tmp_node);
                    continue;
                }
                // 这里用中间has_head直接读取值 省掉一层null比较的开销
                // 不是has_head一定会到这里 是has_head一定到不了这里
                if (head.next is null)
                {
                    has_head = true;
                    head.next = tmp_node;
                    final = tmp_node;
                    size++;
                }
            }

        }
        else // 无数组情况
        {
            final = head;
        }
    }
    // 向列表追加元素
    private void Append(Node node)
    {
        // 这样就可以很简单地建立连接关系
        final!.next = node;
        final = node;
        size++;
    }

    // 获得目标索引所在节点的上一个节点
    private Node Get_index_before_Node(int index)
    {
        // head不算 直接拿next
        Node tmp = head;
        int tmp_index = 0;
        // 这个保证不会出现null轧钢
        if (index >= size || index < 0) throw new IndexOutOfRangeException();
        // 单向链表只能正向遍历 这个性能一下子就不行了
        while (tmp.next is not null && tmp_index != index)
        {
            // 因为head是不算在索引里的 然后前面又有index的检查 所以这里的next一定不是空的 
            // 但是又有可能在最后一个位置插入 所以这里只是索引迭代一直拿到目标位置的指针

            // 因为直接指向head 所以不用延迟
            tmp = tmp.next;
            tmp_index++;
        }
        return tmp;
    }
    // 插入元素
    // 我觉得这里设计缺陷啊 这个index应该是写在Node内层会好一点，这样直接空着干容易轧钢
    public void Insert(int index, T element)
    {
        Node tmp = Get_index_before_Node(index);
        // 这个方法走完了一定是拿到了目标位置的指针的 tmp.next给到newNode构造函数 tmp.next设置为newNode 重新切一下就行
        tmp.next = new Node(element, tmp.next);
        // 插完了记得size
        size++;

        // final可以不用管 不管插在哪里 始终指向最后一个元素
    }

    // 直接添加新元素
    public void Add(T? element)
    {
        // Add不是插入，直接在末尾追加对循环来说很容易轧钢，所以我们用final处理就会很快
        Node tmp = new(element, null);
        final!.next = tmp;
        final = tmp;
        // 别忘了size
        size++;
    }

    // 删除某个元素 直接可以写成Insert的反方向
    public void Remove(int index)
    {
        Node tmp = Get_index_before_Node(index);
        //  涉及final 这里要单独对末尾进行一下判断
        if (tmp.next!.next is null)
        {
            // 说明是删除最后一个元素
            final = tmp; // final移动为当前的tmp
        }
        tmp.next = tmp.next!.next;
        size--;
    }


    public override string ToString()
    {
        Node? tmp_node = head.next;
        if (size == 0)
        {
            return "[]";
        }
        // size不为0这里就不可能不进行循环
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
                // 这里一定是next为null 所以tmp_node会一直保持 你可以给它赋值null或者直接break
                result.Append(']');
                break;
            }
        }
        return result.ToString();
    }
}