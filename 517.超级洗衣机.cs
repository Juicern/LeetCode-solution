using System;
/*
 * @lc app=leetcode.cn id=517 lang=csharp
 *
 * [517] 超级洗衣机
 *
 * https://leetcode-cn.com/problems/super-washing-machines/description/
 *
 * algorithms
 * Hard (41.89%)
 * Likes:    45
 * Dislikes: 0
 * Total Accepted:    1.9K
 * Total Submissions: 4.6K
 * Testcase Example:  '[1,0,5]'
 *
 * 假设有 n 台超级洗衣机放在同一排上。开始的时候，每台洗衣机内可能有一定量的衣服，也可能是空的。
 * 
 * 在每一步操作中，你可以选择任意 m （1 ≤ m ≤ n） 台洗衣机，与此同时将每台洗衣机的一件衣服送到相邻的一台洗衣机。
 * 
 * 
 * 给定一个非负整数数组代表从左至右每台洗衣机中的衣物数量，请给出能让所有洗衣机中剩下的衣物的数量相等的最少的操作步数。如果不能使每台洗衣机中衣物的数量相等，则返回
 * -1。
 * 
 * 
 * 
 * 示例 1：
 * 
 * 输入: [1,0,5]
 * 
 * 输出: 3
 * 
 * 解释: 
 * 第一步:    1     0 <-- 5    =>    1     1     4
 * 第二步:    1 <-- 1 <-- 4    =>    2     1     3    
 * 第三步:    2     1 <-- 3    =>    2     2     2   
 * 
 * 
 * 示例 2：
 * 
 * 输入: [0,3,0]
 * 
 * 输出: 2
 * 
 * 解释: 
 * 第一步:    0 <-- 3     0    =>    1     2     0    
 * 第二步:    1     2 --> 0    =>    1     1     1     
 * 
 * 
 * 示例 3:
 * 
 * 输入: [0,2,0]
 * 
 * 输出: -1
 * 
 * 解释: 
 * 不可能让所有三个洗衣机同时剩下相同数量的衣物。
 * 
 * 
 * 
 * 
 * 提示：
 * 
 * 
 * n 的范围是 [1, 10000]。
 * 在每台超级洗衣机中，衣物数量的范围是 [0, 1e5]。
 * 
 * 
 * 
 * 
 */

// @lc code=start
public class Solution {
    public int FindMinMoves(int[] machines) {
        int n = machines.Length;
        int sum = machines.Sum();
        if(sum % n != 0) return -1;
        int perMachine = sum / n;
        for(int i = 0;i<n;i++) machines[i] -= perMachine;
        int maxClothes = 0;
        int preSum = 0;
        int res = 0;
        foreach(var machine in machines) {
            maxClothes = Math.Max(maxClothes, machine);
            preSum += machine;
            res = Math.Max(res, Math.Abs(preSum));
        }
        return Math.Max(res, maxClothes);
    }
}
// @lc code=end

