/*
 * @lc app=leetcode.cn id=763 lang=csharp
 *
 * [763] 划分字母区间
 *
 * https://leetcode-cn.com/problems/partition-labels/description/
 *
 * algorithms
 * Medium (72.48%)
 * Likes:    338
 * Dislikes: 0
 * Total Accepted:    40.6K
 * Total Submissions: 53.3K
 * Testcase Example:  '"ababcbacadefegdehijhklij"'
 *
 * 字符串 S 由小写字母组成。我们要把这个字符串划分为尽可能多的片段，同一个字母只会出现在其中的一个片段。返回一个表示每个字符串片段的长度的列表。
 * 
 * 
 * 
 * 示例 1：
 * 
 * 输入：S = "ababcbacadefegdehijhklij"
 * 输出：[9,7,8]
 * 解释：
 * 划分结果为 "ababcbaca", "defegde", "hijhklij"。
 * 每个字母最多出现在一个片段中。
 * 像 "ababcbacadefegde", "hijhklij" 的划分是错误的，因为划分的片段数较少。
 * 
 * 
 * 
 * 
 * 提示：
 * 
 * 
 * S的长度在[1, 500]之间。
 * S只包含小写字母 'a' 到 'z' 。
 * 
 * 
 */

// @lc code=start
public class Solution {
    public IList<int> PartitionLabels(string S) {
        IList<int> ans = new List<int>();
        var pos = new int[26];
        for(int i = 0;i<S.Length;i++) {
            pos[S[i] - 'a'] = i; 
        }
        int index = 0;
        while(index < S.Length) {
            int start = index;
            int max = pos[S[index] - 'a'];
            while(index <= max) {
                if(pos[S[index] - 'a'] > max) {
                    max = pos[S[index] - 'a'];
                }
                index++;
            }
            ans.Add(index - start);
        }
        return ans;
    }
}

// @lc code=end

