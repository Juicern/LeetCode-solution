/*
 * @lc app=leetcode.cn id=143 lang=csharp
 *
 * [143] 重排链表
 *
 * https://leetcode-cn.com/problems/reorder-list/description/
 *
 * algorithms
 * Medium (56.57%)
 * Likes:    407
 * Dislikes: 0
 * Total Accepted:    60.3K
 * Total Submissions: 102K
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
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution {
    public void ReorderList(ListNode head) {
        if(head == null) return;
        var middle = FindMiddle(head);
        var list1 = head;
        var list2 = middle.next;
        middle.next = null;
        list2 = ReverseList(list2);
        while(list1 != null && list2 != null) {
            var temp1 = list1.next;
            var temp2 = list2.next;
            list1.next = list2;
            list2.next = temp1;
            list1 = temp1;
            list2 = temp2;
        }
    }
    private ListNode FindMiddle(ListNode head) {
        var fast = head;
        var slow = head;
        while(fast.next != null && fast.next.next != null) {
            fast = fast.next.next;
            slow = slow.next;
        }
        return slow;
    }
    private ListNode ReverseList(ListNode head ) {
        if(head == null) return null;
        var pre = head;
        var cur = head.next;
        while(cur != null) {
            var temp = cur.next;
            cur.next = pre;
            pre = cur;
            cur = temp;
        }
        head.next = null;
        return pre;
    }
}
// @lc code=end

