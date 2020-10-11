/*
 * @lc app=leetcode.cn id=767 lang=cpp
 *
 * [767] 重构字符串
 *
 * https://leetcode-cn.com/problems/reorganize-string/description/
 *
 * algorithms
 * Medium (42.59%)
 * Likes:    131
 * Dislikes: 0
 * Total Accepted:    10.7K
 * Total Submissions: 25.1K
 * Testcase Example:  '"aab"'
 *
 * 给定一个字符串S，检查是否能重新排布其中的字母，使得两相邻的字符不同。
 * 
 * 若可行，输出任意可行的结果。若不可行，返回空字符串。
 * 
 * 示例 1:
 * 
 * 
 * 输入: S = "aab"
 * 输出: "aba"
 * 
 * 
 * 示例 2:
 * 
 * 
 * 输入: S = "aaab"
 * 输出: ""
 * 
 * 
 * 注意:
 * 
 * 
 * S 只包含小写字母并且长度在[1, 500]区间内。
 * 
 * 
 */

// @lc code=start
class Solution {
public:
    string reorganizeString(string S) {
        int n = S.size();
        vector<int> count(26, 0);
        for (auto c : S) {
            count[c - 'a'] += 100; // 统计次数
            if (count[c - 'a'] / 100 > (n + 1) / 2) return ""; // 超过（n+1)/2个字符，不可能得到答案
        }
        for (int i = 0; i < 26; ++i) count[i] += i; // 将字符信息加入数组值中
        // 此时count中的元素存储了次数和字符信息
        // 如 count[i] = 203 表示字符 'd'='a'+203%100 出现了 2=203/100 次
        sort(count.begin(), count.end()); // 对次数从小到大排序
        int index = 1;
        string ret(n, ' ');
        for (auto c : count) {
            int cnt = c / 100; // 取出次数
            char ch = 'a' + (c % 100); // 取出字符信息
            for (int i = 0; i < cnt; ++i) {
                if (index >= n) index = 0; // 第一遍走完 从0开始
                ret[index] = ch;
                index += 2; // 间隔添加相同字符
            }
        }
        return ret;
    }
};
// @lc code=end

