namespace Structure.LinearList;

// 基于数组的线性表 称为ArrayList 随机存取的一种数据结构
// 这个我写的是非线程安全的
public class ArrayList<T>
{
    // 基于数组所以内部有一个数组 不可能为空
    private T[]? inner_array;
    // 容量声明
    private int capacity;
    private int default_capacity = 8;

    // 数组元素声明
    public int size = 0; // 可以直接访问

    // 构造函数初始化
    // 这个构造函数要分两类 一种传入数组给你造的 一种传入多参数给你造的
    // 这个Array可以是可变参数 也可以直接数组
    public ArrayList(int capacity = 8, params T[]? array)
    {
        // 首先应该判断array
        if (array is not null && array.Length != 0)
        {
            // 当这个 array 不为空时 应该把内部数组初始化为array
            this.capacity = array.Length;
            size = array.Length;
            inner_array = (T[])array.Clone(); // 浅拷贝
        }
        else
        {
            size = 0;
            this.capacity = capacity; // 容量声明
            inner_array = new T[capacity]; // 直接new一个就行
        }
    }
    // 两种写法
    public ArrayList(params T[]? array)
    {
        if (array is not null && array.Length != 0)
        {
            // 当这个 array 不为空时 应该把内部数组初始化为array
            capacity = array.Length;
            size = array.Length;
            inner_array = (T[])array.Clone(); // 浅拷贝
        }
        else
        {
            size = 0;
            capacity = 8; // 容量声明
            inner_array = new T[capacity]; // 直接new一个就行
        }
    }

    // 插入元素函数 参数为index和插入元素
    public void Insert(int index, T element)
    {
        // 首先判断插入长度是否超过
        if (index < 0 || index >= capacity)
        {
            // 不能在大于等于capacity的位置插入的 也不能在负数位置
            throw new IndexOutOfRangeException();
        }
        else
        {
            // 插入前要判断一下是不是已经满了
            if (capacity == size)
            {
                // 扩容 这个扩容的机制其实相当复杂(内存和运行 空间和时间) 这里简单一点就是加一倍的默认capacity
                Resize(capacity + default_capacity >> 1);
            }

            // 执行插入逻辑 把已有的元素从index位置后移1位
            for (int i = size - 1; i >= index; i--)
            {
                // 因为前面进行扩容了 所以这里一定不会索引超出
                inner_array![i + 1] = inner_array[i]; // 一定不会为空
            }
            // 移动之后赋值就行了
            inner_array![index] = element;
            size += 1; // size变化
        }
    }

    // 删除元素操作
    public void Remove(int index)
    {
        if (index < 0 || index >= capacity)
        {
            throw new IndexOutOfRangeException();
        }
        else
        {
            if (size - 1  <= capacity >> 1)
            {
                Resize((capacity >> 1) + 1); // +1防止异常操作
            }

            for (int i = index; i < size - 1; i++)
            {
                inner_array![i] = inner_array[i+1]; // 一定不会为空
            }

            size -= 1; // size变化
        }
    }

    // 获取元素
    public T Get(int index){
        if (index < 0 || index >= capacity)
        {
            throw new IndexOutOfRangeException();
        }
        else
        {
            return inner_array![index];
        }
    }

    // 寻找对应元素下标
    public int IndexOf(T target)
    {
        // 循环来找实在是没有性能我说实话 这里应该有更好的办法
        for(int i=0;i < size;i++){
            // 考虑到T可能塞了null值进去 这里判断一下
            if(inner_array![i] is not null &&inner_array![i].Equals(target)){
                return i;
            }
        }
        return -1;
    }

    // 动态扩容函数
    private void Resize(int needed_capacity)
    {
        // 这个Resize我们直接给到需求空间 最大化减少内存使用
        // C# 没有足够强大的数组操作函数 所以只能比较低效地进行一下
        T[] newArray = new T[needed_capacity];
        // 复制新的数组
        Array.Copy(inner_array!, newArray, size); // 这里inner_array 不可能为空 拷贝长度只取用size有效元素长度省一层访问开销
        inner_array = newArray; // 重新设置指针 原来的inner_array会被回收
        capacity = needed_capacity; // 容量变化
    }

    // 转换为字符串函数 这个不是普适的 Debug Only
    public override string ToString()
    {
        if (size == 0)
        {
            return "[]";
        }

        var result = new System.Text.StringBuilder("[");
        for (int i = 0; i < size; i++)
        {
            if (inner_array![i] != null)
            {
                result.Append(inner_array![i].ToString());
            }
            else
            {
                result.Append("null");
            }

            if (i < size - 1)
            {
                result.Append(", ");
            }
        }
        result.Append(']');
        return result.ToString();
    }

}