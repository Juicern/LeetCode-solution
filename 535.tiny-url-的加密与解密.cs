/*
 * @lc app=leetcode.cn id=535 lang=csharp
 *
 * [535] TinyURL 的加密与解密
 *
 * https://leetcode-cn.com/problems/encode-and-decode-tinyurl/description/
 *
 * algorithms
 * Medium (82.77%)
 * Likes:    94
 * Dislikes: 0
 * Total Accepted:    10.8K
 * Total Submissions: 13.1K
 * Testcase Example:  '"https://leetcode.com/problems/design-tinyurl"'
 *
 * TinyURL是一种URL简化服务， 比如：当你输入一个URL https://leetcode.com/problems/design-tinyurl
 * 时，它将返回一个简化的URL http://tinyurl.com/4e9iAk.
 * 
 * 要求：设计一个 TinyURL 的加密 encode 和解密 decode
 * 的方法。你的加密和解密算法如何设计和运作是没有限制的，你只需要保证一个URL可以被加密成一个TinyURL，并且这个TinyURL可以用解密方法恢复成原本的URL。
 * 
 */

// @lc code=start
public class Codec
{
    Hashtable hash1 = new Hashtable();
    Hashtable hash2 = new Hashtable();
    string shortStringSource = "abcdefthijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

    // Encodes a URL to a shortened URL
    public string encode(string longUrl)
    {
        StringBuilder shortString = new StringBuilder();

        if (longUrl == null || longUrl == string.Empty)
            return string.Empty;
        else if (hash1.ContainsKey(longUrl))
            return (string)hash1[longUrl];

        for (int i = 0; i <= 5; i++)
            shortString.Append(shortStringSource[new Random().Next(0, 61)]);

        hash1.Add(longUrl, "http://tinyurl.com/" + shortString.ToString());
        hash2.Add("http://tinyurl.com/" + shortString.ToString(), longUrl);

        return "http://tinyurl.com/" + shortString.ToString();
    }

    // Decodes a shortened URL to its original URL.
    public string decode(string shortUrl)
    {
        return (string)hash2[shortUrl];
    }
}

// Your Codec object will be instantiated and called as such:
// Codec codec = new Codec();
// codec.decode(codec.encode(url));
// @lc code=end

