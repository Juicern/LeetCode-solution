import java.util.List;

/*
 * @lc app=leetcode.cn id=61 lang=java
 *
 * [61] 旋转链表
 *
 * https://leetcode-cn.com/problems/rotate-list/description/
 *
 * algorithms
 * Medium (39.77%)
 * Likes:    213
 * Dislikes: 0
 * Total Accepted:    47.8K
 * Total Submissions: 119.5K
 * Testcase Example:  '[1,2,3,4,5]\n2'
 *
 * 给定一个链表，旋转链表，将链表每个节点向右移动 k 个位置，其中 k 是非负数。
 * 
 * 示例 1:
 * 
 * 输入: 1->2->3->4->5->NULL, k = 2
 * 输出: 4->5->1->2->3->NULL
 * 解释:
 * 向右旋转 1 步: 5->1->2->3->4->NULL
 * 向右旋转 2 步: 4->5->1->2->3->NULL
 * 
 * 
 * 示例 2:
 * 
 * 输入: 0->1->2->NULL, k = 4
 * 输出: 2->0->1->NULL
 * 解释:
 * 向右旋转 1 步: 2->0->1->NULL
 * 向右旋转 2 步: 1->2->0->NULL
 * 向右旋转 3 步: 0->1->2->NULL
 * 向右旋转 4 步: 2->0->1->NULL
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
    /*
    public class ListNode {
        int val;
        ListNode next;
        ListNode(int x) { val = x; }
    }
    */
    public ListNode rotateRight(ListNode head, int k) {
        if(head==null) return head;
        ListNode p = head;
        ListNode r = p;;
        int n = 0;
        while(p!=null){
            r = p;
            p = p.next;
            n++;
        }
        k = k % n;
        p = head;
        if(k==0) return head;
        for(int i=1;i<n-k;i++){
            p = p.next;
        }
        ListNode res = p.next;
        r.next = head;
        p.next = null;
        return res;
    }
}
// @lc code=end

