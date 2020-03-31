import java.util.*;
/*
 * @lc app=leetcode.cn id=57 lang=java
 *
 * [57] 插入区间
 *
 * https://leetcode-cn.com/problems/insert-interval/description/
 *
 * algorithms
 * Hard (36.60%)
 * Likes:    110
 * Dislikes: 0
 * Total Accepted:    17.1K
 * Total Submissions: 46.2K
 * Testcase Example:  '[[1,3],[6,9]]\n[2,5]'
 *
 * 给出一个无重叠的 ，按照区间起始端点排序的区间列表。
 * 
 * 在列表中插入一个新的区间，你需要确保列表中的区间仍然有序且不重叠（如果有必要的话，可以合并区间）。
 * 
 * 示例 1:
 * 
 * 输入: intervals = [[1,3],[6,9]], newInterval = [2,5]
 * 输出: [[1,5],[6,9]]
 * 
 * 
 * 示例 2:
 * 
 * 输入: intervals = [[1,2],[3,5],[6,7],[8,10],[12,16]], newInterval = [4,8]
 * 输出: [[1,2],[3,10],[12,16]]
 * 解释: 这是因为新的区间 [4,8] 与 [3,5],[6,7],[8,10] 重叠。
 * 
 * 
 */

// @lc code=start
class Solution {
    Stack<int[]> ans = new Stack<>();
    public int[][] insert(int[][] intervals, int[] newInterval) {
        if(intervals.length==0){
            int[][] temp = new int[1][2];
            temp[0]  = newInterval;
            return temp;
        }
        if(newInterval.length==0){
            return intervals;
        }
        int n = intervals.length;
        boolean isAdd = false;
        for(int i=0;i<n;i++){
            if(!isAdd){
                if(intervals[i][0] < newInterval[0]) ans.push(intervals[i]);
                else{
                    if(!ans.isEmpty()){
                        testAndPush(newInterval);   
                    }
                    else ans.push(newInterval);
                    i--;
                    isAdd = true;
                }
            }
            //已经加入
            else testAndPush(intervals[i]);
        }
        if(!isAdd) testAndPush(newInterval);  
        int m = ans.size();
        int[][] res = new int[m][2];
        for(int i=0;i<m;i++){
            res[m-1-i] = ans.pop();
        }
        return res;
    }
    private void testAndPush(int[] a) {
        int[] temp = ans.pop();
        if(temp[1]>=a[0] && a[1]>temp[1]){
            temp[1] = a[1];
            ans.push(temp);
        } 
        else if(temp[1]>=a[1]) ans.push(temp);
        else if(temp[1]<a[0]){
            ans.push(temp);
            ans.push(a);
        }
    }
}
// @lc code=end

