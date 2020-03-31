/*
 * @lc app=leetcode.cn id=143 lang=java
 *
 * [143] 重排链表
 *
 * https://leetcode-cn.com/problems/reorder-list/description/
 *
 * algorithms
 * Medium (54.05%)
 * Likes:    174
 * Dislikes: 0
 * Total Accepted:    18.8K
 * Total Submissions: 34.1K
 * Testcase Example:  '[1,2,3,4]'
 *
 * 给定一个单链表 L：L0→L1→…→Ln-1→Ln ，
 * 将其重新排列后变为： L0→Ln→L1→Ln-1→L2→Ln-2→…
 * 
 * 你不能只是单纯的改变节点内部的值，而是需要实际的进行节点交换。
 * 
 * 示例 1:
 * 
 * 给定链表 1->2->3->4, 重新排列为 1->4->2->3.
 * 
 * 示例 2:
 * 
 * 给定链表 1->2->3->4->5, 重新排列为 1->5->2->4->3.
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
    public ListNode helper(ListNode head, int len){
        if(len==1){
            ListNode tmp = head.next;
            head.next = null;
            return tmp;
        }
        if(len==2){
            ListNode tmp = head.next.next;
            head.next.next = null;
            return tmp;
        }
        ListNode tail = helper(head.next, len-2);
        ListNode middle = head.next;
        head.next = tail;
        ListNode nextTail = tail.next;
        tail.next = middle;
        return nextTail;
    }
    public void reorderList(ListNode head) {
        if (head == null || head.next == null || head.next.next == null) {
            return;
        }
        int len = 0;
        ListNode p = head;
        while(p!=null){
            len++;
            p = p.next;
        }
        helper(head, len);
    }
}
// @lc code=end

