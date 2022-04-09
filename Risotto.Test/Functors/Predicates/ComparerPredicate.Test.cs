using NUnit.Framework;
using Risotto.Functors.Predicates;
using System;
using System.Collections.Generic;

namespace Risotto.Test.Functors.Predicates
{
	[TestFixture]
	public class ComparerPredicateTest
	{
		[Test]
		public void ComparerPredicateNullComparer()
		{
			var ex = Assert.Throws<ArgumentNullException>(() =>
			{
				ComparerPredicate<int> predicate = new(1, null, ComparerPredicate<int>.Criterion.EQUAL);
			});
		}

		[Test]
		public void ComparerPredicateAssertEqualsTrue()
		{
			var cuboid1 = new Cuboid(1, 2, 3);
			var cuboid2 = new Cuboid(1, 2, 3);

			ComparerPredicate<Cuboid> predicate = new(cuboid1, new CuboidAreaComparer(), ComparerPredicate<Cuboid>.Criterion.EQUAL);

			Assert.IsTrue(predicate.Evaluate(cuboid2));
		}

		[Test]
		public void ComparerPredicateAssertEqualsFalse()
		{
			var cuboid1 = new Cuboid(1, 2, 3);
			var cuboid2 = new Cuboid(2, 2, 3);

			ComparerPredicate<Cuboid> predicate = new(cuboid1, new CuboidAreaComparer(), ComparerPredicate<Cuboid>.Criterion.EQUAL);

			Assert.IsFalse(predicate.Evaluate(cuboid2));
		}

		[Test]
		public void ComparerPredicateAssertLessThanTrue()
		{
			var cuboid1 = new Cuboid(1, 2, 3);
			var cuboid2 = new Cuboid(2, 2, 3);

			ComparerPredicate<Cuboid> predicate = new(cuboid1, new CuboidAreaComparer(), ComparerPredicate<Cuboid>.Criterion.LESS);

			Assert.IsTrue(predicate.Evaluate(cuboid2));
		}

		[Test]
		public void ComparerPredicateAssertLessThanFalse()
		{
			var cuboid1 = new Cuboid(1, 2, 3);
			var cuboid2 = new Cuboid(2, 2, 3);

			ComparerPredicate<Cuboid> predicate = new(cuboid2, new CuboidAreaComparer(), ComparerPredicate<Cuboid>.Criterion.LESS);

			Assert.IsFalse(predicate.Evaluate(cuboid1));
		}

		[Test]
		public void ComparerPredicateAssertLessThanOrEqualTrue()
		{
			var cuboid1 = new Cuboid(1, 2, 3);
			var cuboid2 = new Cuboid(1, 2, 3);

			ComparerPredicate<Cuboid> predicate = new(cuboid1, new CuboidAreaComparer(), ComparerPredicate<Cuboid>.Criterion.LESS_OR_EQUAL);

			Assert.IsTrue(predicate.Evaluate(cuboid2));
		}

		[Test]
		public void ComparerPredicateAssertLessThanOrEqualFalse()
		{
			var cuboid1 = new Cuboid(1, 2, 3);
			var cuboid2 = new Cuboid(2, 2, 3);

			ComparerPredicate<Cuboid> predicate = new(cuboid2, new CuboidAreaComparer(), ComparerPredicate<Cuboid>.Criterion.LESS_OR_EQUAL);
			Assert.IsFalse(predicate.Evaluate(cuboid1));
		}

		[Test]
		public void ComparerPredicateAssertGreaterThanTrue()
		{
			var cuboid1 = new Cuboid(1, 2, 3);
			var cuboid2 = new Cuboid(2, 2, 3);

			ComparerPredicate<Cuboid> predicate = new(cuboid2, new CuboidAreaComparer(), ComparerPredicate<Cuboid>.Criterion.GREATER);

			Assert.IsTrue(predicate.Evaluate(cuboid1));
		}

		[Test]
		public void ComparerPredicateAssertGreaterThanFalse()
		{
			var cuboid1 = new Cuboid(1, 2, 3);
			var cuboid2 = new Cuboid(2, 2, 3);

			ComparerPredicate<Cuboid> predicate = new(cuboid1, new CuboidAreaComparer(), ComparerPredicate<Cuboid>.Criterion.GREATER);

			Assert.IsFalse(predicate.Evaluate(cuboid2));
		}

		[Test]
		public void ComparerPredicateAssertGreaterThanOrEqualTrue()
		{
			var cuboid1 = new Cuboid(1, 2, 3);
			var cuboid2 = new Cuboid(1, 2, 3);

			ComparerPredicate<Cuboid> predicate = new(cuboid1, new CuboidAreaComparer(), ComparerPredicate<Cuboid>.Criterion.GREATER_OR_EQUAL);

			Assert.IsTrue(predicate.Evaluate(cuboid2));
		}

		[Test]
		public void ComparerPredicateAssertGreaterThanOrEqualFalse()
		{
			var cuboid1 = new Cuboid(1, 2, 3);
			var cuboid2 = new Cuboid(2, 2, 3);

			ComparerPredicate<Cuboid> predicate = new(cuboid1, new CuboidAreaComparer(), ComparerPredicate<Cuboid>.Criterion.GREATER_OR_EQUAL);
			Assert.IsFalse(predicate.Evaluate(cuboid2));
		}
	}

	public class Cuboid : IComparable<Cuboid>
	{
		public int XSide { get; private set; }
		public int YSide { get; private set; }
		public int ZSide { get; private set; }

		public Cuboid(int xSide, int ySide, int zSide)
		{
			XSide = xSide;
			YSide = ySide;
			ZSide = zSide;
		}

		public int CompareTo(Cuboid other)
		{
			if (XSide.CompareTo(other.XSide) != 0)
				return XSide.CompareTo(other.XSide);
			if (YSide.CompareTo(other.YSide) != 0)
				return YSide.CompareTo(other.YSide);
			if (ZSide.CompareTo(other.ZSide) != 0)
				return ZSide.CompareTo(other.ZSide);
			return 0;
		}

		public int GetSurfaceArea()
		{
			return 2 * ((XSide * YSide) + (YSide * ZSide) + (XSide * ZSide));
		}
	}

	public class CuboidAreaComparer : Comparer<Cuboid>
	{
		public override int Compare(Cuboid x, Cuboid y)
		{
			return x.GetSurfaceArea().CompareTo(y.GetSurfaceArea());
		}
	}
}
