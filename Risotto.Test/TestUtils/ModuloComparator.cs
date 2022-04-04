using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Risotto.Test.TestUtils
{
	public class ModuloComparator : IEqualityComparer<int>
	{
		public bool Equals(int x, int y)
		{
			if ((x % 2) == (y % 2))
				return true;

			return false;
		}

		public int GetHashCode(int obj)
		{
			return obj.GetHashCode();
		}
	}
}
