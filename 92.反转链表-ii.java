/*
 * @lc app=leetcode.cn id=92 lang=java
 *
 * [92] 反转链表 II
 *
 * https://leetcode-cn.com/problems/reverse-linked-list-ii/description/
 *
 * algorithms
 * Medium (48.66%)
 * Likes:    315
 * Dislikes: 0
 * Total Accepted:    38.7K
 * Total Submissions: 78.2K
 * Testcase Example:  '[1,2,3,4,5]\n2\n4'
 *
 * 反转从位置 m 到 n 的链表。请使用一趟扫描完成反转。
 * 
 * 说明:
 * 1 ≤ m ≤ n ≤ 链表长度。
 * 
 * 示例:
 * 
 * 输入: 1->2->3->4->5->NULL, m = 2, n = 4
 * 输出: 1->4->3->2->5->NULL
 * 
 */

// @lc code=start
/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     int val;
 *     ListNode next;
 *     ListNode(int x) { val = x; }
 * }
 */
class Solution {
    public ListNode reverseBetween(ListNode head, int m, int n) {
        ListNode dummy = new ListNode(0);
        dummy.next = head;
        ListNode pre = dummy;
        for(int i=0;i<m-1;i++) pre = pre.next;
        ListNode start = pre.next;
        ListNode p = pre.next;
        ListNode q = p.next;
        for(int i=0;i<n-m;i++){
            ListNode r = q.next;
            q.next = p;
            p = q;
            q = r;
        }
        pre.next = p;
        start.next = q;
        return dummy.next;
    }
}
// @lc code=end

