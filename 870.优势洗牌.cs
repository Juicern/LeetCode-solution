/*
 * @lc app=leetcode.cn id=870 lang=csharp
 *
 * [870] 优势洗牌
 *
 * https://leetcode-cn.com/problems/advantage-shuffle/description/
 *
 * algorithms
 * Medium (37.42%)
 * Likes:    59
 * Dislikes: 0
 * Total Accepted:    6.5K
 * Total Submissions: 17.3K
 * Testcase Example:  '[2,7,11,15]\n[1,10,4,11]'
 *
 * 给定两个大小相等的数组 A 和 B，A 相对于 B 的优势可以用满足 A[i] > B[i] 的索引 i 的数目来描述。
 * 
 * 返回 A 的任意排列，使其相对于 B 的优势最大化。
 * 
 * 
 * 
 * 示例 1：
 * 
 * 输入：A = [2,7,11,15], B = [1,10,4,11]
 * 输出：[2,11,7,15]
 * 
 * 
 * 示例 2：
 * 
 * 输入：A = [12,24,8,32], B = [13,25,32,11]
 * 输出：[24,32,8,12]
 * 
 * 
 * 
 * 
 * 提示：
 * 
 * 
 * 1 <= A.length = B.length <= 10000
 * 0 <= A[i] <= 10^9
 * 0 <= B[i] <= 10^9
 * 
 * 
 */

// @lc code=start
public class Solution 
{
    public int[] AdvantageCount(int[] A, int[] B) 
    {
        List<int> result = new List<int>(), list = new List<int>(A);
        list.Sort();
        for(int i = 0; i < B.Length; i++)
        {
            var index = list.BinarySearch(B[i] + 1);
            if(index < 0) index = ~index;
            if(index == list.Count) index = 0;
            result.Add(list[index]);
            list.RemoveAt(index);
        }
        return result.ToArray();
    }
}
// @lc code=end

