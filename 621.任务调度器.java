/*
 * @lc app=leetcode.cn id=621 lang=java
 *
 * [621] 任务调度器
 *
 * https://leetcode-cn.com/problems/task-scheduler/description/
 *
 * algorithms
 * Medium (48.40%)
 * Likes:    264
 * Dislikes: 0
 * Total Accepted:    21.5K
 * Total Submissions: 43.9K
 * Testcase Example:  '["A","A","A","B","B","B"]\n2'
 *
 * 给定一个用字符数组表示的 CPU 需要执行的任务列表。其中包含使用大写的 A - Z 字母表示的26
 * 种不同种类的任务。任务可以以任意顺序执行，并且每个任务都可以在 1 个单位时间内执行完。CPU
 * 在任何一个单位时间内都可以执行一个任务，或者在待命状态。
 * 
 * 然而，两个相同种类的任务之间必须有长度为 n 的冷却时间，因此至少有连续 n 个单位时间内 CPU 在执行不同的任务，或者在待命状态。
 * 
 * 你需要计算完成所有任务所需要的最短时间。
 * 
 * 
 * 
 * 示例 ：
 * 
 * 输入：tasks = ["A","A","A","B","B","B"], n = 2
 * 输出：8
 * 解释：A -> B -> (待命) -> A -> B -> (待命) -> A -> B.
 * ⁠    在本示例中，两个相同类型任务之间必须间隔长度为 n = 2
 * 的冷却时间，而执行一个任务只需要一个单位时间，所以中间出现了（待命）状态。 
 * 
 * 
 * 
 * 提示：
 * 
 * 
 * 任务的总个数为 [1, 10000]。
 * n 的取值范围为 [0, 100]。
 * 
 * 
 */

// @lc code=start
class Solution {
    public int leastInterval(char[] tasks, int n) {
        HashMap<Character, Integer> task_map = new HashMap<>();
        // 记录单个任务出现的最多的次数
        int max_count = 0;
        // 记录有最多任务数的 任务个数
        int difference = 0;
        for (Character task : tasks) {
            int count = task_map.getOrDefault(task, 0) + 1;
            task_map.put(task, count);
            max_count = Math.max(max_count, count);
        }
        for(Map.Entry<Character, Integer> entry:task_map.entrySet()){
            if(entry.getValue() == max_count) difference++;
        }
        int number1 = (n + 1) * (max_count - 1) + difference;
        int number2 = tasks.length;
        return Math.max(number1,number2);
    }
}
// @lc code=end

