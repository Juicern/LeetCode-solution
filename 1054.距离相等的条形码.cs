/*
 * @lc app=leetcode.cn id=1054 lang=csharp
 *
 * [1054] 距离相等的条形码
 *
 * https://leetcode-cn.com/problems/distant-barcodes/description/
 *
 * algorithms
 * Medium (35.50%)
 * Likes:    55
 * Dislikes: 0
 * Total Accepted:    5.8K
 * Total Submissions: 16.2K
 * Testcase Example:  '[1,1,1,2,2,2]'
 *
 * 在一个仓库里，有一排条形码，其中第 i 个条形码为 barcodes[i]。
 * 
 * 请你重新排列这些条形码，使其中两个相邻的条形码 不能 相等。 你可以返回任何满足该要求的答案，此题保证存在答案。
 * 
 * 
 * 
 * 示例 1：
 * 
 * 输入：[1,1,1,2,2,2]
 * 输出：[2,1,2,1,2,1]
 * 
 * 
 * 示例 2：
 * 
 * 输入：[1,1,1,1,2,2,3,3]
 * 输出：[1,3,1,3,2,1,2,1]
 * 
 * 
 * 
 * 提示：
 * 
 * 
 * 1 <= barcodes.length <= 10000
 * 1 <= barcodes[i] <= 10000
 * 
 * 
 * 
 * 
 */

// @lc code=start
public class Solution {
    public int[] RearrangeBarcodes(int[] barcodes) {
        Dictionary<int, int> count = new Dictionary<int, int>(); 
        foreach(var barcode in barcodes) {
            if(!count.ContainsKey(barcode)) count.Add(barcode, 1);
            else count[barcode]++;
        }
        count = count.OrderBy(x => -x.Value).ToDictionary(x => x.Key, x => x.Value);
        int index = 0;
        var ans = new int[barcodes.Length];
        foreach(var key in count.Keys) {
            int times = count[key];
            while(times > 0) {
                ans[index] = key;
                index += 2;
                if(index >= barcodes.Length) index = 1;
                times--;
            }
        }
        return ans;
    }
}
// @lc code=end

