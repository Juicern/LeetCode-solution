/*
 * @lc app=leetcode.cn id=21 lang=java
 *
 * [21] 合并两个有序链表
 *
 * https://leetcode-cn.com/problems/merge-two-sorted-lists/description/
 *
 * algorithms
 * Easy (59.20%)
 * Likes:    869
 * Dislikes: 0
 * Total Accepted:    191.8K
 * Total Submissions: 319.8K
 * Testcase Example:  '[1,2,4]\n[1,3,4]'
 *
 * 将两个有序链表合并为一个新的有序链表并返回。新链表是通过拼接给定的两个链表的所有节点组成的。 
 * 
 * 示例：
 * 
 * 输入：1->2->4, 1->3->4
 * 输出：1->1->2->3->4->4
 * 
 * 
 */

// @lc code=start
/**
 * Definition for singly-linked list.
 * public class ListNode {
     int val;
     ListNode next;
     ListNode(int x) { val = x; }
 * }
 */
class Solution {
    /*
    public class ListNode {
        int val;
        ListNode next;
        ListNode(int x) { val = x; }
    }
    */
    public ListNode mergeTwoLists(ListNode l1, ListNode l2) {
        ListNode dummy = new ListNode(0);
        ListNode node = dummy;
        ListNode first = l1;
        ListNode second = l2;
        while(first!=null || second!=null){
            if(first==null){
                node.next = second;
                break;
            }
            if(second==null){
                node.next = first;
                break;
            }
            if(first.val < second.val){
                node.next = first;
                node = node.next;
                first = first.next;
            }
            else{
                node.next = second;
                node = node.next;
                second = second.next;
            }  
        }
        return dummy.next;
    }
}
// @lc code=end

