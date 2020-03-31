import java.util.*;

/*
 * @lc app=leetcode.cn id=93 lang=java
 *
 * [93] 复原IP地址
 *
 * https://leetcode-cn.com/problems/restore-ip-addresses/description/
 *
 * algorithms
 * Medium (45.41%)
 * Likes:    203
 * Dislikes: 0
 * Total Accepted:    29.7K
 * Total Submissions: 64.6K
 * Testcase Example:  '"25525511135"'
 *
 * 给定一个只包含数字的字符串，复原它并返回所有可能的 IP 地址格式。
 * 
 * 示例:
 * 
 * 输入: "25525511135"
 * 输出: ["255.255.11.135", "255.255.111.35"]
 * 
 */

// @lc code=start
class Solution {
    List<String> ans = new ArrayList<>();
    public void backtrace(String pre, String post, int rest){
        if(post.length() > rest*3 || post.length()==0) return;
        if(rest==1){
            if(post.length()>1 && post.charAt(0)=='0') return;
            if(Integer.parseInt(post)<256){
                ans.add(pre + post);
            }
            return;
        }
        for(int i=1;i<=3;i++){
            if(post.length()>i && Integer.parseInt(post.substring(0,i))<256){
                if(i>1 && post.charAt(0)=='0') return;
                backtrace(pre + post.substring(0,i) + ".", post.substring(i), rest-1);
            }
        }
        return;
    }
    public List<String> restoreIpAddresses(String s) {
        backtrace(new String(), s, 4);
        return ans;
    }
}
// @lc code=end

