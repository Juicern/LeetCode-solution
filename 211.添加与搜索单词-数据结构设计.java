import java.util.*;


/*
 * @lc app=leetcode.cn id=211 lang=java
 *
 * [211] 添加与搜索单词 - 数据结构设计
 *
 * https://leetcode-cn.com/problems/add-and-search-word-data-structure-design/description/
 *
 * algorithms
 * Medium (41.98%)
 * Likes:    99
 * Dislikes: 0
 * Total Accepted:    8.7K
 * Total Submissions: 20.1K
 * Testcase Example:  '["WordDictionary","addWord","addWord","addWord","search","search","search","search"]\n' +
  '[[],["bad"],["dad"],["mad"],["pad"],["bad"],[".ad"],["b.."]]'
 *
 * 设计一个支持以下两种操作的数据结构：
 * 
 * void addWord(word)
 * bool search(word)
 * 
 * 
 * search(word) 可以搜索文字或正则表达式字符串，字符串只包含字母 . 或 a-z 。 . 可以表示任何一个字母。
 * 
 * 示例:
 * 
 * addWord("bad")
 * addWord("dad")
 * addWord("mad")
 * search("pad") -> false
 * search("bad") -> true
 * search(".ad") -> true
 * search("b..") -> true
 * 
 * 
 * 说明:
 * 
 * 你可以假设所有单词都是由小写字母 a-z 组成的。
 * 
 */

// @lc code=start
class WordDictionary {
    class TrieNode{
        TrieNode[] children;
        boolean isEnd;
        public TrieNode(){
            children = new TrieNode[26];
            isEnd = false;
            for(int i=0;i<26;i++) children[i] = null;
        }
    }
    TrieNode root;
    /** Initialize your data structure here. */
    public WordDictionary() {
        root = new TrieNode();
    }
    
    /** Adds a word into the data structure. */
    public void addWord(String word) {
        char[] ch = word.toCharArray();
        TrieNode cur = root;
        for(int i=0;i<ch.length;i++){
            if(cur.children[ch[i]-'a']==null){
                cur.children[ch[i]-'a'] = new TrieNode();
            }
            cur = cur.children[ch[i]-'a'];
        }
        cur.isEnd = true;
    }
    
    /** Returns if the word is in the data structure. A word could contain the dot character '.' to represent any one letter. */
    public boolean search(String word) {
        return searchHelper(word, root);
    }

    public boolean searchHelper(String word, TrieNode root){
        char[] ch = word.toCharArray();
        TrieNode cur = root;
        for(int i=0;i<ch.length;i++){
            if(ch[i]=='.'){
                for(int j=0;j<26;j++){
                    if(cur.children[j]!=null){
                        if(searchHelper(word.substring(i+1), cur.children[j])) return true;
                    }
                }
                return false;
            }
            if(cur.children[ch[i]-'a']==null){
                return false;
            }
            cur = cur.children[ch[i]-'a'];
        }
        return cur.isEnd;
    }
}

/**
 * Your WordDictionary object will be instantiated and called as such:
 * WordDictionary obj = new WordDictionary();
 * obj.addWord(word);
 * boolean param_2 = obj.search(word);
 */
// @lc code=end

