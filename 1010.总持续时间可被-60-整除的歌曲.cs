using System.Collections.Generic;
using System.Threading;

/*
 * @lc app=leetcode.cn id=1010 lang=csharp
 *
 * [1010] 总持续时间可被 60 整除的歌曲
 *
 * https://leetcode-cn.com/problems/pairs-of-songs-with-total-durations-divisible-by-60/description/
 *
 * algorithms
 * Easy (43.56%)
 * Likes:    111
 * Dislikes: 0
 * Total Accepted:    15.5K
 * Total Submissions: 35.5K
 * Testcase Example:  '[30,20,150,100,40]'
 *
 * 在歌曲列表中，第 i 首歌曲的持续时间为 time[i] 秒。
 * 
 * 返回其总持续时间（以秒为单位）可被 60 整除的歌曲对的数量。形式上，我们希望索引的数字 i 和 j 满足  i < j 且有 (time[i] +
 * time[j]) % 60 == 0。
 * 
 * 
 * 
 * 示例 1：
 * 
 * 输入：[30,20,150,100,40]
 * 输出：3
 * 解释：这三对的总持续时间可被 60 整数：
 * (time[0] = 30, time[2] = 150): 总持续时间 180
 * (time[1] = 20, time[3] = 100): 总持续时间 120
 * (time[1] = 20, time[4] = 40): 总持续时间 60
 * 
 * 
 * 示例 2：
 * 
 * 输入：[60,60,60]
 * 输出：3
 * 解释：所有三对的总持续时间都是 120，可以被 60 整数。
 * 
 * 
 * 
 * 
 * 提示：
 * 
 * 
 * 1 <= time.length <= 60000
 * 1 <= time[i] <= 500
 * 
 * 
 */

// @lc code=start
public class Solution {
    public int NumPairsDivisibleBy60(int[] times) {
        var dict = new Dictionary<int, int>();
        foreach(var time in times) {
            if(!dict.ContainsKey(time % 60)) dict.Add(time % 60, 0);
            dict[time % 60]++;
        }
        int count = 0;
        foreach(var time in times) {
            if(time % 60 == 0) count += dict[0] - 1;
            else {
                dict[time % 60]--;
                if(dict.ContainsKey(60 - time % 60)) count += dict[60 - time % 60];
                dict[time % 60]++; 
            }
        }
        return count / 2; 
    }
}
// @lc code=end

