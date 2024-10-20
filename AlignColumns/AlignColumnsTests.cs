/*
Given a text file of many lines, where fields within a line are delineated by a single 'dollar' character, write a program that aligns each column of fields by ensuring that words in each column are separated by at least one space.

For Example:

Given$a$text$file$of$many$lines,$where$fields$within$a$line$
are$delineated$by$a$single$'dollar'$character,$write$a$program
that$aligns$each$column$of$fields$by$ensuring$that$words$in$each$
column$are$separated$by$at$least$one$space.

Notes:
- The example input texts lines may, or may not, have trailing dollar characters.
- Lines may, or may not, contain the same number of fields.
- All columns should share the same alignment.
- Consecutive space characters produced adjacent to the end of lines are insignificant for the purposes of the task.
- Assume output text will be viewed in a mono-spaced font on a plain text editor or basic terminal.
- The minimum space between columns should be computed from the text and not hard-coded.

[Source https://rosettacode.org]
 */

[TestFixture]
public class AlignColumnsTests
{
    [TestCase("", "")]
    [TestCase("word", "word")]
    [TestCase("word$", "word")]
    [TestCase("A$B", "A  B")]
    [TestCase("A$B$", "A  B")]
    [TestCase(@"
A$B
C$D
", @"
A  B
C  D
")]
    [TestCase(@"
A$B$
C$D
", @"
A  B
C  D
")]
    [TestCase(@"
ABC$D
E$F
", @"
ABC  D
E    F
")]
    [TestCase(@"
A$B
C$DEF
", @"
A  B
C  DEF
")]
    [TestCase(@"
A$DEF
C$B
", @"
A  DEF
C  B
")]
    [TestCase(@"
A$BCD$E
F$G$H
", @"
A  BCD  E
F  G    H
")]    
    [TestCase(@"
A$B$C$D
E$F
", @"
A  B  C  D
E  F
")]     
    [TestCase(@"
A$B
C$D$E$F
", @"
A  B
C  D  E  F
")]
    [TestCase(@"
A$BCD$E$F
G$H$I
", @"
A  BCD  E  F
G  H    I
")]
    [TestCase(@"
A$B
C$D
E$F
", @"
A  B
C  D
E  F
")]
    [TestCase(@"
Given$a$text$file$of$many$lines,$where$fields$within$a$line$
are$delineated$by$a$single$'dollar'$character,$write$a$program
that$aligns$each$column$of$fields$by$ensuring$that$words$in$each$
column$are$separated$by$at$least$one$space.
", @"
Given   a           text       file    of      many      lines,      where     fields  within   a   line
are     delineated  by         a       single  'dollar'  character,  write     a       program
that    aligns      each       column  of      fields    by          ensuring  that    words    in  each
column  are         separated  by      at      least     one         space.
")]
    public void GivenEmptyString_ThenEmptyString(string input, string expected)
    {
        string result = AlignColumns.Align(input.Trim());

        TestContext.Out.WriteLine(result);

        Assert.That(result, Is.EqualTo(expected.Trim()));
    }
}
