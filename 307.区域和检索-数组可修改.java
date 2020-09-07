/*
 * @lc app=leetcode.cn id=307 lang=java
 *
 * [307] 区域和检索 - 数组可修改
 *
 * https://leetcode-cn.com/problems/range-sum-query-mutable/description/
 *
 * algorithms
 * Medium (53.05%)
 * Likes:    125
 * Dislikes: 0
 * Total Accepted:    9K
 * Total Submissions: 16.4K
 * Testcase Example:  '["NumArray","sumRange","update","sumRange"]\n[[[1,3,5]],[0,2],[1,2],[0,2]]'
 *
 * 给定一个整数数组  nums，求出数组从索引 i 到 j  (i ≤ j) 范围内元素的总和，包含 i,  j 两点。
 * 
 * update(i, val) 函数可以通过将下标为 i 的数值更新为 val，从而对数列进行修改。
 * 
 * 示例:
 * 
 * Given nums = [1, 3, 5]
 * 
 * sumRange(0, 2) -> 9
 * update(1, 2)
 * sumRange(0, 2) -> 8
 * 
 * 
 * 说明:
 * 
 * 
 * 数组仅可以在 update 函数下进行修改。
 * 你可以假设 update 函数与 sumRange 函数的调用次数是均匀分布的。
 * 
 * 
 */

// @lc code=start
class NumArray {
    int[] tree;
    int n;
    public NumArray(int[] nums) {
        n = nums.length;
        tree = new int[2*n];
        for(int i=n, j=0;j<n;i++, j++) {
            tree[i] = nums[j];
        }
        for(int i=n-1;i>0;i--){
            tree[i] = tree[2*i] + tree[2*i+1];
        }
    }
    
    public void update(int pos, int val) {
        pos += n;
        tree[pos] = val; 
        while(pos>0) {
            int left = (pos&1)==0 ? pos : pos-1;
            int right = (pos&1)==0 ? pos+1 : pos;
            tree[pos>>1] = tree[left] + tree[right];
            pos >>= 1;
        }
    }
    
    public int sumRange(int left, int right) {
        int sum = 0;
        left += n;
        right += n;
        while(left<=right){
            if((left&1)==1) {
                sum += tree[left];
                left++;
            }
            if((right&1)==0) {
                sum += tree[right];
                right--;
            }
            left>>=1;
            right>>=1;
        }
        return sum;
    }
}

/**
 * Your NumArray object will be instantiated and called as such:
 * NumArray obj = new NumArray(nums);
 * obj.update(i,val);
 * int param_2 = obj.sumRange(i,j);
 */
// @lc code=end

