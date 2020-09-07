/*
 * @lc app=leetcode.cn id=1019 lang=csharp
 *
 * [1019] 链表中的下一个更大节点
 */

// @lc code=start
/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    public int[] NextLargerNodes(ListNode head) {
        var lst = new List<int>();
        var res = new List<int>();
        var st = new Stack<int>();
        ListNode p = head;
        int index = 0;
        while(p!=null)
        {
            res.Add(0);
            lst.Add(p.val);
            while(st.Count!=0 && lst[st.Peek()] < p.val)
            {
                res[st.Peek()] = p.val;
                st.Pop(); 
            }
            st.Push(index++);
        }
        var ans = new int[index];
        for(int i=0;i<index;i++) ans[i] = res[i];
        return ans;
    }
}
// @lc code=end

