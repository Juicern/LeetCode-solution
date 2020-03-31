import java.util.*;
/*
 * @lc app=leetcode.cn id=30 lang=java
 *
 * [30] 串联所有单词的子串
 *
 * https://leetcode-cn.com/problems/substring-with-concatenation-of-all-words/description/
 *
 * algorithms
 * Hard (28.68%)
 * Likes:    223
 * Dislikes: 0
 * Total Accepted:    24.1K
 * Total Submissions: 81.8K
 * Testcase Example:  '"barfoothefoobarman"\n["foo","bar"]'
 *
 * 给定一个字符串 s 和一些长度相同的单词 words。找出 s 中恰好可以由 words 中所有单词串联形成的子串的起始位置。
 * 
 * 注意子串要与 words 中的单词完全匹配，中间不能有其他字符，但不需要考虑 words 中单词串联的顺序。
 * 
 * 
 * 
 * 示例 1：
 * 
 * 输入：
 * ⁠ s = "barfoothefoobarman",
 * ⁠ words = ["foo","bar"]
 * 输出：[0,9]
 * 解释：
 * 从索引 0 和 9 开始的子串分别是 "barfoo" 和 "foobar" 。
 * 输出的顺序不重要, [9,0] 也是有效答案。
 * 
 * 
 * 示例 2：
 * 
 * 输入：
 * ⁠ s = "wordgoodgoodgoodbestword",
 * ⁠ words = ["word","good","best","word"]
 * 输出：[]
 * 
 * 
 */

// @lc code=start
class Solution {
    public List<Integer> findSubstring(String s, String[] words) {
        List<Integer> list = new ArrayList<>();
        if(s.length()==0 || words.length==0) return list;
        int one_word = words[0].length();
        int word_num = words.length;
        int length = one_word*word_num;
        for(int i=0;i<s.length()-length+1;i++){
            Map<String, Integer> m = new HashMap<>();
            for(int j=0;j<word_num;j++){
                m.put(words[j], m.getOrDefault(words[j], 0)+1);
            }
            boolean isRight = true;
            for(int j=0;j<word_num;j++){
                String tmp = s.substring(i+j*one_word, i+j*one_word+one_word);
                if(m.getOrDefault(tmp, 0)>0){
                    m.put(tmp, m.get(tmp)-1);
                }
                else{
                    isRight = false;
                    break;
                }
            }
            if(isRight==true) list.add(i);
        }
        return list;
    }
}
// @lc code=end

