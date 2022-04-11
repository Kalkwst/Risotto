using NUnit.Framework;
using Risotto.Collection;
using Risotto.Functors;
using Risotto.Functors.Predicates;
using System;
using System.Collections.Generic;

namespace Risotto.Test.Collection.Builders
{
	[TestFixture]
	public class PredicatedCollectionBuilderTest
	{
		[Test]
		public void PredicatedCollectionBuilderConstructorNoNullPredicate()
		{
			Assert.Throws<ArgumentNullException>(() =>
			{
				AllPredicate<int> predicate = null;
				new PredicatedCollectionBuilder<int>(predicate);
			});
		}

		[Test]
		public void PredicatedCollectionBuilderAddValidElements()
		{
			NotNullPredicate<string> predicate = new();
			PredicatedCollectionBuilder<string> builder = new(predicate);

			string str1 = "hello";
			string str2 = "builder";
			string str3 = "xyz";

			builder.Add(str1)
				   .Add(str2)
				   .Add(str3);
			

			List<string> list = builder.GetAcceptedElements();

			Assert.IsTrue(list.Contains(str1));
			Assert.IsTrue(list.Contains(str2));
			Assert.IsTrue(list.Contains(str3));

			Assert.IsTrue(builder.GetRejectedElements().Count == 0);
		}

		[Test]
		public void PredicatedCollectionBuilderAddInvalidElements()
		{
			NotNullPredicate<string> predicate = new();
			PredicatedCollectionBuilder<string> builder = new(predicate);

			string str1 = null;
			string str2 = null;
			string str3 = null;

			builder.Add(str1)
				   .Add(str2)
				   .Add(str3);


			List<string> list = builder.GetRejectedElements();

			Assert.IsTrue(list.Contains(str1));
			Assert.IsTrue(list.Contains(str2));
			Assert.IsTrue(list.Contains(str3));

			Assert.IsTrue(builder.GetAcceptedElements().Count == 0);
		}
	}
}
