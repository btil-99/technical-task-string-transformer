# Technical Task

Console app that transforms a string based on three rules.

## The rules

Given an input string, the output is made up of the following concatenated:

1. the reverse of the input string
2. the earliest character in the alphabet present in the input string
3. `open` if the input contains an odd number of vowels, `rent` if even.

## Running it

Requires the .NET 10 SDK.

Pass the string as an argument:

```bash
dotnet run --project TechnicalTask -- "nepo"
# Output: openerent
```

Or without an argument:
```bash
dotnet run --project TechnicalTask
# Enter a string: nepo
# Output: openerent
```

Run the tests with:

```bash
dotnet test
```

## Assumptions

The following assumptions have been made:
- Zero vowels counts as even, and therefore outputs `rent`
- Case is ignored when picking earliest letter, but original case is returned (Z is before a)
- Non-alpha characters are reversed but get ignored when picking earliest letter in alphabet
