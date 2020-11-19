/*
 * @lc app=leetcode.cn id=592 lang=csharp
 *
 * [592] 分数加减运算
 *
 * https://leetcode-cn.com/problems/fraction-addition-and-subtraction/description/
 *
 * algorithms
 * Medium (50.70%)
 * Likes:    35
 * Dislikes: 0
 * Total Accepted:    2.9K
 * Total Submissions: 5.6K
 * Testcase Example:  '"-1/2+1/2"'
 *
 * 给定一个表示分数加减运算表达式的字符串，你需要返回一个字符串形式的计算结果。 这个结果应该是不可约分的分数，即最简分数。 如果最终结果是一个整数，例如
 * 2，你需要将它转换成分数形式，其分母为 1。所以在上述例子中, 2 应该被转换为 2/1。
 * 
 * 示例 1:
 * 
 * 
 * 输入:"-1/2+1/2"
 * 输出: "0/1"
 * 
 * 
 * 示例 2:
 * 
 * 
 * 输入:"-1/2+1/2+1/3"
 * 输出: "1/3"
 * 
 * 
 * 示例 3:
 * 
 * 
 * 输入:"1/3-1/2"
 * 输出: "-1/6"
 * 
 * 
 * 示例 4:
 * 
 * 
 * 输入:"5/3+1/3"
 * 输出: "2/1"
 * 
 * 
 * 说明:
 * 
 * 
 * 输入和输出字符串只包含 '0' 到 '9' 的数字，以及 '/', '+' 和 '-'。 
 * 输入和输出分数格式均为 ±分子/分母。如果输入的第一个分数或者输出的分数是正数，则 '+' 会被省略掉。
 * 输入只包含合法的最简分数，每个分数的分子与分母的范围是  [1,10]。 如果分母是1，意味着这个分数实际上是一个整数。
 * 输入的分数个数范围是 [1,10]。
 * 最终结果的分子与分母保证是 32 位整数范围内的有效整数。
 * 
 * 
 */
// @lc code=start
public class Solution
{
    //分数计算 只有加减

    public string
    FractionAddition(string expression) //7/2+2/3-3/4
    {
        int monther = 1; //通分分母
        int son = 0;
        List<int> sons = new List<int>();
        expression.Trim(); //去除空格
        string[] sSplit = expression.Split('+', '-'); //按 + 分割

        foreach (string str in sSplit)
        {
            if (!string.IsNullOrEmpty(str))
            {
                string[] temp = str.Split('/'); //找分母
                if (monther % Convert.ToInt32(temp[1]) != 0)
                {
                    monther = monther * Convert.ToInt32(temp[1]); //通分
                }
            }
        }

        foreach (string str in sSplit)
        {
            if (!string.IsNullOrEmpty(str))
            {
                string[] temp = str.Split('/');
                sons
                    .Add(Convert.ToInt32(temp[0]) *
                    (monther / Convert.ToInt32(temp[1]))); //分子
            }
        }
        sSplit = expression.Split('/');
        for (int i = 0; i < sSplit.Length; i++)
        {
            int count = sSplit[i].Split('-', '+').Length;
            if (
                count == 1 //不含有 + -
            )
            {
                son = Convert.ToInt32(sSplit[i]);
            }
            else
            {
                int length = sSplit[i].Split('-', '+')[0].Length;
                son = Convert.ToInt32(sSplit[i].Remove(0, length));
            }
            if (
                son < 0 //分子符号
            )
            {
                sons[i] = sons[i] * -1;
            }
        }
        son = 0;
        foreach (var temp in sons)
        {
            son = son + temp;
        }
        A:
        int min =
            (
            Math.Abs(son) < Math.Abs(monther)
                ? Math.Abs(son)
                : Math.Abs(monther)
            );
        for (int i = 2; i <= min; i++)
        {
            if (son % i == 0 && monther % i == 0)
            {
                son = son / i;
                monther = monther / i;
                goto A; //约分
            }
        }
        if (son == 0) monther = 1; //判断0
        return son.ToString() + "/" + monther.ToString();
    }
}

// @lc code=end
