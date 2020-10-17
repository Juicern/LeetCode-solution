using System.Collections.Generic;
using System.Linq;
/*
 * @lc app=leetcode.cn id=460 lang=csharp
 *
 * [460] LFU缓存
 *
 * https://leetcode-cn.com/problems/lfu-cache/description/
 *
 * algorithms
 * Hard (42.55%)
 * Likes:    280
 * Dislikes: 0
 * Total Accepted:    18K
 * Total Submissions: 42.3K
 * Testcase Example:  '["LFUCache","put","put","get","put","get","get","put","get","get","get"]\n' +
  '[[2],[1,1],[2,2],[1],[3,3],[2],[3],[4,4],[1],[3],[4]]'
 *
 * 请你为 最不经常使用（LFU）缓存算法设计并实现数据结构。它应该支持以下操作：get 和 put。
 * 
 * 
 * get(key) - 如果键存在于缓存中，则获取键的值（总是正数），否则返回 -1。
 * put(key, value) -
 * 如果键已存在，则变更其值；如果键不存在，请插入键值对。当缓存达到其容量时，则应该在插入新项之前，使最不经常使用的项无效。在此问题中，当存在平局（即两个或更多个键具有相同使用频率）时，应该去除最久未使用的键。
 * 
 * 
 * 「项的使用次数」就是自插入该项以来对其调用 get 和 put 函数的次数之和。使用次数会在对应项被移除后置为 0 。
 * 
 * 
 * 
 * 进阶：
 * 你是否可以在 O(1) 时间复杂度内执行两项操作？
 * 
 * 
 * 
 * 示例：
 * 
 * LFUCache cache = new LFUCache( 2 /* capacity (缓存容量) */ );
 * 
 * cache.put(1, 1);
 * cache.put(2, 2);
 * cache.get(1);       // 返回 1
 * cache.put(3, 3);    // 去除 key 2
 * cache.get(2);       // 返回 -1 (未找到key 2)
 * cache.get(3);       // 返回 3
 * cache.put(4, 4);    // 去除 key 1
 * cache.get(1);       // 返回 -1 (未找到 key 1)
 * cache.get(3);       // 返回 3
 * cache.get(4);       // 返回 4
 * 
 */

// @lc code=start
public class LFUCache {
    int minFreq;
    int capacity;
    Dictionary<int, Node> key_table;
    Dictionary<int, LinkedList<Node>> freq_table;
    public LFUCache(int capacity) {
        this.minFreq = 0;
        this.capacity = capacity;
        key_table = new Dictionary<int, Node>();
        freq_table = new Dictionary<int, LinkedList<Node>>();
    }
    
    public int Get(int key) {
        if(capacity == 0) return -1;
        if(!key_table.ContainsKey(key)) return -1;
        Node node = key_table[key];
        int val = node.val;
        int freq = node.freq;
        freq_table[freq].Remove(node);
        if(!freq_table[freq].Any()) {
            freq_table.Remove(freq);
            if(minFreq == freq) {
                minFreq++;
            }
        }
        if(!freq_table.ContainsKey(freq + 1)) freq_table.Add(freq + 1, new LinkedList<Node>());
        var list = freq_table[freq + 1]; 
        list.AddFirst(new Node(key, val, freq + 1));
        freq_table[freq + 1] =  list;
        key_table[key] =  freq_table[freq + 1].First();
        return val;
    }
    
    public void Put(int key, int value) {
        if(capacity == 0) return;
        if(!key_table.ContainsKey(key)){
            if(key_table.Count == capacity) {
                Node node = freq_table[minFreq].Last();
                key_table.Remove(node.key);
                freq_table[minFreq].RemoveLast();
                if(!freq_table[minFreq].Any()) {
                    freq_table.Remove(minFreq);
                }
            }
            if(!freq_table.ContainsKey(1)) freq_table.Add(1, new LinkedList<Node>());
            var list = freq_table[1];
            list.AddFirst(new Node(key, value, 1));
            freq_table[1] = list;
            key_table[key] = freq_table[1].First();
            minFreq = 1;
        }
        else{
            var node = key_table[key];
            int freq = node.freq;
            freq_table[freq].Remove(node);
            if(!freq_table[freq].Any()){
                freq_table.Remove(freq);
                if(minFreq == freq){
                    minFreq ++;
                }
            }
            if(!freq_table.ContainsKey(freq + 1)) freq_table.Add(freq + 1, new LinkedList<Node>());
            var list = freq_table[freq + 1];
            list.AddFirst(new Node(key, value, freq + 1));
            freq_table[freq + 1] = list;
            key_table[key] = freq_table[freq + 1].First();
        }
    }
}
public class Node{
    public int key {get; set;}
    public int val {get; set;}
    public int freq {get; set;}
    public Node(int key, int val, int freq )
    {
        this.key = key;
        this.val = val;
        this.freq = freq;
    }
}

/**
 * Your LFUCache object will be instantiated and called as such:
 * LFUCache obj = new LFUCache(capacity);
 * int param_1 = obj.Get(key);
 * obj.Put(key,value);
 */
// @lc code=end

