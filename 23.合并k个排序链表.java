/*
 * @lc app=leetcode.cn id=23 lang=java
 *
 * [23] 合并K个排序链表
 *
 * https://leetcode-cn.com/problems/merge-k-sorted-lists/description/
 *
 * algorithms
 * Hard (48.50%)
 * Likes:    504
 * Dislikes: 0
 * Total Accepted:    78.6K
 * Total Submissions: 160K
 * Testcase Example:  '[[1,4,5],[1,3,4],[2,6]]'
 *
 * 合并 k 个排序链表，返回合并后的排序链表。请分析和描述算法的复杂度。
 * 
 * 示例:
 * 
 * 输入:
 * [
 * 1->4->5,
 * 1->3->4,
 * 2->6
 * ]
 * 输出: 1->1->2->3->4->4->5->6
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
    public ListNode mergeKLists(ListNode[] lists) {
        ListNode dummy = new ListNode(0);
        ListNode[] index = new ListNode[lists.length];
        for(int i=0;i<lists.length;i++) index[i] = lists[i];
        ListNode node = dummy;
        boolean isEnd = false;
        while(!isEnd){
            isEnd = true;
            int minIndex = 0;
            int min = Integer.MAX_VALUE;
            for(int i=0;i<lists.length;i++){
                if(index[i]!=null && index[i].val < min){
                    minIndex = i;
                    min = index[i].val;
                    isEnd = false;
                }
            }
            if(isEnd==true) break;
            node.next = index[minIndex];
            index[minIndex] = index[minIndex].next;
            node = node.next;
        }
        return dummy.next; 
    }
}
// @lc code=end

