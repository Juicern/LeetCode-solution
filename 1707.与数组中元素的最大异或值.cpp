/*
 * @lc app=leetcode.cn id=1707 lang=cpp
 *
 * [1707] 与数组中元素的最大异或值
 *
 * https://leetcode-cn.com/problems/maximum-xor-with-an-element-from-array/description/
 *
 * algorithms
 * Hard (42.71%)
 * Likes:    21
 * Dislikes: 0
 * Total Accepted:    1.6K
 * Total Submissions: 3.8K
 * Testcase Example:  '[0,1,2,3,4]\n[[3,1],[1,3],[5,6]]'
 *
 * 给你一个由非负整数组成的数组 nums 。另有一个查询数组 queries ，其中 queries[i] = [xi, mi] 。
 * 
 * 第 i 个查询的答案是 xi 和任何 nums 数组中不超过 mi 的元素按位异或（XOR）得到的最大值。换句话说，答案是 max(nums[j]
 * XOR xi) ，其中所有 j 均满足 nums[j] <= mi 。如果 nums 中的所有元素都大于 mi，最终答案就是 -1 。
 * 
 * 返回一个整数数组 answer 作为查询的答案，其中 answer.length == queries.length 且 answer[i] 是第 i
 * 个查询的答案。
 * 
 * 
 * 
 * 示例 1：
 * 
 * 输入：nums = [0,1,2,3,4], queries = [[3,1],[1,3],[5,6]]
 * 输出：[3,3,7]
 * 解释：
 * 1) 0 和 1 是仅有的两个不超过 1 的整数。0 XOR 3 = 3 而 1 XOR 3 = 2 。二者中的更大值是 3 。
 * 2) 1 XOR 2 = 3.
 * 3) 5 XOR 2 = 7.
 * 
 * 
 * 示例 2：
 * 
 * 输入：nums = [5,2,4,6,6,3], queries = [[12,4],[8,1],[6,3]]
 * 输出：[15,-1,5]
 * 
 * 
 * 
 * 
 * 提示：
 * 
 * 
 * 1 <= nums.length, queries.length <= 10^5
 * queries[i].length == 2
 * 0 <= nums[j], xi, mi <= 10^9
 * 
 * 
 */

// @lc code=start
struct TrieNode {
    int lo = INT_MAX;
    TrieNode* children[2]{};
};

class Solution {
public:
    vector<int> maximizeXor(vector<int>& nums, vector<vector<int>>& queries) {
        TrieNode* root = new TrieNode();
        for (int num : nums) {
            TrieNode* p = root;
            for (int i = 30; i >= 0; --i) {
                int nxt = (num & (1 << i)) ? 1 : 0;
                if (!p->children[nxt]) p->children[nxt] = new TrieNode();
                p = p->children[nxt];
                p->lo = min(p->lo, num);
            }
        }
        vector<int> ret;
        for (auto q : queries) {
            int x = q[0], limit = q[1];
            int ans = 0;
            TrieNode* p = root;
            for (int i = 30; i >= 0; --i) {
                if (x & (1 << i)) {
                    if (p->children[0]) {
                        p = p->children[0];
                        ans ^= (1 << i);
                    } else if (!p->children[1] || (p->children[1]->lo > limit)) {
                        ret.emplace_back(-1);
                        break;
                    } else {
                        p = p->children[1];
                    }
                } else {
                    if (p->children[1] && (p->children[1]->lo <= limit)) {
                        p = p->children[1];
                        ans ^= (1 << i);
                    } else if (!p->children[0]) {
                        ret.emplace_back(-1);
                        break;
                    } else {
                        p = p->children[0];
                    }
                }
                if (i == 0) ret.emplace_back(ans);
            }
        }
        return ret;
    }
};
// @lc code=end

