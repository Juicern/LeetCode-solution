import java.util.ArrayList;

/*
 * @lc app=leetcode.cn id=60 lang=java
 *
 * [60] 第k个排列
 *
 * https://leetcode-cn.com/problems/permutation-sequence/description/
 *
 * algorithms
 * Medium (47.98%)
 * Likes:    187
 * Dislikes: 0
 * Total Accepted:    25.5K
 * Total Submissions: 52.7K
 * Testcase Example:  '3\n3'
 *
 * 给出集合 [1,2,3,…,n]，其所有元素共有 n! 种排列。
 * 
 * 按大小顺序列出所有排列情况，并一一标记，当 n = 3 时, 所有排列如下：
 * 
 * 
 * "123"
 * "132"
 * "213"
 * "231"
 * "312"
 * "321"
 * 
 * 
 * 给定 n 和 k，返回第 k 个排列。
 * 
 * 说明：
 * 
 * 
 * 给定 n 的范围是 [1, 9]。
 * 给定 k 的范围是[1,  n!]。
 * 
 * 
 * 示例 1:
 * 
 * 输入: n = 3, k = 3
 * 输出: "213"
 * 
 * 
 * 示例 2:
 * 
 * 输入: n = 4, k = 9
 * 输出: "2314"
 * 
 * 
 */

// @lc code=start
class Solution {
    public String getPermutation(int n, int k) {
        StringBuffer res = new StringBuffer();
        ArrayList<Integer> lst = new ArrayList<>();
        for(int i=1;i<=n;i++) lst.add(i);
        for(int i=0;i<n;i++){
            int num = 0;
            if(k!=0){
                int comb = factorial(n-1-i);
                num = (k-1)/comb;
                k = k - num*comb;
            }
            res.append(lst.get(num));
            lst.remove(num);
        }
        return res.toString();
    }
    public static int factorial(int number) {
        if (number <= 1)
            return 1;
        else
            return number * factorial(number - 1);
    }
}
// @lc code=end

