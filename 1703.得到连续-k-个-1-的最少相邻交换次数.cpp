/*
 * @lc app=leetcode.cn id=1703 lang=cpp
 *
 * [1703] 得到连续 K 个 1 的最少相邻交换次数
 *
 * https://leetcode-cn.com/problems/minimum-adjacent-swaps-for-k-consecutive-ones/description/
 *
 * algorithms
 * Hard (39.19%)
 * Likes:    19
 * Dislikes: 0
 * Total Accepted:    868
 * Total Submissions: 2.2K
 * Testcase Example:  '[1,0,0,1,0,1]\n2'
 *
 * 给你一个整数数组 nums 和一个整数 k 。 nums 仅包含 0 和 1 。每一次移动，你可以选择 相邻 两个数字并将它们交换。
 * 
 * 请你返回使 nums 中包含 k 个 连续 1 的 最少 交换次数。
 * 
 * 
 * 
 * 示例 1：
 * 
 * 输入：nums = [1,0,0,1,0,1], k = 2
 * 输出：1
 * 解释：在第一次操作时，nums 可以变成 [1,0,0,0,1,1] 得到连续两个 1 。
 * 
 * 
 * 示例 2：
 * 
 * 输入：nums = [1,0,0,0,0,0,1,1], k = 3
 * 输出：5
 * 解释：通过 5 次操作，最左边的 1 可以移到右边直到 nums 变为 [0,0,0,0,0,1,1,1] 。
 * 
 * 
 * 示例 3：
 * 
 * 输入：nums = [1,1,0,1], k = 2
 * 输出：0
 * 解释：nums 已经有连续 2 个 1 了。
 * 
 * 
 * 
 * 
 * 提示：
 * 
 * 
 * 1 <= nums.length <= 10^5
 * nums[i] 要么是 0 ，要么是 1 。
 * 1 <= k <= sum(nums)
 * 
 * 
 */

// @lc code=start
#include<vector>

using namespace std;

class Solution {
public:
    int minMoves(vector<int>& nums, int k) {
        if (k == 1) {
            return 0;
        }
        
        int n = nums.size();
        vector<int> g;
        vector<int> sum = {0};
        int count = -1;
        for (int i = 0; i < n; ++i) {
            if (nums[i] == 1) {
                ++count;
                g.push_back(i - count);
                sum.push_back(sum.back() + g.back());
            }
        }
        
        int m = g.size();
        int ans = INT_MAX;
        for (int i = 0; i + k <= m; ++i) {
            int mid = (i + i + k - 1) / 2;
            int q = g[mid];
            ans = min(ans, (2 * (mid - i) - k + 1) * q + (sum[i + k] - sum[mid + 1]) - (sum[mid] - sum[i]));
        }
        
        return ans;
    }
};
// @lc code=end

