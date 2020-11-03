#
# @lc app=leetcode.cn id=920 lang=python3
#
# [920] 播放列表的数量
#
# https://leetcode-cn.com/problems/number-of-music-playlists/description/
#
# algorithms
# Hard (44.79%)
# Likes:    58
# Dislikes: 0
# Total Accepted:    1.2K
# Total Submissions: 2.7K
# Testcase Example:  '3\n3\n1'
#
# 你的音乐播放器里有 N 首不同的歌，在旅途中，你的旅伴想要听 L 首歌（不一定不同，即，允许歌曲重复）。请你为她按如下规则创建一个播放列表：
# 
# 
# 每首歌至少播放一次。
# 一首歌只有在其他 K 首歌播放完之后才能再次播放。
# 
# 
# 返回可以满足要求的播放列表的数量。由于答案可能非常大，请返回它模 10^9 + 7 的结果。
# 
# 
# 
# 示例 1：
# 
# 输入：N = 3, L = 3, K = 1
# 输出：6
# 解释：有 6 种可能的播放列表。[1, 2, 3]，[1, 3, 2]，[2, 1, 3]，[2, 3, 1]，[3, 1, 2]，[3, 2,
# 1].
# 
# 
# 示例 2：
# 
# 输入：N = 2, L = 3, K = 0
# 输出：6
# 解释：有 6 种可能的播放列表。[1, 1, 2]，[1, 2, 1]，[2, 1, 1]，[2, 2, 1]，[2, 1, 2]，[1, 2, 2]
# 
# 
# 示例 3：
# 
# 输入：N = 2, L = 3, K = 1
# 输出：2
# 解释：有 2 种可能的播放列表。[1, 2, 1]，[2, 1, 2]
# 
# 
# 
# 
# 提示：
# 
# 
# 0 <= K < N <= L <= 100
# 
# 
#

# @lc code=start
class Solution:
    def numMusicPlaylists(self, N: int, L: int, K: int) -> int:
        mod = 10 ** 9 + 7
        # dp[i][j] 表示用j首不同的歌填充长度为i的歌单
        dp = [[0] * (N + 1) for _ in range(L + 1)]
        dp[0][0] = 1
        for i in range(1, L + 1):
            for j in range(1, N + 1):
                # 分成两种情况
                # 如果当前的歌和前面的都不一样，歌单前i-1首歌只包括了j-1首不同的歌曲，
                # 那么当前的选择有dp[i-1][j-1] * (N-j+1)
                # 如果当前的歌和前面的有重复的，那最近的K首必然是不能重复的，
                # 所以选择就是dp[i-1][j] * max(0, j-K)
                dp[i][j] = (dp[i-1][j-1] * (N - j + 1) + dp[i-1][j] * max(0, j - K)) % mod
        return dp[-1][-1]

        
# @lc code=end

