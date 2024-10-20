﻿// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Minor Code Smell", "S6605:Collection-specific \"Exists\" method should be used instead of the \"Any\" extension", Justification = "<Pending>", Scope = "member", Target = "~P:EightQueens.EightQueensTests.Board.HasFreeSpace")]
[assembly: SuppressMessage("Major Code Smell", "S3358:Ternary operators should not be nested", Justification = "<Pending>", Scope = "member", Target = "~M:EightQueens.EightQueensTests.Board.PrintCell(System.Int32)~System.String")]
[assembly: SuppressMessage("Minor Code Smell", "S6603:The collection-specific \"TrueForAll\" method should be used instead of the \"All\" extension", Justification = "<Pending>", Scope = "member", Target = "~M:EightQueens.EightQueensTests.Board.IsNoThreat~System.Boolean")]
[assembly: SuppressMessage("Minor Code Smell", "S6603:The collection-specific \"TrueForAll\" method should be used instead of the \"All\" extension", Justification = "<Pending>", Scope = "member", Target = "~M:EightQueens.Board.IsNoThreat~System.Boolean")]
[assembly: SuppressMessage("Minor Code Smell", "S6603:The collection-specific \"TrueForAll\" method should be used instead of the \"All\" extension", Justification = "<Pending>", Scope = "member", Target = "~M:EightQueens.Board.HasNoThreat~System.Boolean")]
