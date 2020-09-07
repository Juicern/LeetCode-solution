using System.Linq;
using System.Collections.Generic;
using System;
/*
 * @lc app=leetcode.cn id=954 lang=csharp
 *
 * [954] 二倍数对数组
 *
 * https://leetcode-cn.com/problems/array-of-doubled-pairs/description/
 *
 * algorithms
 * Medium (27.26%)
 * Likes:    22
 * Dislikes: 0
 * Total Accepted:    3K
 * Total Submissions: 11K
 * Testcase Example:  '[3,1,3,6]'
 *
 * 给定一个长度为偶数的整数数组 A，只有对 A 进行重组后可以满足 “对于每个 0 <= i < len(A) / 2，都有 A[2 * i + 1] =
 * 2 * A[2 * i]” 时，返回 true；否则，返回 false。
 * 
 * 
 * 
 * 示例 1：
 * 
 * 输入：[3,1,3,6]
 * 输出：false
 * 
 * 
 * 示例 2：
 * 
 * 输入：[2,1,2,6]
 * 输出：false
 * 
 * 
 * 示例 3：
 * 
 * 输入：[4,-2,2,-4]
 * 输出：true
 * 解释：我们可以用 [-2,-4] 和 [2,4] 这两组组成 [-2,-4,2,4] 或是 [2,4,-2,-4]
 * 
 * 示例 4：
 * 
 * 输入：[1,2,4,16,8,4]
 * 输出：false
 * 
 * 
 * 
 * 
 * 提示：
 * 
 * 
 * 0 <= A.length <= 30000
 * A.length 为偶数
 * -100000 <= A[i] <= 100000
 * 
 * 
 */

// @lc code=start
public class Solution
{
    public bool CanReorderDoubled(int[] A)
    {
        Array.Sort(A);
        int zero = A.Length;
        for(int i=0;i<A.Length;i++) {
            if(A[i] >= 0) {zero = i;break;}
        }
        var list1 = new List<int>(A.Take(zero).ToArray());
        var list2 = new List<int>(A.Skip(zero).ToArray());
        while(list1.Count > 0)
        {
            int index = list1.BinarySearch(list1[list1.Count-1] * 2);
            if(index<0) return false;
            if(index==list1.Count-1) index--;
            if(index==-1 || list1[index] != list1[list1.Count-1] * 2) return false;
            list1.RemoveAt(index);
            list1.RemoveAt(list1.Count-1);
        }
        while(list2.Count > 0)
        {
            int index = list2.BinarySearch(list2[0] * 2);
            if(index<0) return false;
            if(index==0) index++;
            if(index==list2.Count || list2[index] != list2[0] * 2) return false;
            list2.RemoveAt(index);
            list2.RemoveAt(0);
        }
        return true;
    }
}
// @lc code=end

