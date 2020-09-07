/*
 * @lc app=leetcode.cn id=321 lang=csharp
 *
 * [321] 拼接最大数
 *
 * https://leetcode-cn.com/problems/create-maximum-number/description/
 *
 * algorithms
 * Hard (30.63%)
 * Likes:    121
 * Dislikes: 0
 * Total Accepted:    4.1K
 * Total Submissions: 13.4K
 * Testcase Example:  '[3,4,6,5]\n[9,1,2,5,8,3]\n5'
 *
 * 给定长度分别为 m 和 n 的两个数组，其元素由 0-9 构成，表示两个自然数各位上的数字。现在从这两个数组中选出 k (k <= m + n)
 * 个数字拼接成一个新的数，要求从同一个数组中取出的数字保持其在原数组中的相对顺序。
 * 
 * 求满足该条件的最大数。结果返回一个表示该最大数的长度为 k 的数组。
 * 
 * 说明: 请尽可能地优化你算法的时间和空间复杂度。
 * 
 * 示例 1:
 * 
 * 输入:
 * nums1 = [3, 4, 6, 5]
 * nums2 = [9, 1, 2, 5, 8, 3]
 * k = 5
 * 输出:
 * [9, 8, 6, 5, 3]
 * 
 * 示例 2:
 * 
 * 输入:
 * nums1 = [6, 7]
 * nums2 = [6, 0, 4]
 * k = 5
 * 输出:
 * [6, 7, 6, 0, 4]
 * 
 * 示例 3:
 * 
 * 输入:
 * nums1 = [3, 9]
 * nums2 = [8, 9]
 * k = 3
 * 输出:
 * [9, 8, 9]
 * 
 */

// @lc code=start
public class Solution
{
    private string Select(IList<int>[] digits2Indices, int[] nums, int length)
    {
        StringBuilder sb = new StringBuilder(length);
        int currRight = -1;

        int currDigit = 9;
        int idx = 0;

        while (sb.Length != length)
        {
            while (idx < digits2Indices[currDigit].Count)
            {
                if (sb.Length == length)
                {
                    break;
                }

                if (digits2Indices[currDigit][idx] <= currRight)
                {
                    idx++;
                    continue;
                }

                if (nums.Length - digits2Indices[currDigit][idx] >= length - sb.Length)
                {
                    sb.Append((char)(currDigit + '0'));
                    currRight = digits2Indices[currDigit][idx];
                    currDigit = 9;
                    idx = 0;
                    continue;
                }

                break;
            }

            currDigit--;
            idx = 0;
        }

        return sb.ToString();
    }

    private string Merge(ref string a, ref string b)
    {
        StringBuilder sb = new StringBuilder(a.Length + b.Length);

        int i = 0;
        int j = 0;

        while (sb.Length != a.Length + b.Length)
        {
            if (i == a.Length)
            {
                sb.Append(b[j++]);
                continue;
            }

            if (j == b.Length)
            {
                sb.Append(a[i++]);
                continue;
            }

            if (Compare(ref a, ref b, i, j) < 0)
            {
                sb.Append(b[j++]);
            }
            else
            {
                sb.Append(a[i++]);
            }
        }

        return sb.ToString();
    }

    private int Compare(ref string a, ref string b, int aIdx, int bIdx)
    {
        int len1 = a.Length - aIdx;
        int len2 = b.Length - bIdx;

        int len = Math.Max(len1, len2);

        for (int i = 0; i < len; i++)
        {
            var digit1 = aIdx + i < a.Length ? a[aIdx + i] : '0';
            var digit2 = bIdx + i < b.Length ? b[bIdx + i] : '0';
            if (digit1 != digit2)
            {
                return digit1.CompareTo(digit2);
            }
        }

        return 0;
    }

    public int[] MaxNumber(int[] nums1, int[] nums2, int k)
    {
        IList<int>[] digits2Indices1 = new IList<int>[10];
        IList<int>[] digits2Indices2 = new IList<int>[10];

        for (int i = 0; i < 10; i++)
        {
            digits2Indices1[i] = new List<int>();
            digits2Indices2[i] = new List<int>();
        }

        for (int i = 0; i < nums1.Length; i++)
        {
            digits2Indices1[nums1[i]].Add(i);
        }

        for (int i = 0; i < nums2.Length; i++)
        {
            digits2Indices2[nums2[i]].Add(i);
        }

        string res = null;

        for (int i = 0; i <= k; i++)
        {
            int oneChunk = i;
            int twoChunk = k - i;

            if (oneChunk > nums1.Length || twoChunk > nums2.Length)
            {
                continue;
            }

            string combination1 = Select(digits2Indices1, nums1, oneChunk);
            string combination2 = Select(digits2Indices2, nums2, twoChunk);

            var candidate = Merge(ref combination1, ref combination2);
            res = res ?? candidate;

            if (string.Compare(res, candidate, StringComparison.OrdinalIgnoreCase) < 0)
            {
                res = candidate;
            }
        }


        return (res?.Length).GetValueOrDefault(0) == 0 ? new int[] { } : res.ToCharArray().Select(c => c - '0').ToArray();
    }
}
// @lc code=end

