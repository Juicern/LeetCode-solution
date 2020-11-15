/*
 * @lc app=leetcode.cn id=328 lang=typescript
 *
 * [328] 奇偶链表
 *
 * https://leetcode-cn.com/problems/odd-even-linked-list/description/
 *
 * algorithms
 * Medium (63.51%)
 * Likes:    338
 * Dislikes: 0
 * Total Accepted:    85K
 * Total Submissions: 129.8K
 * Testcase Example:  '[1,2,3,4,5]'
 *
 * 给定一个单链表，把所有的奇数节点和偶数节点分别排在一起。请注意，这里的奇数节点和偶数节点指的是节点编号的奇偶性，而不是节点的值的奇偶性。
 * 
 * 请尝试使用原地算法完成。你的算法的空间复杂度应为 O(1)，时间复杂度应为 O(nodes)，nodes 为节点总数。
 * 
 * 示例 1:
 * 
 * 输入: 1->2->3->4->5->NULL
 * 输出: 1->3->5->2->4->NULL
 * 
 * 
 * 示例 2:
 * 
 * 输入: 2->1->3->5->6->4->7->NULL 
 * 输出: 2->3->6->7->1->5->4->NULL
 * 
 * 说明:
 * 
 * 
 * 应当保持奇数节点和偶数节点的相对顺序。
 * 链表的第一个节点视为奇数节点，第二个节点视为偶数节点，以此类推。
 * 
 * 
 */

// @lc code=start
/**
 * Definition for singly-linked list.
 * class ListNode {
 *     val: number
 *     next: ListNode | null
 *     constructor(val?: number, next?: ListNode | null) {
 *         this.val = (val===undefined ? 0 : val)
 *         this.next = (next===undefined ? null : next)
 *     }
 * }
 */

function oddEvenList(head: ListNode | null): ListNode | null {
    if(head === null) return head;
    let p1 : ListNode | null = head;
    let p2 : ListNode | null  = head.next;
    let tempHead : ListNode | null = head.next;
    while(p2 != null && p2.next != null && p1 != null && p1.next != null) {
        let temp1 : ListNode | null = p1.next.next;
        let temp2 : ListNode | null = p2.next.next;
        p1.next = temp1;
        p2.next = temp2;
        p1 = temp1;
        p2 = temp2;
    }
    if(p1 != null) p1.next = tempHead;
    return head;
};
// @lc code=end

