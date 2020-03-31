import java.util.*;
/*
 * @lc app=leetcode.cn id=212 lang=java
 *
 * [212] 单词搜索 II
 *
 * https://leetcode-cn.com/problems/word-search-ii/description/
 *
 * algorithms
 * Hard (38.83%)
 * Likes:    122
 * Dislikes: 0
 * Total Accepted:    11.2K
 * Total Submissions: 28.3K
 * Testcase Example:  '[["o","a","a","n"],["e","t","a","e"],["i","h","k","r"],["i","f","l","v"]]\n' +
  '["oath","pea","eat","rain"]'
 *
 * 给定一个二维网格 board 和一个字典中的单词列表 words，找出所有同时在二维网格和字典中出现的单词。
 * 
 * 
 * 单词必须按照字母顺序，通过相邻的单元格内的字母构成，其中“相邻”单元格是那些水平相邻或垂直相邻的单元格。同一个单元格内的字母在一个单词中不允许被重复使用。
 * 
 * 示例:
 * 
 * 输入: 
 * words = ["oath","pea","eat","rain"] and board =
 * [
 * ⁠ ['o','a','a','n'],
 * ⁠ ['e','t','a','e'],
 * ⁠ ['i','h','k','r'],
 * ⁠ ['i','f','l','v']
 * ]
 * 
 * 输出: ["eat","oath"]
 * 
 * 说明:
 * 你可以假设所有输入都由小写字母 a-z 组成。
 * 
 * 提示:
 * 
 * 
 * 你需要优化回溯算法以通过更大数据量的测试。你能否早点停止回溯？
 * 如果当前单词不存在于所有单词的前缀中，则可以立即停止回溯。什么样的数据结构可以有效地执行这样的操作？散列表是否可行？为什么？
 * 前缀树如何？如果你想学习如何实现一个基本的前缀树，请先查看这个问题： 实现Trie（前缀树）。
 * 
 * 
 */

// @lc code=start
class TrieNode{
    TrieNode[] children;
    String word;
    public TrieNode(){
        children = new TrieNode[26];
        word = null;
        for(int i=0;i<26;i++) children[i] = null;
    }
}

class Trie{
    TrieNode root;
    public Trie(){
        root = new TrieNode();
    }
    public void insert(String word){
        char[] ch = word.toCharArray();
        TrieNode cur = root;
        for(int i=0;i<ch.length;i++){
            if(cur.children[ch[i]-'a']==null){
                cur.children[ch[i]-'a'] = new TrieNode();
            }
            cur = cur.children[ch[i]-'a']; 
        }
        cur.word = word;
    }
}

class Solution {
    public void backtrace(char[][] board, int row, int col, TrieNode node, List<String> res){
        if(row<0 || row >=board.length || col<0 || col>=board[0].length) return;
        char cur = board[row][col];
        if(cur=='$' || node.children[cur-'a']==null) return;
        node = node.children[cur-'a'];
        if(node.word!=null){
            res.add(node.word);
            node.word = null;
        }
        char tmp = board[row][col];
        board[row][col] = '$';
        backtrace(board, row+1, col, node, res);
        backtrace(board, row-1, col, node, res);
        backtrace(board, row, col+1, node, res);
        backtrace(board, row, col-1, node, res);
        board[row][col] = tmp;
        return;
    }
    public List<String> findWords(char[][] board, String[] words) {
        List<String> res = new ArrayList<>();
        Trie trie = new Trie();
        for(String word : words) trie.insert(word);
        int row = board.length;
        if(row==0) return res;
        int col = board[0].length;
        for(int i=0;i<row;i++){
            for(int j=0;j<col;j++){
                backtrace(board, i, j, trie.root, res);
            }
        } 
        return res;
    }
}
// @lc code=end

