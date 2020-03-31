import java.util.*;

/*
 * @lc app=leetcode.cn id=68 lang=java
 *
 * [68] 文本左右对齐
 *
 * https://leetcode-cn.com/problems/text-justification/description/
 *
 * algorithms
 * Hard (42.01%)
 * Likes:    54
 * Dislikes: 0
 * Total Accepted:    6.7K
 * Total Submissions: 15.6K
 * Testcase Example:  '["This", "is", "an", "example", "of", "text", "justification."]\n16'
 *
 * 给定一个单词数组和一个长度 maxWidth，重新排版单词，使其成为每行恰好有 maxWidth 个字符，且左右两端对齐的文本。
 * 
 * 你应该使用“贪心算法”来放置给定的单词；也就是说，尽可能多地往每行中放置单词。必要时可用空格 ' ' 填充，使得每行恰好有 maxWidth 个字符。
 * 
 * 要求尽可能均匀分配单词间的空格数量。如果某一行单词间的空格不能均匀分配，则左侧放置的空格数要多于右侧的空格数。
 * 
 * 文本的最后一行应为左对齐，且单词之间不插入额外的空格。
 * 
 * 说明:
 * 
 * 
 * 单词是指由非空格字符组成的字符序列。
 * 每个单词的长度大于 0，小于等于 maxWidth。
 * 输入单词数组 words 至少包含一个单词。
 * 
 * 
 * 示例:
 * 
 * 输入:
 * words = ["This", "is", "an", "example", "of", "text", "justification."]
 * maxWidth = 16
 * 输出:
 * [
 * "This    is    an",
 * "example  of text",
 * "justification.  "
 * ]
 * 
 * 
 * 示例 2:
 * 
 * 输入:
 * words = ["What","must","be","acknowledgment","shall","be"]
 * maxWidth = 16
 * 输出:
 * [
 * "What   must   be",
 * "acknowledgment  ",
 * "shall be        "
 * ]
 * 解释: 注意最后一行的格式应为 "shall be    " 而不是 "shall     be",
 * 因为最后一行应为左对齐，而不是左右两端对齐。       
 * ⁠    第二行同样为左对齐，这是因为这行只包含一个单词。
 * 
 * 
 * 示例 3:
 * 
 * 输入:
 * words =
 * ["Science","is","what","we","understand","well","enough","to","explain",
 * "to","a","computer.","Art","is","everything","else","we","do"]
 * maxWidth = 20
 * 输出:
 * [
 * "Science  is  what we",
 * ⁠ "understand      well",
 * "enough to explain to",
 * "a  computer.  Art is",
 * "everything  else  we",
 * "do                  "
 * ]
 * 
 * 
 */

// @lc code=start
class Solution {
    private String rowJustify(ArrayList<String> words, int maxWidth, boolean isLast, int words_length){
        int length = words.get(0).length();
        int index = 1;
        int n = words.size();
        StringBuffer res = new StringBuffer();
        res.append(words.get(0));
        if(n==1) isLast = true;
        if(isLast){
            while(index < n){
                res.append(" " + words.get(index));
                length = length + words.get(index).length() + 1;
                index++;
            }
            for(int i=length;i<maxWidth;i++){
                res.append(" ");
            }
        }
        else{
            int extra_space_num = maxWidth - words_length;  //额外需要的空格
            int each_extra = extra_space_num / (n-1);    //每个单词间基本的空格数
            int add_each = extra_space_num % (n-1);  //有几个单词间需要额外加空格
            String space = "";
            for(int i=0;i<each_extra;i++) space += " ";
            while(index<n){
                if(add_each-->0) res.append(" ");
                res.append(space + " " + words.get(index));
                index++;
            }
        }
        return res.toString();
    }
    public List<String> fullJustify(String[] words, int maxWidth) {
        List<String> ans = new ArrayList<>();
        int index = 0;
        int n = words.length;
        boolean isLast = false;
        while(index<n){
            index++;
            int num = 1;    //一句话的单词数量
            int length = words[index-1].length();   //目前已经形成的单词长度
            ArrayList<String> row_words = new ArrayList<>();
            row_words.add(words[index-1]);
            while(length<maxWidth){
                if(index>=n){
                    isLast = true;      
                    break;
                }
                if(length+words[index].length()+1 <= maxWidth){
                    row_words.add(words[index]);
                    length = length + words[index].length() + 1;
                    num++;
                    index++;
                    
                }
                else break;
            }
            ans.add(rowJustify(row_words, maxWidth, isLast, length));
        }
        return ans;
    }
}
// @lc code=end

