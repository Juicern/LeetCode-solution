/*
 * @lc app=leetcode.cn id=352 lang=java
 *
 * [352] 将数据流变为多个不相交区间
 *
 * https://leetcode-cn.com/problems/data-stream-as-disjoint-intervals/description/
 *
 * algorithms
 * Hard (54.34%)
 * Likes:    28
 * Dislikes: 0
 * Total Accepted:    1.9K
 * Total Submissions: 3.6K
 * Testcase Example:  '["SummaryRanges","addNum","getIntervals","addNum","getIntervals","addNum","getIntervals","addNum","getIntervals","addNum","getIntervals"]\n' +
  '[[],[1],[],[3],[],[7],[],[2],[],[6],[]]'
 *
 * 给定一个非负整数的数据流输入 a1，a2，…，an，…，将到目前为止看到的数字总结为不相交的区间列表。
 * 
 * 例如，假设数据流中的整数为 1，3，7，2，6，…，每次的总结为：
 * 
 * [1, 1]
 * [1, 1], [3, 3]
 * [1, 1], [3, 3], [7, 7]
 * [1, 3], [7, 7]
 * [1, 3], [6, 7]
 * 
 * 
 * 
 * 
 * 进阶：
 * 如果有很多合并，并且与数据流的大小相比，不相交区间的数量很小，该怎么办?
 * 
 * 提示：
 * 特别感谢 @yunhong 提供了本问题和其测试用例。
 * 
 */

// @lc code=start
class SummaryRanges {
	private Set<Integer> dataStream;
	private LinkedList<int[]> intervals;

	public SummaryRanges() {
		dataStream = new HashSet<>();
		intervals = new LinkedList<>();
		return;
	}

	public void addNum(int val) {
		if (!dataStream.contains(val)) {
			setIntervals(intervals, val);
			dataStream.add(val);
		}
		return;
	}

	private void setIntervals(LinkedList<int[]> intervals, int val) {
		int pos = findPos(intervals, val);
		if (dataStream.contains(val - 1) && dataStream.contains(val + 1)) { // 合并两个区间
			intervals.get(pos - 1)[1] = intervals.get(pos)[1];
			intervals.remove(pos);
		} else if (dataStream.contains(val - 1)) { 		// 扩展左区间
			intervals.get(pos - 1)[1]++;
		} else if (dataStream.contains(val + 1)) { 		// 扩展右区间
			intervals.get(pos)[0]--;
		} else { 										// 新增区间
			intervals.add(pos, new int[] { val, val });
		}
	}

	private int findPos(LinkedList<int[]> intervals, int val) {
		int index = 0;
		while (index < intervals.size() && val > intervals.get(index)[0]) {
			index++;
		}
		return index;
	}

	public int[][] getIntervals() {
		return intervals.toArray(new int[0][0]);
	}
}

/**
 * Your SummaryRanges object will be instantiated and called as such:
 * SummaryRanges obj = new SummaryRanges();
 * obj.addNum(val);
 * int[][] param_2 = obj.getIntervals();
 */
// @lc code=end

