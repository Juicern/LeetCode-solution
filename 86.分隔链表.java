/*
 * @lc app=leetcode.cn id=86 lang=java
 *
 * [86] 分隔链表
 *
 * https://leetcode-cn.com/problems/partition-list/description/
 *
 * algorithms
 * Medium (55.08%)
 * Likes:    170
 * Dislikes: 0
 * Total Accepted:    29.1K
 * Total Submissions: 51.5K
 * Testcase Example:  '[1,4,3,2,5,2]\n3'
 *
 * 给定一个链表和一个特定值 x，对链表进行分隔，使得所有小于 x 的节点都在大于或等于 x 的节点之前。
 * 
 * 你应当保留两个分区中每个节点的初始相对位置。
 * 
 * 示例:
 * 
 * 输入: head = 1->4->3->2->5->2, x = 3
 * 输出: 1->2->2->4->3->5
 * 
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
    public ListNode partition(ListNode head, int x) {
        ListNode dummy = new ListNode(0);
        dummy.next = head;
        ListNode pre = dummy;
        ListNode p = dummy;
        ListNode q = p.next;
        while(q!=null){
            if(q.val < x){
                if(pre.next==q){
                    pre = pre.next;
                    p = p.next;
                    q = p.next;;
                }
                else{
                    p.next = q.next;
                    q.next = pre.next;
                    pre.next = q;
                    pre = q;
                    q = p.next;
                }
            }
            else{
                p = p.next;
                q = p.next;
            }
        }
        return dummy.next; 
    }
}
// @lc code=end

