/*
 * @lc app=leetcode.cn id=936 lang=java
 *
 * [936] 戳印序列
 *
 * https://leetcode-cn.com/problems/stamping-the-sequence/description/
 *
 * algorithms
 * Hard (33.09%)
 * Likes:    12
 * Dislikes: 0
 * Total Accepted:    783
 * Total Submissions: 2.3K
 * Testcase Example:  '"abc"\n"ababc"'
 *
 * 你想要用小写字母组成一个目标字符串 target。 
 * 
 * 开始的时候，序列由 target.length 个 '?' 记号组成。而你有一个小写字母印章 stamp。
 * 
 * 在每个回合，你可以将印章放在序列上，并将序列中的每个字母替换为印章上的相应字母。你最多可以进行 10 * target.length  个回合。
 * 
 * 举个例子，如果初始序列为 "?????"，而你的印章 stamp 是 "abc"，那么在第一回合，你可以得到
 * "abc??"、"?abc?"、"??abc"。（请注意，印章必须完全包含在序列的边界内才能盖下去。）
 * 
 * 如果可以印出序列，那么返回一个数组，该数组由每个回合中被印下的最左边字母的索引组成。如果不能印出序列，就返回一个空数组。
 * 
 * 例如，如果序列是 "ababc"，印章是 "abc"，那么我们就可以返回与操作 "?????" -> "abc??" -> "ababc" 相对应的答案
 * [0, 2]；
 * 
 * 另外，如果可以印出序列，那么需要保证可以在 10 * target.length 个回合内完成。任何超过此数字的答案将不被接受。
 * 
 * 
 * 
 * 示例 1：
 * 
 * 输入：stamp = "abc", target = "ababc"
 * 输出：[0,2]
 * （[1,0,2] 以及其他一些可能的结果也将作为答案被接受）
 * 
 * 
 * 示例 2：
 * 
 * 输入：stamp = "abca", target = "aabcaca"
 * 输出：[3,0,1]
 * 
 * 
 * 
 * 
 * 提示：
 * 
 * 
 * 1 <= stamp.length <= target.length <= 1000
 * stamp 和 target 只包含小写字母。
 * 
 * 
 */

// @lc code=start
class Solution {
    public int[] movesToStamp(String stamp, String target) {
        char[] S = stamp.toCharArray();
        char[] T = target.toCharArray();
        List<Integer> res = new ArrayList<>();
        boolean[] visited = new boolean[T.length];
        int stars = 0;
        
        while (stars < T.length) {
            boolean doneReplace = false;
            for (int i = 0; i <= T.length - S.length; i++) {
                if (!visited[i] && canReplace(T, i, S)) {
                    stars = doReplace(T, i, S.length, stars);
                    doneReplace = true;
                    visited[i] = true;
                    res.add(i);
                    if (stars == T.length) {
                        break;
                    }
                }
            }
            
            if (!doneReplace) {
                return new int[0];
            }
        }
        
        int[] resArray = new int[res.size()];
        for (int i = 0; i < res.size(); i++) {
            resArray[i] = res.get(res.size() - i - 1);
        }
        return resArray;
    }
    
    private boolean canReplace(char[] T, int p, char[] S) {
        for (int i = 0; i < S.length; i++) {
            if (T[i + p] != '*' && T[i + p] != S[i]) {
                return false;
            }
        }
        return true;
    }
    
    private int doReplace(char[] T, int p, int len, int count) {
        for (int i = 0; i < len; i++) {
            if (T[i + p] != '*') {
                T[i + p] = '*';
                count++;
            }
        }
        return count;
    } 
}
// @lc code=end

