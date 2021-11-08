## Table Of Contents

- [Styleguides](#styleguides)
  - [Git Commit Messages](#git-commit-messages)
    - [Git Commit Template](#git-commit-template)
  - [C# Styleguides](#c-styleguides)
      - [Namespaces](#namespaces)
      - [Classes & Interfaces](#classes--interfaces)
      - [Methods](#methods)
      - [Fields](#fields)
      - [Properties](#properties)
      - [Parameters](#parameters)
      - [Actions](#actions)
      - [Misc](#misc)
    - [Declarations](#declarations)
      - [Access Level Modifiers](#access-level-modifiers)
      - [Fields & Variables](#fields--variables)
      - [Classes](#classes)
      - [Interfaces](#interfaces)
    - [Spacing](#spacing)
      - [Indentation](#indentation)
      - [Blocks](#blocks)
      - [Line Length](#line-length)
      - [Vertical Spacing](#vertical-spacing)
    - [Switch Statements](#switch-statements)
- [Documentation and Comments](#documentation-and-comments)
- [Additional Notes](#additional-notes)
  - [Issue and Pull Request Labels](#issue-and-pull-request-labels)
    - [Type of Issue and Issue State](#type-of-issue-and-issue-state)
    - [Topic Labels](#topic-labels)
    - [Pull Request Labels](#pull-request-labels)

## Styleguides

### Git Commit Messages

* Use the present tense ("Add feature" not "Added feature")
* Use the imperative mood ("Move cursor to..." not "Moves cursor to...")
* Limit the first line to 50 characters or less
* For each subsequent line limit to 72 characters or lesd
* Reference issues and pull requests liberally after the commit body
* When only changing documentation, include `[ci skip]` in the commit title
* Consider starting the commit message with an applicable emoji:
    * :art: `:art:` when improving the format/structure of the code
    * :zap: `:zap:` when improving performance
    * :fire: `:fire:` when removing code or files
    * :bug: `:bug:` when fixing a bug
    * :sparkles: `:sparkles:` when introducing a new feature
    * :ambulance: `:ambulance:` when introducing a critical hotfix
    * :memo: `:memo:` when adding or updating documentation
    * :white_check_mark: `:white_check_mark:` when adding or updating tests
    * :rotating_light: `:rotating_light:` when fixing compiler warnings
    * :recycle: `:recycle:` when refactoring code
    * :coffin: `:coffin:` when removing dead code
    * :arrow_up: `:arrow_up:` when upgrading dependencies
    * :arrow_down: `:arrow_down:` when downgrading dependencies
    * :construction_worker: `:construction_worker:` when adding or updating CI scripts
    * :heavy_plus_sign: `:heavy_plus_sign:` when adding a dependency
    * :heavy_minus_sign: `:heavy_minus_sign:` when removing a dependency
* Consider using the provided git commit template

#### Git Commit Template

<details>
    <summary> View Git Commit Template </summary>
   
```sh
# [<cli-skip>][<gitmoji>][<tag>] (If applied, this commit will...) <subject> (Max 72 char)
# |<----   Preferably using up to 50 chars   --->|<------------------->|
# Example:
# [feat] Implement automated commit messages

# (Optional) Explain why this change is being made
# |<----   Try To Limit Each Line to a Maximum Of 72 Characters   ---->|

# (Optional) Provide links or keys to any relevant tickets, articles or other resources
# Example: Github issue #23

# At the end: Include Co-authored-by for all contributors. 
# Co-authored-by: name <user@users.noreply.github.com>

# --- COMMIT END ---
# gitmoji can be
#    :art:                  (formatting, changing the structure of the code)
#    :zap:                  (improving performance)
#    :fire:                 (removing code or files)
#    :bug:                  (fixing a bug)
#    :sparkles:             (adding a new feature)
#    :ambulance:            (introducing a critical hotfix)
#    :memo:                 (adding or updating documentation)
#    :white_check_mark:     (adding or updating tests)
#    :recycle:              (refactroign code)
#
# For a comprehensive list of all available project gitmojis, refer to the CONTRIBUTING.md file
#
# Tag can be 
#    feat        (new feature)
#    fix         (bug fix)
#    refactor    (refactoring code)
#    style       (formatting, missing semi colons, etc; no code change)
#    doc         (changes to documentation)
#    test        (adding or refactoring tests; no production code change)
#    dependency  (version bump/new release; no production code change)
#    dbg         (Changes in debugging code/frameworks; no production code change)
#    hack        (Temporary fix to make things move forward; please avoid it)
#    WIP         (Work In Progress; for intermediate commits to keep patches reasonably sized)
#
# Note: Multiple tags can be combined, e.g. [fix][WIP] Fix issue X with methodhandles
# --------------------
# Remember to:
#   * Capitalize the subject line
#   * Use the imperative mood in the subject line
#   * Do not end the subject line with a period
#   * Separate subject from body with a blank line
#   * Use the body to explain what and why vs. how
#   * Can use multiple lines with "-" or "*" for bullet points in body
# --------------------
```
   
</details>
   
To tell Git to use the template file, use the following command:
```
git config commit.template ~/.gitmessage
```

### C# Styleguides

##### Namespaces

Namespaces are all **PascalCase**, multiple words concatenated together, without hyphens(`-`) or underscores(`_`). The exception to this rule are acronyms like *GUI* or *HUD*, which can be uppercase:

**Avoid**

```
com.some.long.name.space.thingy
```

**Prefer**

```
Some.Long.Namespace.Including.GUI.UUIDGenerator
```

##### Classes & Interfaces

Classes and interfaces are written in **PascalCase**. For example `EnumerableUtils`.

##### Methods

Methods are written in **PascalCase**. For example `DoSomething()`.

##### Fields

All non-static fields are written in **camelCase**.

For example:

```csharp
public class MyClass
{
    private int privateField;
    protected int protectedField;
}
```

**Avoid**

```csharp
private int _privateVariable;
```

**Prefer**

```csharp
private int privateVariable;
```

Static, public and package private fields are the exception and should be written in **PascalCase**:

```csharp
public static int TheAnswer = 42;
```

##### Properties

All properties are written in **PascalCase**. For example:

```csharp
public int PageNumber
{
    get {return pageNumber;}
    set {pageNumber = value;}
}
```

##### Parameters

Parameters are written in **camelCase**.

**Avoid**

```csharp
void DoSomething(IEnumerable Source)
```

**Prefer**

```csharp
void DoSomething(IEnumerable source)
```

##### Actions

Actions are written in **PascalCase**. For example:

```csharp
public Action<int> ValueChanged;
```

##### Misc

In code, acronyms should be treated as words. For example:

**Avoid**

```
XMLHTTPRequest
string URL
findPostByID
```

**Prefer**

```
XmlHttpRequest
url
findPostById
```

#### Declarations

##### Access Level Modifiers

Access level modifiers should be explicitly defined for classes, methods and member variables.

##### Fields & Variables

Prefer single declaration per line

**Avoid**

```csharp
string username, githubHandle;
```

**Prefer**

```csharp
string username;
string githubHandle;
```

##### Classes

Exactly one class per source file, although inner classes are encouraged where scoping appropriate.

##### Interfaces

All interfaces should be prefaced with the letter **I**.

#### Spacing

##### Indentation

Indentation should be done using **spaces** - never **tabs**.

##### Blocks

Indentation for blocks uses **4 spaces** for optimal readability:

**Avoid**

```csharp
for (int i = 0; i < 10; i++)
{
  Debug.Log($"Index: {i}");
}
```

**Prefer**

```csharp
for (int i = 0; i < 10; i++)
{
    Debug.Log($"Index: {i}");
}
```

##### Line Length

Lines should be no longer than **100** characters long.

##### Vertical Spacing

There should be exactly one blank line between methods to aid in visual clarity and organization. Whitespace within methods should separate functionality, but having too many sections in a method often means you should refactor into several methods.

#### Switch Statements

Switch statements come with `default` case by default. If the `default` case is never reached, be sure to remove it.

**Avoid**  
  
```csharp
switch (variable) 
{
    case 1:
        break;
    case 2:
        break;
    default:
        break;
}
```

**Prefer**  
  
```csharp
switch (variable) 
{
    case 1:
        break;
    case 2:
        break;
}
```

## Documentation and Comments

All types, and all members with public/protected scope require documentation. Take the time to write good documentation. Private/internal types, properties, and methods do not require documentation, but you should add documentation where it can ease future understanding and maintenance of the code.

Format documentation as XML doc comments. Refer to the table below:

| **Tag**                                                        | **Explanation**                                                                                                                                                                |
| -------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
| `<summary></summary>`                                          | Explain what the class/method does and how/why/when to use it. Keep the summary to a couple sentences. Use <remarks> for more information                                      |
| `<param name="parameterName"></param>`                         | Document each parameter and its purpose in the method.                                                                                                                         |
| `<paramref="parameterName"/>`                                  | Refer to parameters of your method in documentation.                                                                                                                           |
| `<typeparam name="TypeParameterName"></typeparam>`             | Document each type parameter of a generic class or method.                                                                                                                     |
| `<typeparamref="TypeParameterName"/>`                          | Refer to type parameters in documentation for a generic method or class.                                                                                                       |
| `<returns></returns>`                                          | Explain what the method returns: the return value and any expected state changes after the method is done executing.                                                           |
| `<remarks></remarks>`                                          | Add other commentary to your method, in addition to what the method does or when to call it.                                                                                   |
| `<exception cref="ExceptionName"></exception>`                 | Document known exceptions the method can throw. Typically used for exceptions that can be caught and ignored/logged, when they will not put your application into a bad state. |
| `<see cref="ClassName.MethodName"/>`                           | Provide navigation to classes, methods and other items defined in C#.                                                                                                          |
| `<inheritdoc/>` or `<inheritdoc cref="ClassName.MethodName"/>` | Inherit documentation from a base interface/class.                                                                                                                             |

## Additional Notes

### Issue and Pull Request Labels

This section lists the labels we use to help us track and manage issues and pull requests.

The labels are loosely grouped by their purpose, but it's not required that every issue has a label from every group or that an issue can't have more than one label from the same group.

#### Type of Issue and Issue State

| Label name                | :mag_right:                                         | Description                                                                                                          |
| ------------------------- | --------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------- |
| `enhancement`             | [search][search-repo-label-enhancement]             | Feature requests                                                                                                     |
| `bug`                     | [search][search-repo-label-bug]                     | Confirmed bugs or reports that are very likely to be bugs                                                            |
| `question`                | [search][search-repo-label-question]                | Questions (e.g., how do I do X)                                                                                      |
| `feedback`                | [search][search-repo-label-feedback]                | General feedback                                                                                                     |
| `help-wanted`             | [search][search-repo-label-help-wanted]             | We would appreciate help in resolving these issues                                                                   |
| `beginner`                | [search][search-repo-label-beginner]                | Less complex issues which would be good first issues to work on for users who want to contribute                     |
| `more-information-needed` | [search][search-repo-label-more-information-needed] | More information needs to be collected about these problems or feature requests (e.g. steps to reproduce)            |
| `needs-reproduction`      | [search][search-repo-label-needs-reproduction]      | Likely bugs, but haven't been reliably reproduced                                                                    |
| `blocked`                 | [search][search-repo-label-blocked]                 | Issues blocked on other issues                                                                                       |
| `duplicate`               | [search][search-repo-label-duplicate]               | Issues which are duplicates of other issues, i.e. they have been reported before                                     |
| `wontfix`                 | [search][search-repo-label-wontfix]                 | We have decided not to fix these issues for now, either because they're working as intended or for some other reason |
| `invalid`                 | [search][search-repo-label-invalid]                 | Issues which aren't valid (e.g. user errors)                                                                         |

#### Topic Labels

| Label name      | :mag_right:                               | Description                          |
| --------------- | ----------------------------------------- | ------------------------------------ |
| `documentation` | [search][search-repo-label-documentation] | Related to any type of documentation |
| `performance`   | [search][search-repo-label-performance]   | Related to performance               |

#### Pull Request Labels

| Label name         | :mag_right:                                  | Description                                                                             |
| ------------------ | -------------------------------------------- | --------------------------------------------------------------------------------------- |
| `work-in-progress` | [search][search-repo-label-work-in-progress] | Pull requests which are still being worked on, more changes will follow                 |
| `needs-review`     | [search][search-repo-label-needs-review]     | Pull requests which need code review, and approval from maintainers                     |
| `under-review`     | [search][search-repo-label-under-review]     | Pull requests being reviewed by maintainers                                             |
| `requires-changes` | [search][search-repo-label-requires-changes] | Pull requests which need to be updated based on review comments and then reviewed again |
| `needs-testing`    | [search][search-repo-label-needs-testing]    | Pull requests which need manual testing                                                 |

[search-repo-label-enhancement]: https://github.com/Kalkwst/SmashBurger/labels/enhancement
[search-repo-label-bug]: https://github.com/Kalkwst/SmashBurger/labels/bug
[search-repo-label-question]: https://github.com/Kalkwst/SmashBurger/labels/question
[search-repo-label-feedback]: https://github.com/Kalkwst/SmashBurger/labels/feedback
[search-repo-label-help-wanted]: https://github.com/Kalkwst/SmashBurger/labels/help-wanted
[search-repo-label-beginner]: https://github.com/Kalkwst/SmashBurger/labels/beginner
[search-repo-label-more-information-needed]: https://github.com/Kalkwst/SmashBurger/labels/more-information-needed
[search-repo-label-needs-reproduction]: https://github.com/Kalkwst/SmashBurger/labels/needs-reproduction
[search-repo-label-blocked]: https://github.com/Kalkwst/SmashBurger/labels/blocked
[search-repo-label-duplicate]: https://github.com/Kalkwst/SmashBurger/labels/duplicate
[search-repo-label-wontfix]: https://github.com/Kalkwst/SmashBurger/labels/wontfix
[search-repo-label-invalid]: https://github.com/Kalkwst/SmashBurger/labels/invalid
[search-repo-label-documentation]: https://github.com/Kalkwst/SmashBurger/labels/documentation
[search-repo-label-performance]: https://github.com/Kalkwst/SmashBurger/labels/performance
[search-repo-label-work-in-progress]: https://github.com/Kalkwst/SmashBurger/labels/work-in-progress
[search-repo-label-needs-review]: https://github.com/Kalkwst/SmashBurger/labels/needs-review
[search-repo-label-under-review]: https://github.com/Kalkwst/SmashBurger/labels/under-review
[search-repo-label-requires-changes]: https://github.com/Kalkwst/SmashBurger/labels/requires-changes
[search-repo-label-needs-testing]: https://github.com/Kalkwst/SmashBurger/labels/needs-testing
