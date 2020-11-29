/*
 * @lc app=leetcode.cn id=805 lang=java
 *
 * [805] 数组的均值分割
 *
 * https://leetcode-cn.com/problems/split-array-with-same-average/description/
 *
 * algorithms
 * Hard (27.61%)
 * Likes:    53
 * Dislikes: 0
 * Total Accepted:    1.8K
 * Total Submissions: 6.4K
 * Testcase Example:  '[1,2,3,4,5,6,7,8]'
 *
 * 给定的整数数组 A ，我们要将 A数组 中的每个元素移动到 B数组 或者 C数组中。（B数组和C数组在开始的时候都为空）
 * 
 * 返回true ，当且仅当在我们的完成这样的移动后，可使得B数组的平均值和C数组的平均值相等，并且B数组和C数组都不为空。
 * 
 * 
 * 示例:
 * 输入: 
 * [1,2,3,4,5,6,7,8]
 * 输出: true
 * 解释: 我们可以将数组分割为 [1,4,5,8] 和 [2,3,6,7], 他们的平均值都是4.5。
 * 
 * 
 * 注意:
 * 
 * 
 * A 数组的长度范围为 [1, 30].
 * A[i] 的数据范围为 [0, 10000].
 * 
 * 
 */

// @lc code=start
class Solution {
    //np问题，不能暴搜
    public boolean splitArraySameAverage(int[] A) {
        int len = A.length;
        int sum = 0;//sum为总和
        for(int i = 0; i < len; i++){
            sum += A[i];
        }
        Arrays.sort(A);        
        //从小到大排序，从0开始处理较少数据
        for(int i = 1; i <= len/2; i++){
            int remainder = sum * i % len;
            //首先确认能否整除
            int target = sum * i / len;
            //这是目标和
            if(remainder == 0 && helper(A,0,i,target))
                return true;
        }
        return false;
    }
    
    public boolean helper(int[] A, int begin, int len, int target){
        if(len == 0) 
            return target == 0;
        if(target < len * A[begin])
            return false;
        for(int i = begin; i <= A.length - len; i++){
            //略去重复的情况，缩短运行时间
            if(i > begin && A[i] == A[i-1]) continue;
            if(helper(A, i+1, len-1, target- A[i]))
                return true;
        }
        return false;
    }
}
// @lc code=end

