using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Risotto.Test
{
	[TestFixture]
	public class ListUtils
	{
		private static readonly List<string> DinosaurList = new List<string>()
		{
			"Tyrannosaurus",
			"Amargasaurus",
			"Mamenchisaurus",
			"Brachiosaurus",
			"Deinonychus",
			"Tyrannosaurus",
			"Compsognathus"
		};

		#region IndexOf

		[Test]
		public void IndexOfNullCustomComparer()
		{
			Assert.Throws<ArgumentNullException>(() => DinosaurList.IndexOf("TYRANNOSAURUS", null));
		}

		[Test]
		public void IndexOfCustomComparerOnlyTargetExisting()
		{
			Assert.That(DinosaurList.IndexOf("TYRANNOSAURUS", StringComparer.OrdinalIgnoreCase) == 0);
		}

		[Test]
		public void IndexOfCustomComparerOnlyTargetNotExisting()
		{
			Assert.That(DinosaurList.IndexOf("Stegosaurus", StringComparer.OrdinalIgnoreCase) == -1);
		}

		[Test]
		public void IndexOfCustomComparerTargetAndStartingIndexNullComparer()
		{
			Assert.Throws<ArgumentNullException>(() => DinosaurList.IndexOf("TyRanNoSaurUs", 3, null));
		}

		[Test]
		public void IndexOfCustomComparerTargetAndStartingIndexOutOfRange()
		{
			Assert.Throws<ArgumentOutOfRangeException>(() => DinosaurList.IndexOf("TyRanNoSaurUs", 113, StringComparer.OrdinalIgnoreCase));
		}

		[Test]
		public void IndexOfCustomComparerTargetAndStartingIndexNegativeIndex()
		{
			Assert.Throws<ArgumentOutOfRangeException>(() => DinosaurList.IndexOf("TyRanNoSaurUs", -1, StringComparer.OrdinalIgnoreCase));
		}

		[Test]
		public void IndexOfCustomComparerTargetAndStartingIndexNotExisting()
		{
			Assert.That(DinosaurList.IndexOf("Amargasaurus", 3, StringComparer.OrdinalIgnoreCase) == -1);
		}

		[Test]
		public void IndexOfCustomComparerTargetAndStartingIndexExisting()
		{
			Assert.That(DinosaurList.IndexOf("TyRanNoSaurUs", 3, StringComparer.OrdinalIgnoreCase) == 5);
		}

		[Test]
		public void IndexOfCustomComparerTargetIntIntNegativeIndex()
		{
			Assert.Throws<ArgumentOutOfRangeException>(() => DinosaurList.IndexOf("TyRanNoSaurUs", -1, 3, StringComparer.OrdinalIgnoreCase));
		}

		[Test]
		public void IndexOfCustomComparerTargetIntIntGreaterIndex()
		{
			Assert.Throws<ArgumentOutOfRangeException>(() => DinosaurList.IndexOf("TyRanNoSaurUs", 113, 3, StringComparer.OrdinalIgnoreCase));
		}

		[Test]
		public void IndexOfCustomComparerTargetIntIntNegativeCount()
		{
			Assert.Throws<ArgumentOutOfRangeException>(() => DinosaurList.IndexOf("Tyrannosaurus", 1, -3, StringComparer.OrdinalIgnoreCase));
		}

		[Test]
		public void IndexOfCustomComparerTargetIntIntCountOverflow()
		{
			Assert.Throws<ArgumentOutOfRangeException>(() => DinosaurList.IndexOf("Tyrannosaurus", 1, 18, StringComparer.OrdinalIgnoreCase));
		}

		[Test]
		public void IndexOfCustomComparerTargetIntIntTargetNotFound()
		{
			Assert.That(DinosaurList.IndexOf("TyRanNosAuruS", 2, 2, StringComparer.OrdinalIgnoreCase) == -1);
		}

		[Test]
		public void IndexOfCustomComparerTargetIntIntTargetFound()
		{
			Assert.That(DinosaurList.IndexOf("TyRanNosAuruS", 0, 3, StringComparer.OrdinalIgnoreCase) == 0);
		}
		#endregion
	}
}
