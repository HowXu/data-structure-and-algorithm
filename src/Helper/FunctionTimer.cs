namespace Helper;

using System.Diagnostics;

public class FunctionTimer
{
    /// <summary>
    /// 执行函数并统计其运行时间
    /// </summary>
    /// <typeparam name="T">输入参数类型</typeparam>
    /// <typeparam name="TResult">返回结果类型</typeparam>
    /// <param name="func">要执行的函数</param>
    /// <param name="input">函数的输入参数</param>
    /// <param name="elapsedTime">输出参数，函数执行耗时</param>
    /// <returns>函数的执行结果</returns>
    public static TResult MeasureFunction<T, TResult>(Func<T, TResult> func, T input, out TimeSpan elapsedTime)
    {
        Stopwatch stopwatch = Stopwatch.StartNew();
        TResult result = func(input);
        stopwatch.Stop();

        elapsedTime = stopwatch.Elapsed;
        return result;
    }

    /// <summary>
    /// 执行无参函数并统计其运行时间
    /// </summary>
    /// <typeparam name="TResult">返回结果类型</typeparam>
    /// <param name="func">要执行的函数</param>
    /// <param name="elapsedTime">输出参数，函数执行耗时</param>
    /// <returns>函数的执行结果</returns>
    public static TResult MeasureFunction<TResult>(Func<TResult> func, out TimeSpan elapsedTime)
    {
        Stopwatch stopwatch = Stopwatch.StartNew();
        TResult result = func();
        stopwatch.Stop();

        elapsedTime = stopwatch.Elapsed;
        return result;
    }
}