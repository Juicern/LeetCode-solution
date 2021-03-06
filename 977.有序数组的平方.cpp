#include<vector>
using namespace std;
/*
 * @lc app=leetcode.cn id=977 lang=cpp
 *
 * [977] 有序数组的平方
 *
 * https://leetcode-cn.com/problems/squares-of-a-sorted-array/description/
 *
 * algorithms
 * Easy (71.58%)
 * Likes:    127
 * Dislikes: 0
 * Total Accepted:    48.1K
 * Total Submissions: 67.2K
 * Testcase Example:  '[-4,-1,0,3,10]'
 *
 * 给定一个按非递减顺序排序的整数数组 A，返回每个数字的平方组成的新数组，要求也按非递减顺序排序。
 * 
 * 
 * 
 * 示例 1：
 * 
 * 输入：[-4,-1,0,3,10]
 * 输出：[0,1,9,16,100]
 * 
 * 
 * 示例 2：
 * 
 * 输入：[-7,-3,2,3,11]
 * 输出：[4,9,9,49,121]
 * 
 * 
 * 
 * 
 * 提示：
 * 
 * 
 * 1 <= A.length <= 10000
 * -10000 <= A[i] <= 10000
 * A 已按非递减顺序排序。
 * 
 * 
 */

// @lc code=start
class Solution {
public:
    vector<int> sortedSquares(vector<int>& A) {
        vector<int> ans;
        int cur = 0;
        while(cur < A.size()) {
            if(A[cur] >= 0) break;
            cur++;
        }
        int p1 = cur - 1;
        int p2 = cur;
        while(p1 >= 0 || p2 < A.size()) {
            if(p1 < 0) {
                ans.push_back(A[p2] * A[p2]);
                p2++;
            }
            else if(p2 >= A.size()) {
                ans.push_back(A[p1] * A[p1]);
                p1--;
            }
            else {
                if(-A[p1] > A[p2]) {
                   ans.push_back(A[p2] * A[p2]);
                    p2++; 
                }
                else {
                    ans.push_back(A[p1] * A[p1]);
                    p1--;
                }
            }
        }
        return ans;

    }
};
// @lc code=end

