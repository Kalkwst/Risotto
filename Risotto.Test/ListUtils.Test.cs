using NUnit.Framework;
using System;
using System.Collections.Generic;

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

		#region LastIndexOf

		[Test]
		public void LastIndexOfNullCustomComparer()
		{
			Assert.Throws<ArgumentNullException>(() => DinosaurList.LastIndexOf("TYRANNOSAURUS", null));
		}

		[Test]
		public void LastIndexOfCustomComparerOnlyTargetExisting()
		{
			Assert.That(DinosaurList.LastIndexOf("TYRANNOSAURUS", StringComparer.OrdinalIgnoreCase) == 5);
		}

		[Test]
		public void LastIndexOfCustomComparerOnlyTargetNotExisting()
		{
			Assert.That(DinosaurList.LastIndexOf("Stegosaurus", StringComparer.OrdinalIgnoreCase) == -1);
		}

		[Test]
		public void LastIndexOfCustomComparerTargetAndStartingIndexNullComparer()
		{
			Assert.Throws<ArgumentNullException>(() => DinosaurList.LastIndexOf("TyRanNoSaurUs", 3, null));
		}

		[Test]
		public void LastIndexOfCustomComparerTargetAndStartingIndexOutOfRange()
		{
			Assert.Throws<ArgumentOutOfRangeException>(() => DinosaurList.LastIndexOf("TyRanNoSaurUs", 113, StringComparer.OrdinalIgnoreCase));
		}

		[Test]
		public void LastIndexOfCustomComparerTargetAndStartingIndexNegativeIndex()
		{
			Assert.Throws<ArgumentOutOfRangeException>(() => DinosaurList.LastIndexOf("TyRanNoSaurUs", -1, StringComparer.OrdinalIgnoreCase));
		}

		[Test]
		public void LastIndexOfCustomComparerTargetAndStartingIndexNotExisting()
		{
			Assert.That(DinosaurList.LastIndexOf("Amargasaurus", 3, StringComparer.OrdinalIgnoreCase) == 1);
		}

		[Test]
		public void LastIndexOfCustomComparerTargetAndStartingIndexExisting()
		{
			Assert.That(DinosaurList.LastIndexOf("TyRanNoSaurUs", 3, StringComparer.OrdinalIgnoreCase) == 0);
		}

		[Test]
		public void LastIndexOfCustomComparerTargetIntIntNegativeIndex()
		{
			Assert.Throws<ArgumentOutOfRangeException>(() => DinosaurList.LastIndexOf("TyRanNoSaurUs", -1, 3, StringComparer.OrdinalIgnoreCase));
		}

		[Test]
		public void LastIndexOfCustomComparerTargetIntIntGreaterIndex()
		{
			Assert.Throws<ArgumentOutOfRangeException>(() => DinosaurList.LastIndexOf("TyRanNoSaurUs", 113, 3, StringComparer.OrdinalIgnoreCase));
		}

		[Test]
		public void LastIndexOfCustomComparerTargetIntIntNegativeCount()
		{
			Assert.Throws<ArgumentOutOfRangeException>(() => DinosaurList.LastIndexOf("Tyrannosaurus", 1, -3, StringComparer.OrdinalIgnoreCase));
		}

		[Test]
		public void LastIndexOfCustomComparerTargetIntIntCountOverflow()
		{
			Assert.Throws<ArgumentOutOfRangeException>(() => DinosaurList.LastIndexOf("Tyrannosaurus", 1, 18, StringComparer.OrdinalIgnoreCase));
		}

		[Test]
		public void LastIndexOfCustomComparerTargetIntIntTargetNotFound()
		{
			Assert.That(DinosaurList.LastIndexOf("TyRanNosAuruS", 2, 2, StringComparer.OrdinalIgnoreCase) == -1);
		}

		#endregion
	}
}
