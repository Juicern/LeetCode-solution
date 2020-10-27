using System.Collections.Specialized;
using System.Reflection.Metadata;
using System.Collections;
using System.Collections.Generic;
/*
 * @lc app=leetcode.cn id=992 lang=csharp
 *
 * [992] K 个不同整数的子数组
 *
 * https://leetcode-cn.com/problems/subarrays-with-k-different-integers/description/
 *
 * algorithms
 * Hard (31.34%)
 * Likes:    120
 * Dislikes: 0
 * Total Accepted:    5.3K
 * Total Submissions: 17K
 * Testcase Example:  '[1,2,1,2,3]\n2'
 *
 * 给定一个正整数数组 A，如果 A 的某个子数组中不同整数的个数恰好为 K，则称 A 的这个连续、不一定独立的子数组为好子数组。
 * 
 * （例如，[1,2,3,1,2] 中有 3 个不同的整数：1，2，以及 3。）
 * 
 * 返回 A 中好子数组的数目。
 * 
 * 
 * 
 * 示例 1：
 * 
 * 输入：A = [1,2,1,2,3], K = 2
 * 输出：7
 * 解释：恰好由 2 个不同整数组成的子数组：[1,2], [2,1], [1,2], [2,3], [1,2,1], [2,1,2],
 * [1,2,1,2].
 * 
 * 
 * 示例 2：
 * 
 * 输入：A = [1,2,1,3,4], K = 3
 * 输出：3
 * 解释：恰好由 3 个不同整数组成的子数组：[1,2,1,3], [2,1,3], [1,3,4].
 * 
 * 
 * 
 * 
 * 提示：
 * 
 * 
 * 1 <= A.length <= 20000
 * 1 <= A[i] <= A.length
 * 1 <= K <= A.length
 * 
 * 
 */

// @lc code=start
using System.Collections.Specialized;

public class Solution
{
    public int SubarraysWithKDistinct(int[] A, int K)
    {
        int res = 0;
        Dictionary<int, int> dict = new Dictionary<int, int>();
        // from (start, index) to (current, index)
        // the sum of diffrent numbers is K
        int start = 0;
        int current = 0;
        int index = 0;
        while (index < A.Length)
        {
            if (!dict.ContainsKey(A[index])) dict.Add(A[index], 0);
            dict[A[index]]++;
            if (dict.Keys.Count == K)
            {
                // if dict[A[current]] == 1, decreasing it will make it to be 0
                // then it should be removed from the dict, 
                // and dict.Keys.Count == K - 1
                // so stop when dict[A[current]] == 1
                while (dict[A[current]] > 1)
                {
                    dict[A[current++]]--;
                }
                //from(start, index) to (current, index),
                //they all contain K diffrent numbers
                //so add them(count = current - start + 1)
                res += current - start + 1;
                index++;
            }
            else if(dict.Keys.Count > K){
                //We should start at the next left number
                //else the sum of diffrent numbers will be over K
                //So try to remove the left number 
                //to make the sum equals to K
                while(dict.Keys.Count > K){
                    dict.Remove(A[current++]);
                    start = current;
                }
                dict.Remove(A[index]);
            }
            else index++;
        }
        return res;
    }
}

// @lc code=end

