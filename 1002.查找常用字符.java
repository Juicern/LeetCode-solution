/*
 * @lc app=leetcode.cn id=1002 lang=java
 *
 * [1002] 查找常用字符
 *
 * https://leetcode-cn.com/problems/find-common-characters/description/
 *
 * algorithms
 * Easy (67.03%)
 * Likes:    69
 * Dislikes: 0
 * Total Accepted:    12.4K
 * Total Submissions: 18.3K
 * Testcase Example:  '["bella","label","roller"]'
 *
 * 给定仅有小写字母组成的字符串数组 A，返回列表中的每个字符串中都显示的全部字符（包括重复字符）组成的列表。例如，如果一个字符在每个字符串中出现 3
 * 次，但不是 4 次，则需要在最终答案中包含该字符 3 次。
 * 
 * 你可以按任意顺序返回答案。
 * 
 * 
 * 
 * 示例 1：
 * 
 * 输入：["bella","label","roller"]
 * 输出：["e","l","l"]
 * 
 * 
 * 示例 2：
 * 
 * 输入：["cool","lock","cook"]
 * 输出：["c","o"]
 * 
 * 
 * 
 * 
 * 提示：
 * 
 * 
 * 1 <= A.length <= 100
 * 1 <= A[i].length <= 100
 * A[i][j] 是小写字母
 * 
 * 
 */

// @lc code=start
class Solution {
    public List<String> commonChars(String[] A) {
        int[] hash = new int[26];
        int[] temp = new int[26];
        for(int i = 0; i < 26; i++)
            hash[i] = 100;//每个字符出现次数最多100次，因为题目有限制每个单词最多含有100字符
        for(int i = 0; i < A.length; i++)
        {
            for(char c : A[i].toCharArray())
                temp[c - 'a']++;
            for(int j = 0; j < 26; j++)
            {
                hash[j] = Math.min(hash[j], temp[j]);
                temp[j] = 0;
            }
        }
        List<String> list = new LinkedList<String>();
        for(int i = 0; i < 26; i++)
        {
            while(hash[i] > 0)
            {
                list.add(String.valueOf((char)(i + 'a')));
                hash[i]--;
            }
        }
        return list;
    }
}
// @lc code=end

