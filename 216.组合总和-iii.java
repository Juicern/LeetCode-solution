import java.util.*;
/*
 * @lc app=leetcode.cn id=216 lang=java
 *
 * [216] 组合总和 III
 *
 * https://leetcode-cn.com/problems/combination-sum-iii/description/
 *
 * algorithms
 * Medium (69.84%)
 * Likes:    93
 * Dislikes: 0
 * Total Accepted:    17.3K
 * Total Submissions: 24.6K
 * Testcase Example:  '3\n7'
 *
 * 找出所有相加之和为 n 的 k 个数的组合。组合中只允许含有 1 - 9 的正整数，并且每种组合中不存在重复的数字。
 * 
 * 说明：
 * 
 * 
 * 所有数字都是正整数。
 * 解集不能包含重复的组合。 
 * 
 * 
 * 示例 1:
 * 
 * 输入: k = 3, n = 7
 * 输出: [[1,2,4]]
 * 
 * 
 * 示例 2:
 * 
 * 输入: k = 3, n = 9
 * 输出: [[1,2,6], [1,3,5], [2,3,4]]
 * 
 * 
 */

// @lc code=start
class Solution {
    List<List<Integer>> ans = new ArrayList<>();
    public void helper(int k, int n, int start, List<Integer> cur){
        if(k==1){
            if(n>9 || n<start) return;
            cur.add(n);
            ans.add(new ArrayList<>(cur));
            cur.remove(cur.size()-1);
            return;
        }
        for(int i=start;i<=n/k;i++){
            cur.add(i);
            helper(k-1, n-i, i+1, cur);
            cur.remove(cur.size()-1);
        }
    }
    public List<List<Integer>> combinationSum3(int k, int n) {
        if(k>9 || n>45) return ans;
        helper(k, n, 1, new ArrayList<>());
        return ans;
    }
}
// @lc code=end

