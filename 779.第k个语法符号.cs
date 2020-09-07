using System;
/*
 * @lc app=leetcode.cn id=779 lang=csharp
 *
 * [779] 第K个语法符号
 *
 * https://leetcode-cn.com/problems/k-th-symbol-in-grammar/description/
 *
 * algorithms
 * Medium (42.86%)
 * Likes:    64
 * Dislikes: 0
 * Total Accepted:    9.4K
 * Total Submissions: 22K
 * Testcase Example:  '1\n1'
 *
 * 在第一行我们写上一个 0。接下来的每一行，将前一行中的0替换为01，1替换为10。
 * 
 * 给定行数 N 和序数 K，返回第 N 行中第 K个字符。（K从1开始）
 * 
 * 
 * 例子:
 * 
 * 输入: N = 1, K = 1
 * 输出: 0
 * 
 * 输入: N = 2, K = 1
 * 输出: 0
 * 
 * 输入: N = 2, K = 2
 * 输出: 1
 * 
 * 输入: N = 4, K = 5
 * 输出: 1
 * 
 * 解释:
 * 第一行: 0
 * 第二行: 01
 * 第三行: 0110
 * 第四行: 01101001
 * 
 * 
 * 
 * 注意：
 * 
 * 
 * N 的范围 [1, 30].
 * K 的范围 [1, 2^(N-1)].
 * 
 * 
 */

// @lc code=start
public class Solution {
    public int KthGrammar(int N, int K) {
        if(N==1)
            return 0;
        if(N==2 && K==1)
            return 0;
        if(N==2 && K==2)
            return 1;
    
        if(K%2==0)
            return KthGrammar(N-1,K/2) == 0 ? 1 : 0;
        else
            return KthGrammar(N-1, (K+1)/2) == 0 ? 0 : 1 ;
    }
}
// @lc code=end

