using System;
/*
 * @lc app=leetcode.cn id=826 lang=csharp
 *
 * [826] 安排工作以达到最大收益
 *
 * https://leetcode-cn.com/problems/most-profit-assigning-work/description/
 *
 * algorithms
 * Medium (35.58%)
 * Likes:    36
 * Dislikes: 0
 * Total Accepted:    4.5K
 * Total Submissions: 12.7K
 * Testcase Example:  '[2,4,6,8,10]\n[10,20,30,40,50]\n[4,5,6,7]'
 *
 * 有一些工作：difficulty[i] 表示第 i 个工作的难度，profit[i] 表示第 i 个工作的收益。
 * 
 * 现在我们有一些工人。worker[i] 是第 i 个工人的能力，即该工人只能完成难度小于等于 worker[i] 的工作。
 * 
 * 每一个工人都最多只能安排一个工作，但是一个工作可以完成多次。
 * 
 * 举个例子，如果 3 个工人都尝试完成一份报酬为 1 的同样工作，那么总收益为 $3。如果一个工人不能完成任何工作，他的收益为 $0 。
 * 
 * 我们能得到的最大收益是多少？
 * 
 * 
 * 
 * 示例：
 * 
 * 输入: difficulty = [2,4,6,8,10], profit = [10,20,30,40,50], worker = [4,5,6,7]
 * 输出: 100 
 * 解释: 工人被分配的工作难度是 [4,4,6,6] ，分别获得 [20,20,30,30] 的收益。
 * 
 * 
 * 
 * 提示:
 * 
 * 
 * 1 <= difficulty.length = profit.length <= 10000
 * 1 <= worker.length <= 10000
 * difficulty[i], profit[i], worker[i]  的范围是 [1, 10^5]
 * 
 * 
 */

// @lc code=start
public class Solution {
    public int MaxProfitAssignment(int[] difficulty, int[] profit, int[] worker) {
        int n = difficulty.Length;
        int m = worker.Length;
        var work = new Work[n];
        for(int i =0; i<n;i++) 
        {
            work[i] = new Work(difficulty[i], profit[i]);
        }
        Array.Sort(work, (o1, o2) => o1.difficulty - o2.difficulty);
        Array.Sort(worker);
        int ans = 0;
        int index1 = 0;
        int index2 = 0;
        int max = 0;
        while(index1 < n && index2 < m) {
            if(work[index1].difficulty <= worker[index2]) {
                max = Math.Max(max, work[index1].profit);
                index1++;
            }
            else {
                ans += max;
                index2++;
            }
        }
        ans += (m - index2) * max;
        return ans;
    }

}
public class Work {
    public int difficulty;
    public int profit;
    public Work(int difficulty, int profit) {
        this.difficulty = difficulty;
        this.profit = profit;
    }
}
// @lc code=end

