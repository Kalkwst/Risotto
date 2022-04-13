using NUnit.Framework;
using Risotto.Collection;
using Risotto.Functors;
using System;
using System.Collections.Generic;

namespace Risotto.Test.Collection
{
	[TestFixture]
	public class PredicatedCollectionTest
	{
		[Test]
		public void PredicatedCollectionFactoryMethodValidElements()
		{
			List<string> list = new();
			NotNullPredicate<string> predicate = new NotNullPredicate<string>();

			list.Add("a");
			list.Add("b");
			list.Add("c");

			var predicatedCollection = PredicatedCollection<string>.GetCollection(list, predicate);

			Assert.That(predicatedCollection, Is.Not.Null);
			Assert.IsTrue(predicatedCollection.Count == 3);
		}

		[Test]
		public void PredicatedCollectionFactoryMethodInvalidElements()
		{
			List<string> list = new();
			NotNullPredicate<string> predicate = new();

			list.Add("a");
			list.Add("b");
			list.Add(null);

			Assert.Throws<ArgumentException>(() =>
			{
				var predicatedCollection = PredicatedCollection<string>.GetCollection(list, predicate);
			});
		}

		[Test]
		public void PredicatedCollectionAddValidElement()
		{
			List<string> list = new();
			NotNullPredicate<string> predicate = new NotNullPredicate<string>();

			list.Add("a");
			list.Add("b");
			list.Add("c");

			var predicatedCollection = PredicatedCollection<string>.GetCollection(list, predicate);

			predicatedCollection.Add("d");

			Assert.IsTrue(predicatedCollection.Contains("d"));
		}

		[Test]
		public void PredicatedCollectionAddInvalidElement()
		{
			List<string> list = new();
			NotNullPredicate<string> predicate = new NotNullPredicate<string>();

			list.Add("a");
			list.Add("b");
			list.Add("c");

			var predicatedCollection = PredicatedCollection<string>.GetCollection(list, predicate);

			try
			{
				predicatedCollection.Add(null);
			}
			catch (ArgumentException) { }
		

			Assert.IsTrue(predicatedCollection.Count == 3);
			Assert.IsTrue(!predicatedCollection.Contains(null));
		}

		[Test]
		public void PredicatedCollectionAddRangeOfValidElements()
		{
			List<string> list = new();
			NotNullPredicate<string> predicate = new NotNullPredicate<string>();

			list.Add("a");
			list.Add("b");
			list.Add("c");

			var predicatedCollection = PredicatedCollection<string>.GetCollection(list, predicate);

			List<string> newElements = new();
			newElements.Add("d");
			newElements.Add("e");
			newElements.Add("f");
			newElements.Add("g");

			predicatedCollection.AddRange(newElements);

			Assert.IsTrue(predicatedCollection.Count == 7);
			Assert.IsTrue(predicatedCollection.Contains("d"));
			Assert.IsTrue(predicatedCollection.Contains("e"));
			Assert.IsTrue(predicatedCollection.Contains("f"));
			Assert.IsTrue(predicatedCollection.Contains("g"));
		}

		[Test]
		public void PredicatedCollectionAddRangeOfInvalidElements()
		{
			List<string> list = new();
			NotNullPredicate<string> predicate = new NotNullPredicate<string>();

			list.Add("a");
			list.Add("b");
			list.Add("c");

			var predicatedCollection = PredicatedCollection<string>.GetCollection(list, predicate);

			List<string> newElements = new();
			newElements.Add(null);
			newElements.Add(null);
			newElements.Add(null);
			newElements.Add(null);

			Assert.Throws<ArgumentException>(() => {
				predicatedCollection.AddRange(newElements);
			});
		}

		[Test]
		public void PredicatedCollectionTryAddValidElement()
		{
			List<string> list = new();
			NotNullPredicate<string> predicate = new NotNullPredicate<string>();

			list.Add("a");
			list.Add("b");
			list.Add("c");

			var predicatedCollection = PredicatedCollection<string>.GetCollection(list, predicate);

			var added = predicatedCollection.TryAdd("d");

			Assert.IsTrue(added);
			Assert.IsTrue(predicatedCollection.Count == 4);
			Assert.IsTrue(predicatedCollection.Contains("d"));
		}

		[Test]
		public void PredicatedCollectionTryAddInvalidElement()
		{
			List<string> list = new();
			NotNullPredicate<string> predicate = new NotNullPredicate<string>();

			list.Add("a");
			list.Add("b");
			list.Add("c");

			var predicatedCollection = PredicatedCollection<string>.GetCollection(list, predicate);

			var added = predicatedCollection.TryAdd(null);

			Assert.IsFalse(added);
			Assert.IsTrue(predicatedCollection.Count == 3);
			Assert.IsTrue(!predicatedCollection.Contains("d"));
		}
	}
}
