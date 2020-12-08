/*
 * @lc app=leetcode.cn id=888 lang=c
 *
 * [888] 公平的糖果交换
 *
 * https://leetcode-cn.com/problems/fair-candy-swap/description/
 *
 * algorithms
 * Easy (55.32%)
 * Likes:    81
 * Dislikes: 0
 * Total Accepted:    15.5K
 * Total Submissions: 27.9K
 * Testcase Example:  '[1,1]\n[2,2]'
 *
 * 爱丽丝和鲍勃有不同大小的糖果棒：A[i] 是爱丽丝拥有的第 i 块糖的大小，B[j] 是鲍勃拥有的第 j 块糖的大小。
 * 
 * 因为他们是朋友，所以他们想交换一个糖果棒，这样交换后，他们都有相同的糖果总量。（一个人拥有的糖果总量是他们拥有的糖果棒大小的总和。）
 * 
 * 返回一个整数数组 ans，其中 ans[0] 是爱丽丝必须交换的糖果棒的大小，ans[1] 是 Bob 必须交换的糖果棒的大小。
 * 
 * 如果有多个答案，你可以返回其中任何一个。保证答案存在。
 * 
 * 
 * 
 * 示例 1：
 * 
 * 输入：A = [1,1], B = [2,2]
 * 输出：[1,2]
 * 
 * 
 * 示例 2：
 * 
 * 输入：A = [1,2], B = [2,3]
 * 输出：[1,2]
 * 
 * 
 * 示例 3：
 * 
 * 输入：A = [2], B = [1,3]
 * 输出：[2,3]
 * 
 * 
 * 示例 4：
 * 
 * 输入：A = [1,2,5], B = [2,4]
 * 输出：[5,4]
 * 
 * 
 * 
 * 
 * 提示：
 * 
 * 
 * 1 <= A.length <= 10000
 * 1 <= B.length <= 10000
 * 1 <= A[i] <= 100000
 * 1 <= B[i] <= 100000
 * 保证爱丽丝与鲍勃的糖果总量不同。
 * 答案肯定存在。
 * 
 * 
 */

// @lc code=start

/**
 * Note: The returned array must be malloced, assume caller calls free().
 */
int *fairCandySwap(int *A, int ASize, int *B, int BSize, int *returnSize)
{
    int sum1 = 0;
    int sum2 = 0;
    int hash[100001] = {0};
    int *arr = (int *)malloc(2 * sizeof(int));
    *returnSize = 2;
    for (int i = 0; i < ASize; i++)
    {
        sum1 += A[i];
        hash[A[i]]++;
    }
    for (int i = 0; i < BSize; i++)
    {
        sum2 += B[i];
    }

    for (int i = 0; i < BSize; i++)
    {
        int val = (sum1 - sum2 + 2 * B[i]) / 2;
        if (val >= 0 && val <= 100001 && hash[val])
        {
            arr[0] = val;
            arr[1] = B[i];
            return arr;
        }
    }
    return arr;
}

// @lc code=end
