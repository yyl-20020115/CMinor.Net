using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace utils
{
    public static class IntUtils
    {
		public static string ToString(int num, int n)
		{
			char[] ch = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a',
				'b', 'c', 'd', 'e', 'f' };
			int mask = ~(-1 << n);
			char[] buf = new char[32 / n + 1];
			int i = buf.Length - 1;
			while (num != 0)
			{
				buf[i--] = ch[mask & num];
				num >>= n;
			}
			return new string(buf, i + 1, buf.Length - (i + 1));
		}

        public static string ToHexString(int num) => ToString(num, 4);

        public static string ToOctalString(int num) => ToString(num, 3);
    }
}
