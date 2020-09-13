/*
 * @lc app=leetcode.cn id=911 lang=csharp
 *
 * [911] 在线选举
 *
 * https://leetcode-cn.com/problems/online-election/description/
 *
 * algorithms
 * Medium (41.89%)
 * Likes:    24
 * Dislikes: 0
 * Total Accepted:    2.5K
 * Total Submissions: 5.8K
 * Testcase Example:  '["TopVotedCandidate","q","q","q","q","q","q"]\n' +
  '[[[0,1,1,0,0,1,0],[0,5,10,15,20,25,30]],[3],[12],[25],[15],[24],[8]]'
 *
 * 在选举中，第 i 张票是在时间为 times[i] 时投给 persons[i] 的。
 * 
 * 现在，我们想要实现下面的查询函数： TopVotedCandidate.q(int t) 将返回在 t 时刻主导选举的候选人的编号。
 * 
 * 在 t 时刻投出的选票也将被计入我们的查询之中。在平局的情况下，最近获得投票的候选人将会获胜。
 * 
 * 示例：
 * 
 * 输入：["TopVotedCandidate","q","q","q","q","q","q"],
 * [[[0,1,1,0,0,1,0],[0,5,10,15,20,25,30]],[3],[12],[25],[15],[24],[8]]
 * 输出：[null,0,1,1,0,0,1]
 * 解释：
 * 时间为 3，票数分布情况是 [0]，编号为 0 的候选人领先。
 * 时间为 12，票数分布情况是 [0,1,1]，编号为 1 的候选人领先。
 * 时间为 25，票数分布情况是 [0,1,1,0,0,1]，编号为 1 的候选人领先（因为最近的投票结果是平局）。
 * 在时间 15、24 和 8 处继续执行 3 个查询。
 * 
 * 
 * 
 * 
 * 提示：
 * 
 * 
 * 1 <= persons.length = times.length <= 5000
 * 0 <= persons[i] <= persons.length
 * times 是严格递增的数组，所有元素都在 [0, 10^9] 范围中。
 * 每个测试用例最多调用 10000 次 TopVotedCandidate.q。
 * TopVotedCandidate.q(int t) 被调用时总是满足 t >= times[0]。
 * 
 * 
 */

// @lc code=start
public class TopVotedCandidate
{
    private readonly (int time, int winner)[] _data;

    public TopVotedCandidate(int[] persons, int[] times)
    {
        int currentWinner = -1;
        int maxScore = 0;

        IDictionary<int, int> person2Score = new Dictionary<int, int>();
        _data = new (int time, int winner)[times.Length];

        for (int i = 0; i < persons.Length; i++)
        {
            if (!person2Score.ContainsKey(persons[i]))
            {
                person2Score[persons[i]] = 0;
            }

            person2Score[persons[i]]++;
            if (person2Score[persons[i]] >= maxScore)
            {
                maxScore = person2Score[persons[i]];
                currentWinner = persons[i];
            }

            _data[i] = (times[i], currentWinner);
        }

    }

    public int Q(int t) => BinarySearch(t);

    private int BinarySearch(int target)
    {
        int l = 0;
        int r = _data.Length - 1;

        while (l < r)
        {
            int mid = l + (r - l) / 2;

            if (r - l == 1)
            {
                break;
            }

            if (target == _data[mid].time)
            {
                return _data[mid].winner;
            }

            if (target < _data[mid].time)
            {
                r = mid;
                continue;
            }

            l = mid;
        }

        if (target == _data[l].time)
        {
            return _data[l].winner;
        }


        if (target == _data[r].time)
        {
            return _data[r].winner;
        }


        if (_data[r].time < target)
        {
            return _data[r].winner;
        }

        return _data[l].winner;
    }
}

/**
 * Your TopVotedCandidate object will be instantiated and called as such:
 * TopVotedCandidate obj = new TopVotedCandidate(persons, times);
 * int param_1 = obj.Q(t);
 */
// @lc code=end

