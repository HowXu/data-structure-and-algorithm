using System.Collections;

namespace Practice._20;

// 这个老经典的问题了 括号问题语法分析用栈这种数据结构就可以拯救世界
public class Solution
{
    public bool IsValid(string s)
    {
        char[] arr = s.ToArray();
        if (arr.Length % 2 == 1) return false;
        Stack<char> stack = new();
        try{
            foreach (var item in arr)
            {
                switch (item)
                {
                    case '(':
                            {
                                stack.Push(')');
                                break;
                            }
                        
                    case '[':
                        {
                            stack.Push(']');
                            break;
                        }
                    case '{':
                        {
                            stack.Push('}');
                            break;
                        }
                    // 遇到右括号可以直接开始匹配了
                    default:{
                        if(stack.Count == 0 || item != stack.Pop()) return false;
                        // 直接可以提前在这里判断
                        break;
                    }
                }
            }
        }catch(Exception e){
            // 可能遇到左右括号数量不相等的情况 那么这个东西一定会出现Pop异常 可以捕获直接扔掉 也可以直接提前判断栈的长度 这样就不需要异常捕获
            return false;
        }

        return stack.Count == 0; // 不为0说明也不对 可以额外打一个if标签 正常没人这样写看不懂的代码
    }
}