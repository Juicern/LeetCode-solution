/*
 * @lc app=leetcode.cn id=381 lang=csharp
 *
 * [381] O(1) 时间插入、删除和获取随机元素 - 允许重复
 *
 * https://leetcode-cn.com/problems/insert-delete-getrandom-o1-duplicates-allowed/description/
 *
 * algorithms
 * Hard (38.09%)
 * Likes:    112
 * Dislikes: 0
 * Total Accepted:    6.3K
 * Total Submissions: 15.2K
 * Testcase Example:  '["RandomizedCollection","insert","insert","insert","getRandom","remove","getRandom"]\n' +
  '[[],[1],[1],[2],[],[1],[]]'
 *
 * 设计一个支持在平均 时间复杂度 O(1) 下， 执行以下操作的数据结构。
 * 
 * 注意: 允许出现重复元素。
 * 
 * 
 * insert(val)：向集合中插入元素 val。
 * remove(val)：当 val 存在时，从集合中移除一个 val。
 * getRandom：从现有集合中随机获取一个元素。每个元素被返回的概率应该与其在集合中的数量呈线性相关。
 * 
 * 
 * 示例:
 * 
 * // 初始化一个空的集合。
 * RandomizedCollection collection = new RandomizedCollection();
 * 
 * // 向集合中插入 1 。返回 true 表示集合不包含 1 。
 * collection.insert(1);
 * 
 * // 向集合中插入另一个 1 。返回 false 表示集合包含 1 。集合现在包含 [1,1] 。
 * collection.insert(1);
 * 
 * // 向集合中插入 2 ，返回 true 。集合现在包含 [1,1,2] 。
 * collection.insert(2);
 * 
 * // getRandom 应当有 2/3 的概率返回 1 ，1/3 的概率返回 2 。
 * collection.getRandom();
 * 
 * // 从集合中删除 1 ，返回 true 。集合现在包含 [1,2] 。
 * collection.remove(1);
 * 
 * // getRandom 应有相同概率返回 1 和 2 。
 * collection.getRandom();
 * 
 * 
 */

// @lc code=start
public class RandomizedCollection
{
    Random random;
    Dictionary<int, HashSet<int>> numberAndIndexSet;
    IList<int> numberList;
    /** Initialize your data structure here. */
    public RandomizedCollection()
    {
        random = new Random();
        numberAndIndexSet = new Dictionary<int, HashSet<int>>();
        numberList = new List<int>();
    }

    /** Inserts a value to the collection. Returns true if the collection did not already contain the specified element. */
    public bool Insert(int val)
    {
        if (numberAndIndexSet.ContainsKey(val))
        {
            numberList.Add(val);
            numberAndIndexSet[val].Add(numberList.Count - 1);
            return false;
        }
        else
        {
            numberList.Add(val);
            numberAndIndexSet[val] = new HashSet<int>() { numberList.Count - 1 };
            return true;
        }
    }

    /** Removes a value from the collection. Returns true if the collection contained the specified element. */
    public bool Remove(int val)
    {
        if (!numberAndIndexSet.ContainsKey(val)) return false;

        var curIndex = numberAndIndexSet[val].First();

        numberAndIndexSet[val].Remove(curIndex);
        if (!numberAndIndexSet[val].Any()) numberAndIndexSet.Remove(val);

        if (curIndex == numberList.Count - 1)
        {
            numberList.RemoveAt(numberList.Count - 1);
        }
        else
        {
            var needToModifiedNumber = numberList[numberList.Count - 1];
            numberList[curIndex] = needToModifiedNumber;
            numberList.RemoveAt(numberList.Count - 1);

            numberAndIndexSet[needToModifiedNumber].Remove(numberList.Count);
            numberAndIndexSet[needToModifiedNumber].Add(curIndex);
        }

        return true;
    }

    /** Get a random element from the collection. */
    public int GetRandom()
    {
        var randomIndex = random.Next(numberList.Count);

        return numberList[randomIndex];
    }
}

/**
 * Your RandomizedCollection object will be instantiated and called as such:
 * RandomizedCollection obj = new RandomizedCollection();
 * bool param_1 = obj.Insert(val);
 * bool param_2 = obj.Remove(val);
 * int param_3 = obj.GetRandom();
 */
// @lc code=end

