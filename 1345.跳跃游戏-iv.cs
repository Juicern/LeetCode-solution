/*
 * @lc app=leetcode.cn id=1345 lang=csharp
 *
 * [1345] 跳跃游戏 IV
 *
 * https://leetcode-cn.com/problems/jump-game-iv/description/
 *
 * algorithms
 * Hard (35.49%)
 * Likes:    42
 * Dislikes: 0
 * Total Accepted:    4.1K
 * Total Submissions: 11.5K
 * Testcase Example:  '[100,-23,-23,404,100,23,23,23,3,404]'
 *
 * 给你一个整数数组 arr ，你一开始在数组的第一个元素处（下标为 0）。
 * 
 * 每一步，你可以从下标 i 跳到下标：
 * 
 * 
 * i + 1 满足：i + 1 < arr.length
 * i - 1 满足：i - 1 >= 0
 * j 满足：arr[i] == arr[j] 且 i != j
 * 
 * 
 * 请你返回到达数组最后一个元素的下标处所需的 最少操作次数 。
 * 
 * 注意：任何时候你都不能跳到数组外面。
 * 
 * 
 * 
 * 示例 1：
 * 
 * 输入：arr = [100,-23,-23,404,100,23,23,23,3,404]
 * 输出：3
 * 解释：那你需要跳跃 3 次，下标依次为 0 --> 4 --> 3 --> 9 。下标 9 为数组的最后一个元素的下标。
 * 
 * 
 * 示例 2：
 * 
 * 输入：arr = [7]
 * 输出：0
 * 解释：一开始就在最后一个元素处，所以你不需要跳跃。
 * 
 * 
 * 示例 3：
 * 
 * 输入：arr = [7,6,9,6,9,6,9,7]
 * 输出：1
 * 解释：你可以直接从下标 0 处跳到下标 7 处，也就是数组的最后一个元素处。
 * 
 * 
 * 示例 4：
 * 
 * 输入：arr = [6,1,9]
 * 输出：2
 * 
 * 
 * 示例 5：
 * 
 * 输入：arr = [11,22,7,7,7,7,7,7,7,22,13]
 * 输出：3
 * 
 * 
 * 
 * 
 * 提示：
 * 
 * 
 * 1 <= arr.length <= 5 * 10^4
 * -10^8 <= arr[i] <= 10^8
 * 
 * 
 */
// @lc code=start
public class Solution
{
    public int MinJumps(int[] arr)
    {
        int n = arr.Length;
        var visited = new bool[n];
        IDictionary<int, IList<int>> dict = new Dictionary<int, IList<int>>();
        for (int i = 0; i < n; i++)
        {
            if (!dict.ContainsKey(arr[i]))
            {
                dict.Add(arr[i], new List<int>());
            }
            dict[arr[i]].Add(i);
            int steps = 1;
            while (i + steps < n && arr[i + steps] == arr[i])
            {
                visited[i + steps] = true;
                steps++;
            }
            if (steps > 1)
            {
                dict[arr[i]].Add(i + steps - 1);
                visited[i + steps - 1] = false;
            }
            i = i + steps - 1;
        }
        var queue = new Queue<int>();
        queue.Enqueue(0);
        visited[0] = true;
        int ans = 0;
        while (queue.Any())
        {
            int size = queue.Count;
            for (int _ = 0; _ < size; _++)
            {
                int index = queue.Dequeue();
                visited[index] = true;
                if (index == n - 1) return ans;
                if (index > 0 && !visited[index - 1]) queue.Enqueue(index - 1);
                if (index < n - 1 && !visited[index + 1])
                    queue.Enqueue(index + 1);
                foreach (var i in dict[arr[index]])
                {
                    if (!visited[i]) queue.Enqueue(i);
                }
            }
            ans++;
        }
        return ans;
    }
}
// @lc code=end
