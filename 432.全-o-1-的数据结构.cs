using System;
using System.Collections.Generic;
using System.Linq;
/*
 * @lc app=leetcode.cn id=432 lang=csharp
 *
 * [432] 全 O(1) 的数据结构
 *
 * https://leetcode-cn.com/problems/all-oone-data-structure/description/
 *
 * algorithms
 * Hard (34.99%)
 * Likes:    68
 * Dislikes: 0
 * Total Accepted:    4.3K
 * Total Submissions: 12.3K
 * Testcase Example:  '["AllOne","getMaxKey","getMinKey"]\n[[],[],[]]'
 *
 * 请你实现一个数据结构支持以下操作：
 * 
 * 
 * Inc(key) - 插入一个新的值为 1 的 key。或者使一个存在的 key 增加一，保证 key 不为空字符串。
 * Dec(key) - 如果这个 key 的值是 1，那么把他从数据结构中移除掉。否则使一个存在的 key 值减一。如果这个 key
 * 不存在，这个函数不做任何事情。key 保证不为空字符串。
 * GetMaxKey() - 返回 key 中值最大的任意一个。如果没有元素存在，返回一个空字符串"" 。
 * GetMinKey() - 返回 key 中值最小的任意一个。如果没有元素存在，返回一个空字符串""。
 * 
 * 
 * 
 * 
 * 挑战：
 * 
 * 你能够以 O(1) 的时间复杂度实现所有操作吗？
 * 
 */

// @lc code=start
public class AllOne {
    // 存储key的次数
    public Dictionary<string, int> dic;
    // 存储当前次数的所有key值
    public SortedDictionary<int, HashSet<string>> counts;
    // 存储最大次数
    int maxCount;

    /** Initialize your data structure here. */
    public AllOne() {
        dic = new Dictionary<string, int>();
        counts = new SortedDictionary<int, HashSet<string>>();
    }
    
    /** Inserts a new key <Key> with value 1. Or increments an existing key by 1. */
    public void Inc(string key) {
        if(!dic.ContainsKey(key)) dic.Add(key, 0);
        else {
            // 从两个哈希表中删除旧的次数
            counts[dic[key]].Remove(key);
            if(!counts[dic[key]].Any()) counts.Remove(dic[key]);
        }
        // 更新哈希表的值
        dic[key]++;
        if(!counts.ContainsKey(dic[key])) counts.Add(dic[key], new HashSet<string>());
        counts[dic[key]].Add(key);
        // 更新最大次数
        maxCount = Math.Max(maxCount, dic[key]);
    }
    
    /** Decrements an existing key by 1. If Key's value is 1, remove it from the data structure. */
    public void Dec(string key) {
        // 若没有这个key，直接返回
        if(!dic.ContainsKey(key)) return;
        // 删除旧有值
        counts[dic[key]].Remove(key);
        if(!counts[dic[key]].Any()) counts.Remove(dic[key]);
        // 更新新值
        dic[key]--;
        if(dic[key] == 0) dic.Remove(key); // 若当前key的次数已为0，则删去它
        else { 
            if(!counts.ContainsKey(dic[key])) counts.Add(dic[key], new HashSet<string>());
            counts[dic[key]].Add(key);
        } 
        // 若maxCount次数的key值不存在，则说明唯一一个最大次数的key被dec了，因此更新maxCount
        if(!counts.ContainsKey(maxCount)) maxCount--;
    }
    
    /** Returns one of the keys with maximal value. */
    public string GetMaxKey() {
        // 返回maxCount次数的任意一个节点
        if(counts.Any()){
            foreach(var ans in counts[maxCount]) {
                return ans;
            }
        }
        return string.Empty;
    }
    
    /** Returns one of the keys with Minimal value. */
    public string GetMinKey() {
        if(counts.Any()){
            // 顺序遍历SortedDictionary，第一个即时最小的key
            foreach(var key in counts.Keys) {
                foreach(var ans in counts[key]){
                    return ans;
                }
            }
        }
        return string.Empty;
    }
}

/**
 * Your AllOne object will be instantiated and called as such:
 * AllOne obj = new AllOne();
 * obj.Inc(key);
 * obj.Dec(key);
 * string param_3 = obj.GetMaxKey();
 * string param_4 = obj.GetMinKey();
 */
// @lc code=end

