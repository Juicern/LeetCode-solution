import java.util.*;

/*
 * @lc app=leetcode.cn id=131 lang=java
 *
 * [131] 分割回文串
 *
 * https://leetcode-cn.com/problems/palindrome-partitioning/description/
 *
 * algorithms
 * Medium (64.78%)
 * Likes:    234
 * Dislikes: 0
 * Total Accepted:    24.9K
 * Total Submissions: 37.6K
 * Testcase Example:  '"aab"'
 *
 * 给定一个字符串 s，将 s 分割成一些子串，使每个子串都是回文串。
 * 
 * 返回 s 所有可能的分割方案。
 * 
 * 示例:
 * 
 * 输入: "aab"
 * 输出:
 * [
 * ⁠ ["aa","b"],
 * ⁠ ["a","a","b"]
 * ]
 * 
 */

// @lc code=start
class Solution {
    List<String> pre = new ArrayList<String>();
    List<List<String>> ans = new ArrayList<>();
    public boolean isPalindrone(String s){
        int n = s.length();
        if(n==0) return false;
        int left = 0;
        int right = n-1;
        while(left<right){
            if(s.charAt(left)!=s.charAt(right)) return false;
            left++;
            right--;
        }
        return true;
    }
    public void connect(String s){
        if(s.length()==0){
            ans.add(new ArrayList<>(pre));
            return;
        }
        int n = s.length();
        for(int i=0;i<n;i++){
            if(isPalindrone(s.substring(0, i+1))){
                pre.add(s.substring(0, i+1));
                connect(s.substring(i+1));
                pre.remove(pre.size()-1);
            }
        }
        return;
    }
    public List<List<String>> partition(String s) {
        if(s.length()==0) return ans;
        connect(s);
        return ans;
    }
}
// @lc code=end

