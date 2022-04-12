using NUnit.Framework;
using Risotto.Functors;
using Risotto.List;
using System;
using System.Collections.Generic;

namespace Risotto.Test.List
{
	[TestFixture]
	public class PredicatedListTest
	{
		[Test]
		public void PredicatedListEmptyList()
		{
			List<string> list = new();
			TruePredicate<string> predicate = new();

			PredicatedList<string> predicatedList = PredicatedList<string>.GetPredicatedList(list, predicate);

			predicatedList.Add("a");
			predicatedList.Add("b");
			predicatedList.Add("c");

			Assert.IsTrue(predicatedList.Count == 3);
			Assert.IsTrue(predicatedList.Contains("a"));
			Assert.IsTrue(predicatedList.Contains("b"));
			Assert.IsTrue(predicatedList.Contains("c"));
		}

		[Test]
		public void PredicatedListFullyValidatedList()
		{
			List<string> list = new();
			list.Add("a");
			list.Add("b");
			list.Add("c");

			NotNullPredicate<string> predicate = new();
			PredicatedList<string> predicatedList = PredicatedList<string>.GetPredicatedList(list, predicate);

			Assert.IsTrue(predicatedList.Count == 3);
			Assert.IsTrue(predicatedList.Contains("a"));
			Assert.IsTrue(predicatedList.Contains("b"));
			Assert.IsTrue(predicatedList.Contains("c"));
		}

		[Test]
		public void PredicatedListNonValidatedList()
		{

			List<string> list = new();
			list.Add("a");
			list.Add("b");
			list.Add(null);

			NotNullPredicate<string> predicate = new();

			var ex = Assert.Throws<ArgumentException>(() =>
			{
				PredicatedList<string> predicatedList = PredicatedList<string>.GetPredicatedList(list, predicate);
			});
		}

		[Test]
		public void PredicatedListGetAccessor()
		{
			List<string> list = new();
			list.Add("a");
			list.Add("b");
			list.Add("c");

			NotNullPredicate<string> predicate = new();
			PredicatedList<string> predicatedList = PredicatedList<string>.GetPredicatedList(list, predicate);

			Assert.IsTrue(predicatedList[2].Equals("c"));
		}

		[Test]
		public void PredicatedListSetAccessor()
		{
			List<string> list = new();
			list.Add("a");
			list.Add("b");
			list.Add("c");

			NotNullPredicate<string> predicate = new();
			PredicatedList<string> predicatedList = PredicatedList<string>.GetPredicatedList(list, predicate);

			Assert.IsTrue(predicatedList[2].Equals("c"));

			predicatedList[2] = "f";

			Assert.IsTrue(predicatedList[2].Equals("f"));
		}

		[Test]
		public void PredicatedListIndexOf()
		{
			List<string> list = new();
			list.Add("a");
			list.Add("b");
			list.Add("c");

			NotNullPredicate<string> predicate = new();
			PredicatedList<string> predicatedList = PredicatedList<string>.GetPredicatedList(list, predicate);

			Assert.IsTrue(predicatedList.IndexOf("a") == 0);
			Assert.IsTrue(predicatedList.IndexOf("f") == -1);
		}

		[Test]
		public void PredicatedListInsertValidItem()
		{
			List<string> list = new();
			list.Add("a");
			list.Add("b");
			list.Add("c");

			NotNullPredicate<string> predicate = new();
			PredicatedList<string> predicatedList = PredicatedList<string>.GetPredicatedList(list, predicate);

			predicatedList.Insert(1, "g");

			Assert.IsTrue(predicatedList.Contains("g"));
			Assert.IsTrue(predicatedList.IndexOf("g") == 1);
		}

		[Test]
		public void PredicatedListInsertInvalidItem()
		{
			List<string> list = new();
			list.Add("a");
			list.Add("b");
			list.Add("c");

			NotNullPredicate<string> predicate = new();
			PredicatedList<string> predicatedList = PredicatedList<string>.GetPredicatedList(list, predicate);

			Assert.Throws<ArgumentException>(() =>
						{
							predicatedList.Insert(1, null);
						});
		}

		[Test]
		public void PredicatedListRemoveAt()
		{
			List<string> list = new();
			list.Add("a");
			list.Add("b");
			list.Add("c");

			NotNullPredicate<string> predicate = new();
			PredicatedList<string> predicatedList = PredicatedList<string>.GetPredicatedList(list, predicate);

			predicatedList.RemoveAt(2);

			Assert.IsTrue(predicatedList.Count == 2);
			Assert.IsTrue(predicatedList.Contains("a"));
			Assert.IsTrue(predicatedList.Contains("b"));
			Assert.IsFalse(predicatedList.Contains("c"));
		}


	}
}
