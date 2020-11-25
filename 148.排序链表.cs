using System.Reflection.Emit;
/*
 * @lc app=leetcode.cn id=148 lang=csharp
 *
 * [148] 排序链表
 *
 * https://leetcode-cn.com/problems/sort-list/description/
 *
 * algorithms
 * Medium (67.15%)
 * Likes:    869
 * Dislikes: 0
 * Total Accepted:    115.9K
 * Total Submissions: 171.3K
 * Testcase Example:  '[4,2,1,3]'
 *
 * 给你链表的头结点 head ，请将其按 升序 排列并返回 排序后的链表 。
 * 
 * 进阶：
 * 
 * 
 * 你可以在 O(n log n) 时间复杂度和常数级空间复杂度下，对链表进行排序吗？
 * 
 * 
 * 
 * 
 * 示例 1：
 * 
 * 
 * 输入：head = [4,2,1,3]
 * 输出：[1,2,3,4]
 * 
 * 
 * 示例 2：
 * 
 * 
 * 输入：head = [-1,5,3,4,0]
 * 输出：[-1,0,3,4,5]
 * 
 * 
 * 示例 3：
 * 
 * 
 * 输入：head = []
 * 输出：[]
 * 
 * 
 * 
 * 
 * 提示：
 * 
 * 
 * 链表中节点的数目在范围 [0, 5 * 10^4] 内
 * -10^5 
 * 
 * 
 */

// @lc code=start
/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution {
    public ListNode SortList(ListNode head) {
        if(head == null || head.next == null) return head;
        var fast = head.next.next;
        var slow = head;
        if(fast!= null && fast.next != null) {
            fast = fast.next.next;
            slow = slow.next;
        }
        var temp = slow.next;
        slow.next = null;
        return Merge(SortList(head), SortList(temp));
    }
    public ListNode Merge(ListNode p1, ListNode p2) {
        ListNode dummy = new ListNode(0);
        ListNode p = dummy;
        while(p1 !=null && p2!=null) {
            if(p1.val > p2.val) {
                p.next = p2;
                p2 =p2.next; 
            }
            else {
                p.next = p1;
                p1 = p1.next;
            }
            p = p.next;
        }
        if(p1!=null) {
            p.next = p1;
        }
        if(p2!=null) {
            p.next = p2;
        }
        return dummy.next;
    }
}
// @lc code=end

