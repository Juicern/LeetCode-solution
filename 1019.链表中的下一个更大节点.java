/*
 * @lc app=leetcode.cn id=1019 lang=java
 *
 * [1019] 链表中的下一个更大节点
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
    public int[] nextLargerNodes(ListNode head) {
        Stack stack = new Stack();
        ArrayList<Integer> data = new ArrayList<>();
        ArrayList<Integer> res = new ArrayList<>();

        int index = 0;
        while(head != null) {
            res.add(0);
            data.add(head.val);

            while (!stack.empty() && head.val > data.get((Integer)stack.peek())) {
                res.set((Integer)stack.pop(), head.val);
            }

            stack.push(index);
            index++;
            head = head.next;
        }

        int[] ans = new int[res.size()];

        for (int i = 0; i < res.size(); i++) {
            ans[i] = res.get(i);
        }

        return ans;
    }
}

// @lc code=end

