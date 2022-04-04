using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;


public class ComparisonCustomClass : IEquatable<ComparisonCustomClass>
{
	public Guid MyId { get; set; }
	public string MyProperty { get; set; }

	public ComparisonCustomClass(Guid myId, string myProperty)
	{
		MyId = myId;
		MyProperty = myProperty;
	}

	public bool Equals(ComparisonCustomClass other)
	{
		if (other == null)
			return false;

		if (this.MyId.Equals(other.MyId) && this.MyProperty.Equals(other.MyProperty))
			return true;
		else
			return false;
	}

	public override bool Equals(Object obj)
	{
		if (obj == null)
			return false;

		ComparisonCustomClass customClass = obj as ComparisonCustomClass;
		if (customClass == null)
			return false;
		else
			return Equals(customClass);
	}

	public override int GetHashCode()
	{
		return this.MyId.GetHashCode();
	}
}

public class GuidEqualityComparer : IEqualityComparer<ComparisonCustomClass>
{
	public bool Equals(ComparisonCustomClass x, ComparisonCustomClass y)
	{
		if (x == null && y == null)
			return true;
		else if (x == null || y == null)
			return false;

		return (x.MyId == y.MyId);
	}

	public int GetHashCode([DisallowNull] ComparisonCustomClass obj)
	{
		return obj.GetHashCode();
	}
}