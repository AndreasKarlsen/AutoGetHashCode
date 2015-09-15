using System;
using System.Collections.Generic;
using System.Linq;
using AutoGetHashCode.Exceptions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace AutoGetHashCode
{
    public class HashCodeGenerator
    {
        private readonly SolutionScanner _solutionScanner;

        public HashCodeGenerator(SolutionScanner solutionScanner)
        {
            _solutionScanner = solutionScanner;
        }

        /*
        1. Find klasser med AutoGetHashCode attributten
        2. Check om den overrider Equals metoden
        3. Check om den overrider GetHashCode
        4. Generer GetHashCode som partial klasse>
        4.a Gem Namespace
        4.b Gem Class name
        4.c Generer GetHashCode metode 
        4.d Fields
        4.e Properties
        */
        public void GenerateHashCode()
        {
            var solutionToAnalyze = _solutionScanner.GetCompilation();

            ScanForAttributedClasses(solutionToAnalyze);
        }

        private static void ScanForAttributedClasses(Solution solutionToAnalyze)
        {
            foreach (var project in solutionToAnalyze.Projects)
            {
                var compilation = project.GetCompilationAsync().Result;
                foreach (var syntaxTree in compilation.SyntaxTrees)
                {
                    GenerateForAttributedClasses(syntaxTree);                    
                }
            }
        }

        private static void GenerateForAttributedClasses(SyntaxTree syntaxTree)
        {
            var attributedClasses = SyntaxAnalyzer.GetAttributedClasses(syntaxTree);
            foreach (var classDeclarationSyntax in attributedClasses)
            {
                ValidateClass(classDeclarationSyntax);
                var namespaceName = SyntaxAnalyzer.GetNamespace(syntaxTree);
                var className = SyntaxAnalyzer.GetClassName(classDeclarationSyntax);

                ClassGenerator.GenerateClass(namespaceName, className, syntaxTree);

            }
        }

        private static void ValidateClass(ClassDeclarationSyntax classDeclarationSyntax)
        {
            if (!SyntaxAnalyzer.IsOverridingEquals(classDeclarationSyntax))
            {
                throw new NotOverridingEqualsException(
                    $"{classDeclarationSyntax.Identifier} does not override Equals, thus we do not need to generate GetHashCode");
            }
            if (SyntaxAnalyzer.IsOverridingGetHashCode(classDeclarationSyntax))
            {
                throw new AlreadyOverridingGetHashCode(
                    $"{classDeclarationSyntax.Identifier} already overrides GetHashCode, thus we do not need to generate it");
            }
            if (!SyntaxAnalyzer.IsClassPartial(classDeclarationSyntax))
            {
                throw new ClassNotPartialException(
                    $"{classDeclarationSyntax.Identifier} is not declared partial. This is required for generating a GetHashCode method");
            }
        }
    }
}