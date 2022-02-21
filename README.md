# Risotto
![build](https://img.shields.io/github/workflow/status/Kalkwst/Risotto/CI/develop)
![license](https://img.shields.io/github/license/Kalkwst/Risotto)

## 📖 Table of Contents

## Features at a Glance

### LINQ Operators

<details>
    <summary> View Operators </summary>

#### AllEqual

Checks if all elements in a sequence are equal. 
This operator can be provided with a custom predicate to perform on all elements of the sequence before the equality check.

This method has 4 overloads.

#### AllUnique

Checks if all elements in the sequence are unique. This operator can be provided with a custom predicate to apply on all elements of the sequence, before the uniqueness check.

This method has 2 overloads.

#### AtLeast

Determines whether or not the number of elements in the sequence is greater than or equal to the given integer.

#### AtMost

Determines whether or not the number of elements in the sequence is less than or equal to the given integer.
    
#### Attempt

Asserts that all elements of a sequence meet a given condition otherwise throws an exception.

This method has 2 overloads.

#### Bifurcate

Splits values into two groups, based on the result of the given filtering function.

#### Chunk

Batches the source sequence into sized chunks.

This method has 2 overloads.

#### Compact

 Remove all elements that are considered "falsy" by the provided predicate.

 This method has 2 overloads.

 #### ContainsAll

Determines whether the first sequence contains all of the elements of the second sequence.

This method has 2 overloads.

#### ContainsAny

Determines whether the first sequence contains any of the elements of the second sequence.

This method has 2 overloads.

#### CountBetween

Determines whether or not the number of elements in the sequence is between an inclusive range of minimum
and maximum integers.

#### CountBy

Applies a key-generating function to each element of a sequence and returns a sequence of unique keys and their number of occurrences in the original sequence.

This method has 2 overloads.
    
#### CountOccurrences

Counts the occurrences of a value in a sequence.

This method has 2 overloads.

#### Difference

Returns all the elements that exists in the first sequence, that do not exists in the second sequence, without filtering out duplicates.

This method has 2 overloads.

#### DifferenceBy

Returns the difference between to sequences, after applying the provided function to each array element of both.

This method has 2 overloads.

#### DistinctBy

Returns all distinct elements of the given source, where "distinctness" is determined via a projection and the default equality comparer for the projected type.

This method has 2 overloads.

#### EveryNth

Returns every `nth` element in the sequence.

#### Exactly

Determines whether or not the number of elements in the sequence is equals to the given integer.

#### ForEach

Executes the given action on each element in the source sequence.

This method has 4 overloads.

#### Purge

Completely consumes the given sequence. This method uses immediate execution and doesn't store any data.

#### SkipUntil

Skips items from the input sequence until the given predicate returns true, when applied to the current sequence item. That item will not be skipped.

#### Transform

Transfoorms all of the elements in the sequence and returns the transformed results.

</details>

## Documentation

The Risotto documentation is [available here](https://github.com/Kalkwst/Risotto/wiki)
