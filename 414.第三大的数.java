import java.util.*;
/*
 * @lc app=leetcode.cn id=414 lang=java
 *
 * [414] 第三大的数
 *
 * https://leetcode-cn.com/problems/third-maximum-number/description/
 *
 * algorithms
 * Easy (34.81%)
 * Likes:    126
 * Dislikes: 0
 * Total Accepted:    25.2K
 * Total Submissions: 72.3K
 * Testcase Example:  '[3,2,1]'
 *
 * 给定一个非空数组，返回此数组中第三大的数。如果不存在，则返回数组中最大的数。要求算法时间复杂度必须是O(n)。
 * 
 * 示例 1:
 * 
 * 
 * 输入: [3, 2, 1]
 * 
 * 输出: 1
 * 
 * 解释: 第三大的数是 1.
 * 
 * 
 * 示例 2:
 * 
 * 
 * 输入: [1, 2]
 * 
 * 输出: 2
 * 
 * 解释: 第三大的数不存在, 所以返回最大的数 2 .
 * 
 * 
 * 示例 3:
 * 
 * 
 * 输入: [2, 2, 3, 1]
 * 
 * 输出: 1
 * 
 * 解释: 注意，要求返回第三大的数，是指第三大且唯一出现的数。
 * 存在两个值为2的数，它们都排第二。
 * 
 * 
 */

// @lc code=start
class Solution {
    public int thirdMax(int[] nums) {
        List<Integer> lst = new LinkedList<>();
        for (int num : nums) {
            if (lst.isEmpty()) lst.add(num);
            else {
                int index = 0;
                while (index<lst.size() && lst.get(index) > num) index++;
                if (index<lst.size()) {
                    if(lst.get(index)==num) continue;
                    lst.add(index, num);
                    if(lst.size()==4) lst.remove(3);
                }
                else {
                    lst.add(index, num);
                    if(lst.size()==4) lst.remove(3);
                }
            }
        }
        if(lst.size()<3) return lst.get(0);
        return lst.get(2);
    }
}
// @lc code=end

