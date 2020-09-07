/*
 * @lc app=leetcode.cn id=786 lang=csharp
 *
 * [786] 第 K 个最小的素数分数
 *
 * https://leetcode-cn.com/problems/k-th-smallest-prime-fraction/description/
 *
 * algorithms
 * Hard (38.21%)
 * Likes:    40
 * Dislikes: 0
 * Total Accepted:    1.5K
 * Total Submissions: 3.9K
 * Testcase Example:  '[1,2,3,5]\n3'
 *
 * 一个已排序好的表 A，其包含 1 和其他一些素数.  当列表中的每一个 p<q 时，我们可以构造一个分数 p/q 。
 * 
 * 那么第 k 个最小的分数是多少呢?  以整数数组的形式返回你的答案, 这里 answer[0] = p 且 answer[1] = q.
 * 
 * 示例:
 * 输入: A = [1, 2, 3, 5], K = 3
 * 输出: [2, 5]
 * 解释:
 * 已构造好的分数,排序后如下所示:
 * 1/5, 1/3, 2/5, 1/2, 3/5, 2/3.
 * 很明显第三个最小的分数是 2/5.
 * 
 * 输入: A = [1, 7], K = 1
 * 输出: [1, 7]
 * 
 * 
 * 注意:
 * 
 * 
 * A 长度的取值范围在 2 — 2000.
 * 每个 A[i] 的值在 1 —30000.
 * K 取值范围为 1 —A.length * (A.length - 1) / 2
 * 
 * 
 */

// @lc code=start
public class Solution
{
    public int[] KthSmallestPrimeFraction(int[] A, int K)
    {
        int n = A.Length;
        double left = 0, right = 1;
        int p = 0;
        int q = 1;
        while (true)
        {
            int count = 0;
            p = 0;
            double mid = (left + right) / 2;
            for (int i = 0; i < n; i++)
            {
                int j = n - 1;
                while (j >= 0 && A[i] > mid * A[n - 1 - j]) j--;
                count += (j + 1);
                if (j >= 0 && p * A[n - 1 - j] < q * A[i])
                {
                    p = A[i];
                    q = A[n - 1 - j];
                }
            }
            if (count < K) left = mid;
            else if (count > K) right = mid;
            else return new int[] { p, q };
        }
        
    }
}
// @lc code=end

