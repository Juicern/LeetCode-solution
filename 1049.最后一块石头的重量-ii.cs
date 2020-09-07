using System.Linq;
/*
 * @lc app=leetcode.cn id=1049 lang=csharp
 *
 * [1049] 最后一块石头的重量 II
 *
 * https://leetcode-cn.com/problems/last-stone-weight-ii/description/
 *
 * algorithms
 * Medium (44.71%)
 * Likes:    66
 * Dislikes: 0
 * Total Accepted:    3.5K
 * Total Submissions: 7.7K
 * Testcase Example:  '[2,7,4,1,8,1]'
 *
 * 有一堆石头，每块石头的重量都是正整数。
 * 
 * 每一回合，从中选出任意两块石头，然后将它们一起粉碎。假设石头的重量分别为 x 和 y，且 x <= y。那么粉碎的可能结果如下：
 * 
 * 
 * 如果 x == y，那么两块石头都会被完全粉碎；
 * 如果 x != y，那么重量为 x 的石头将会完全粉碎，而重量为 y 的石头新重量为 y-x。
 * 
 * 
 * 最后，最多只会剩下一块石头。返回此石头最小的可能重量。如果没有石头剩下，就返回 0。
 * 
 * 
 * 
 * 示例：
 * 
 * 输入：[2,7,4,1,8,1]
 * 输出：1
 * 解释：
 * 组合 2 和 4，得到 2，所以数组转化为 [2,7,1,8,1]，
 * 组合 7 和 8，得到 1，所以数组转化为 [2,1,1,1]，
 * 组合 2 和 1，得到 1，所以数组转化为 [1,1,1]，
 * 组合 1 和 1，得到 0，所以数组转化为 [1]，这就是最优值。
 * 
 * 
 * 
 * 
 * 提示：
 * 
 * 
 * 1 <= stones.length <= 30
 * 1 <= stones[i] <= 1000
 * 
 * 
 */

// @lc code=start
public class Solution {
    public int LastStoneWeightII(int[] stones) {
        int sum = stones.Sum();
        for(int i=(sum>>1);;i--)
        {
            if(helper(stones, 0, 0, i)) return sum - 2 * i;
        }
    }
    private bool helper(int[] stones, int index, int sum, int target)
    {
        if(target == sum) return true;
        if(index==stones.Length) return false;
        if(sum > target) return false;
        return helper(stones, index+1, sum + stones[index], target)
            || helper(stones, index+1, sum, target);
    }
}
// @lc code=end

