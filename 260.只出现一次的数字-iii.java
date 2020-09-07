import java.util.Set;

/*
 * @lc app=leetcode.cn id=260 lang=java
 *
 * [260] 只出现一次的数字 III
 *
 * https://leetcode-cn.com/problems/single-number-iii/description/
 *
 * algorithms
 * Medium (69.13%)
 * Likes:    198
 * Dislikes: 0
 * Total Accepted:    17.6K
 * Total Submissions: 24.8K
 * Testcase Example:  '[1,2,1,3,2,5]'
 *
 * 给定一个整数数组 nums，其中恰好有两个元素只出现一次，其余所有元素均出现两次。 找出只出现一次的那两个元素。
 * 
 * 示例 :
 * 
 * 输入: [1,2,1,3,2,5]
 * 输出: [3,5]
 * 
 * 注意：
 * 
 * 
 * 结果输出的顺序并不重要，对于上面的例子， [5, 3] 也是正确答案。
 * 你的算法应该具有线性时间复杂度。你能否仅使用常数空间复杂度来实现？
 * 
 * 
 */

// @lc code=start
class Solution {
    public int[] singleNumber(int[] nums) {
        Set<Integer> s = new HashSet<>();
        for(int num : nums){
            if(s.contains(num)) s.remove(num);
            else s.add(num);
        }
        int[] ans = new int[2];
        int index = 0;
        for(int num : s){
            ans[index++] = num;
        }
        return ans;
    }
}
// @lc code=end

