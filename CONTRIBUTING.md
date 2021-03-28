#### Table Of Contents

[What should I know before I get started?](#what-should-i-know-before-i-get-started)
  * [Code of Conduct](#code-of-conduct)
  
 [How Can I Contribute?](#how-can-i-contribute)
  * [Reporting Bugs](#reporting-bugs)
  * [Suggesting Enhancements](#suggesting-enhancements)
  * [Your First Code Contribution](#your-first-code-contribution)
  * [Pull Requests](#pull-requests)
  
## What should I know before I get started?

### Code of Conduct

This project adheres to the NCoC [code of conduct](CODE_OF_CONDUCT.md).
By participating, you are expected to uphold this code.

## How Can I Contribute?

### Reporting Bugs

This section guides you through submitting a bug report for Uwizard. Following these guidelines helps maintainers and the community understand your report, reproduce the behavior, and find related reports.

Before creating bug reports, please check [this list](#before-submitting-a-bug-report) as you might find out that you don't need to create one. When you are creating a bug report, please [include as many details as possible](#how-do-i-submit-a-good-bug-report). If you'd like, you can use [this template](#template-for-submitting-bug-reports) to structure the information.

#### Before Submitting A Bug Report

* **Confirm** that you are on the lastest [release](https://github.com/EvilGamerX/Uwizard/releases) of Uwizard. If you are beta testing, make sure you check you the Dev build.
* **Perform a [cursory search](https://github.com/EvilGamerX/Uwizard/issues?utf8=%E2%9C%93&q=is%3Aissue+is%3Aopen+)** to see if the problem has already been reported. If it has, add a comment to the existing issue instead of opening a new one.

#### How Do I Submit A (Good) Bug Report?

Bugs are tracked as [GitHub issues](https://guides.github.com/features/issues/). Create an issue on the repository and provide the following information.

Explain the problem and include additional details to help maintainers reproduce the problem:

* **Use a clear and descriptive title** for the issue to identify the problem.
* **Describe the exact steps which reproduce the problem** in as many details as possible. When listing steps, **don't just say what you did, but explain how you did it**. For example, if you opened a WiiU Game, which game, and how.
* **Describe the behavior you observed after following the steps** and point out what exactly is the problem with that behavior.
* **Explain which behavior you expected to see instead**
* **Include screenshots or animated GIFs** which show you following the described steps and clearly demonstrate the problem.
* **If the problem wasn't triggered by a specific action**, describe what you were doing before the problem happened and share more information using the guidelines below.

Provide more context by answering these questions:

* **Did the problem start happening recently** (e.g. after updating to a new version of Uwizard) or was this always a problem?
* If the problem started happening recently, **can you reproduce the problem in an older version of Uwizard?** What's the most recent version in which the problem doesn't happen? You can download older versions of Uwizard from [the releases page](https://github.com/EvilGamerX/Uwizard/releases).
* **Can you reliably reproduce the issue?** If not, provide details about how often the problem happens and under which conditions it normally happens.
* If the problem is related to working with files (e.g. opening and editing files), **does the problem happen for all files and projects or only some?** 

Include details about your configuration and environment:

* **Which version of Uwizard are you using?** 

#### Template For Submitting Bug Reports

    [Short description of problem here]

    **Reproduction Steps:**

    1. [First Step]
    2. [Second Step]
    3. [Other Steps...]

    **Expected behavior:**

    [Describe expected behavior here]

    **Observed behavior:**

    [Describe observed behavior here]

    **Screenshots or GIFs**

    ![Screenshots or GIFs which follow reproduction steps to demonstrate the problem](url)

    **Uwizard version:** [Enter Uwizard version here]
    
    **Additional information:**

    * Problem started happening recently, didn't happen in an older version of Atom: [Yes/No]
    * Problem can be reliably reproduced, doesn't happen randomly: [Yes/No]
    * Problem happens with all files and projects, not only some files or projects: [Yes/No]

### Suggesting Enhancements

This section guides you through submitting an enhancement suggestion for Uwizard, including completely new features and minor improvements to existing functionality. Following these guidelines helps maintainers and the community understand your suggestion and find related suggestions.

Before creating enhancement suggestions, please check [this list](#before-submitting-an-enhancement-suggestion) as you might find out that you don't need to create one. When you are creating an enhancement suggestion, please [include as many details as possible](#how-do-i-submit-a-good-enhancement-suggestion). If you'd like, you can use [this template](#template-for-submitting-enhancement-suggestions) to structure the information.

#### Before Submitting An Enhancement Suggestion

* **Confirm** that you are on the lastest [release](https://github.com/EvilGamerX/Uwizard/releases) of Uwizard. You may find that your enhancement has already been made.
* **Perform a [cursory search](https://github.com/EvilGamerX/Uwizard/issues?utf8=%E2%9C%93&q=is%3Aissue+is%3Aopen+)** to see if the enhancement has already been suggested. If it has, add a comment to the existing issue instead of opening a new one.

#### How Do I Submit A (Good) Enhancement Suggestion?

Enhancement suggestions are tracked as [GitHub issues](https://guides.github.com/features/issues/). Create an issue on that repository and provide the following information:

* **Use a clear and descriptive title** for the issue to identify the suggestion.
* **Provide a step-by-step description of the suggested enhancement** in as many details as possible.
* **Describe the current behavior** and **explain which behavior you expected to see instead** and why.
* **Include screenshots or animated GIFs** which help you demonstrate the steps or point out the part of Uwizard which the suggestion is related to.
* **Explain why this enhancement would be useful** to most Uwizard users.
* **Specify which version of Uwizard you're using.** 

#### Template For Submitting Enhancement Suggestions

    [Short description of suggestion]

    **Steps which explain the enhancement**

    1. [First Step]
    2. [Second Step]
    3. [Other Steps...]

    **Current and suggested behavior**

    [Describe current and suggested behavior here]

    **Why would the enhancement be useful to most users**

    [Explain why the enhancement would be useful to most users]

    **Screenshots or GIFs**

    ![Screenshots or GIFs which demonstrate the steps or part of Atom the enhancement suggestion is related to](url)

    **Uwizard Version:** [Enter Uwizard version here]

### Your First Code Contribution

Unsure where to begin contributing to Atom? You can start by looking through these `beginner` and `help-wanted` issues:

* [Beginner issues][beginner] - issues which should only require a few lines of code, and a test or two.
* [Help wanted issues][help-wanted] - issues which should be a bit more involved than `beginner` issues.

Both issue lists are sorted by total number of comments. While not perfect, number of comments is a reasonable proxy for impact a given change will have.

### Pull Requests

* Follow the [C#](https://msdn.microsoft.com/en-us/library/ff926074.aspxe)
* Document new code the the fullest of your extent.
* Using a plain `return` when returning explicitly at the end of a void function.
    * Not `return null`, `return undefined`, `null`, or `undefined`