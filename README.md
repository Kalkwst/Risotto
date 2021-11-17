# Risotto

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

#### CountOccurrences

Counts the occurrences of a value in a sequence.

This method has 2 overloads.

#### CountBy

Applies a key-generating function to each element of a sequence and returns a sequence of unique keys and their number of occurrences in the original sequence.

This method has 2 overloads.

#### Purge

Completely consumes the given sequence. This method uses immediate execution and doesn't store any data.

#### Transform

Transfoorms all of the elements in the sequence and returns the transformed results.

</details>
