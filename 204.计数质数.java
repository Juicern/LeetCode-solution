import java.util.Arrays;

/*
 * @lc app=leetcode.cn id=204 lang=java
 *
 * [204] 计数质数
 *
 * https://leetcode-cn.com/problems/count-primes/description/
 *
 * algorithms
 * Easy (31.70%)
 * Likes:    309
 * Dislikes: 0
 * Total Accepted:    48.6K
 * Total Submissions: 147.9K
 * Testcase Example:  '10'
 *
 * 统计所有小于非负整数 n 的质数的数量。
 * 
 * 示例:
 * 
 * 输入: 10
 * 输出: 4
 * 解释: 小于 10 的质数一共有 4 个, 它们是 2, 3, 5, 7 。
 * 
 * 
 */

// @lc code=start
class Solution {
    
    public int countPrimes(int n) {
        boolean[] nums = new boolean[n];
        Arrays.fill(nums, true);
        for(int i=2;i*i<n;i++){
            if(nums[i]){
                for(int j=i*i;j<n;j+=i){
                    nums[j] = false;
                }
            }
        }
        int count=0;
        for(int i=2;i<n;i++){
            if(nums[i]) count++;
        }
        return count;
    }
}
// @lc code=end

