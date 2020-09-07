using System.Collections.Generic;
/*
 * @lc app=leetcode.cn id=401 lang=csharp
 *
 * [401] 二进制手表
 *
 * https://leetcode-cn.com/problems/binary-watch/description/
 *
 * algorithms
 * Easy (51.87%)
 * Likes:    136
 * Dislikes: 0
 * Total Accepted:    14.5K
 * Total Submissions: 28K
 * Testcase Example:  '0'
 *
 * 二进制手表顶部有 4 个 LED 代表 小时（0-11），底部的 6 个 LED 代表 分钟（0-59）。
 * 
 * 每个 LED 代表一个 0 或 1，最低位在右侧。
 * 
 * 
 * 
 * 例如，上面的二进制手表读取 “3:25”。
 * 
 * 给定一个非负整数 n 代表当前 LED 亮着的数量，返回所有可能的时间。
 * 
 * 
 * 
 * 示例：
 * 
 * 输入: n = 1
 * 返回: ["1:00", "2:00", "4:00", "8:00", "0:01", "0:02", "0:04", "0:08", "0:16",
 * "0:32"]
 * 
 * 
 * 
 * 提示：
 * 
 * 
 * 输出的顺序没有要求。
 * 小时不会以零开头，比如 “01:00” 是不允许的，应为 “1:00”。
 * 分钟必须由两位数组成，可能会以零开头，比如 “10:2” 是无效的，应为 “10:02”。
 * 超过表示范围（小时 0-11，分钟 0-59）的数据将会被舍弃，也就是说不会出现 "13:00", "0:61" 等时间。
 * 
 * 
 */

// @lc code=start
public class Solution
{
    private void BackTracking(int index, int num, int hour, int minute, List<string> ans)
    {
        if (hour > 11 || minute > 59) return;
        if (num > 10 - index) return;
        if (num == 0)
        {
            ans.Add(hour + ":" + (minute < 10 ? "0" : "") + minute);
            return;
        }
        BackTracking(index + 1, num, hour, minute, ans);
        if (index < 4) BackTracking(index + 1, num - 1, hour + (1 << index), minute, ans);
        else BackTracking(index + 1, num - 1, hour, minute + (1 << (index - 4)), ans);
    }
    public IList<string> ReadBinaryWatch(int num)
    {
        List<string> ans = new List<string>();
        BackTracking(0, num, 0, 0, ans);
        return ans;
    }
}
// @lc code=end

