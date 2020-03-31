/*
 * @lc app=leetcode.cn id=82 lang=java
 *
 * [82] 删除排序链表中的重复元素 II
 *
 * https://leetcode-cn.com/problems/remove-duplicates-from-sorted-list-ii/description/
 *
 * algorithms
 * Medium (45.27%)
 * Likes:    230
 * Dislikes: 0
 * Total Accepted:    36.3K
 * Total Submissions: 77.9K
 * Testcase Example:  '[1,2,3,3,4,4,5]'
 *
 * 给定一个排序链表，删除所有含有重复数字的节点，只保留原始链表中 没有重复出现 的数字。
 * 
 * 示例 1:
 * 
 * 输入: 1->2->3->3->4->4->5
 * 输出: 1->2->5
 * 
 * 
 * 示例 2:
 * 
 * 输入: 1->1->1->2->3
 * 输出: 2->3
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
    public ListNode deleteDuplicates(ListNode head) {
        if(head==null) return head;
        ListNode dummy = new ListNode(0);
        dummy.next = head;
        ListNode pre = dummy;
        ListNode p = head;
        ListNode q = head.next;
        boolean isHead = true;
        while(q!=null){
            if(p.val == q.val){
                while(q!=null && q.val==p.val){
                    q = q.next;
                }
                if(isHead) dummy.next = q;
                pre.next = q;
                p = q;
                if(q==null) return dummy.next;
                q = q.next;
            }
            else{
                isHead = false;
                pre = p;
                p = q;
                q = q.next; 
            }
        }
        return dummy.next;
    }
}
// @lc code=end

