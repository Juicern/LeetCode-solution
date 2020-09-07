using System.Collections.Generic;
using System.Linq;
/*
 * @lc app=leetcode.cn id=658 lang=csharp
 *
 * [658] 找到 K 个最接近的元素
 *
 * https://leetcode-cn.com/problems/find-k-closest-elements/description/
 *
 * algorithms
 * Medium (43.63%)
 * Likes:    94
 * Dislikes: 0
 * Total Accepted:    9.9K
 * Total Submissions: 22.5K
 * Testcase Example:  '[1,2,3,4,5]\n4\n3'
 *
 * 给定一个排序好的数组，两个整数 k 和 x，从数组中找到最靠近 x（两数之差最小）的 k 个数。返回的结果必须要是按升序排好的。如果有两个数与 x
 * 的差值一样，优先选择数值较小的那个数。
 * 
 * 示例 1:
 * 
 * 
 * 输入: [1,2,3,4,5], k=4, x=3
 * 输出: [1,2,3,4]
 * 
 * 
 * 
 * 
 * 示例 2:
 * 
 * 
 * 输入: [1,2,3,4,5], k=4, x=-1
 * 输出: [1,2,3,4]
 * 
 * 
 * 
 * 
 * 说明:
 * 
 * 
 * k 的值为正数，且总是小于给定排序数组的长度。
 * 数组不为空，且长度不超过 10^4
 * 数组里的每个元素与 x 的绝对值不超过 10^4
 * 
 * 
 * 
 * 
 * 更新(2017/9/19):
 * 这个参数 arr 已经被改变为一个整数数组（而不是整数列表）。 请重新加载代码定义以获取最新更改。
 * 
 */

// @lc code=start
public class Solution {
    public IList<int> FindClosestElements(int[] arr, int k, int x) {
        var ans = new List<int>();
        int left = BinaryFind(arr, x);
        int right = left + 1;
        while(ans.Count < k) {
            if(left == -1) {
                ans.Add(arr[right++]);
                continue;
            }
            if(right == arr.Length) {
                ans.Insert(0, arr[left--]);
                continue;
            }
            if(x - arr[left] <= arr[right] - x) {
                ans.Insert(0, arr[left--]);
            }
            else {
                ans.Add(arr[right++]);
            }
        }
        return ans;
    }
    private int BinaryFind(int[] arr, int x) {
        if(x > arr.Last()) return arr.Length;
        if(x < arr.First()) return -1;
        int left = 0;
        int right = arr.Length-1;
        while(left < right) {
            int mid = (left + right) >> 1;
            if(arr[mid]==x) return mid;
            if(arr[mid] < x) left = mid + 1;
            if(arr[mid] > x) right = mid;
        }
        return left - 1;
    }
}
// @lc code=end

