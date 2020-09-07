import java.util.*;
/*
 * @lc app=leetcode.cn id=445 lang=java
 *
 * [445] 两数相加 II
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
    public ListNode addTwoNumbers(ListNode l1, ListNode l2) {
        Stack<Integer> st1 = new Stack<>();
        Stack<Integer> st2 = new Stack<>();
        ListNode p1 = l1;
        ListNode p2 = l2;
        while(p1!=null) {
            st1.push(p1.val);
            p1 = p1.next;
        }
        while(p2!=null) { 
            st2.push(p2.val);
            p2 = p2.next;
        }
        ListNode dummy = null;
        int carry = 0;
        while(st1.size()!=0 || st2.size()!=0 || carry>0) {
            ListNode node = new ListNode(0);
            node.val = carry + ((st1.size()==0) ? 0 : st1.pop()) + ((st2.size()==0) ? 0 : st2.pop());
            carry = node.val / 10;
            node.val = node.val %10;
            node.next = dummy;
            dummy = node;  
        }
        return dummy;
    }
}
// @lc code=end

